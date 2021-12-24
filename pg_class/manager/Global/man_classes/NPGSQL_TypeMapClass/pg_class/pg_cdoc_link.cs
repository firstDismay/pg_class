using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class
{
    /// <summary>
    /// Композитный тип данных ссылка на документ
    /// </summary>
    public class pg_vdoc_link
    {
        public Int64 id { get; set; }
        public Int64 id_conception { get; set; }
        public Int64 id_document { get; set; }
        public Int32 id_category { get; set; }
        public String name { get; set; }
        public String regnum { get; set; }
        public DateTime regdate { get; set; }
        public Int32 id_entity { get; set; }
        public Int64 id_entity_instance { get; set; }
        public Int64 id_sub_entity_instance { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}

