using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет сортировку свойства шаблона позиции поднимая указанное свойство вверх на одну позицию
        /// </summary>
        public pos_temp_prop pos_temp_prop_sort_up(Int64 iid_pos_temp_prop)
        {
            pos_temp_prop pos_temp_prop = null;
            pos_temp pos_temp_sort = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_sort_up");
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

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
            cmdk.ExecuteNonQuery();

            pos_temp_prop = pos_temp_prop_by_id(iid_pos_temp_prop);
            pos_temp_sort = pos_temp_by_id(pos_temp_prop.Id_pos_temp);
            //Генерируем событие применения метода сортировки
            if (pos_temp_sort != null)
            {
                PosTempChangeEventArgs e = new PosTempChangeEventArgs(pos_temp_sort, eAction.Update);
                PosTempPropSortOnChange(e);
            }

            //Возвращаем сущность
            return pos_temp_prop;
        }

        /// <summary>
        /// Метод изменяет сортировку свойства шаблона позиции поднимая указанное свойство вверх на одну позицию
        /// </summary>
        public pos_temp_prop pos_temp_prop_sort_up(pos_temp_prop Pos_temp_prop)
        {
            return pos_temp_prop_sort_up(Pos_temp_prop.Id); ;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_sort_up(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_sort_up");
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