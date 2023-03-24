using System;

namespace pg_class
{
    /// <summary>
    /// Композитный тип данных столбца таблицы
    /// </summary>
    public class pg_vclass_prop
    {
        public Int64 id { get; set; }
        public Int64 id_class { get; set; }
        public DateTime timestamp_class { get; set; }
        public Boolean on_inherit { get; set; }
        public Boolean inheritance { get; set; }
        public Int64 id_prop_inherit { get; set; }
        public DateTime timestamp_class_inherit { get; set; }
        public Int32 id_prop_type { get; set; }
        public Int32 id_data_type { get; set; }
        public String name { get; set; }
        public String desc { get; set; }
        public Int32 sort { get; set; }
        public Boolean on_override { get; set; }
        public Boolean on_val { get; set; }
        public String string_val { get; set; }
        public String tablename { get; set; }
        public Boolean ready { get; set; }
        public Int64 id_conception { get; set; }
        public Int64 id_class_definition { get; set; }
        public DateTime timestamp_class_definition { get; set; }
        public Int64 id_prop_definition { get; set; }
        public Boolean on_override_prop_inherit { get; set; }
        public Boolean on_global { get; set; }
        public Int64 id_global_prop { get; set; }
        public String tag { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}


