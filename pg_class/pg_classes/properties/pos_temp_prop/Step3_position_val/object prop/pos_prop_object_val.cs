using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс значение объектного свойства позиции, определяющий правила назначений объектов значений в позиции носителе свойства
    /// </summary>
    public partial class position_prop_object_val
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected position_prop_object_val()
        {
            imagekey = "position_prop_object_val_us";
            bquantity = 0;
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public position_prop_object_val(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "vposition_prop_object_val")
            {
                id_position_carrier = (Int64)row["id_position_carrier"];
                id_position_root_carrier = (Int64)row["id_position_root_carrier"];
                id_pos_temp_position_carrier = (Int64)row["id_pos_temp_position_carrier"];
                id_pos_temp_prop_position_carrier = (Int64)row["id_pos_temp_prop_position_carrier"];
                on_val = (Boolean)row["on_val"];
                bquantity = (Decimal)row["bquantity"];
                bquantity_max = (Decimal)row["bquantity_max"];
                bquantity_min = (Decimal)row["bquantity_min"];
                id_class_val = (Int64)row["id_class_val"];
                timestamp_class_val = (DateTime)row["timestamp_class_val"];
                timestamp_val = (DateTime)row["timestamp_val"];
                not_set = (Boolean)row["not_set"];
                tablename = (String)row["tablename"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private Int64 id_position_carrier;
        private Int64 id_position_root_carrier;
        private Int64 id_pos_temp_position_carrier;
        private Int64 id_pos_temp_prop_position_carrier;
        private Boolean on_val;
        private Decimal bquantity;
        private Decimal bquantity_max;
        private Decimal bquantity_min;
        private Int64 id_class_val;
        private DateTime timestamp_class_val;
        private Boolean not_set;

        /// <summary>
        /// Тип хранилища данных сущности
        /// </summary>
        public eStorageType StorageType
        {
            get
            {
                String pattern1 = "notsaved";
                String pattern2 = "vpos_temp";
                eStorageType tmp = eStorageType.History;
                if (System.Text.RegularExpressions.Regex.IsMatch(tablename, pattern1) || System.Text.RegularExpressions.Regex.IsMatch(tablename, pattern2))
                {
                    tmp = eStorageType.NotSaved;
                }
                return tmp;
            }
        }

        private String tablename;
        /// <summary>
        /// Имя таблицы базы ассистента, содержащей запись о значении свойства класса
        /// </summary>
        public String Tablename
        {
            get
            {
                return tablename;
            }
        }

        private DateTime timestamp_val;
        /// <summary>
        /// Штам времени объекта носителя свойства
        /// </summary>
        public DateTime Timestamp_val
        {
            get
            {
                return timestamp_val;
            }
        }

        /// <summary>
        /// Тип свойства
        /// </summary>
        public ePropType Prop_type
        {
            get
            {
                return ePropType.PropObject;
            }
        }

        /// <summary>
        /// Идентификатор шаблона позиции носителя свойства
        /// </summary>
        public Int64 Id_pos_temp_position_carrier
        {
            get
            {
                return id_pos_temp_position_carrier;
            }
        }

        
        /// <summary>
        /// Идентификатор свойства позиции носителя
        /// </summary>
        public Int64 Id_position_prop
        {
            get
            {
                return id_pos_temp_prop_position_carrier;
            }
        }

        /// <summary>
        /// Идентификатор свойства шаблона позиции
        /// </summary>
        public Int64 Id_pos_temp_prop
        {
            get
            {
                return id_pos_temp_prop_position_carrier;
            }
        }

        /// <summary>
        /// Идентификатор позиции носителя объектного свойства
        /// </summary>
        public Int64 Id_position_carrier
        {
            get
            {
                return id_position_carrier;
            }
        }

        

        /// <summary>
        /// Колличество объекта значения объектного свойства
        /// </summary>
        public Decimal Bquantity
        {
            get
            {
                return bquantity;
            }
        }

        /// <summary>
        /// Минимальное колличество объектов включаемых в объектное свойство класса в режиме связывания включить
        /// </summary>
        public Decimal Bquantity_min
        {
            get
            {
                return bquantity_min;
            }
        }

        /// <summary>
        /// Максимальное колличество объектов включаемых в объектное свойство класса в режиме связывания включить
        /// </summary>
        public Decimal Bquantity_max
        {
            get
            {
                return bquantity_max;
            }
        }

        /// <summary>
        /// Штамп времени класса значения свойства
        /// </summary>
        public DateTime Timestamp_class_val
        {
            get
            {
                return timestamp_class_val;
            }
        }

        /// <summary>
        /// Идентификатор класса значения свойства
        /// </summary>
        public Int64 Id_class_val
        {
            get
            {
                return id_class_val;
            }
        }

        /// <summary>
        /// Уникальный строковый идентификатор позиции
        /// </summary>
        
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

        /// <summary>
        /// Признак наличия установленного объекта значения объектного свойства объекта STEP 3
        /// </summary>
        public Boolean On_val
        {
            get
            {
                return on_val;
            }
        }

        /// <summary>
        /// Признак ошибки данных значения объектного свойства объекта STEP 3
        /// </summary>
        public Boolean Not_set
        {
            get
            {
                return not_set;
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

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.position_prop_object_val_is_actual(this);
        }

        /// <summary>
        /// Лист объектов значений объектного свойства STEP3
        /// </summary>
        public List<object_general> value_get(Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_object_prop_by_id_position_carrier_ext(id_position_carrier, id_pos_temp_prop_position_carrier); 
            }
            else
            {
                Result = Manager.object_object_prop_by_id_position_carrier(id_position_carrier, id_pos_temp_prop_position_carrier);
            }
            return Result;
        }


        /// <summary>
        /// Класс значение объектного свойства
        /// </summary>
        public vclass class_value_get()
        {
            vclass Result;
            Result = Manager.class_snapshot_by_id(id_class_val, timestamp_class_val);
            if (Result == null)
            {
                Result = Manager.class_act_by_id(id_class_val);
            }
            return Result;
        }

        /// <summary>
        /// Шаблон позиции носителя свойства
        /// </summary>
        public pos_temp pos_temp_carrier_get()
        {
            return Manager.pos_temp_by_id(id_pos_temp_position_carrier);
        }

        /// <summary>
        /// Свойство шаблона позиции носителя
        /// </summary>
        public pos_temp_prop pos_temp_prop_get()
        {
            return Manager.pos_temp_prop_by_id(id_pos_temp_prop_position_carrier);
        }


        /// <summary>
        /// Свойство позиции носителя
        /// </summary>
        public position_prop object_prop_get()
        {
            return Manager.position_prop_by_id(id_position_carrier, id_pos_temp_prop_position_carrier);
        }

        /// <summary>
        /// Обновление представления класса из БД
        /// </summary>
        public Boolean Refresh()
        {
            position_prop_object_val temp = null;
            Boolean Result = false;
            
                temp = Manager.position_prop_object_val_by_id_prop(id_position_carrier, id_pos_temp_prop_position_carrier);

                if (temp != null)
                {
                id_position_carrier = temp.Id_position_carrier;
                id_pos_temp_position_carrier = temp.Id_pos_temp_position_carrier;
                id_pos_temp_prop_position_carrier = temp.Id_pos_temp_prop;
                on_val = temp.on_val;
                bquantity = temp.bquantity;
                bquantity_max = temp.bquantity_max;
                bquantity_min = temp.bquantity_min;
                id_class_val = temp.id_class_val;
                timestamp_class_val = temp.timestamp_class_val;
                not_set = temp.not_set;
                timestamp_class_val = temp.timestamp_val;
                tablename = temp.Tablename;
                Result = true;
                
            }
                else
                {
                    Result = false;
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
            return String.Format("Свойство{0} Носитель: {1} - Количество: {2}", id_pos_temp_prop_position_carrier, id_position_carrier, bquantity); ;
        }
        #endregion

    }
}
