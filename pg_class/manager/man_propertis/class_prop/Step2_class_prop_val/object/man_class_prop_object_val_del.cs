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
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void class_prop_object_val_del(Int64 iid_class_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            class_prop_object_val class_prop_object_val = null;
            
            cmdk = CommandByKey("class_prop_object_val_del");
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
            class_prop_object_val = class_prop_object_val_by_id_prop(iid_class_prop);

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);

            class_prop class_prop = class_prop_by_id(iid_class_prop);
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_class_prop, eEntity.class_prop_object_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления значения свойства класса
            if (class_prop != null)
            {
                ClassPropChangeEventArgs e = new ClassPropChangeEventArgs(class_prop, eAction.Update);
                ClassPropOnChange(e);
            }

            if (class_prop_object_val != null)
            {
                //Генерируем событие изменения значения объектного свойства класса
                ClassPropObjectValChangeEventArgs e2 = new ClassPropObjectValChangeEventArgs(class_prop_object_val, eAction.Delete);
                ClassPropObjectValOnChange(e2);
            }
        }


        /// <summary>
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void class_prop_object_val_del(class_prop class_prop)
        {
            if (class_prop != null)
            {
                if (class_prop.StorageType == eStorageType.Active)
                {
                    class_prop_object_val_del(class_prop.Id);
                }
                else
                {
                    throw new PgDataException(eEntity.vclass, eAction.Delete, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод удаления значения объектного свойства класса не применим к историческому представлению класса!");
                }
            }
        }

        /// <summary>
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void class_prop_object_val_del(class_prop_object_val ClassPropObjectVal)
        {
            if (ClassPropObjectVal != null)
            {
                if (ClassPropObjectVal.StorageType == eStorageType.Active)
                {
                    class_prop_object_val_del(ClassPropObjectVal.Id_class_prop);
                }
                else
                {
                    throw new PgDataException(eEntity.vclass, eAction.Delete, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод удаления значения объектного свойства класса не применим к историческому представлению класса!");
                }
            }
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_object_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_object_val_del");
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