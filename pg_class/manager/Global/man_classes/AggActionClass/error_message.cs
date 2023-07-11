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
        /// Идентификатор экземпляра сущности
        /// </summary>
        public Int64 entity_instance_id { get; set; }

        /// <summary>
        /// Идентификатор сущности дополнительный
        /// </summary>
        public Int64 sub_entity_instance_id { get; set; }


        public PgFunctionMessage MessageGet()
        {
            return JsonConvert.DeserializeObject<PgFunctionMessage>(message);
        }
    }
}