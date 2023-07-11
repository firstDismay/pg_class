using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class position
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ С ОБЪЕКТАМИ

        /// <summary>
        /// Лист объектов позиции
        /// object_by_id_position
        /// object_ext_by_id_position
        /// </summary>
        public List<object_general> Object_list_get(Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_id_position(this);
            }
            else
            {
                Result = Manager.object_by_id_position(this);
            }
            return Result;
        }

        /// <summary>
        /// Лист объектов позиции
        /// object_by_id_position_recursive
        /// object_ext_by_id_position_recursive
        /// </summary>
        public List<object_general> Object_list_recursive_get(Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_id_position_recursive(this);
            }
            else
            {
                Result = Manager.object_by_id_position_recursive(this);
            }
            return Result;
        }

        /// <summary>
        /// Лист объектов позиции для указанного класса(рекурсивно)
        /// object_by_id_class_id_pos
        /// object_ext_by_id_class_id_pos
        /// </summary>
        public List<object_general> Object_list_get(Int64 iid_class, Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_id_class_id_pos(iid_class, id);
            }
            else
            {
                Result = Manager.object_by_id_class_id_pos(iid_class, id);
            }
            return Result;
        }

        /// <summary>
        /// Лист объектов позиции для указанного класса(рекурсивно)
        /// object_by_id_class_id_pos
        /// object_ext_by_id_class_id_pos
        /// </summary>
        public List<object_general> Object_list_get(vclass Class, Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_id_class_id_pos(Class, this);
            }
            else
            {
                Result = Manager.object_by_id_class_id_pos(Class, this);
            }
            return Result;
        }

        /// <summary>
        /// Лист объектов позиции(рекурсивно) по маске имени объекта
        /// object_by_name_id_pos
        /// object_ext_by_name_id_pos
        /// </summary>
        public List<object_general> Object_by_name(String ObjectNameMask, Boolean on_inside, Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_name_id_pos(ObjectNameMask, id, on_inside);
            }
            else
            {
                Result = Manager.object_by_name_id_pos(ObjectNameMask, id, on_inside);
            }
            return Result;
        }

        /// <summary>
        /// Лист представлений объектов соотвествующих набору значений глобальных/определяющих свойств (подбор по критериям)
        /// object_by_array_prop
        /// object_ext_by_array_prop
        /// </summary>
        public List<object_general> Object_by_array_prop(PropSearchСondition[] array_prop, Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_array_prop(array_prop, id);
            }
            else
            {
                Result = Manager.object_by_array_prop(array_prop, id);
            }
            return Result;
        }
        #endregion

        #region МЕТОДЫ РАБОТЫ С ОБЪЕКТАИ
        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новый объект
        /// </summary>
        public object_general Object_add(vclass Class, unit_conversion_rule Unit_conversion_rule, Decimal quantity)
        {
            return Manager.object_add(Class, this, Unit_conversion_rule, quantity);
        }

        /// <summary>
        /// Метод добавляет новый объект с правилом пересчета по умолчанию
        /// </summary>
        public object_general Object_add(vclass Class, Decimal quantity)
        {
            return Manager.object_add(Class, this, Class.Unit_conversion_rule_base, quantity);
        }

        /// <summary>
        /// Метод добавляет новые объекты в указанное расположение в виде единичных юнитов с количеством указанного правила пересчета
        /// </summary>
        public List<object_general> object_add_by_single_unit(vclass Class, Decimal quantity)
        {
            return Manager.object_add_by_single_unit(Class, this, Class.Unit_conversion_rule_base, quantity);
        }
        #endregion

        #region ДОБАВИТЬ ОБЪЕКТЫ ВЕЩЕСТВЕННЫХ КЛАССОВ
        /// <summary>
        ///  Метод выполняет создание объектов всех вещественных классов указанного класса
        ///  object_add_for_class_act
        /// </summary>
        public List<error_message> Object_add_for_class_act(vclass Class)
        {
            return Manager.object_add_for_class_act(Class, this);
        }
        #endregion

        #region МЕТОДЫ РАБОТЫ С ОБЪЕКТАМИ ГРУПП
        /// <summary>
        /// Приводит все объекты позиции к активным состояниям классов
        /// object_cast_for_class_act_by_id_group
        /// </summary>
        public List<errarg_cast> Object_cast_to_active_state()
        {
            return Manager.object_cast_for_class_act_by_id_position(this);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет объект
        /// object_del
        /// </summary>
        public void Object_del(object_general Object)
        {
            if (Object.Id_position == this.id)
            {
                Manager.object_del(Object);
            }
        }

        /// <summary>
        /// Метод удаляет всеобъекты  значения объектного свойства объекта
        /// object_del
        /// </summary>
        public void Object_del()
        {
            foreach (object_general Object_Val in Object_list_get())
            {
                Object_del(Object_Val);
            }
        }
        #endregion

        #region УНИЧТОЖИТЬ
        /// <summary>
        /// Метод уничтожает объект
        /// object_destroy
        /// </summary>
        public void Object_destroy(object_general Object)
        {
            if (Object.Id_position == this.id)
            {
                Manager.object_destroy(Object);
            }
        }

        /// <summary>
        /// Метод уничтожает все объекты позиции
        /// object_del
        /// </summary>
        public void Object_destroy()
        {
            foreach (object_general Object_Val in Object_list_get())
            {
                Object_destroy(Object_Val);
            }
        }
        #endregion
        #endregion
    }
}