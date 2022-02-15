using System;
using System.Collections.Generic;
using System.Data;
using NpgsqlTypes;

namespace pg_class.pg_classes.calendar
{
    /// <summary>
    /// Класс планов 
    /// </summary>
    public partial class plan_range
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected plan_range()
        {
            on_change = false;
            imagekey = "plan_range_us";
            selectedimagekey = "plan_range_s";
        }

        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public plan_range(System.Data.DataRow row) : this()
        {

            switch (row.Table.TableName)
            {
                case "vpaln_range":
                    tablename = row.Table.TableName;
                    id = (Int64)row["id"];
                    id_conception = (Int64)row["id_conception"];
                    id_plan = (Int64)row["id_plan"];
                    range_plan = (NpgsqlRange<DateTime>)row["range_plan"];
                    timestamp = Convert.ToDateTime(row["timestamp"]);
                    timestamp_child_change = Convert.ToDateTime(row["timestamp_child_change"]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private Int64 id;
        private Int64 id_conception;
        private Int64 id_plan;
        private NpgsqlRange<DateTime> range_plan;
        private DateTime timestamp;
        private DateTime timestamp_child_change;
        private Boolean on_change;

        private String tablename;
        /// <summary>
        /// Имя таблицы базы ассистента, содержащей запись
        /// </summary>
        public String Tablename { get => tablename; }

        /// <summary>
        /// Идентификатор плана
        /// </summary>
        public Int64 Id { get => id;}

        /// <summary>
        /// Идентификатор концепции плана
        /// </summary>
        public Int64 Id_conception { get => id_conception; }

        /// <summary>
        /// Идентификатор плана носителя
        /// </summary>
        public Int64 Id_plan { get => id_plan; }

        /// <summary>
        /// Значение планового диапазона
        /// </summary>
        public NpgsqlRange<DateTime> Range_plan
        {
            get
            {
                return range_plan;
            }
            set
            {
                range_plan = value;
                on_change = true;
            }
        }

        /// <summary>
        /// Верхняя граница планового диапазона
        /// </summary>
        public DateTime Range_plan_upper
        {
            get 
            {
                if (range_plan != null)
                {
                    return range_plan.UpperBound;
                }
                else
                {
                    return DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Верхняя граница планового диапазона включена в диапазон
        /// </summary>
        public Boolean Range_plan_upper_inc
        {
            get
            {
                if (range_plan != null)
                {
                    return range_plan.UpperBoundIsInclusive;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Нижняя граница планового диапазона
        /// </summary>
        public DateTime Range_plan_lower
        {
            get
            {
                if (range_plan != null)
                {
                    return range_plan.LowerBound;
                }
                else
                {
                    return DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Нижняя граница планового диапазона включена в диапазон
        /// </summary>
        public Boolean Range_plan_lower_inc
        {
            get
            {
                if (range_plan != null)
                {
                    return range_plan.LowerBoundIsInclusive;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Штамп времени плана
        /// </summary>
        public DateTime Timestamp { get => timestamp; }

        /// <summary>
        /// Штамп времени состояния потомков плана
        /// </summary>
        public DateTime Timestamp_child_change { get => timestamp_child_change; }

        
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

        private String imagekey;
        /// <summary>
        /// Ключ объекта
        /// </summary>
        public string ImageKey
        {
            get
            {
                return imagekey;
            }
        }

        private String selectedimagekey;
        /// <summary>
        /// Ключ выделенного объекта
        /// </summary>
        public string SelectedImageKey
        {
            get
            {
                return selectedimagekey;
            }
        }
        #endregion

        #region МЕТОДЫ КЛАССА

        /// <summary>
        /// Свойство определяет актуальность текущего состояния планового диапазона
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.plan_range_is_actual(this);
        }

        /// <summary>
        /// Обновление группы в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {             
                Manager.plan_range_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Обновление группы из БД
        /// </summary>
        public Boolean Refresh()
        {
            plan_range temp;
            Boolean Result = false;
            temp = Manager.plan_range_by_id(id);

            if (temp != null)
            {
                tablename = temp.Tablename;
                range_plan = temp.Range_plan;
                timestamp = temp.Timestamp;
                timestamp_child_change = temp.Timestamp_child_change;
            }
            else
            {
                Result = false;
            }
            return Result;
        }

        /// <summary>
        /// удаление документа и вложенных файлов
        /// group_del
        /// </summary>
        public void Del()
        {
            Manager.plan_range_del(id);
        }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return range_plan.ToString();
        }
        #endregion
    }
}
