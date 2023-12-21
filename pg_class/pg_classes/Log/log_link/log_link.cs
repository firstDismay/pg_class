using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс ссылка сообщения журнала
    /// </summary>
    public partial class log_link
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected log_link()
        {
            imagekey = "log_link_us";
            selectedimagekey = "log_link_s";
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public log_link(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vlog_link")
            {
                id = (Int64)row["id"];
                id_conception = (Int64)row["id_conception"];
                id_log = (Int64)row["id_log"];
                id_category = (Int64)row["id_category"];
                message = (String)row["message"];
                datetime = (DateTime)row["datetime"];

                id_entity = (Int32)row["id_entity"];
                id_entity_instance = (Int64)row["id_entity_instance"];
                id_sub_entity_instance = (Int64)row["id_sub_entity_instance"];
                path = (String)row["path"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }

        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через класс композитного типа
        /// </summary>
        public log_link(pg_vlog_link ll) : this()
        {

            if (ll != null)
            {
                id = ll.id;
                id_conception = ll.id_conception;
                id_log = ll.id_log;
                id_category = ll.id_category;
                message = ll.message;
                datetime = ll.datetime;

                id_entity = ll.id_entity;
                id_entity_instance = ll.id_entity_instance;
                id_sub_entity_instance = ll.id_sub_entity_instance;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Переданное значение композитного типа равно нулю");
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private Int64 id;
        private Int64 id_conception;
        private Int64 id_log;
        private Int64 id_category;
        private String message;
        private DateTime datetime;
        private Int32 id_entity;
        private Int64 id_entity_instance;
        private Int64 id_sub_entity_instance;

        /// <summary>
        /// Идентификатор ссылки 
        /// </summary>
        public Int64 Id { get => id; }

        /// <summary>
        /// Идентификатор концепции 
        /// </summary>
        public Int64 Id_conception { get => id_conception; }

        /// <summary>
        /// Идентификатор записи журнала
        /// </summary>
        public Int64 Id_log { get => id_log; }

        /// <summary>
        /// Категория записи журнала
        /// </summary>
        public Int64 Id_category { get => id_category; }

        /// <summary>
        /// Сообщение записи журнала
        /// </summary>
        public String Message
        {
            get
            {
                return message;
            }
        }

        /// <summary>
        /// Дата записи журнала
        /// </summary>
        public DateTime Datetime { get => datetime; }


        /// <summary>
        /// Перечисление ссылающейся сущности определяющей тип ссылочного объекта
        /// </summary>
        public eEntity Link_e_entity
        {
            get
            {
                return (eEntity)id_entity;
            }
        }

        /// <summary>
        /// Идентификатор ссылающейся сущности
        /// </summary>
        public Int32 Link_id_entity { get => id_entity; }

        /// <summary>
        /// Идентификатор экземпляра ссылающейся сущности
        /// </summary>
        public Int64 Link_id_entity_instance { get => id_entity_instance; }

        /// <summary>
        /// Дополнительный идентификатор ссылающейся сущности
        /// </summary>
        public Int64 Link_id_sub_entity_instance { get => id_sub_entity_instance; }

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
        /// Метод определяет актуальность текущего состояния ссылки
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.log_link_is_actual(id);
        }


        /// <summary>
        /// Обновление группы из БД
        /// </summary>
        public Boolean Refresh()
        {
            log_link temp;
            Boolean Result = false;
            temp = Manager.log_link_by_id(id);

            if (temp != null)
            {
                id = temp.Id;
                id_conception = temp.Id_conception;
                id_log = temp.Id_log;
                id_category = temp.Id_category;
                message = temp.Message;
                datetime = temp.Datetime;

                id_entity = temp.Link_id_entity;
                id_entity_instance = temp.Link_id_entity_instance;
                id_sub_entity_instance = temp.Link_id_sub_entity_instance;
                Result = true;
            }
            else
            {
                Result = false;
            }
            return Result;
        }

        /// <summary>
        /// Удаление ссылки
        /// log_link_del
        /// </summary>
        public void Del()
        {
            Manager.log_link_del(id);
        }

        /// <summary>
        /// Метод возвращает экземпляр сущности носителя ссылки
        /// </summary>
        public object Link_entity_instance_get()
        {
            object Result = null;
            switch (Link_e_entity)
            {
                case eEntity.user:
                    Result = Manager.user_by_id(id_entity_instance);
                    break;
                case eEntity.pos_temp:
                    Result = Manager.pos_temp_by_id(id_entity_instance);
                    break;
                case eEntity.position:
                    Result = Manager.position_by_id(id_entity_instance);
                    break;
                case eEntity.position_prop:
                    Result = Manager.position_prop_by_id(id_entity_instance, id_sub_entity_instance);
                    break;
                case eEntity.pos_temp_prop:
                    Result = Manager.pos_temp_prop_by_id(id_entity_instance);
                    break;
                case eEntity.group:
                    Result = Manager.group_by_id(id_entity_instance);
                    break;
                case eEntity.vclass:
                    Result = Manager.class_act_by_id(id_entity_instance);
                    break;
                case eEntity.class_prop:
                    Result = Manager.class_prop_by_id(id_entity_instance);
                    break;
                case eEntity.vobject:
                    Result = Manager.object_by_id(id_entity_instance);
                    break;
                case eEntity.object_prop:
                    Result = Manager.object_prop_by_id(id_entity_instance, id_sub_entity_instance);
                    break;
                case eEntity.document:
                    Result = Manager.document_by_id(id_entity_instance);
                    break;
                default:
                    Result = Manager.entity_by_id(Convert.ToInt32(id_entity));
                    break;
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
            return message;
        }
        #endregion
    }
}