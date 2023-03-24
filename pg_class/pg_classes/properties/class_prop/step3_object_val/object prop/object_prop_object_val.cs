using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс значение объектного свойства объекта, определяющий правила назначений объектов значений в объекте носителе свойства
    /// </summary>
    public partial class object_prop_object_val
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected object_prop_object_val()
        {
            imagekey = "object_prop_obj_val_object_us";
            bquantity = 0;
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public object_prop_object_val(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "vobject_prop_object_val")
            {
                id_object_carrier = (Int64)row["id_object_carrier"];
                id_class_object_carrier = (Int64)row["id_class_object_carrier"];
                timestamp_class_object_carrier = (DateTime)row["timestamp_class_object_carrier"];
                id_class_prop_object_carrier = (Int64)row["id_class_prop_object_carrier"];
                on_val = (Boolean)row["on_val"];
                bquantity = (Decimal)row["bquantity"];
                bquantity_max = (Decimal)row["bquantity_max"];
                bquantity_min = (Decimal)row["bquantity_min"];
                id_class_val = (Int64)row["id_class_val"];
                timestamp_class_val = (DateTime)row["timestamp_class_val"];
                timestamp_val = (DateTime)row["timestamp_val"];
                not_set = (Boolean)row["not_set"];
                tablename = (String)row["tablename"];

                embed_mode = (eObjectPropCreateEmdedMode)row["embed_mode"];
                embed_single = (Boolean)row["embed_single"];
                embed_class_real_id = (Int64)row["embed_class_real_id"];
                id_unit_conversion_rule = (Int32)row["id_unit_conversion_rule"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private Int64 id_object_carrier;
        private Int64 id_class_object_carrier;
        private DateTime timestamp_class_object_carrier;
        private Int64 id_class_prop_object_carrier;
        private Boolean on_val;
        private Decimal bquantity;
        private Decimal bquantity_max;
        private Decimal bquantity_min;
        private Int64 id_class_val;
        private DateTime timestamp_class_val;
        private Boolean not_set;

        private eObjectPropCreateEmdedMode embed_mode;
        private Boolean embed_single;
        private Int64 embed_class_real_id;
        private Int32 id_unit_conversion_rule;


        /// <summary>
        /// Тип хранилища данных сущности
        /// </summary>
        public eStorageType StorageType
        {
            get
            {
                String pattern1 = "notsaved";
                String pattern2 = "class";
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
        /// Идентификатор снимка класса объекта носителя
        /// </summary>
        public Int64 Id_class_object_carrier
        {
            get
            {
                return id_class_object_carrier;
            }
        }



        /// <summary>
        /// Штамп времени снимка класса объекта носителя
        /// </summary>
        public DateTime Timestamp_class_object_carrier
        {
            get
            {
                return timestamp_class_object_carrier;
            }
        }



        /// <summary>
        /// Идентификатор свойства объекта носителя (наследованного от класса)
        /// </summary>
        public Int64 Id_object_prop
        {
            get
            {
                return id_class_prop_object_carrier;
            }
        }

        /// <summary>
        /// Идентификатор свойства класса объекта носителя
        /// </summary>
        public Int64 Id_class_prop
        {
            get
            {
                return id_class_prop_object_carrier;
            }
        }

        /// <summary>
        /// Идентификатор объекта носителя объектного свойства
        /// </summary>
        public Int64 Id_object_carrier
        {
            get
            {
                return id_object_carrier;
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
        /// Режим встраивания объектов значений объектных свойств объектов при создании несущих объектов определяющий количество
        /// </summary>
        public eObjectPropCreateEmdedMode Embed_mode
        {
            get
            {
                return embed_mode;
            }
        }

        /// <summary>
        /// Режим встраивания объектов значений объектных свойств объектов при создании несущих объектов определяющий штучность
        /// true встроить указанное количество по 1 штуке
        /// </summary>
        public Boolean Embed_single
        {
            get
            {
                return embed_single;
            }
        }

        /// <summary>
        /// Идентификатор активного представления вещественного класса используемого для порождения встраиваемых объектов
        /// </summary>
        public Int64 Embed_class_real_id
        {
            get
            {
                return embed_class_real_id;
            }
        }

        /// <summary>
        /// Идентификатор правила пересчета используемого для встраивания объектов
        /// </summary>
        public Int32 Id_unit_conversion_rule
        {
            get
            {
                return id_unit_conversion_rule;
            }
        }
        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния
        /// </summary>
        public eEntityState Is_actual()
        {
            return manager.Instance().object_prop_is_actual(id_class_prop_object_carrier, id_object_carrier, timestamp_val);
        }

        /// <summary>
        /// Лист объектов значений объектного свойства STEP3
        /// </summary>
        public List<object_general> value_get(Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_object_prop_by_id_object_carrier_ext(id_object_carrier, id_class_prop_object_carrier);
            }
            else
            {
                Result = Manager.object_object_prop_by_id_object_carrier(id_object_carrier, id_class_prop_object_carrier);
            }
            return Result;
        }

        /// <summary>
        /// Класс область значений объектного свойства текущая(активная)
        /// </summary>
        public vclass class_value_get()
        {
            vclass Result;
            Result = Manager.class_act_by_id(id_class_val);
            if (Result == null)
            {
                Result = Manager.class_snapshot_by_id(id_class_val, timestamp_class_val);
            }
            return Result;
        }

        /// <summary>
        /// Класс область значений объектного свойства фактическая(историческая)
        /// </summary>
        public vclass class_snapshot_value_get()
        {
            return Manager.class_snapshot_by_id(id_class_val, timestamp_class_val);
        }

        /// <summary>
        /// Историческое представление класса объекта носителя свойства
        /// </summary>
        public vclass class_snapshot_carrier_get()
        {
            return Manager.class_snapshot_by_id(id_class_object_carrier, timestamp_class_object_carrier);
        }


        /// <summary>
        /// Свойство класса объекта носителя
        /// </summary>
        public class_prop class_prop_snapshot_get()
        {
            return Manager.class_prop_snapshot_by_id(id_class_prop_object_carrier, timestamp_class_object_carrier);
        }


        /// <summary>
        /// Свойство объекта носителя
        /// </summary>
        public object_prop object_prop_get()
        {
            return Manager.object_prop_by_id(id_object_carrier, id_class_prop_object_carrier);
        }

        /// <summary>
        /// Обновление представления класса из БД
        /// </summary>
        public Boolean Refresh()
        {
            object_prop_object_val temp = null;
            Boolean Result = false;

            temp = Manager.object_prop_object_val_by_id_prop(id_object_carrier, id_class_prop_object_carrier);

            if (temp != null)
            {
                id_object_carrier = temp.id_object_carrier;
                id_class_object_carrier = temp.id_class_object_carrier;
                timestamp_class_object_carrier = temp.timestamp_class_object_carrier;
                id_class_prop_object_carrier = temp.id_class_prop_object_carrier;
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
            return String.Format("Свойство{0} Носитель: {1} - Количество: {2}", id_class_prop_object_carrier, id_object_carrier, bquantity); ;
        }
        #endregion

    }
}
