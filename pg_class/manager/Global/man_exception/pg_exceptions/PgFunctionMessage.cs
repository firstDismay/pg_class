using System;

namespace pg_class.pg_exceptions
{
    /// <summary>
    /// Сообщение функции API
    /// </summary>
    public class PgFunctionMessage
    {
        public String func { get; set; }
        public String codeerr { get; set; }
        public String actionerr { get; set; }
        public String entity { get; set; }
        public String messageerr { get; set; }
        public String hinterr { get; set; }
        public String classerr { get; set; }
        public String classerrdesc { get; set; }

        public override string ToString()
        {
            return String.Format("Функция: {0} Код ошибки: {1} Сообщение: {2}", func, codeerr, messageerr);
        }
    }
}