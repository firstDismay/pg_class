using System;

namespace pg_class
{
    /// <summary>
    /// Композитный тип данных ссылка на документ
    /// </summary>
    public class pg_vlog_link
    {
        public Int64 id { get; set; }
        public Int64 id_conception { get; set; }
        public Int64 id_log { get; set; }
        public Int32 id_category { get; set; }
        public String message { get; set; }
        public DateTime datetime { get; set; }
        public Int32 id_entity { get; set; }
        public Int64 id_entity_instance { get; set; }
        public Int64 id_sub_entity_instance { get; set; }

        public override string ToString()
        {
            return message;
        }
    }
}

