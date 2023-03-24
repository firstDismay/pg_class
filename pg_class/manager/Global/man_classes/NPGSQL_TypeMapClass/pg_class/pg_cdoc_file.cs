using System;

namespace pg_class
{
    /// <summary>
    /// Композитный тип данных файла документа
    /// </summary>
    public class pg_vdoc_file
    {
        public Int64 id { get; set; }
        public Guid uuid { get; set; }
        public String md5 { get; set; }
        public Int64 id_conception { get; set; }
        public Int32 catalog { get; set; }
        public Int64 id_document { get; set; }
        public String name { get; set; }
        public String extension { get; set; }
        public DateTime versiondate { get; set; }
        public String version { get; set; }
        public Boolean fulltxtsrch_on { get; set; }
        public DateTime timestamp { get; set; }
        public Int32 data_length { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}

