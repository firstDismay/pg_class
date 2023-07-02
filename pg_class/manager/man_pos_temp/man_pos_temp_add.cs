using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет новый шаблон позиций
        /// </summary>
        public pos_temp pos_temp_add(String iname, Int64 iid_con, Int32 iid_prototype, Boolean inested_limit, String idesc)
        {
            pos_temp pos_temp = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_add");
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

            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["iid_con"].Value = iid_con;
            cmdk.Parameters["iid_prototype"].Value = iid_prototype;
            cmdk.Parameters["inested_limit"].Value = inested_limit;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.ExecuteNonQuery();

            id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
            if (id > 0)
            {
                pos_temp = pos_temp_by_id(id);
            }

            if (pos_temp != null)
            {
                //Генерируем событие изменения концепции
                PosTempChangeEventArgs e = new PosTempChangeEventArgs(pos_temp, eAction.Insert);
                PosTempOnChange(e);
            }
            //Возвращаем сущность
            return pos_temp;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_add");
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
        /// Метод копирует указанный шаблон позиций
        /// </summary>
        public pos_temp pos_temp_copy(Int64 iid_pattern)
        {
            pos_temp pos_temp = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_copy");
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

            cmdk.Parameters["iid_pattern"].Value = iid_pattern;
            cmdk.ExecuteNonQuery();

            id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
            if (id > 0)
            {
                pos_temp = pos_temp_by_id(id);
            }

            if (pos_temp != null)
            {
                //Генерируем событие изменения шаблона позиции
                PosTempChangeEventArgs e = new PosTempChangeEventArgs(pos_temp, eAction.Insert);
                PosTempOnChange(e);
            }
            //Возвращаем сущность
            return pos_temp;
        }

        /// <summary>
        /// Метод копирует указанный шаблон позиций
        /// </summary>
        public pos_temp pos_temp_copy(pos_temp pos_temp_pattern)
        {
            return pos_temp_copy(pos_temp_pattern.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_copy(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_copy");
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