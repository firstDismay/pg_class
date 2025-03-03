using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет новое свойство шаблона позиций по шаблону глобального свойства
        /// </summary>
        public pos_temp_prop pos_temp_prop_add_as_global_prop(Int64 iid_pos_temp, Int64 iid_global_prop, Boolean ion_override, Int32 isort)
        {
            pos_temp_prop pos_temp_prop = null;
            Int64 id = 0;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_add_as_global_prop");
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
            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Parameters["ion_override"].Value = ion_override;
            cmdk.Parameters["isort"].Value = isort;
            cmdk.ExecuteNonQuery();

            id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
            if (id > 0)
            {
                pos_temp_prop = pos_temp_prop_by_id(id);
            }

            if (pos_temp_prop != null)
            {
                //Генерируем событие изменения свойства
                PosTempPropChangeEventArgs e = new PosTempPropChangeEventArgs(pos_temp_prop, eAction.Insert);
                PosTempPropOnChange(e);
            }
            //Возвращаем сущность
            return pos_temp_prop;
        }

        /// <summary>
        /// Метод добавляет новое свойство класса по шаблону глобального свойства
        /// </summary>
        public pos_temp_prop pos_temp_prop_add_as_global_prop(pos_temp_prop pos_Temp_Prop, global_prop Global_prop, Boolean On_Override, Int32 isort)
        {
            pos_temp_prop Result = null;
            if (pos_Temp_Prop != null)
            {
                Result = pos_temp_prop_add_as_global_prop(pos_Temp_Prop.Id, Global_prop.Id, On_Override, isort);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_add_as_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_add_as_global_prop");
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