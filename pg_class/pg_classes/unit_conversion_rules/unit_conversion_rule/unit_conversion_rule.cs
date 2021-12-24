using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс правил конвертаций единиц измемерния
    /// </summary>
    public partial class unit_conversion_rule
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected unit_conversion_rule()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public unit_conversion_rule(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vunit_conversion_rules")
            {
                id = (Int32)row["id"]; 
                id_unit = (Int32)row["id_unit"];
                mc = (Decimal)row["mc"]; 
                bunit = (String)row["bunit"];
                cunit = (String)row["cunit"];
                desc = (String)row["desc"];
                on_base = (Boolean)row["on_base"];
                on_single = (Boolean)row["on_single"];
                on = (Boolean)row["on"];
                is_use = (Boolean)row["is_use"];
                round = (Int32)row["round"];
                not_fractional = (Boolean)row["not_fractional"];
                timestamp = (DateTime)row["timestamp"];
                is_entity = (Boolean)row["is_entity"];
                id_conception = (Int64)row["id_conception"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private Int32 id;
        private Int32 id_unit;
        private Decimal mc;
        private String bunit;
        private String cunit;
        private String desc;
        private Boolean on_base;
        private Boolean on_single;
        private Boolean on;
        private Boolean is_use;
        private Int32 round;
        private Boolean not_fractional;
        private Boolean is_entity;
        private DateTime timestamp;
        private Int64 id_conception;

        /// <summary>
        /// Учет сущностей БД 
        /// </summary>
        public Boolean Is_Entity { get => is_entity; }

        /// <summary>
        /// Идентификатор правила пересчета
        /// </summary>
        public Int32 Id { get => id;}

        /// <summary>
        /// Идентификатор концепции правила пересчета
        /// </summary>
        public Int64 Id_conception { get => id_conception; }


        /// <summary>
        /// Концепция правила пересчета
        /// </summary>
        public conception Сonception { get => Manager.conception_by_id(id_conception); }


        /// <summary>
        /// Идентификатор единиц измерения
        /// </summary>
        public Int32 Id_unit { get => id_unit; }

        /// <summary>
        /// Измеряемая величина правила пересчета
        /// </summary>
        public unit Unit
        {
            get
            {
                return Manager.units_by_id(id_unit);
            }
        }

        /// <summary>
        /// Коэффициент пересчета единиц измерения правила пересчета в базовые единицы измеряемой величины
        /// </summary>
        public Decimal Mc
        {
            get
            {
                return mc;
            }
            set
            {
                if (mc != value)
                {
                    mc = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Колличество знаков после запятой
        /// </summary>
        public Int32 Round {
            get
            {
                return round;
            }
            set
            {
                if (round != value)
                {
                    round = value;
                    on_change = true;

                }
            }
        }

        /// <summary>
        /// Признак запрета дробной части колличестве объектов
        /// </summary>
        public Boolean Not_fractional
        {
            get
            {
                return not_fractional;
            }
        }
        /// <summary>
        /// Единицы измерения базовые
        /// </summary>
        public String Bunit { get => bunit; }
        
        /// <summary>
        /// Единицы измерения установленные в текущем правиле
        /// </summary>
        public String Cunit {
            get
            {
                return cunit;
            }
            set
            {
                if (cunit != value)
                {
                    cunit = value;
                    on_change = true;

                }
            }
        }

        /// <summary>
        /// Описание правила пересчета
        /// </summary>
        public String Desc {
            get
            {
                return desc;
            }
            set
            {
                if (desc != value)
                {
                    desc = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Признак принадлежности правила пересчета базовым единицам (mc=1)
        /// </summary>
        public Boolean On_base
        {
            get
            {
                return on_base;
            }
        }

        /// <summary>
        /// Признак правила единичного учета, применимо для экономических единиц (шт)
        /// </summary>
        public Boolean On_single
        {
            get
            {
                return on_single;
            }
            set
            {
                if (on_single != value)
                {
                    on_single = value;
                    on_change = true;

                }
            }
        }

        /// <summary>
        /// Признак включенного правила пересчета доступного к применению в активной конфигурации
        /// </summary>
        public Boolean On
        { get
            {
                return on;
            }
            set
            {
                if (on != value)
                {
                    on = value;
                    on_change = true;

                }
            }
        }

        /// <summary>
        /// Признак правила используемого в с труктурах данных базы
        /// </summary>
        public Boolean Is_use { get => is_use; }


        /// <summary>
        /// Штамп времени объекта
        /// </summary>
        public DateTime Timestamp { get => timestamp; }

        /// <summary>
        /// Уникальный строковый идентификатор
        /// </summary>
        public String Key
        {
            get
            {
                return String.Format("unit_conversion_rule_{0}", id );
            }
        }

        /// <summary>
        /// Ключ объекта
        /// </summary>
        public string ImageKey
        {
            get
            {
                return String.Format("unit_conversion_rule_us");
            }
        }

        /// <summary>
        /// Ключ выделенного объекта
        /// </summary>
        public string SelectedImageKey
        {
            get
            {
                return String.Format("unit_conversion_rule_s");
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

        private Boolean on_change;
        /// <summary>
        /// Свойство определяющее потребность в обновлении данных БД
        /// </summary>
        public Boolean On_change
        {
            get
            {
                return on_change;
            }
        }

        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния
        /// </summary>
        public eEntityState Is_actual()
        {
            return manager.Instance().unit_conversion_rules_is_actual(this);
        }

        /// <summary>
        /// Обновление правила пересчета объектов в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                Manager.unit_conversion_rule_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Обновление группы из БД
        /// </summary>
        public Boolean Refresh()
        {
            unit_conversion_rule temp;
            Boolean Result = false;
            temp = Manager.unit_conversion_rule_by_id(id);

            if (temp != null)
            {
                mc = temp.Mc;
                bunit = temp.Bunit;
                cunit = temp.Cunit;
                desc = temp.Desc;
                on_base = temp.On_base;
                on_single = temp.On_single;
                on = temp.On;
                is_use = temp.Is_use;
                round = temp.Round;
                not_fractional = temp.Not_fractional;
                timestamp = temp.Timestamp;
                Result = true;
            }
            else
            {
                Result = false;
            }
            return Result;
        }


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
            sb.Append(desc);
            if (On_base & !On_single )
            {
                sb.Append(" (базовая единица)");
            }

            if (On_single)
            {
                sb.Append(" (единичный учет)");
            }
            return sb.ToString();
        }
        #endregion

    }
}
