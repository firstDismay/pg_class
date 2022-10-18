﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class
{
    /// <summary>
    /// Композитный тип данных файла документа
    /// </summary>
    public class pg_clog_category
    {
        public Int64 id { get; set; }
        public Int64 id_conception { get; set; }
        public String name { get; set; }
        public String desc { get; set; }
        public Int32 level { get; set; }
		public Boolean on { get; set; }
        public DateTime timestamp { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
