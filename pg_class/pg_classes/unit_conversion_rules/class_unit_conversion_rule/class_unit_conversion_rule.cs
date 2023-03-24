using System;
using System.Collections.Generic;
using System.Text;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс правила разрешающего использование в объектах вещественных классов указанное правило пересчета объектов
    /// </summary>
    public partial class class_unit_conversion_rule
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected class_unit_conversion_rule()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public class_unit_conversion_rule(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "vclass_unit_conversion_rules")
            {
                id_conception = (Int64)row["id_conception"];
                id_class = (Int64)row["id_class"];
                id_unit = (Int32)row["id_unit"];
                id_unit_conversion_rule = (Int32)row["id_unit_conversion_rule"];
                is_create = (Boolean)row["is_create"];
                is_use = (Boolean)row["is_use"];
                on_base = (Boolean)row["on_base"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id_conception;
        private Int64 id_class;
        private Int32 id_unit;
        private Int32 id_unit_conversion_rule;
        private Boolean is_use;
        private Boolean on_base;
        private Boolean is_create;


        /// <summary>
        /// Идентификатор класса правила назнечения
        /// </summary>
        public Int64 Id_conception { get => id_conception; }

        /// <summary>
        /// Идентификатор класса правила назнечения
        /// </summary>
        public Int64 Id_class { get => id_class; }

        /// <summary>
        /// Идентификатор единиц измерения
        /// </summary>
        public Int32 Id_unit { get => id_unit; }

        /// <summary>
        /// Идентификатор метода пересчета колличества объектов
        /// </summary>
        public Int32 Id_unit_conversion_rule { get => id_unit_conversion_rule; }

        /// <summary>
        /// Признак используемого правила
        /// </summary>
        public Boolean Is_use { get => is_use; }

        /// <summary>
        /// Признак базового правила
        /// </summary>
        public Boolean On_base { get => on_base; }

        /// <summary>
        /// Признак правила добавленного в таблицу правил БД
        /// </summary>
        public Boolean Is_create { get => is_create; }

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

        /// <summary>
        /// Уникальный строковый идентификатор правила
        /// </summary>
        public String Key
        {
            get
            {
                return "class_unit_conversion_rule_" + Id_unit_conversion_rule.ToString();
            }
        }

        /// <summary>
        /// Класс правила
        /// </summary>
        public vclass Vclass
        {
            get
            {
                return Manager.class_act_by_id(id_class);
            }
        }

        /// <summary>
        /// Правило пересчета правила
        /// </summary>
        public unit_conversion_rule Unit_conversion_rule
        {
            get
            {
                return Manager.unit_conversion_rule_by_id(Id_unit_conversion_rule);
            }
        }

        #endregion

        #region МЕТОДЫ КЛАССА
        ///**************************************

        /// <summary>
        /// Лист объектов по идентификатору правила пересчета
        /// object_by_id_unit_conversion_rule
        /// </summary>
        public List<object_general> Object_using_get(Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_id_unit_conversion_rule(this);
            }
            else
            {
                Result = Manager.object_by_id_unit_conversion_rule(this);
            }
            return Result;
        }

        /// <summary>
        /// Лист представлений активных классов по идентификатору правила пересчета
        /// class_act_by_id_unit_conversion_rule
        /// </summary>
        public List<vclass> Class_act_using_get()
        {
            return Manager.class_act_by_id_unit_conversion_rule(this);
        }

        /// <summary>
        /// Лист представлений снимков классов по идентификатору правила пересчета
        /// class_snapshot_by_id_unit_conversion_rule
        /// </summary>
        public List<vclass> Class_snapshot_using_get()
        {
            return Manager.class_snapshot_by_id_unit_conversion_rule(this);
        }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Правило: ");
            sb.Append(Vclass.ToString());
            sb.Append(" - ");
            sb.Append(Unit_conversion_rule.ToString());
            return sb.ToString();
        }
        #endregion


    }
}
