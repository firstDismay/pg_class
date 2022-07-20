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
        /// Метод определяет формат имен объектов классов
        /// </summary>
        protected vclass class_act_name_format_set(Int64 iid_class, String iname_format)
        {
            vclass vclass = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("class_act_name_format_set");
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

            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.Parameters["iname_format"].Value = iname_format;
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    vclass = class_act_by_id(iid_class);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_class, eEntity.vclass, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения представления класса
            ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Update);
            ClassOnChange(e);
            //Возвращаем Объект
            return vclass;
        }

        /// <summary>
        /// Метод определяет формат имен объектов классов
        /// </summary>
        public vclass class_act_name_format_set(vclass Vclass, String iname_format)
        {
            vclass Result = null;

            if (Vclass != null)
            {
                if (Vclass.StorageType == eStorageType.Active)
                {
                    Result = class_act_name_format_set(Vclass.Id, iname_format);
                }
                else
                {
                    throw new PgDataException(eEntity.vclass, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод обновления данных класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }

        /// <summary>
        /// Метод определяет формат имен объектов классов
        /// </summary>
        public vclass class_act_name_format_set(class_name_format_builder Class_name_format_builder)
        {
            vclass Result = null;

            if (Class_name_format_builder.Сlass != null)
            {
                if (Class_name_format_builder.Сlass.StorageType == eStorageType.Active)
                {
                    Result = class_act_name_format_set(Class_name_format_builder.Сlass.Id, Class_name_format_builder.Format_get());
                }
                else
                {
                    throw new PgDataException(eEntity.vclass, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод обновления данных класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_name_format_set(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_act_name_format_set");
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
        /// Метод устанавливает значение флага отображения количества в имени объектов
        /// </summary>
        protected vclass class_quantity_show_set(Int64 iid_class, Boolean iquantity_show)
        {
            vclass vclass = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_quantity_show_set");
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

            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.Parameters["iquantity_show"].Value = iquantity_show;
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    vclass = class_act_by_id(iid_class);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_class, eEntity.vclass, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения представления класса
            ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Update);
            ClassOnChange(e);
            //Возвращаем Объект
            return vclass;
        }

        /// <summary>
        /// Метод устанавливает значение флага отображения количества в имени объектов
        /// </summary>
        public vclass class_quantity_show_set(vclass Vclass, Boolean iquantity_show)
        {
            vclass Result = null;

            if (Vclass != null)
            {
                if (Vclass.StorageType == eStorageType.Active)
                {
                    Result = class_quantity_show_set(Vclass.Id, iquantity_show);
                }
                else
                {
                    throw new PgDataException(eEntity.vclass, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод обновления данных класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }

        /// <summary>
        /// Метод устанавливает значение флага отображения количества в имени объектов
        /// </summary>
        public vclass class_quantity_show_set(class_name_format_builder Class_name_format_builder)
        {
            vclass Result = null;

            if (Class_name_format_builder.Сlass != null)
            {
                if (Class_name_format_builder.Сlass.StorageType == eStorageType.Active)
                {
                    Result = class_quantity_show_set(Class_name_format_builder.Сlass.Id, Class_name_format_builder.Quantity_show);
                }
                else
                {
                    throw new PgDataException(eEntity.vclass, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод обновления данных класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_quantity_show_set(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_quantity_show_set");
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