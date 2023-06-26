using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Удалить данные значени объектного свойства шаблона
        /// </summary>
        public void pos_temp_prop_object_val_del(Int64 iid_pos_temp_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            pos_temp_prop_object_val pos_temp_prop_object_val = null;

            cmdk = CommandByKey("pos_temp_prop_object_val_del");
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

            //Предварительный запрос данных
            pos_temp_prop_object_val = pos_temp_prop_object_val_by_id_prop(iid_pos_temp_prop);

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
            cmdk.ExecuteNonQuery();

            pos_temp_prop pos_temp_prop = pos_temp_prop_by_id(iid_pos_temp_prop);
            //Генерируем событие удаления значения свойства класса
            if (pos_temp_prop != null)
            {
                PosTempPropChangeEventArgs e = new PosTempPropChangeEventArgs(pos_temp_prop, eAction.Update);
                PosTempPropOnChange(e);

                //Генерируем событие изменения значения объектного свойства класса
                PosTempPropObjectValChangeEventArgs e2 = new PosTempPropObjectValChangeEventArgs(pos_temp_prop_object_val, eAction.Delete);
                PosTempPropObjectValOnChange(e2);
            }
            //Генерируем событие удаления значения свойства класса
            if (pos_temp_prop != null)
            {
                PosTempPropChangeEventArgs e = new PosTempPropChangeEventArgs(pos_temp_prop, eAction.Update);
                PosTempPropOnChange(e);

                //Генерируем событие изменения значения объектного свойства класса
                PosTempPropObjectValChangeEventArgs e2 = new PosTempPropObjectValChangeEventArgs(pos_temp_prop_object_val, eAction.Delete);
                PosTempPropObjectValOnChange(e2);
            }
        }

        /// <summary>
        /// Удалить данные значени объектного свойства шаблона
        /// </summary>
        public void pos_temp_prop_object_val_del(pos_temp_prop PosTemp_prop)
        {
            if (PosTemp_prop != null)
            {
                pos_temp_prop_object_val_del(PosTemp_prop.Id);
            }
        }

        /// <summary>
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void pos_temp_prop_object_val_del(pos_temp_prop_object_val PosTempPropObjectVal)
        {
            if (PosTempPropObjectVal != null)
            {
                pos_temp_prop_object_val_del(PosTempPropObjectVal.Id_pos_temp_prop);
            }
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_object_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_object_val_del");
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