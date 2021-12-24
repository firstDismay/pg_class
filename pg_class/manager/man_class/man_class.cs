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
        #region МЕТОДЫ КЛАССА: ПРЕДСТАВЛЕНИЯ КЛАССА

        #region ДОБАВИТЬ
        
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
        #endregion

        #region ИЗМЕНИТЬ
        /// <summary>
        /// Метод изменяет указанное представление класса
        /// </summary>
        public vclass class_upd(Int64 iid, String iname, String idesc, Boolean ion, Boolean ion_extensible, 
                            Boolean ion_abstraction, Int32 iid_unit, Int32 iid_unit_conversion_rule, Int64 ibarcode_manufacturer)

        {
            vclass vclass = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_upd");

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

            cmdk.Parameters["iid"].Value = iid;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["ion"].Value = ion;
            cmdk.Parameters["ion_extensible"].Value = ion_extensible;
            cmdk.Parameters["ion_abstraction"].Value = ion_abstraction;
            cmdk.Parameters["iid_unit"].Value = iid_unit;
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.Parameters["ibarcode_manufacturer"].Value = ibarcode_manufacturer;
            //=======================

            //Начало транзакции
            cmdk.ExecuteNonQuery();
           
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                        vclass = class_act_by_id(iid);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid, eEntity.vclass, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (vclass != null)
            {
                //Генерируем событие изменения представления класса
                ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Update);
                ClassOnChange(e);
            }
            //Возвращаем Объект
            return vclass;
        }
        
        /// <summary>
        /// Метод изменяет указанный абстрактный базовый класс
        /// </summary>
        public vclass class_upd(vclass Vclass)
        {
            vclass Result = null;

            if (Vclass != null)
            {
                if (Vclass.StorageType == eStorageType.Active)
                {
                    Result = class_upd(Vclass.Id, Vclass.Name, Vclass.Desc, Vclass.On, Vclass.On_extensible,
                                    Vclass.On_abstraction, Vclass.Id_unit, Vclass.Id_unit_conversion_rule, Vclass.Barcode_manufacturer);
                }
                else
                {
                    throw new PgDataException(eEntity.vclass, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules, 
                        "Метод обновления данных класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_upd");
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
        /// Метод переносит представление базового абстрактного класса в новую группу
        /// </summary>
        public vclass class_move_to_group(Int64 iid_class, Int64 iid_group)
        {
            vclass vclass = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_move_to_group");

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

            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.Parameters["iid_group"].Value = iid_group;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
              
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            
            //=======================
            switch (error)
            {
                case 0:
                    vclass = class_act_by_id(iid_class);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_class, eEntity.vclass, error, desc_error, eAction.Move, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (vclass != null)
            {
                //Генерируем событие изменения позиции
                ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Move);
                ClassOnChange(e);
            }
            //Возвращаем Объект
            return vclass;
        }

        /// <summary>
        /// Метод переносит представление базового абстрактного класса в новую группу
        /// </summary>
        public vclass class_move_to_group(vclass Class_pattern, group Group_target)
        {
            vclass Result = null;
            if (Class_pattern != null & Group_target != null)
            {
                if (Class_pattern.StorageType == eStorageType.Active)
                {
                    Result = class_move_to_group(Class_pattern.Id, Group_target.Id);
                }
                else
                {
                    throw new PgDataException(eEntity.vclass, eAction.Move, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод перемещения базового класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_move_to_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_move_to_group");
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
        /// Метод переносит активное представление класса в указанный абстрактный класс
        /// </summary>
        public vclass class_move_to_class(Int64 iid_pattern, Int64 iid_target)
        {
            vclass vclass = null;
            Int32 error;
            Int64 id = 0;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_move_to_class");

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

            //Запрос удаляемой сущности
            vclass vclass_del = class_act_by_id(iid_pattern);
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
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.vclass, error, desc_error, eAction.Move, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            if (vclass != null)
            {
                //Генерируем событие изменения класса
                ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Move);
                ClassOnChange(e);
            }

            //Генерируем событие удаления класса паттерна
            if (vclass_del != null)
            {
                ClassChangeEventArgs e2 = new ClassChangeEventArgs(vclass_del, eAction.Delete);
                ClassOnChange(e2);
            }
            //Возвращаем Объект
            return vclass;
        }

        /// <summary>
        /// Метод переносит активное представление класса в указанный абстрактный класс
        /// </summary>
        public vclass class_move_to_class(vclass Class_pattern, vclass Class_target)
        {
            return class_move_to_class(Class_pattern.Id, Class_target.Id);
        }
       
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_move_to_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_move_to_class");
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
        /// Метод откатывает представление класса к указанному снимку
        /// </summary>
        public vclass class_rollback(Int64 iid_snapshot, System.DateTime timestamp_snapshot)
        {
            vclass vclass = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_rollback");

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

            cmdk.Parameters["iid_snapshot"].Value = iid_snapshot;
            cmdk.Parameters["timestamp_snapshot"].Value = timestamp_snapshot;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    vclass = class_act_by_id(iid_snapshot);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_snapshot, eEntity.vclass, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (vclass != null)
            {
                //Генерируем событие изменения позиции
                ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Move);
                ClassOnChange(e);
            }
            //Возвращаем Объект
            return vclass;
        }

        /// <summary>
        /// Метод откатывает представление класса к указанному снимку
        /// </summary>
        public vclass class_rollback(vclass Vclass)
        {
            vclass Result = null;
            if (Vclass != null)
            {
                if (Vclass.StorageType == eStorageType.Active)
                {
                    Result = class_rollback(Vclass.Id, Vclass.Timestamp);
                }
                else
                {
                    throw new PgDataException(eEntity.vclass, eAction.RollBack, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод удаления данных класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_rollback(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_rollback");
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
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет представление класса и все наследующие классы
        /// </summary>
        public void class_del(Int64 iid)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_del");

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

            cmdk.Parameters["iid"].Value = iid;

            //Запрос удаляемой сущности
            vclass vclass = class_act_by_id(iid);
            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid, eEntity.vclass, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления представления класса
            if (vclass != null)
            {
                ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Delete);
                ClassOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет представление класса и все наследующие классы
        /// </summary>
        public void class_del(vclass Vclass)
        {

            if (Vclass != null)
            {
                if (Vclass.StorageType == eStorageType.Active)
                {
                    class_del(Vclass.Id);
                }
                else
                {
                    throw new PgDataException(eEntity.vclass, eAction.Delete, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод удаления класса не применим к историческому представлению класса!");
                }
            }
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_del");
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
        #endregion

        #region ВЫБРАТЬ

        //*********************************************************************************************
        /// <summary>
        /// Выбор активного представления класса по идентификатору
        /// </summary>
        public vclass class_act_by_id(Int64 id)
        {
            vclass vclass = null;

            DataTable tbl_vclass = TableByName("vclass"); //TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_by_id");

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

            cmdk.Parameters["iid"].Value = id;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            
            if (tbl_vclass.Rows.Count > 0)
            {
                vclass = new vclass(tbl_vclass.Rows[0]);
            }
            return vclass;
        }

        /// <summary>
        /// Выбор активного представления класса по объекту vclass
        /// </summary>
        public vclass class_act_by_class(vclass Class)
        {

            vclass Result = null;
            switch (Class.StorageType)
            {
                case eStorageType.Active:
                    Result = class_act_by_id(Class.Id);
                    break;
                case eStorageType.History:
                    throw new PgDataException(505, "Исторический класс не допустим методе class_act_by_class_path!");
            }
            return Result;
        }

        /// <summary>
        /// Выбор активного представления класса по объекту vclass_path
        /// </summary>
        public vclass class_act_by_class_path(class_path Class_path)
        {

            vclass Result = null;
            switch (Class_path.StorageType)
            {
                case eStorageType.Active:
                    Result = class_act_by_id(Class_path.Id);
                    break;
                case eStorageType.History:
                    throw new PgDataException(505, "Исторический класс class_path не допустим методе class_act_by_class_path!");
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_by_id");
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
        /// Лист представлений активных классов по идентификатору родительского класса
        /// </summary>
        public List<vclass> class_act_by_id_parent(Int64 id_parent)
        {
            List<vclass> vclass_list = new List<vclass>();

            
            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_by_id_parent");

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

            cmdk.Parameters["iid_parent"].Value = id_parent;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов по идентификатору родительского класса
        /// </summary>
        public List<vclass> class_act_by_id_parent(vclass Vclass_parent)
        {
            List<vclass> Result = null;
            switch (Vclass_parent.StorageType)
            {
                case eStorageType.Active:
                    Result = class_act_by_id_parent(Vclass_parent.Id);
                    break;
                case eStorageType.History:
                    throw new PgDataException(505, "Тип представления класса не соотвествует сигнатуре функции, требуется активное представление класса");
            }
            return Result;
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Экспорт представлений объектов по id объекта носителя
        /// </summary>
        public Byte[] class_act_by_id_parent(Int64 id_parent, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.class_act_by_id_parent({0})", id_parent);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT c.* FROM ONLY bpd.class c JOIN bpd.class_act_by_id_parent({0}) f ON f.id = c.id", id_parent);
                    break;
            }
            Result = export_to_excel(command_export);
            return Result;
        }

        /// <summary>
        /// Команда экспорта представлений объектов по id объекта носителя
        /// </summary>
        public command_export class_act_by_id_parent_command_export(Int64 id_parent, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String command_export = "";
            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.class_act_by_id_parent({0})", id_parent);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT c.* FROM ONLY bpd.class c JOIN bpd.class_act_by_id_parent({0}) f ON f.id = c.id", id_parent);
                    break;
            }
            
            String desc = String.Format(@"Экпорт: Активные классы абстрактного класса: {0} | Режим: {1}", class_act_by_id(id_parent).Name, manager.ExportMode(ExportFormat));
            Result = export_to_excel_get_command(command_export, desc);
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_parent(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_by_id_parent");
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
        /// Лист представлений активных классов по идентификатору глобального свойства
        /// </summary>
        public List<vclass> class_act_by_id_global_prop(Int64 iid_global_prop)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_by_id_global_prop");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов по идентификатору родительского класса
        /// </summary>
        public List<vclass> class_act_by_id_global_prop(global_prop Global_prop)
        {
            return class_act_by_id_global_prop(Global_prop.Id); 
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Экспорт представлений объектов по id объекта носителя
        /// </summary>
        public Byte[] class_act_by_id_global_prop(Int64 iid_global_prop, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.class_act_by_id_global_prop({0})", iid_global_prop);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT c.* FROM ONLY bpd.class c JOIN bpd.class_act_by_id_global_prop({0}) f ON f.id = c.id", iid_global_prop);
                    break;
            }
            Result = export_to_excel(command_export);
            return Result;
        }

        /// <summary>
        /// Команда экспорта представлений объектов по id объекта носителя
        /// </summary>
        public command_export class_act_by_id_global_prop_command_export(Int64 iid_global_prop, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String command_export = "";
            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.class_act_by_id_global_prop({0})", iid_global_prop);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT c.* FROM ONLY bpd.class c JOIN bpd.class_act_by_id_global_prop({0}) f ON f.id = c.id", iid_global_prop);
                    break;
            }

            String desc = String.Format(@"Экпорт: Активные классы глобального свойства: {0} | Режим: {1}", global_prop_by_id(iid_global_prop).Name, manager.ExportMode(ExportFormat));
            Result = export_to_excel_get_command(command_export, desc);
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_by_id_global_prop");
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
        /// Лист представлений активных вещественных классов по идентификатору родительского класса
        /// </summary>
        public List<vclass> class_act_real_by_id_parent(Int64 id_parent)
        {
            List<vclass> vclass_list = new List<vclass>();

            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_real_by_id_parent");

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

            cmdk.Parameters["iid_parent"].Value = id_parent;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных вещественных классов по идентификатору родительского класса
        /// </summary>
        public List<vclass> class_act_real_by_id_parent(vclass Vclass_parent)
        {
            List<vclass> Result = null;
            switch (Vclass_parent.StorageType)
            {
                case eStorageType.Active:
                    Result = class_act_real_by_id_parent(Vclass_parent.Id);
                    break;
                case eStorageType.History:
                    throw new PgDataException(505, "Тип представления класса не соотвествует сигнатуре функции, требуется активное представление класса");
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_real_by_id_parent(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_real_by_id_parent");
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

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Экспорт представлений объектов по id объекта носителя
        /// </summary>
        public Byte[] class_act_real_by_id_parent(Int64 id_parent, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.class_act_real_by_id_parent({0})", id_parent);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT c.* FROM ONLY bpd.class c JOIN bpd.class_act_real_by_id_parent({0}) f ON f.id = c.id", id_parent);
                    break;
                case eBaseExportFormat.ReportEntity:
                case eBaseExportFormat.ReportEntityWithProp:
                    Result = export_class_act_real_with_prop_by_id_parent_to_excel(id_parent);
                    break;
            }
            Result = export_to_excel(command_export);
            return Result;
        }

        /// <summary>
        /// Команда экспорта представлений объектов по id объекта носителя
        /// </summary>
        public command_export class_act_real_by_id_parent_command_export(Int64 id_parent, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String command_export = "";
            String desc = "";
            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.class_act_real_by_id_parent({0})", id_parent);
                    desc = String.Format(@"Экпорт: Активные вещественные классы абстрактного класса: {0} | Режим: {1}", class_act_by_id(id_parent).Name, manager.ExportMode(ExportFormat));
                    Result = export_to_excel_get_command(command_export, desc);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT c.* FROM ONLY bpd.class c JOIN bpd.class_act_real_by_id_parent({0}) f ON f.id = c.id", id_parent);
                    desc = String.Format(@"Экпорт: Активные вещественные классы абстрактного класса: {0} | Режим: {1}", class_act_by_id(id_parent).Name, manager.ExportMode(ExportFormat));
                    Result = export_to_excel_get_command(command_export, desc);
                    break;
                case eBaseExportFormat.ReportEntity:
                case eBaseExportFormat.ReportEntityWithProp:
                    vclass cp = class_act_by_id(id_parent);
                    if (cp != null)
                    {
                        Result = export_class_act_real_with_prop_by_id_parent_to_excel_get_command(cp);
                    }
                    break;
            }
            return Result;
        }



        //*********************************************************************************************
        /// <summary>
        /// Лист представлений активных базовых классов по идентификатору группы
        /// </summary>
        public List<vclass> class_act_by_id_group(Int64 id_group)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_by_id_group");

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

            cmdk.Parameters["iid_group"].Value = id_group;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных базовых классов по идентификатору группы
        /// </summary>
        public List<vclass> class_act_by_id_group(group Group)
        {
            return class_act_by_id_group(Group.Id);
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Экспорт представлений активных базовых классов по id группы
        /// </summary>
        public Byte[] class_act_by_id_group(Int64 id_group, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.class_act_by_id_group({0})", id_group);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT c.* FROM ONLY bpd.class c JOIN bpd.class_act_by_id_group({0}) f ON f.id = c.id", id_group);
                    break;
            }
            Result = export_to_excel(command_export);
            return Result;
        }

        /// <summary>
        /// Команда экспорта представлений активных базовых классов по id группы
        /// </summary>
        public command_export class_act_by_id_group_command_export(Int64 id_group, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String command_export = "";
            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.class_act_by_id_group({0})", id_group);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT c.* FROM ONLY bpd.class c JOIN bpd.class_act_by_id_group({0}) f ON f.id = c.id", id_group);
                    break;
            }
           
            String desc = String.Format(@"Экпорт: Активные базовые классы группы: {0} | Режим: {1}", group_by_id(id_group).Name, manager.ExportMode(ExportFormat));
            Result = export_to_excel_get_command(command_export, desc);
            return Result;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_by_id_group");
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
        /// Лист представлений активных вещественных классов по идентификатору группы
        /// </summary>
        public List<vclass> class_act_real_by_id_group(Int64 id_group)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_real_by_id_group");

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

            cmdk.Parameters["iid_group"].Value = id_group;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных вещественных классов по идентификатору группы
        /// </summary>
        public List<vclass> class_act_real_by_id_group(group Group)
        {
            return class_act_real_by_id_group(Group.Id);
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Экспорт представлений объектов по id объекта носителя
        /// </summary>
        public Byte[] class_act_real_by_id_group(Int64 id_group, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.class_act_real_by_id_group({0})", id_group);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT c.* FROM ONLY bpd.class c JOIN bpd.class_act_real_by_id_group({0}) f ON f.id = c.id", id_group);
                    break;
            }
            Result = export_to_excel(command_export);
            return Result;
        }

        /// <summary>
        /// Команда экспорта представлений объектов по id объекта носителя
        /// </summary>
        public command_export class_act_real_by_id_group_command_export(Int64 id_group, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String command_export = "";
            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.class_act_real_by_id_group({0})", id_group);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT c.* FROM ONLY bpd.class c JOIN bpd.class_act_real_by_id_group({0}) f ON f.id = c.id", id_group);
                    break;
            }
            
            String desc = String.Format(@"Экпорт: Активные вещественные классы группы: {0} | Режим: {1}", group_by_id(id_group).Name, manager.ExportMode(ExportFormat));
            Result = export_to_excel_get_command(command_export, desc);
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_real_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_real_by_id_group");
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
        /// Лист разрешенных активных представлений вещественных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_real_allowed_by_id_group(Int64 iid_group, Int64 iid_position)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_real_allowed_by_id_group");

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
            cmdk.Parameters["iid_position"].Value = iid_position;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист разрешенных активных представлений вещественных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_real_allowed_by_id_group(group Group, position Position)
        {
            return class_act_real_allowed_by_id_group(Group.Id, Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_real_allowed_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_real_allowed_by_id_group");
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
        /// Лист разрешенных представлений базовых абстрактных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_base_allowed_by_id_group(Int64 iid_group, Int64 iid_position)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_base_allowed_by_id_group");

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
            cmdk.Parameters["iid_position"].Value = iid_position;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист разрешенных представлений базовых абстрактных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_base_allowed_by_id_group(group Group, position Position)
        {
            return class_act_base_allowed_by_id_group(Group.Id, Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_base_allowed_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_base_allowed_by_id_group");
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
        /// Класс носитель свойства, указанного по идентификатору
        /// </summary>
        public vclass class_carrier_by_id_class_prop(Int64 iid_class_prop, DateTime itimestamp_class, eStorageType storagetype)
        {
            vclass vclass = null;

            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_carrier_by_id_class_prop");

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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;
            cmdk.Parameters["storagetype"].Value = storagetype.ToString("G");

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_vclass.Rows.Count > 0)
            {
                vclass = new vclass(tbl_vclass.Rows[0]);
            }
            return vclass;
        }

        /// <summary>
        /// Класс носитель свойства, указанного по идентификатору
        /// </summary>
        public vclass class_carrier_by_id_class_prop(class_prop ClassProp)
        {
            return class_carrier_by_id_class_prop(ClassProp.Id, ClassProp.Timestamp_class, ClassProp.StorageType);
        }

        /// <summary>
        /// Класс носитель свойства, указанного по идентификатору
        /// </summary>
        public vclass class_carrier_by_id_class_prop(object_prop ObjectProp)
        {
            return class_carrier_by_id_class_prop(ObjectProp.Id_class_prop, ObjectProp.Timestamp_class, eStorageType.History);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_carrier_by_id_class_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_carrier_by_id_class_prop");
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
        /// Лист потерянных активных классов концепции
        /// </summary>
        public List<vclass> class_act_lost_info(Int64 iid_conception)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_lost_info");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист потерянных активных классов концепции
        /// </summary>
        public List<vclass> class_act_lost_info(conception Conception)
        {
            return class_act_lost_info(Conception.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_lost_info(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_lost_info");
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
        /// Лист представлений активных классов по идентификатору правила пересчета
        /// </summary>
        public List<vclass> class_act_by_id_unit_conversion_rule(Int32 iid_unit_conversion_rule)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_by_id_unit_conversion_rule");

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

            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов по идентификатору правила пересчета
        /// </summary>
        public List<vclass> class_act_by_id_unit_conversion_rule(unit_conversion_rule Unit_conversion_rule)
        {
            return class_act_by_id_unit_conversion_rule(Unit_conversion_rule.Id);
        }

        /// <summary>
        /// Лист представлений активных классов по идентификатору правила пересчета
        /// </summary>
        public List<vclass> class_act_by_id_unit_conversion_rule(class_unit_conversion_rule Unit_conversion_rule)
        {
            return class_act_by_id_unit_conversion_rule(Unit_conversion_rule.Id_unit_conversion_rule);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_unit_conversion_rule(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_by_id_unit_conversion_rule");
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
        /// Лист представлений активных классов по идентификатору перечисления
        /// </summary>
        public List<vclass> class_act_by_id_prop_enum(Int64 iid_prop_enum)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_by_id_prop_enum");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов по идентификатору перечисления
        /// </summary>
        public List<vclass> class_act_by_id_prop_enum(prop_enum Prop_enum)
        {
            return class_act_by_id_prop_enum(Prop_enum.Id_prop_enum);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_prop_enum(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_by_id_prop_enum");
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
        /// Лист представлений активных классов по идентификатору элемента перечисления
        /// </summary>
        public List<vclass> class_act_by_id_prop_enum_val(Int64 iid_prop_enum_val)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_by_id_prop_enum_val");

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

            cmdk.Parameters["iid_prop_enum_val"].Value = iid_prop_enum_val;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов по идентификатору элемента перечисления
        /// </summary>
        public List<vclass> class_act_by_id_prop_enum_val(prop_enum_val Prop_enum_val)
        {
            return class_act_by_id_prop_enum_val(Prop_enum_val.Id_prop_enum_val);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_prop_enum_val(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_by_id_prop_enum_val");
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
        /// Лист представлений активных классов по идентификатору типа данных свойств концепции
        /// </summary>
        public List<vclass> class_act_by_id_prop_data_type(Int64 iid_conception, Int64 iid_prop_data_type)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_by_id_prop_data_type");

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
            cmdk.Parameters["iid_prop_data_type"].Value = iid_prop_data_type;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов по идентификатору типа данных свойств концепции
        /// </summary>
        public List<vclass> class_act_by_id_prop_data_type(con_prop_data_type Con_prop_data_type)
        {
            return class_act_by_id_prop_data_type(Con_prop_data_type.Id_conception, Con_prop_data_type.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_prop_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_by_id_prop_data_type");
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
        #endregion

        #region ВЫБРАТЬ EXT
        //*********************************************************************************************
        /// <summary>
        /// Выбор активного представления класса с признаком готовности к созданию объектов по идентификатору
        /// class_act_ready_by_id
        /// </summary>
        public vclass class_act_ext_by_id(Int64 iid)
        {
            vclass vclass = null;

            DataTable tbl_vclass = TableByName("vclass_ext");  //new DataTable("vclass_ext")
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_ext_by_id");

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

            cmdk.Parameters["iid"].Value = iid;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_vclass.Rows.Count > 0)
            {
                vclass = new vclass(tbl_vclass.Rows[0]);
            }
            return vclass;
        }

        /// <summary>
        /// Выбор активного представления класса с признаком готовности к созданию объектов по объекту vclass_path
        /// </summary>
        public vclass class_act_ext_by_class_path(class_path Class_path)
        {

            vclass Result = null;
            switch (Class_path.StorageType)
            {
                case eStorageType.Active:
                    Result = class_act_ext_by_id(Class_path.Id);
                    break;
                case eStorageType.History:
                    throw new PgDataException(505, "Исторический класс class_path не допустим методе class_act_by_class_path!");
            }
            return Result;
        }

        /// <summary>
        /// Выбор активного представления класса с признаком готовности к созданию объектов по объекту vclass
        /// class_act_ready_by_id
        /// </summary>
        public vclass class_act_ext_by_class(vclass Class)
        {

            vclass Result = null;
            switch (Class.StorageType)
            {
                case eStorageType.Active:
                    Result = class_act_ext_by_id(Class.Id);
                    break;
                case eStorageType.History:
                    throw new PgDataException(505, "Исторический класс не допустим методе class_act_ext_by_class_path!");
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_ext_by_id");
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
        /// Лист представлений активных классов  с признаком готовности к созданию объектов по идентификатору родительского класса
        /// </summary>
        public List<vclass> class_act_ext_by_id_parent(Int64 id_parent)
        {
            List<vclass> vclass_list = new List<vclass>();

            DataTable tbl_vclass = new DataTable(); // TableByName("vclass_ext");
            tbl_vclass.TableName = "vclass_ext";
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_ext_by_id_parent");

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

            cmdk.Parameters["iid_parent"].Value = id_parent;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов  с признаком готовности к созданию объектов по идентификатору родительского класса
        /// </summary>
        public List<vclass> class_act_ext_by_id_parent(vclass Vclass_parent)
        {
            List<vclass> Result = null;
            switch (Vclass_parent.StorageType)
            {
                case eStorageType.Active:
                    Result = class_act_ext_by_id_parent(Vclass_parent.Id);
                    break;
                case eStorageType.History:
                    throw new PgDataException(505, "Тип представления класса не соотвествует сигнатуре функции, требуется активное представление класса");
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_by_id_parent(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_ext_by_id_parent");
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
        /// Лист представлений активных классов  с признаком готовности к созданию объектов по идентификатору глобального свойства
        /// </summary>
        public List<vclass> class_act_ext_by_id_global_prop(Int64 iid_global_prop)
        {
            List<vclass> vclass_list = new List<vclass>();

            DataTable tbl_vclass = TableByName("vclass_ext");
            //tbl_vclass.TableName = "vclass_ext";
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_ext_by_id_global_prop");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов  с признаком готовности к созданию объектов по идентификатору глобального свойства
        /// </summary>
        public List<vclass> class_act_ext_by_id_global_prop(global_prop Global_prop)
        {
            return class_act_ext_by_id_global_prop(Global_prop.Id); ;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_by_id_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_ext_by_id_global_prop");
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
        /// Лист представлений активных классов  с признаком готовности к созданию объектов по идентификатору родительского класса
        /// </summary>
        public List<vclass> class_act_ext_by_id_group(Int64 iid_group)
        {
            List<vclass> vclass_list = new List<vclass>();

            DataTable tbl_vclass = new DataTable(); // TableByName("vclass_ext");
            tbl_vclass.TableName = "vclass_ext";
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_ext_by_id_group");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов  с признаком готовности к созданию объектов по идентификатору родительского класса
        /// </summary>
        public List<vclass> class_act_ext_by_id_group(group Group)
        {
            return class_act_ext_by_id_group(Group.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_ext_by_id_group");
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
        /// Лист расширенных представлений активных вещественных классов по идентификатору группы
        /// </summary>
        public List<vclass> class_act_real_ext_by_id_group(Int64 id_group)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_real_ext_by_id_group");

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

            cmdk.Parameters["iid_group"].Value = id_group;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист расширенных представлений активных вещественных классов по идентификатору группы
        /// </summary>
        public List<vclass> class_act_real_ext_by_id_group(group Group)
        {
            return class_act_real_ext_by_id_group(Group.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_real_ext_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_real_ext_by_id_group");
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
        /// Лист разрешенных активных расширенных представлений вещественных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_real_ext_allowed_by_id_group(Int64 iid_group, Int64 iid_position)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_real_ext_allowed_by_id_group");

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
            cmdk.Parameters["iid_position"].Value = iid_position;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист разрешенных активных расширенных представлений вещественных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_real_ext_allowed_by_id_group(group Group, position Position)
        {
            return class_act_real_ext_allowed_by_id_group(Group.Id, Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_real_ext_allowed_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_real_ext_allowed_by_id_group");
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
        /// Лист разрешенных расширенных представлений базовых абстрактных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_base_ext_allowed_by_id_group(Int64 iid_group, Int64 iid_position)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_base_ext_allowed_by_id_group");

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
            cmdk.Parameters["iid_position"].Value = iid_position;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист разрешенных расширенных представлений базовых абстрактных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_base_ext_allowed_by_id_group(group Group, position Position)
        {
            return class_act_base_ext_allowed_by_id_group(Group.Id, Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_base_ext_allowed_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_base_ext_allowed_by_id_group");
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
        #endregion

        #region НАЙТИ
        /// <summary>
        /// Лист представлений активных дочерних классов по строгому соотвествию имени
        /// </summary>
        public List<vclass> class_act_by_id_parent_strict_name(Int64 iid_parent, String iname)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_by_id_parent_strict_name");

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

            cmdk.Parameters["iid_parent"].Value = iid_parent;
            cmdk.Parameters["iname"].Value = iname;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных дочерних классов по строгому соотвествию имени
        /// </summary>
        public List<vclass> class_act_by_id_parent_strict_name(vclass Vclass_parent, String iname)
        {
            List<vclass> Result = null;
            switch (Vclass_parent.StorageType)
            {
                case eStorageType.Active:
                    Result = class_act_by_id_parent_strict_name(Vclass_parent.Id, iname);
                    break;
                case eStorageType.History:
                    throw new PgDataException(505, "Тип представления класса не соотвествует сигнатуре функции, требуется активное представление класса");
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_parent_strict_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_by_id_parent_strict_name");
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
        /// Лист представлений активных классов указанного расположения по маске имени
        /// </summary>
        public List<vclass> class_act_by_id_parent_msk_name(Int64 iid_parent, String name_mask)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_by_id_parent_msk_name");

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

            cmdk.Parameters["iid_parent"].Value = iid_parent;
            cmdk.Parameters["name_mask"].Value = name_mask;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов указанного расположения по маске имени
        /// </summary>
        public List<vclass> class_act_by_id_parent_msk_name(vclass Vclass_parent, String name_mask)
        {
            return class_act_by_id_parent_msk_name(Vclass_parent.Id, name_mask); 
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_parent_msk_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_by_id_parent_msk_name");
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
        /// Лист представлений активных классов указанного расположения по маске имени
        /// </summary>
        public List<vclass> class_act_by_id_group_msk_name(Int64 iid_group, String name_mask)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_by_id_group_msk_name");

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
            cmdk.Parameters["name_mask"].Value = name_mask;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов указанного расположения по маске имени
        /// </summary>
        public List<vclass> class_act_by_id_group_msk_name(group Group, String name_mask)
        {
            return class_act_by_id_group_msk_name(Group.Id, name_mask);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_group_msk_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_by_id_group_msk_name");
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
        //**************************************************************************************************
        /// <summary>
        /// Лист представлений активных классов концепции по маске имени
        /// </summary>
        public List<vclass> class_act_by_id_conception_msk_name(Int64 iid_conception, String name_mask)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_by_id_conception_msk_name");

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
            cmdk.Parameters["name_mask"].Value = name_mask;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов концепции по маске имени
        /// </summary>
        public List<vclass> class_act_by_id_conception_msk_name(conception Conception, String name_mask)
        {
            return class_act_by_id_conception_msk_name(Conception.Id, name_mask);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_conception_msk_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_by_id_conception_msk_name");
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
        #endregion

        #region НАЙТИ EXT
        /// <summary>
        /// Лист представлений активных дочерних классов по строгому соотвествию имени
        /// </summary>
        public List<vclass> class_act_ext_by_id_parent_strict_name(Int64 iid_parent, String iname)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_ext_by_id_parent_strict_name");

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

            cmdk.Parameters["iid_parent"].Value = iid_parent;
            cmdk.Parameters["iname"].Value = iname;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных дочерних классов по строгому соотвествию имени
        /// </summary>
        public List<vclass> class_act_ext_by_id_parent_strict_name(vclass Vclass_parent, String iname)
        {
            List<vclass> Result = null;
            switch (Vclass_parent.StorageType)
            {
                case eStorageType.Active:
                    Result = class_act_ext_by_id_parent_strict_name(Vclass_parent.Id, iname);
                    break;
                case eStorageType.History:
                    throw new PgDataException(505, "Тип представления класса не соотвествует сигнатуре функции, требуется активное представление класса");
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_by_id_parent_strict_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_ext_by_id_parent_strict_name");
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
        /// Лист представлений активных классов указанного расположения по маске имени
        /// </summary>
        public List<vclass> class_act_ext_by_id_parent_msk_name(Int64 iid_parent, String name_mask)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_ext_by_id_parent_msk_name");

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

            cmdk.Parameters["iid_parent"].Value = iid_parent;
            cmdk.Parameters["name_mask"].Value = name_mask;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов указанного расположения по маске имени
        /// </summary>
        public List<vclass> class_act_ext_by_id_parent_msk_name(vclass Vclass_parent, String name_mask)
        {
            return class_act_ext_by_id_parent_msk_name(Vclass_parent.Id, name_mask);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_by_id_parent_msk_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_ext_by_id_parent_msk_name");
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
        /// Лист представлений активных классов указанного расположения по маске имени
        /// </summary>
        public List<vclass> class_act_ext_by_id_group_msk_name(Int64 iid_group, String name_mask)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_ext_by_id_group_msk_name");

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
            cmdk.Parameters["name_mask"].Value = name_mask;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов указанного расположения по маске имени
        /// </summary>
        public List<vclass> class_act_ext_by_id_group_msk_name(group Group, String name_mask)
        {
            return class_act_ext_by_id_group_msk_name(Group.Id, name_mask);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_by_id_group_msk_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_ext_by_id_group_msk_name");
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
        //**************************************************************************************************
        /// <summary>
        /// Лист представлений активных классов концепции по маске имени
        /// </summary>
        public List<vclass> class_act_ext_by_id_conception_msk_name(Int64 iid_conception, String name_mask)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_ext_by_id_conception_msk_name");

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
            cmdk.Parameters["name_mask"].Value = name_mask;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов концепции по маске имени
        /// </summary>
        public List<vclass> class_act_ext_by_id_conception_msk_name(conception Conception, String name_mask)
        {
            return class_act_ext_by_id_conception_msk_name(Conception.Id, name_mask);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_by_id_conception_msk_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_ext_by_id_conception_msk_name");
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
        #endregion

        #region СВОЙСТВА ПОЛУЧАЕМЫЕ ИЗ БД
        //*********************************************************************************************
        /// <summary>
        /// Метод определяет актуальность состояния класса
        /// </summary>
        public eEntityState class_is_actual(Int64 iid, DateTime itimestamp, DateTime itimestamp_child_change)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_is_actual3");

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

            cmdk.Parameters["iid"].Value = iid;
            cmdk.Parameters["itimestamp"].Value = itimestamp;
            cmdk.Parameters["itimestamp_child_change"].Value = itimestamp_child_change;

            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Метод определяет актуальность состояния класса
        /// </summary>
        public eEntityState class_is_actual(vclass Class)
        {
            eEntityState Result = eEntityState.History;
            if (Class.StorageType == eStorageType.Active)
            {
                Result = class_is_actual(Class.Id, Class.Timestamp, Class.Timestamp_child_change);
            }
            return Result;
        }

        /// <summary>
        /// Метод проверяет свойства класса на готовность к созданию объектов
        /// </summary>
        public Boolean class_act_prop_check(Int64 iid_class)
        {
            Boolean Result = false;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_act_prop_check");

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

            cmdk.Parameters["iid_class"].Value = iid_class;

            //Начало транзакции
            Result = (Boolean)cmdk.ExecuteScalar();
            
            return Result;
        }

        /// <summary>
        /// Метод проверяет свойства класса на готовность к созданию объектов
        /// </summary>
        public Boolean class_act_prop_check(vclass Class)
        {
            Boolean Result = false;
            if (Class.StorageType == eStorageType.Active)
            {
                Result = class_act_prop_check(Class.Id);
            }
            return Result;
        }

        /// <summary>
        /// Метод проверяет свойства и формат класса на готовность к созданию объектов
        /// </summary>
        public Boolean class_act_ready_check(Int64 iid_class)
        {
            Boolean Result = false;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_act_ready_check");

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

            cmdk.Parameters["iid_class"].Value = iid_class;

            //Начало транзакции
            Result = (Boolean)cmdk.ExecuteScalar();
            
            return Result;
        }

        /// <summary>
        /// Метод проверяет свойства и формат класса на готовность к созданию объектов
        /// </summary>
        public Boolean class_act_ready_check(vclass Class)
        {
            Boolean Result = false;
            if (Class.StorageType == eStorageType.Active)
            {
                Result = class_act_ready_check(Class.Id);
            }
            return Result;
        }
        #endregion

        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ ПРЕДСТАВЛЕНИЯМИ КЛАССОВ

        /// <summary>
        /// Делегат события изменения представления класса
        /// </summary>
        public delegate void ClassChangeEventHandler(Object sender, ClassChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении представления класса методом доступа к БД
        /// </summary>
        public event ClassChangeEventHandler ClassChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения представления класса
        /// </summary>
        protected virtual void ClassOnChange(ClassChangeEventArgs e)
        {
            ClassChangeEventHandler temp = ClassChange;

            if (temp != null)
            {
                temp(this, e);
            }
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(e);
            JournalMessageOnReceived(me);
        }
        #endregion
    }
}
