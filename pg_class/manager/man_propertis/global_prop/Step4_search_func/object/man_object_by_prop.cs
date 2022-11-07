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

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Лист объектов по маске значения свойства
        /// </summary>
        /// <param name="prop_search_condition">Класс критерия поиска</param>
        /// <param name="iid_position">Ссылочная позиция</param>
        /// <returns>Лист объектов</returns>
        /// <exception cref="AccessDataBaseException"></exception>
        public List<object_general> object_by_prop(PropSearchСondition prop_search_condition, Int64 iid_position = -1)
        {
            PropSearchСondition[] array_prop = new PropSearchСondition[1];
            array_prop[0] = prop_search_condition;
            return object_by_array_prop(array_prop, iid_position);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("object_by_array_prop");
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
