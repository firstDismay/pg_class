﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет флаг переопределяемости в свойствах наследующих вещественных классов
        /// </summary>
        public class_prop class_prop_inheriting_override_set(Int64 iid, Boolean ion_override)
        {
            class_prop class_prop = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_inheriting_override_set");
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

            cmdk.Parameters["iid"].Value = iid;
            cmdk.Parameters["ion_override"].Value = ion_override;
            cmdk.ExecuteNonQuery();

            class_prop = class_prop_by_id(iid);

            if (class_prop != null)
            {
                //Генерируем событие изменения свойства класса
                ClassPropChangeEventArgs e = new ClassPropChangeEventArgs(class_prop, eAction.Update);
                ClassPropOnChange(e);
            }
            //Возвращаем сущность
            return class_prop;
        }

        /// <summary>
        /// Метод изменяет флаг переопределяемости в свойствах наследующих вещественных классов
        /// </summary>
        public class_prop class_prop_inheriting_override_set(class_prop Class_prop, Boolean ion_override)
        {
            class_prop Result = null;
            if (Class_prop != null)
            {
                if (Class_prop.StorageType == eStorageType.Active)
                {
                    Result = class_prop_inheriting_override_set(Class_prop.Id, ion_override);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        "Метод обновления данных свойства класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_inheriting_override_set(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_inheriting_override_set");
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