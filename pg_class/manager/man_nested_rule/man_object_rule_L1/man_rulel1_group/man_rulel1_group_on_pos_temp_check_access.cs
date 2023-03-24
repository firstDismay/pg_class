using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод определяет наличие разрешения RL1 группа на шаблон для переданной пары
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_check_access(Int64 iid_pos_temp, Int64 iid_group)
        {
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("rulel1_group_on_pos_temp_check_access");
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

            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;
            cmdk.Parameters["iid_group"].Value = iid_group;

            return (Boolean)cmdk.ExecuteScalar();
        }

        /// <summary>
        /// Метод определяет наличие разрешения RL1 группа на шаблон для переданной пары
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_check_access(pos_temp Pos_temp, group Group)
        {
            return rulel1_group_on_pos_temp_check_access(Pos_temp.Id, Group.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_check_access(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("rulel1_group_on_pos_temp_check_access");
            if (cmdk != null)
            {
                Result = cmdk.Access;
                if (Result)
                {
                    Access = eAccess.Success;
                }
                else
                {
                    Access = eAccess.NotAvailable;
                }
            }
            return Result;
        }
    }
}
