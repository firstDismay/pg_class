using pg_class.pg_commands;
using System.Collections.Generic;
using System.Data;

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