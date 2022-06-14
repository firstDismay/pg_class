using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;
using pg_class.poolcn;

namespace pg_class
{
    public partial class manager
    {
        
        /// <summary>
        /// Метод создания команды экспорта данных в Excel для произвольного запроса
        /// </summary>
        internal command_export export_to_excel_get_command(String command_export, String Desc)
        {
            NpgsqlCommandKey cmdk;
            cmdk = CommandByKey("exp_base_entity_to_excel", true);
            if (cmdk != null)
            {
                if (!cmdk.Access)
                {
                    throw new AccessDataBaseException(404, String.Format(@"Отказано в доступе к методу: {0}!", cmdk.CommandText));
                }
            }
            else
            {
                throw new AccessDataBaseException(405, String.Format(@"Не найден метод: {0}!", cmdk.CommandText));
            }

            cmdk.Parameters["command_export"].Value = command_export;
            command_export cm = new command_export(cmdk, command_export, Desc);
            return cm;
        }
    }
}
