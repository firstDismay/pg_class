using System;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;
using pg_class.poolcn;
using System.Threading;

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
            Result =  new NpgsqlCommandKey(procoid_, cmd_.Clone(), key_, pronargs_, argsignature_, access_);
            Result.cmd_.CommandTimeout = cmd_.CommandTimeout;
            return Result;
        }
        #endregion
    }
}
