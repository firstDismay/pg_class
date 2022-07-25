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
        /// Метод удаляет свойство класса и все наследующие свойства
        /// </summary>
        public void class_prop_del_cascade(Int64 iid)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("class_prop_del_cascade");
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
            class_prop class_prop = class_prop_by_id(iid);

            cmdk.Parameters["iid"].Value = iid;
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid, eEntity.class_prop, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления свойства класса
            if (class_prop != null)
            {
                ClassPropChangeEventArgs e = new ClassPropChangeEventArgs(class_prop, eAction.Delete);
                ClassPropOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет свойство класса и все наследующие свойства
        /// </summary>
        public void class_prop_del_cascade(class_prop Class_Prop)
        {
            if (Class_Prop != null)
            {
                if (Class_Prop.StorageType == eStorageType.Active)
                {
                    class_prop_del_cascade(Class_Prop.Id);
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop, eAction.Delete, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод удаления свойства класса не применим к историческому представлению класса!");
                }
            }
            
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_del_cascade(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_del_cascade");
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