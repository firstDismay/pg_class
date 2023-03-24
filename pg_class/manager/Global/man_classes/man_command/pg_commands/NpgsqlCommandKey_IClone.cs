namespace pg_class.pg_commands
{
    /// <summary>
    /// Класс контейнер для инициализированных команд БД
    /// </summary>
    public partial class NpgsqlCommandKey
    {
        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        public NpgsqlCommandKey Clone()
        {
            NpgsqlCommandKey Result = null;
            Result = new NpgsqlCommandKey(ProcOID, cmd_.Clone(), key_, pronargs_, argsignature_, prorettype_, prorettypename_, proretset_, access_);
            Result.cmd_.CommandTimeout = cmd_.CommandTimeout;
            return Result;
        }
        #endregion
    }
}
