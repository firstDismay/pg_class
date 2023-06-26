﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет указанную концепцию
        /// </summary>
        public conception conception_upd(Int64 iid, String iname, String idesc, Boolean ion, Boolean ion_root_create, Boolean idefault)
        {
            conception conception = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("conception_upd");
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
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["ion"].Value = ion;
            cmdk.Parameters["ion_root_create"].Value = ion_root_create;
            cmdk.Parameters["idefault"].Value = idefault;
            cmdk.ExecuteNonQuery();

            conception = conception_by_id(iid);

            //Генерируем событие изменения концепции
            ConceptionChangeEventArgs e = new ConceptionChangeEventArgs(conception, eAction.Update);
            ConceptionOnChange(e);
            //Возвращаем сущность
            return conception;
        }

        /// <summary>
        /// Метод изменяет указанную концепцию
        /// </summary>
        public conception conception_upd(conception Conception)
        {
            //Int64 iid, String iname, String idesc, Boolean ion
            return conception_upd(Conception.Id, Conception.Name, Conception.Desc, Conception.On, Conception.On_root_create, Conception.Default_Conception);
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean conception_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("conception_upd");
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

        /// <summary>
        /// Метод восстанавливает указанную концепцию
        /// </summary>
        public conception conception_restore(Int64 iid)
        {
            conception conception = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("conception_restore");
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
            cmdk.ExecuteNonQuery();

            conception = conception_by_id(iid);
            //Возвращаем сущность
            return conception;
        }

        /// <summary>
        /// Метод восстанавливает указанную концепцию
        /// </summary>
        public conception conception_restore(conception Conception)
        {
            return conception_restore(Conception.Id);
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean conception_restore(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("conception_restore");
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
