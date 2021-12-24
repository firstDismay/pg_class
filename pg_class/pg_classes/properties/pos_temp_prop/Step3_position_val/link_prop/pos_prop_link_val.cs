﻿using System;
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
    /// Класс данных значения свойства объекта типа ссылка
    /// </summary>
    public partial class position_prop_link_val
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected position_prop_link_val()
        {
            on_change = false;
            imagekey = "position_prop_link_val_us";
            selectedimagekey = "position_prop_link_val_s";
            
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public position_prop_link_val(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vposition_prop_link_val")
            {
                id_conception = (Int64)row["id_conception"];
                id_position = (Int64)row["id_position"];
                id_pos_temp = (Int64)row["id_pos_temp"];
                id_pos_temp_prop = (Int64)row["id_pos_temp_prop"];
                id_data_type = (Int32)row["id_data_type"];
                inheritance = (Boolean)row["inheritance"];

                id_entity = (Int32)row["id_entity"];
                id_entity_instance = (Int64)row["id_entity_instance"];
                id_sub_entity_instance = (Int64)row["id_sub_entity_instance"];

                tablename = (String)row["tablename"];
                on_val = (Boolean)row["on_val"];
                timestamp_val = (DateTime)row["timestamp_val"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id_conception;
        private Int64 id_position;
        private Int64 id_pos_temp;
        private Int64 id_pos_temp_prop;
        private Boolean inheritance;
        private Int32 id_entity;
        private Int64 id_entity_instance;
        private Int64 id_sub_entity_instance;
        private Int32 id_data_type;

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

        /// <summary>
        /// Идентификатор концепции
        /// </summary>
        public Int64 Id_conception { get => id_conception; }

        /// <summary>
        /// Идентификатор позиции носителя свойства
        /// </summary>
        public Int64 Id_position_carrier { get => id_position; }

        /// <summary>
        /// Идентификатор шаблона позиции носителя свойства
        /// </summary>
        public Int64 Шd_pos_temp { get => id_pos_temp; }
        
        /// <summary>
        /// Идентификатор свойства шаблона позиции
        /// </summary>
        public Int64 Id_pos_temp_prop { get => id_pos_temp_prop; }

        /// <summary>
        /// Признак наследованного свойства
        /// </summary>
        public Boolean Inheritance { get => inheritance; }


        /// <summary>
        /// Идентификатор типа данных ссылки
        /// </summary>
        public Int32 Id_data_type
        {
            get
            {
                return id_data_type;
            }
        }

        /// <summary>
        /// Идентификатор ссылочной сущности определяющей данные значения свойстсва
        /// </summary>
        public Int32 Link_id_entity
        {
            get
            {
                return id_entity;
            }
        }

        /// <summary>
        /// Перечисление ссылочной сущности определяющей данные значения свойстсва
        /// </summary>
        public eEntity Link_e_entity
        {
            get
            {
                return (eEntity)id_entity;
            }
        }

        /// <summary>
        /// Идентификатор экземпляра ссылочной сущности определяющей данные значения свойстсва
        /// </summary>
        public Int64 Link_id_entity_instance
        {
            get
            {
                return id_entity_instance;
            }
        }

        /// <summary>
        /// Дополнительный идентификатор экземпляра ссылочной сущности определяющей данные значения свойстсва
        /// </summary>
        public Int64 Link_id_sub_entity_instance
        {
            get
            {
                return id_sub_entity_instance;
            }
        }

        /// <summary>
        /// Тип свойства
        /// </summary>
        public ePropType Prop_type
        {
            get
            {
                return ePropType.PropLink;
            }
        }

        private DateTime timestamp_val;
            /// <summary>
            /// Штам времени класса носителя свойства
            /// </summary>
            public DateTime Timestamp_val
            {
                get
                {
                    return timestamp_val;
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


        private Boolean on_val;
            /// <summary>
            /// Признак установленного значения свойства
            /// </summary>
            public Boolean On_val
            {
                get
                {
                    return on_val;
                }
            }

        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния группы
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.position_prop_link_val_is_actual(this);
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
                        Manager.position_prop_link_val_add(this);
                    }
                    else
                    {
                        Manager.position_prop_link_val_upd(this);
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
            Manager.position_prop_link_val_del(this);
            Refresh();
        }

        /// <summary>
        /// Обновление группы из БД
        /// </summary>
        public Boolean Refresh()
        {
            
            position_prop_link_val temp;
            Boolean Result = false;
            temp = Manager.position_prop_link_val_by_id_prop(this);
            if (temp != null)
            {
                id_data_type = temp.Id_data_type;
                inheritance = temp.Inheritance;
                id_entity = temp.Link_id_entity;
                id_entity_instance = temp.Link_id_entity_instance;
                on_val = temp.On_val;
                timestamp_val = temp.Timestamp_val;
                tablename = temp.Tablename;
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
        /// Метод возвращает сущность в которую входит экземпляр значения
        /// </summary>
        public entity Link_entity_get()
        {
            return Manager.entity_by_id(id_entity);
        }

        /// <summary>
        /// Метод возвращает экземпляр сущности в которую входит экземпляр значения
        /// </summary>
        public object Link_entity_instance_get()
        {
            object Result = null;
            switch (Link_e_entity)
            {
                case eEntity.user:
                    Result = Manager.user_by_id(Link_id_entity_instance);
                    break;
                case eEntity.pos_temp:
                    Result = Manager.pos_temp_by_id(Link_id_entity_instance);
                    break;
                case eEntity.position:
                    Result = Manager.pos_by_id(Link_id_entity_instance);
                    break;
                case eEntity.position_prop:
                    Result = Manager.position_prop_by_id(Link_id_entity_instance, Link_id_sub_entity_instance);
                    break;
                case eEntity.pos_temp_prop:
                    Result = Manager.pos_temp_prop_by_id(Link_id_entity_instance);
                    break;
                case eEntity.group:
                    Result = Manager.group_by_id(Link_id_entity_instance);
                    break;
                case eEntity.vclass:
                    Result = Manager.class_act_by_id(Link_id_entity_instance);
                    break;
                case eEntity.class_prop:
                    Result = Manager.class_prop_by_id(Link_id_entity_instance);
                    break;
                case eEntity.vobject:
                    Result = Manager.object_by_id(Link_id_entity_instance);
                    break;
                case eEntity.object_prop:
                    Result = Manager.object_prop_by_id(Link_id_entity_instance, Link_id_sub_entity_instance);
                    break;
                default:
                    Result = Manager.entity_by_id(Convert.ToInt32(Link_id_entity));
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Значение свойства типа ссылка установить
        /// </summary>
        public void value_set_instance(Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            id_entity_instance = iid_entity_instance;
            id_sub_entity_instance = iid_sub_entity_instance;
            on_change = true;
        }

        /// <summary>
        /// Свойство которому пренадлежит текущее значеие
        /// </summary>
        public pos_temp_prop pos_temp_prop_get()
        {
            return Manager.pos_temp_prop_by_id(id_pos_temp_prop); ;
        }

        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            String Result = "";
            String entity = Manager.entity_by_id(Link_id_entity).Name;
            String entity_instance = "н/д";

            switch (Link_e_entity)
            {
                case eEntity.pos_temp:
                    pos_temp pos_temp = Manager.pos_temp_by_id(Link_id_entity_instance);
                    if (pos_temp != null)
                    {
                        entity_instance = pos_temp.Name_pos_temp;
                    }
                    Result = String.Format("{0}: {1}", entity, entity_instance);
                    break;

                case eEntity.position:
                    position position = Manager.pos_by_id(Link_id_entity_instance);
                    if (position != null)
                    {
                        entity_instance = position.NamePosition;
                    }
                    Result = String.Format("{0}: {1}", entity, entity_instance);
                    break;
                case eEntity.pos_temp_prop:
                    pos_temp_prop pos_temp_prop = Manager.pos_temp_prop_by_id(Link_id_entity_instance);
                    if (pos_temp_prop != null)
                    {
                        entity_instance = pos_temp_prop.Name;
                    }
                    Result = String.Format("{0}: {1}", entity, entity_instance);
                    break;

                case eEntity.group:
                    group group = Manager.group_by_id(Link_id_entity_instance);
                    if (group != null)
                    {
                        entity_instance = group.Name;
                    }
                    Result = String.Format("{0}: {1}", entity, entity_instance);
                    break;

                case eEntity.vclass:
                    vclass vclass;
                    vclass = Manager.class_act_by_id(Link_id_entity_instance);
                    
                    if (vclass != null)
                    {
                        entity_instance = vclass.Name;
                    }
                    Result = String.Format("{0}: {1}", entity, entity_instance);
                    break;

                case eEntity.class_prop:
                    class_prop class_prop;
                    class_prop = Manager.class_prop_by_id(Link_id_entity_instance);
                    if (class_prop != null)
                    {
                        entity_instance = class_prop.Name;
                    }
                    Result = String.Format("{0}: {1}", entity, entity_instance);
                    break;

                case eEntity.vobject:
                    object_general object_general = Manager.object_by_id(Link_id_entity_instance);
                    if (object_general != null)
                    {
                        entity_instance = object_general.Name;
                    }
                    Result = String.Format("{0}: {1}", entity, entity_instance);
                    break;
                case eEntity.object_prop:
                    object_prop object_prop = Manager.object_prop_by_id(Link_id_sub_entity_instance, Link_id_entity_instance);
                    if (object_prop != null)
                    {
                        entity_instance = object_prop.Name;
                    }
                    Result = String.Format("{0}: {1}", entity, entity_instance);
                    break;
                case eEntity.position_prop:
                    position_prop position_prop = Manager.position_prop_by_id(Link_id_sub_entity_instance, Link_id_entity_instance);
                    if (position_prop != null)
                    {
                        entity_instance = position_prop.Name;
                    }
                    Result = String.Format("{0}: {1}", entity, entity_instance);
                    break;
                case eEntity.user:
                    user user = Manager.user_by_id(Link_id_entity_instance);
                    if (user != null)
                    {
                        entity_instance = user.ToString();
                    }
                    Result = String.Format("{0}: {1}", entity, entity_instance);
                    break;
                default:
                    Result = String.Format("{0}: {1}", entity, entity_instance);
                    break;
            }
            return Result;
        }
        #endregion

    }
}
