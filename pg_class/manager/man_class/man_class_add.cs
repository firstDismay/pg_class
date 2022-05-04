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
        /// Метод добавляет новое представление класса
        /// </summary>
        public vclass class_add( Int64 iid_group, Int64 iid_parent, String iname, String idesc, Boolean ion,
            Boolean ion_extensible, Boolean ion_abstraction, Int32 iid_unit, Int32 iid_unit_conversion_rule, Int64 ibarcode_manufacturer)
        {
            vclass vclass = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
            cmdk = CommandByKey("class_add");

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

            cmdk.Parameters["iid_group"].Value = iid_group;
            cmdk.Parameters["iid_parent"].Value = iid_parent;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["ion"].Value = ion;
            cmdk.Parameters["ion_extensible"].Value = ion_extensible;
            cmdk.Parameters["ion_abstraction"].Value = ion_abstraction;
            cmdk.Parameters["iid_unit"].Value = iid_unit;
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.Parameters["ibarcode_manufacturer"].Value = ibarcode_manufacturer;
            
            //Выполнение основной команды в контексте транзакции
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
                        vclass = class_act_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.vclass, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (vclass != null)
            {
                //Генерируем событие изменения представления класса
                ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Insert);
                ClassOnChange(e);
            }
            //Возвращаем Объект
            return vclass;
        }

        /// <summary>
        /// Метод добавляет новое представление класса
        /// </summary>
        public vclass class_add(vclass class_parent, String iname, String idesc, Boolean ion,
            Boolean ion_extensible, Boolean ion_abstraction, Int32 iid_unit, Int32 iid_unit_conversion_rule, Int64 ibarcode_manufacturer,
            Int32 isort)
        {
            return class_add(0, class_parent.Id, iname, idesc, ion,
            ion_extensible, ion_abstraction, iid_unit, iid_unit_conversion_rule, ibarcode_manufacturer);
        }

        /// <summary>
        /// Метод добавляет новое представление класса
        /// </summary>
        public vclass class_add(group group_parent, String iname, String idesc, Boolean ion,
            Boolean ion_extensible, Boolean ion_abstraction, Int32 iid_unit, Int32 iid_unit_conversion_rule, Int64 ibarcode_manufacturer)
        {
            return class_add(group_parent.Id, 0, iname, idesc, ion,
            ion_extensible, ion_abstraction, iid_unit, iid_unit_conversion_rule, ibarcode_manufacturer);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_add");
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
        /// Метод копирует активное представление класса в указанный абстрактный класс
        /// </summary>
        public vclass class_copy_to_class(Int64 iid_pattern, Int64 iid_target, Boolean on_nested)
        {
            vclass vclass = null;
            Int32 error;
            Int64 id = 0;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_copy_to_class");

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

            cmdk.Parameters["iid_pattern"].Value = iid_pattern;
            cmdk.Parameters["iid_target"].Value = iid_target;
            cmdk.Parameters["on_nested"].Value = on_nested;

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
                        vclass = class_act_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.vclass, error, desc_error, eAction.Copy, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (vclass != null)
            {
                //Генерируем событие изменения класса
                ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Copy);
                ClassOnChange(e);
            }
            //Возвращаем Объект
            return vclass;
        }

        /// <summary>
        /// Метод копирует активное представление класса в указанный абстрактный класс
        /// </summary>
        public vclass class_copy_to_class(vclass Class_pattern, vclass Class_target, Boolean on_nested)
        {
            return class_copy_to_class(Class_pattern.Id, Class_target.Id, on_nested);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_copy_to_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_copy_to_class");
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
        /// Метод копирует активное представление базового класса в указанную группу
        /// </summary>
        public vclass class_copy_to_group(Int64 iid_pattern, Int64 iid_target, Boolean on_nested)
        {
            vclass vclass = null;
            Int32 error;
            Int64 id = 0;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_copy_to_group");

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

            cmdk.Parameters["iid_pattern"].Value = iid_pattern;
            cmdk.Parameters["iid_target"].Value = iid_target;
            cmdk.Parameters["on_nested"].Value = on_nested;

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
                        vclass = class_act_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.vclass, error, desc_error, eAction.Copy, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (vclass != null)
            {
                //Генерируем событие изменения класса
                ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Copy);
                ClassOnChange(e);
            }
            //Возвращаем Объект
            return vclass;
        }

        /// <summary>
        /// Метод копирует активное представление базового класса в указанную группу
        /// </summary>
        public vclass class_copy_to_group(vclass Class_pattern, group Group_target, Boolean on_nested)
        {
            return class_copy_to_class(Class_pattern.Id, Group_target.Id, on_nested);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_copy_to_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_copy_to_group");
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
        /// Метод восстанавливает активное представлние вещественного класса объекта и всю цепь наследования до корневого класса
        /// </summary>
        public vclass class_act_restore(Int64  iid_object)
        {
            vclass vclass = null;
            Int32 error;
            Int64 id = 0;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********

            //=======================
            cmdk = CommandByKey("class_act_restore");

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

            cmdk.Parameters["iid_object"].Value = iid_object;
            
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
                        vclass = class_act_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.vclass, error, desc_error, eAction.Restore, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (vclass != null)
            {
                //Генерируем событие изменения класса
                ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Restore);
                ClassOnChange(e);
            }
            //Возвращаем Объект
            return vclass;
        }

        /// <summary>
        /// Метод восстанавливает активное представлние вещественного класса объекта и всю цепь наследования до корневого класса
        /// </summary>
        public vclass class_act_restore(object_general Object)
        {
            return class_act_restore(Object.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_restore(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_restore");
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
