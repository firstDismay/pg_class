using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет новое свойство шаблона
        /// </summary>
        public pos_temp_prop pos_temp_prop_add(Int64 iid_pos_temp, Int32 iid_prop_type, Boolean ion_override, Int32 iid_data_type, String iname, String idesc, Int32 isort)
        {
            pos_temp_prop pos_temp_prop = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_add");
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
            cmdk.Parameters["iid_prop_type"].Value = iid_prop_type;
            cmdk.Parameters["ion_override"].Value = ion_override;
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["isort"].Value = isort;
            cmdk.ExecuteNonQuery();

            id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
            if (id > 0)
            {
                pos_temp_prop = pos_temp_prop_by_id(id);
                if (pos_temp_prop != null)
                {
                    //Генерируем событие изменения свойства
                    PosTempPropChangeEventArgs e = new PosTempPropChangeEventArgs(pos_temp_prop, eAction.Insert);
                    PosTempPropOnChange(e);
                }
            }

            //Возвращаем сущность
            return pos_temp_prop;
        }

        /// <summary>
        /// Метод добавляет новое свойство класса
        /// </summary>
        public pos_temp_prop pos_temp_prop_add(pos_temp PosTemp, prop_type Prop_type, Boolean On_Override, con_prop_data_type Data_type, String iname, String idesc, Int32 isort)
        {
            return pos_temp_prop_add(PosTemp.Id, Prop_type.Id, On_Override, Data_type.Id, iname, idesc, isort);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_add");
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