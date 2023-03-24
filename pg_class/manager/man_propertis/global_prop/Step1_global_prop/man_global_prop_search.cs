using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using System.Data;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Лист глобальных свойств концепции по строкгому соотвествию имени
        /// </summary>
        public global_prop global_prop_by_name(Int64 iid_conception, String iname)
        {
            global_prop global_prop = null;

            DataTable tbl_vglobal_prop = TableByName("vglobal_prop");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("global_prop_by_name");

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


            cmdk.Parameters["iid_conception"].Value = iid_conception;
            cmdk.Parameters["iname"].Value = iname;

            cmdk.Fill(tbl_vglobal_prop);

            if (tbl_vglobal_prop.Rows.Count > 0)
            {
                global_prop = new global_prop(tbl_vglobal_prop.Rows[0]);
            }
            return global_prop;
        }

        /// <summary>
        /// Выбор глобального свойства по идентификатру свойства
        /// </summary>
        public global_prop global_prop_by_name(conception Conception, String iname)
        {
            return global_prop_by_name(Conception.Id, iname);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_by_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("global_prop_by_name");
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
