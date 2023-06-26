using System;

namespace pg_class.pg_exceptions
{
    /// <summary>
    /// Сообщение функции API
    /// </summary>
    public class PgFunctionMessage
    {
        public String codeerr { get; set; }
        public String actionerr { get; set; }
        public String entity { get; set; }
        public String messageerr { get; set; }
        public String hinterr { get; set; }
        public String classerr { get; set; }
        public String classerrdesc { get; set; }
    }
}