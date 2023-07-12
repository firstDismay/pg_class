using Newtonsoft.Json;
using pg_class.pg_exceptions;
using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Квантовый класс для возврата результатов групповых операций 
    /// </summary>
    public class error_message
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public error_message() { }

        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public error_message(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "error_message")
            {
                message = (String)row["message"];
                entity_id = (Int32)row["entity_id"];
                entity_instance_id = (Int64)row["entity_instance_id"];
                sub_entity_instance_id = (Int64)row["sub_entity_instance_id"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }

        /// <summary>
        /// Сообщение об ошибке в формате JSON (PgFunctionMessage)
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public Int32 entity_id { get; set; }

        /// <summary>
        /// Сущность
        /// </summary>
        public eEntity Entity { get => (eEntity)entity_id; }

        /// <summary>
        /// Идентификатор экземпляра сущности
        /// </summary>
        public Int64 entity_instance_id { get; set; }

        /// <summary>
        /// Идентификатор сущности дополнительный
        /// </summary>
        public Int64 sub_entity_instance_id { get; set; }

        /// <summary>
        /// Метод возвращает POCO класс ошибки API
        /// </summary>
        public PgFunctionMessage MessageGet()
        {
            PgFunctionMessage msg;
            try
            {
                msg = JsonConvert.DeserializeObject<PgFunctionMessage>(message);
            }
            catch (JsonSerializationException ex)
            {
                msg = new PgFunctionMessage()
                {
                    actionerr = "any",
                    messageerr=ex.Message,
                    classerr = "none",
                    classerrdesc = ex.Source,
                    entity = "none",
                    codeerr = "none",
                    func = "none",
                    hinterr = "-"
                };
            }
                return msg;
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
        /// Сущность БД
        /// </summary>
        public entity Entity_get()
        {
            return Manager.entity_by_id(entity_id);
        }

        /// <summary>
        /// Метод возвращает экземпляр сущности в которую входит экземпляр значения
        /// </summary>
        public object Entity_instance_get()
        {
            object Result = null;
            switch (Entity)
            {
                case eEntity.user:
                    Result = Manager.user_by_id(entity_instance_id);
                    break;
                case eEntity.pos_temp:
                    Result = Manager.pos_temp_by_id(entity_instance_id);
                    break;
                case eEntity.position:
                    Result = Manager.position_by_id(entity_instance_id);
                    break;
                case eEntity.pos_temp_prop:
                    Result = Manager.pos_temp_prop_by_id(entity_instance_id);
                    break;
                case eEntity.group:
                    Result = Manager.group_by_id(entity_instance_id);
                    break;
                case eEntity.vclass:
                    Result = Manager.class_act_by_id(entity_instance_id);
                    break;
                case eEntity.class_prop:
                    Result = Manager.class_prop_by_id(entity_instance_id);
                    break;
                case eEntity.vobject:
                    Result = Manager.object_by_id(entity_instance_id);
                    break;
                default:
                    Result = Manager.entity_by_id(Convert.ToInt32(entity_instance_id));
                    break;
            }
            return Result;
        }
        public override string ToString()
        {
            PgFunctionMessage msg = this.MessageGet();

            if (msg !=null)
            {
                return String.Format("Функция: {0} код завершения: {1} сообщение: {2} сущность: {3}-{4}-{5}",
                    msg.func, msg.codeerr, msg.messageerr, entity_id, entity_instance_id, sub_entity_instance_id);
            }
            return base.ToString();
        }
    }
}