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
            return String.Format(@"Функция: {0} Действие: {1} Сущность: {2} Класс ошибки: {3} Код ошибки: {4} Сообщение: {5} Подсказка: {6}", 
                                func, actionerr, entity, classerrdesc, codeerr, messageerr, hinterr);
        }
    }
}