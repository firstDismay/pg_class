using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System.Net.Sockets;
using pg_class.poolcn;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Лист команд взаимодействия с сервером PostgreSQL
        /// </summary>
        private List<NpgsqlCommandKey> command_list;

        /// <summary>
        /// Лист таблиц команд взаимодействия с сервером PostgreSQL
        /// </summary>
        private List<DataTable> datatable_list;
    }
}