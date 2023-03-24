using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет новую позиций
        /// </summary>
        public position position_add(Int64 id_parent, Int64 id_pos_temp, String iname, String idesc, Int32 isort)
        {
            position position = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_add");
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

            cmdk.Parameters["iid_parent"].Value = id_parent;
            cmdk.Parameters["iid_pos_temp"].Value = id_pos_temp;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["isort"].Value = isort;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                    if (id > 0)
                    {
                        position = position_by_id(id);
                    }
                    if (position != null)
                    {
                        //Генерируем событие изменения позиции
                        PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Insert);
                        PositionOnChange(e);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.position, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Возвращаем сущность
            return position;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_add");
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
        /// Метод копирует выбранную позицию в указанное расположение
        /// </summary>
        public position position_copy(Int64 iid_pattern, Int64 iid_parent, Boolean on_object)
        {
            position position = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_copy");
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
            cmdk.Parameters["iid_parent"].Value = iid_parent;
            cmdk.Parameters["recursivecall"].Value = false;
            cmdk.Parameters["on_object"].Value = on_object;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                    if (id > 0)
                    {
                        position = position_by_id(id);
                    }
                    if (position != null)
                    {
                        //Генерируем событие изменения позиции
                        PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Insert);
                        PositionOnChange(e);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.position, error, desc_error, eAction.Copy, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Возвращаем сущность
            return position;
        }

        /// <summary>
        /// Метод копирует выбранную позицию в указанное расположение
        /// </summary>
        public position position_copy(position Pos_pattern, position Pos_parent, Boolean on_object)
        {
            return position_copy(Pos_pattern.Id, Pos_parent.Id, on_object);
        }

        /// <summary>
        /// Метод копирует выбранную позицию в текущее расположение
        /// </summary>
        public position position_copy(position Pos_pattern, Boolean on_object)
        {
            return position_copy(Pos_pattern.Id, Pos_pattern.Id_parent, on_object);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_copy(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_copy");
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