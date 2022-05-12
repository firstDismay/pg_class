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
        /// Добавить новое перечисление для свойств
        /// </summary>
        public prop_enum prop_enum_add(Int64 iid_conception, String iname, String idesc, Int32 iid_prop_enum_use_area, Int32 iid_data_type)
        {
            prop_enum Prop_enum = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
            cmdk = CommandByKey("prop_enum_add");

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
            //=======================

            cmdk.Parameters["iid_conception"].Value = iid_conception;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["iid_prop_enum_use_area"].Value = iid_prop_enum_use_area;
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================     
            switch (error)
            {
                case 0:
                    id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                    if (id > 0)
                    {
                        Prop_enum = prop_enum_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.prop_enum, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            PropEnumChangeEventArgs e = new PropEnumChangeEventArgs(Prop_enum, eAction.Insert);
            PropEnumOnChange(e);
            
            //Возвращаем Сущность
            return Prop_enum;
        }

        /// <summary>
        /// Добавить новое перечисление для свойств
        /// </summary>
        public prop_enum prop_enum_add(Int64 iid_conception, String iname, String idesc, prop_enum_use_area iprop_enum_use_area, Int32 iid_data_type)
        {
            return prop_enum_add(iid_conception, iname, idesc, iprop_enum_use_area.Id, iid_data_type);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_add");
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
        //*********************************************************************************************

        /// <summary>
        /// Копировать перечисление в указанную концепцию
        /// </summary>
        public prop_enum prop_enum_copy_to( Int64 iid_prop_enum , Int64 iid_conception)
        {
            prop_enum Prop_enum = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
            cmdk = CommandByKey("prop_enum_copy_to");

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
            //=======================

            cmdk.Parameters["iid_prop_enum"].Value = iid_prop_enum;
            cmdk.Parameters["iid_conception"].Value = iid_conception;


            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================     
            switch (error)
            {
                case 0:
                    id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                    if (id > 0)
                    {
                        Prop_enum = prop_enum_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.prop_enum, error, desc_error, eAction.Copy, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            PropEnumChangeEventArgs e = new PropEnumChangeEventArgs(Prop_enum, eAction.Copy);
            PropEnumOnChange(e);

            //Возвращаем Сущность
            return Prop_enum;
        }

        /// <summary>
        /// Копировать перечисление в указанную концепцию
        /// </summary>
        public prop_enum prop_enum_copy_to(prop_enum Prop_enum, conception Conception)
        {
            return prop_enum_copy_to(Prop_enum.Id_prop_enum, Conception.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_copy_to(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_copy_to");
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
