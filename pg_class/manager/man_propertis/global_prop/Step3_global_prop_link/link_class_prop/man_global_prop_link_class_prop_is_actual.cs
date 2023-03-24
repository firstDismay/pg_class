using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод определяет актуальность данных значения глобального свойства концепции
        /// </summary>
        public eEntityState global_prop_link_class_prop_is_actual(Int64 iid_global_prop, Int64 iid_class_prop_definition)
        {
            Int32 is_actual = 3;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_link_class_prop_is_actual");
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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Parameters["iid_class_prop_definition"].Value = iid_class_prop_definition;
            is_actual = (Int32)cmdk.ExecuteScalar();

            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Метод определяет актуальность данных значения глобального свойства концепции
        /// </summary>
        public eEntityState global_prop_link_class_prop_is_actual(global_prop_link_class_prop GlobalPropLinkClassProp)
        {
            return global_prop_link_class_prop_is_actual(GlobalPropLinkClassProp.Id_global_prop, GlobalPropLinkClassProp.Id_class_prop_definition); ;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_link_class_prop_is_actual(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_link_class_prop_is_actual");
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