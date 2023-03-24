using System;

namespace pg_class
{
    /// <summary>
    /// Композитный тип данных файла документа
    /// </summary>
    public class pg_vdoc_category
    {
        public Int64 id { get; set; }
        public Int64 id_conception { get; set; }
        public String name { get; set; }
        public String desc { get; set; }
        public Boolean on { get; set; }
        public Boolean on_grouping { get; set; }
        public Int64 doc_count { get; set; }
        public Boolean is_use { get; set; }
        public DateTime timestamp { get; set; }


        public override string ToString()
        {
            return name;
        }
    }
}
