using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод удаляет свойство класса из глобального свойства
        /// </summary>
        public global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop_exclude(Int64 iid_pos_temp_prop)
        {
            global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop;
            pos_temp_prop prop_link;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_link_pos_temp_prop_exclude");
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

            //Запрос удаляемой сущности
            global_prop_link_pos_temp_prop = global_prop_link_pos_temp_prop_by_id(iid_pos_temp_prop);

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
            cmdk.ExecuteNonQuery();

            prop_link = pos_temp_prop_by_id(iid_pos_temp_prop);

            if (global_prop_link_pos_temp_prop != null)
            {
                //Генерируем событие изменения
                GlobalPropLinkPosTempPropChangeEventArgs e = new GlobalPropLinkPosTempPropChangeEventArgs(global_prop_link_pos_temp_prop, eAction.Delete);
                GlobalPropLinkPosTempPropOnChange(e);
            }

            if (prop_link != null)
            {
                //Генерируем событие изменения свойства шаблона
                PosTempPropChangeEventArgs e2 = new PosTempPropChangeEventArgs(prop_link, eAction.Update);
                PosTempPropOnChange(e2);
            }
            //Возвращаем сущность
            return global_prop_link_pos_temp_prop;
        }

        /// <summary>
        /// Метод удаляет свойство класса из глобального свойства
        /// </summary>
        public global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop_exclude(pos_temp_prop PosTempProp)
        {
            global_prop_link_pos_temp_prop Result = null;
            if (PosTempProp != null)
            {
                Result = global_prop_link_pos_temp_prop_exclude(PosTempProp.Id);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_link_pos_temp_prop_exclude(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_link_pos_temp_prop_exclude");
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