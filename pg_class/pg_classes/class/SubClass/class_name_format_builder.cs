using pg_class.pg_exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс для построения формата имени объектов
    /// </summary>
    public class class_name_format_builder
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected class_name_format_builder()
        {
            format_default = "none";
            layout_default = "{Наименование класса}";
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public class_name_format_builder(vclass Class) : this()
        {
            if (Class.StorageType == eStorageType.Active && Class.On_abstraction)
            {
                class_ = Class;
                quantity_show = class_.Quantity_show;
            }
            else
            {
                throw new PgDataException(eEntity.vclass, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                    "Указанный класс не допускает определение формата наименования объектов, требуетс активное представление абстрактного класса, содержащего вещественные классы !");
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private vclass class_;
        private Boolean quantity_show;

        private StringBuilder format_builder;
        private StringBuilder class_prop_list_builder;
        private StringBuilder layout_builder;
        private List<Step> Step_list;


        private String format_default;
        private String layout_default;

        private Boolean format_is_create;

        private Int32 s;


        /// <summary>
        /// Связанный активный класс
        /// </summary>
        public vclass Сlass { get => class_; }

        /// <summary>
        /// Признак необходимости отображения количества объекта в формате имени
        /// </summary>
        public Boolean Quantity_show { get => quantity_show; set => quantity_show = value; }


        /// <summary>
        /// Признак этапа формирования формата
        /// </summary>
        public Boolean Format_is_create { get => format_is_create; }


        /// <summary>
        /// Счетчик количества операций форматирования
        /// </summary>
        public Int32 Counter_operation
        {
            get
            {
                Int32 Result = 0;
                if (Step_list != null)
                {
                    Result = Step_list.Count;
                }
                return Result;
            }
        }

        /// <summary>
        /// Ссылка на менеджера данных
        /// </summary>
        private manager Manager
        {
            get
            {
                return manager.Instance();
            }
        }

        #endregion

        #region МЕТОДЫ ПОЛУЧЕНИЯ ИСХОДНЫХ ДАННЫХ КЛАССА
        /// <summary>
        /// Лист строковых паттернов доступных для формирования формата имени объектов
        /// class_name_format_pattern_string_by_all
        /// </summary>
        public List<pattern_string> Pattern_string_list_get()
        {
            return Manager.class_name_format_pattern_string_by_all();
        }
        /// <summary>
        /// Лист свойств класса доступных для формирования формата имени объектов
        /// class_prop_for_format_by_id_class
        /// </summary>
        public List<class_prop> class_prop_for_format_by_id_class()
        {
            return Manager.class_prop_for_format_by_id_class(class_);
        }
        #endregion

        #region МЕТОДЫ УПРАВЛЕНИЯ ПОСТРОЕНИЕМ ФОРМАТА

        /// <summary>
        /// Метод определяет начало формирования нового формата и обуляет внутренние переменные строителей
        /// </summary>
        public void FormatNew()
        {
            format_builder = new StringBuilder();
            class_prop_list_builder = new StringBuilder();
            layout_builder = new StringBuilder();
            Step_list = new List<Step>();
            format_is_create = true;
            s = 0;
        }

        /// <summary>
        /// Метод определяет формат имен объектов классов
        /// class_format_set
        /// </summary>
        public void Format_set()
        {
            Manager.class_act_name_format_set(this);
            class_.Refresh();
        }

        /// <summary>
        /// Метод определяет формат имен объектов классов
        /// class_format_set
        /// </summary>
        public void Quantity_show_set()
        {
            Manager.class_quantity_show_set(this);
            class_.Refresh();
        }

        /// <summary>
        /// Метод добавляет элемент формата типа значение свойства
        /// </summary>
        public void FormatAppend(class_prop Class_prop)
        {
            if (format_builder != null && class_prop_list_builder != null)
            {
                if (Class_prop != null)
                {
                    if (format_is_create)
                    {
                        String frm, lyt, cp;

                        frm = "%s" + s.ToString().Trim();
                        format_builder.Append(frm);

                        cp = ", " + Class_prop.Id_prop_definition.ToString();
                        class_prop_list_builder.Append(cp);

                        lyt = "{" + Class_prop.Name + "}";
                        layout_builder.Append(lyt);

                        Step sp = new Step(frm.Length, cp.Length, lyt.Length, true);
                        Step_list.Add(sp);

                        s = s + 1;
                    }
                    else
                    {
                        throw new PgDataException(eEntity.vclass, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules, "Формат имен объектов класса не создан, используйте метод FormatNew!");
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Класс построителя формата имен объектов не инициализирован!");
            }
        }

        /// <summary>
        /// Метод добавляет элемент формата типа строковый паттерн
        /// </summary>
        public void FormatAppend(pattern_string Pattern_string)
        {
            if (format_builder != null && class_prop_list_builder != null)
            {
                if (Pattern_string != null)
                {
                    if (format_is_create)
                    {
                        String frm, lyt;

                        frm = Pattern_string.Pattern;
                        format_builder.Append(frm);

                        lyt = Pattern_string.Pattern;
                        layout_builder.Append(lyt);

                        Step sp = new Step(frm.Length, 0, lyt.Length, false);
                        Step_list.Add(sp);
                    }
                    else
                    {
                        throw new PgDataException(eEntity.vclass, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules, "Формат имен объектов класса не создан, используйте метод FormatNew!");
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Класс построителя формата имен объектов не прошел инициализирован!");
            }
        }

        /// <summary>
        /// Метод добавляет элемент формата типа произвольный строковый паттерн
        /// </summary>
        public void FormatAppend(String Pattern_string)
        {
            if (format_builder != null && class_prop_list_builder != null)
            {
                if (Pattern_string != null)
                {
                    if (format_is_create)
                    {
                        String frm, lyt;

                        frm = Pattern_string;
                        format_builder.Append(frm);

                        lyt = Pattern_string;
                        layout_builder.Append(lyt);

                        Step sp = new Step(frm.Length, 0, lyt.Length, false);
                        Step_list.Add(sp);
                    }
                    else
                    {
                        throw new PgDataException(eEntity.vclass, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules, "Формат имен объектов класса не создан, используйте метод FormatNew!");
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Класс построителя формата имен объектов не прошел инициализирован!");
            }
        }

        /// <summary>
        /// Метод добавляет элемент формата типа наименование класса
        /// </summary>
        public void FormatAppend()
        {
            if (format_builder != null && class_prop_list_builder != null)
            {
                if (format_is_create)
                {
                    String frm, lyt;

                    frm = "%c";
                    format_builder.Append(frm);

                    lyt = layout_default;
                    layout_builder.Append(lyt);

                    Step sp = new Step(frm.Length, 0, lyt.Length, false);
                    Step_list.Add(sp);
                }
                else
                {
                    throw new PgDataException(eEntity.vclass, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules, "Формат имен объектов класса не создан, используйте метод FormatNew!");
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Класс построителя формата имен объектов не инициализирован!");
            }
        }

        /// <summary>
        /// Метод удаляет последний элемент формата наименования объектов класса
        /// </summary>
        public void FormatDelLast()
        {
            if (format_builder != null && class_prop_list_builder != null)
            {
                if (format_is_create)
                {
                    if (Step_list != null)
                    {
                        if (Step_list.Count > 0)
                        {
                            Int32 i = Step_list.Count - 1;
                            Step temp = Step_list[i];

                            format_builder.Remove(format_builder.Length - temp.Format, temp.Format);
                            class_prop_list_builder.Remove(class_prop_list_builder.Length - temp.Class_prop, temp.Class_prop);
                            layout_builder.Remove(layout_builder.Length - temp.Layout, temp.Layout);

                            if (temp.Decrease_index)
                            {
                                s = s - 1;
                            }
                            Step_list.RemoveAt(i);
                        }
                        else
                        {
                            throw new PgDataException(eEntity.vclass, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules, "Формат не содержит данных для удаления!");
                        }
                    }
                }
                else
                {
                    throw new PgDataException(eEntity.vclass, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules, "Формат имен объектов класса не создан, используйте метод FormatNew!");
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Класс построителя формата имен объектов не инициализирован!");
            }
        }



        /// <summary>
        /// Метод очищает формат до начального значения
        /// </summary>
        public void FormatDefault()
        {
            format_builder = new StringBuilder();
            class_prop_list_builder = new StringBuilder();
            layout_builder = new StringBuilder();

            format_is_create = false;
            format_builder.Append(format_default);
            layout_builder.Append(layout_default);
            s = 0;
        }

        /// <summary>
        /// Метод возвращает макет формата
        /// </summary>
        public String Layout_get()
        {
            String Result;

            if (format_is_create)
            {
                Result = layout_builder.ToString();
            }
            else
            {
                Result = layout_default;
            }
            return Result;
        }

        /// <summary>
        /// Метод возвращает гтовый формат
        /// </summary>
        public String Format_get()
        {
            String Result;

            if (format_is_create)
            {
                Result = String.Format("'{0}'{1}", format_builder.ToString(), class_prop_list_builder.ToString());
            }
            else
            {
                Result = format_default;
            }
            return Result;
        }

        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return Layout_get();
        }
        #endregion


        #region ВНУТРЕННИЕ ЭЛЕМЕНТЫ КЛАССА

        struct Step
        {
            public Step(Int32 format, Int32 class_prop, Int32 layout, Boolean decrease_index)
            {
                Format = format;
                Class_prop = class_prop;
                Layout = layout;
                Decrease_index = decrease_index;
            }
            public Int32 Format { get; }
            public Int32 Class_prop { get; }
            public Int32 Layout { get; }
            public Boolean Decrease_index { get; }
        }
        #endregion
    }
}
