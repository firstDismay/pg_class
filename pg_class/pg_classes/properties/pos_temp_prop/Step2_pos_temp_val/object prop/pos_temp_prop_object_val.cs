﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_exceptions;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс данных значения объектного свойства класса, определяющий правила назначений объектов значений в объекте носителе свойства
    /// </summary>
    public partial class pos_temp_prop_object_val
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected pos_temp_prop_object_val()
        {
            imagekey = "class_prop_obj_val_class_us";
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public pos_temp_prop_object_val(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "vpos_temp_prop_object_val")
            {
                id  = (Int64)row["id"];
                id_pos_temp = (Int64)row["id_pos_temp"];
                id_pos_temp_prop = (Int64)row["id_pos_temp_prop"];

                id_class_val = (Int64)row["id_class_val"];
                timestamp_class_val = (DateTime)row["timestamp_class_val"];
                bquantity_max = (Decimal)row["bquantity_max"];
                bquantity_min = (Decimal)row["bquantity_min"];
                entitysource = eEntitySource.Server;
                tablename = (String)row["tablename"];
                on_val = (Boolean)row["on_val"];
                timestamp = Convert.ToDateTime(row["timestamp"]);

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

        /// <summary>
        /// Дополнительный конструктор класса для комплектации значения на стороне клиента
        /// </summary>
        public pos_temp_prop_object_val(pos_temp_prop PosTempProp, vclass ClassVal,  
            Decimal bQuantityMin, Decimal bQuantityMax) : this()
        {
            if (PosTempProp != null & ClassVal != null)
            {
                id = -1;
                id_pos_temp_prop = PosTempProp.Id;
                id_pos_temp = PosTempProp.Id_pos_temp;
                
                id_class_val = ClassVal.Id;
                timestamp_class_val = ClassVal.Timestamp;
                bquantity_min = bQuantityMin;
                bquantity_max = bQuantityMax;
                entitysource = eEntitySource.Client;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Свойство класса или класс значение равны null!");
            }
        }

        #endregion

        #region СВОЙСТВА КЛАССА
        private Int64 id = 0;
        private Int64 id_pos_temp_prop;
        private Int64 id_pos_temp;
        private Int64 id_class_val;
        private DateTime timestamp_class_val;
        private Decimal bquantity_max;
        private Decimal bquantity_min;
        private String tablename;
        private eEntitySource entitysource;
        private Boolean on_val;

        private eObjectPropCreateEmdedMode embed_mode;
        private Boolean embed_single;
        private Int64 embed_class_real_id;
        private Int32 id_unit_conversion_rule;

        private Boolean on_change;
        
        /// <summary>
        /// Свойство определяет источник сущности
        /// </summary>
        public eEntitySource EntitySource
        {
            get
            {
                return entitysource;
            }
        }


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
        /// Свойство определяющее наличие класса значения в данных значения свойства
        /// </summary>
        public Boolean On_val
        {
            get
            {
                return on_val;
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
            set
            {
                if (bquantity_min != value)
                {
                    bquantity_min = value;
                    on_change = true;
                }
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
            set
            {
                if (bquantity_max != value)
                {
                    bquantity_max = value;
                    on_change = true;
                }
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
        /// Идентификатор шаблона носителя свойства
        /// </summary>
        public Int64 Id_pos_temp
        {
            get
            {
                return id_pos_temp_prop;
            }
        }
        
        /// <summary>
        /// Идентификатор свойства шаблона
        /// </summary>
        public Int64 Id_pos_temp_prop
        {
            get
            {
                return id_pos_temp_prop;
            }
        }

        /// <summary>
        /// Идентификатор значения объектного свойства класса
        /// </summary>
        public Int64 Id
        {
            get
            {
                return id;
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
        /// Тип хранилища данных сущности
        /// </summary>
        public eStorageType StorageType
        {
            get
            {
                String pattern = "notsaved";
                eStorageType tmp = eStorageType.Active;
                if (System.Text.RegularExpressions.Regex.IsMatch(tablename, pattern))
                {
                    tmp = eStorageType.NotSaved;
                }
                return tmp;
            }
        }

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

        private DateTime timestamp;
        /// <summary>
        /// Штамп времени шаблона позиции
        /// </summary>
        public DateTime Timestamp
        {
            get
            {
                return timestamp;
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
            set
            {
                if (embed_mode != value)
                {
                    embed_mode = value;
                    on_change = true;
                }
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
            set
            {
                if (embed_single != value)
                {
                    embed_single = value;
                    on_change = true;
                }
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
            set
            {
                if (embed_class_real_id != value)
                {
                    embed_class_real_id = value;
                    on_change = true;
                }
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
            set
            {
                if (id_unit_conversion_rule != value)
                {
                    id_unit_conversion_rule = value;
                    on_change = true;
                }
            }
        }
        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния данных значения свойства
        /// </summary>
        public eEntityState Is_actual()
        {
            return manager.Instance().pos_temp_is_actual(id_pos_temp, timestamp);
        }

        /// <summary>
        /// Обновление данных значения свойства
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                if (this.StorageType == eStorageType.NotSaved)
                {
                    Manager.pos_temp_prop_object_val_add(this);
                }
                else
                {
                    Manager.pos_temp_prop_object_val_upd(this);
                }
                Refresh();
                on_change = false;
            }
        }


        /// <summary>
        /// Удаление значения из данных значения свойства
        /// </summary>
        public void DelVal()
        {
            Manager.pos_temp_prop_object_val_del(this);
            Refresh();
        }

        /// <summary>
        /// Обновление представления класса из БД
        /// </summary>
        public Boolean Refresh()
        {
            pos_temp_prop_object_val temp = null;
            Boolean Result = false;
            temp = Manager.pos_temp_prop_object_val_by_id(id);
            if (temp != null)
            {
                id = temp.Id;
                id_class_val = temp.Id_class_val;
                timestamp_class_val = temp.Timestamp_class_val;
                on_val = temp.On_val;
                bquantity_max = temp.Bquantity_max;
                bquantity_min = temp.Bquantity_min;
                entitysource = eEntitySource.Server;
                tablename = temp.Tablename;
                timestamp = temp.Timestamp;
                embed_mode = temp.Embed_mode;
                embed_single = temp.Embed_single;
                embed_class_real_id = temp.Embed_class_real_id;
                id_unit_conversion_rule = temp.Id_unit_conversion_rule;
                Result = true;
                on_change = false;
            }
            else
            {
                Result = false;
            }
            return Result;
        }

        /// <summary>
        /// Шаблон носитель свойства
        /// </summary>
        public pos_temp pos_temp_carrier_get()
        {
            return Manager.pos_temp_by_id(id_pos_temp);
        }

        /// <summary>
        /// Класс значение свойства STEP 2
        /// </summary>
        public vclass value_get()
        {
            vclass Result = null;

            switch (StorageType)
            {
                case eStorageType.Active:
                    Result = Manager.class_act_by_id(id_class_val);
                    break;
                case eStorageType.History:
                    Result = Manager.class_snapshot_by_id(Id_class_val, Timestamp_class_val);
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Значение свойства типа объектное установить
        /// </summary>
        public vclass value_set(vclass class_val)
        {
            if (class_val != null)
            {
                id_class_val = class_val.Id;
                timestamp_class_val = class_val.Timestamp;
            }
            on_change = true;
            return class_val;
        }


        /// <summary>
        /// Свойство которому пренадлежит текущее значеие
        /// </summary>
        public pos_temp_prop pos_temp_prop_get()
        {
            return Manager.pos_temp_prop_by_id(id_pos_temp_prop);
        }

        /// <summary>
        /// Лист режимов создания встроенных объектов при создании объектного свойства объекта
        /// object_prop_create_emded_mode_by_all
        /// </summary>
        public List<object_prop_create_emded_mode> Object_prop_create_emded_mode_list_get()
        {
            return Manager.object_prop_create_emded_mode_by_all();
        }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ ШАБЛОНА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return String.Format("Шаблон{0} [{1}/{2}]", id, bquantity_min, bquantity_max); ;
        }
        #endregion
    }
}

