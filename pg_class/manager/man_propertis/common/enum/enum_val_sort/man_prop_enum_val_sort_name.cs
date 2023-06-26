using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using System.Collections.Generic;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет текущую сортировку элементов перечисления на сортировку по имени
        /// </summary>
        public List<prop_enum_val> prop_enum_val_sort_by_name(Int64 iid_prop_enum)
        {
            List<prop_enum_val> SortList = new List<prop_enum_val>();
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("prop_enum_val_sort_by_name");
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

            cmdk.Parameters["iid_prop_enum"].Value = iid_prop_enum;
            cmdk.ExecuteNonQuery();

            SortList = prop_enum_val_by_id_prop_enum(iid_prop_enum);
            foreach (prop_enum_val item in SortList)
            {
                //Генерируем события изменения сортировки элементов перечисления
                PropEnumValChangeEventArgs e = new PropEnumValChangeEventArgs(item, eAction.Update);
                PropEnumValOnChange(e);
            }

            //Возвращаем сущность
            return SortList;
        }

        /// <summary>
        /// Метод изменяет текущую сортировку элементов перечисления на сортировку по имени
        /// </summary>
        public List<prop_enum_val> prop_enum_val_sort_by_name(prop_enum PropEnum)
        {
            return prop_enum_val_sort_by_name(PropEnum.Id_prop_enum); ;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_val_sort_by_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("prop_enum_val_sort_by_name");
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