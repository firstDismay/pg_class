using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод определяет наличие разрешения RL2 класс на позицию для переданной пары
        /// </summary>
        public Boolean rulel2_class_on_position_check_access(Int64 iid_position, Int64 iid_class)
        {
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("rulel2_class_on_position_check_access");
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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_class"].Value = iid_class;
            return (Boolean)cmdk.ExecuteScalar();
        }

        /// <summary>
        /// Метод определяет наличие разрешения RL2 класс на позицию для переданной пары
        /// </summary>
        public Boolean rulel2_class_on_position_check_access(position Position, vclass Class)
        {
            return rulel2_class_on_position_check_access(Position.Id, Class.Id);
        }
    }
}