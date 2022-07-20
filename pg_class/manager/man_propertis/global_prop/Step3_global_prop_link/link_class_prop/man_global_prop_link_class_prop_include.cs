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
        /// Метод добавляет свойство класса к глобальному свойству
        /// </summary>
        public global_prop_link_class_prop global_prop_link_class_prop_include( Int64 iid_global_prop, Int64 iid_class_prop_definition)
        {
            global_prop_link_class_prop global_prop_link_class_prop = null;
            class_prop prop_link;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("global_prop_link_class_prop_include");

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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Parameters["iid_class_prop_definition"].Value = iid_class_prop_definition;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //=======================
            switch (error)
            {
                case 0:
                    global_prop_link_class_prop = global_prop_link_class_prop_by_id(iid_global_prop, iid_class_prop_definition);
                    prop_link = class_prop_by_id(iid_class_prop_definition);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_global_prop, iid_class_prop_definition, eEntity.global_prop_link_class_prop, error, desc_error, eAction.Include, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (global_prop_link_class_prop != null)
            {
                //Генерируем событие изменения данных привязки глобального свойства
                GlobalPropLinkClassPropChangeEventArgs e = new GlobalPropLinkClassPropChangeEventArgs(global_prop_link_class_prop, eAction.Include);
                GlobalPropLinkClassPropOnChange(e);
                //Возвращаем Объект
            }

            if (prop_link != null)
            {
                //Генерируем событие изменения свойства класса
                ClassPropChangeEventArgs e2 = new ClassPropChangeEventArgs(prop_link, eAction.Update);
                ClassPropOnChange(e2);
            }
            //Возвращаем Объект
            return global_prop_link_class_prop;
        }

        /// <summary>
        /// Метод добавляет свойство класса к глобальному свойству
        /// </summary>
        public global_prop_link_class_prop global_prop_link_class_prop_include(global_prop GlobalProp, class_prop ClassProp)
        {
            global_prop_link_class_prop Result = null;
            if ((GlobalProp != null) & (ClassProp !=null))
            {
                Result = global_prop_link_class_prop_include(GlobalProp.Id, ClassProp.Id);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_link_class_prop_include(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_link_class_prop_include");
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
