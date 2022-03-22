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
using Newtonsoft.Json;

namespace pg_class
{
    public partial class manager
    {
        #region МЕТОДЫ КЛАССА: ПРЕДСТАВЛЕНИЯ КЛАССА

        #region ДОБАВИТЬ
        
        /// <summary>
        /// Метод добавляет новый объект в указанное расположение
        /// </summary>
        public object_general object_add( Int64 iid_class, Int64 iid_position,  Int32 iid_unit_conversion_rule, Decimal icquantity)
        {
            object_general Object_add = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_add");

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
            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.Parameters["icquantity"].Value = icquantity;
            cmdk.Parameters["setname"].Value = true;

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
                        Object_add = object_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.vobject, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения 
            if (Object_add != null)
            {
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object_add, eAction.Insert);
                ObjectOnChange(e);
            }
            //Возвращаем Объект
            return Object_add;
        }

        /// <summary>
        /// Метод добавляет новый объект в указанное расположение
        /// </summary>
        public object_general object_add(vclass Class, position Position, unit_conversion_rule Unit_conversion_rule, Decimal icquantity)
        {
            return object_add(Class.Id, Position.Id, Unit_conversion_rule.Id, icquantity);
        }
        
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_add");
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

        #region ДОБАВИТЬ КАК ЕДИНИЧНЫЕ ЮНИТЫ

        /// <summary>
        /// Метод добавляет новые объекты в указанное расположение в виде единичных юнитов с количеством указанного правила пересчета
        /// </summary>
        public List<object_general> object_add_by_single_unit(Int64 iid_class, Int64 iid_position, Int32 iid_unit_conversion_rule, Decimal icquantity)
        {
            List<object_general> Object_list = new List<object_general>();
            object_general Object;
            Int64[] id_array;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_add_by_single_unit");

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
            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.Parameters["icquantity"].Value = icquantity;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
           
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    id_array = (Int64[])(cmdk.Parameters["outid"].Value);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(-1, eEntity.vobject, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Генерируем событие изменения объектов
            foreach (Int64 i in id_array)
            {
                if (i > 0)
                {
                    Object = object_by_id(i);
                    if (Object != null)
                    {
                        Object_list.Add(Object);
                        ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object, eAction.Insert);
                        ObjectOnChange(e);
                    }
                }
            }
            //Возвращаем Объекты
            return Object_list;
        }

        /// <summary>
        /// Метод добавляет новые объекты в указанное расположение в виде единичных юнитов с количеством указанного правила пересчета
        /// </summary>
        public List<object_general> object_add_by_single_unit(vclass Class, position Position, unit_conversion_rule Unit_conversion_rule, Decimal icquantity)
        {
            return object_add_by_single_unit(Class.Id, Position.Id, Unit_conversion_rule.Id, icquantity);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_add_by_single_unit(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_add_by_single_unit");
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

        #region ДОБАВИТЬ ДЛЯ КЛАССА
        /// <summary>
        ///  Метод выполняет создание объектов всех вещественных классов указанного класса
        /// </summary>
        public List<errarg_object_add> object_add_for_class_act(Int64 iid_class, Int64 iid_position_target)
        {
            List<errarg_object_add> object_list = new List<errarg_object_add>();
            //object_general o;

            DataTable tbl_result = TableByName("errarg_object_add");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_add_for_class_act");

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
            cmdk.Parameters["iid_position_target"].Value = iid_position_target;

            cmdk.Fill(tbl_result);
            
            errarg_object_add og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new errarg_object_add(dr);
                    object_list.Add(og);
                }
            }

            position p = pos_by_id(iid_position_target);
            if (p != null)
            {
                //Генерируем событие изменения остава объектов позиции
                PositionChangeEventArgs e = new PositionChangeEventArgs(p, eAction.Insert_mass);
                PositionOnChange(e);
            }
            return object_list;
        }

        /// <summary>
        ///  Метод выполняет создание объектов всех вещественных классов указанного класса
        /// </summary>
        public List<errarg_object_add> object_add_for_class_act(vclass Class, position Position_target)
        {
            return object_add_for_class_act(Class.Id, Position_target.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_add_for_class_act(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_add_for_class_act");
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

        #region ДОБАВИТЬ ДЛЯ МАССИВА ПАРАМЕТРОВ ОБЪЕКТОВ
        /// <summary>
        ///  Метод добавляет список объектов по массиву параметров объектов
        /// </summary>
        public List<errarg_object_add> object_add_for_array_object_parameter(json_object_parameters[] array_object_parameter)
        {
            List<errarg_object_add> object_list = new List<errarg_object_add>();
            //object_general o;

            DataTable tbl_result = TableByName("errarg_object_add");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_add_for_array_object_parameter");

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

            String[] sarray_object_parameter = new String[array_object_parameter.Length];

            for (Int32 i = 0; i < array_object_parameter.Length; i++)
            {
                sarray_object_parameter[i] = JsonConvert.SerializeObject(array_object_parameter[i], Formatting.Indented);
            }

            cmdk.Parameters["array_object_parameter"].Value = sarray_object_parameter;
            

            cmdk.Fill(tbl_result);

            errarg_object_add og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new errarg_object_add(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }
       
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_add_for_array_object_parameter(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_add_for_array_object_parameter");
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

        #region КОПИРОВАТЬ

        /// <summary>
        /// Метод копирует объект в указанное расположение
        /// </summary>
        public object_general object_copy(Int64 iid_object_pattern, Int32 iid_entity_target, Int64 iid_entity_instance_target, Int64 iid_sub_entity_instance_target)
        {
            object_general Object_copy = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_copy");

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

            cmdk.Parameters["iid_object_pattern"].Value = iid_object_pattern;
            cmdk.Parameters["iid_entity_target"].Value = iid_entity_target;
            cmdk.Parameters["iid_entity_instance_target"].Value = iid_entity_instance_target;
            cmdk.Parameters["iid_sub_entity_instance_target"].Value = iid_sub_entity_instance_target;
            cmdk.Parameters["on_check_nested_rule"].Value = true;

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
                        Object_copy = object_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.vobject, error, desc_error, eAction.Copy, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (Object_copy != null)
            {
                //Генерируем событие изменения 
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object_copy, eAction.Copy);
                ObjectOnChange(e);
                //Возвращаем Объект
            }
            return Object_copy;
        }

        /// <summary>
        /// Метод копирует объект в указанное расположение
        /// </summary>
        public object_general object_copy(object_general Object_pattern, position Position_target)
        {
            return object_copy(Object_pattern.Id, Position_target.EntityID, Position_target.Id, -1);
        }

        /// <summary>
        /// Метод копирует объект в указанное расположение
        /// </summary>
        public object_general object_copy(object_general Object_pattern, position_prop Position_prop_target)
        {
            return object_copy(Object_pattern.Id, Position_prop_target.EntityID, Position_prop_target.Id_pos_temp_prop, Position_prop_target.Id_position_carrier);
        }

        /// <summary>
        /// Метод копирует объект в указанное расположение
        /// </summary>
        public object_general object_copy(object_general Object_pattern, object_prop Object_prop_target)
        {
            return object_copy(Object_pattern.Id, Object_prop_target.EntityID, Object_prop_target.Id_class_prop, Object_prop_target.Id_object_carrier);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_copy(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_copy");
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

        #region ИЗМЕНИТЬ
        /// <summary>
        /// Метод изменяет указанное представление класса
        /// </summary>
        public object_general object_upd(Int64 iid, Int32 iid_unit_conversion_rule, Decimal icquantity)

        {
            object_general Object = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_upd");

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
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.Parameters["icquantity"].Value = icquantity;
            cmdk.Parameters["setname"].Value = true;

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
                    Object = object_by_id(iid);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid, eEntity.vobject, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (Object != null)
            {
                //Генерируем событие изменения
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object, eAction.Update);
                ObjectOnChange(e);
            }
            //Возвращаем Объект
            return Object;
        }


        /// <summary>
        /// Метод изменяет указанное представление класса
        /// </summary>
        public object_general object_upd(object_general Object)
        {
            return object_upd(Object.Id, Object.Id_unit_conversion_rule, Object.Quantity_curent);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_upd");
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
        /// Метод переносит объект в новое расположение
        /// </summary>
        public object_general object_move(Int64 iid_object, Int64 iid_position, Decimal icquantity)
        {
            object_general Object_move = null;
            object_general Object_change = null;

            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_move");

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
            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["icquantity"].Value = icquantity;

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
                        Object_move = object_by_id(id);
                    }

                    //Если идет частичное встраивание с созданием нового объекта находим остаток
                    if (id != iid_object)
                    {
                        Object_change = object_by_id(iid_object);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_object, eEntity.vobject, error, desc_error, eAction.Move, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения объекта
            ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object_move, eAction.Move);
            ObjectOnChange(e);
            
            //Если есть остаток то генерируем изменение остатка
            if (Object_change != null)
            {
                ObjectChangeEventArgs e3 = new ObjectChangeEventArgs(Object_change, eAction.Update);
                ObjectOnChange(e3);
            }
            //Возвращаем Объект
            return Object_move;
        }

        /// <summary>
        /// Метод переносит объект в новое расположение
        /// </summary>
        public object_general object_move(object_general Object, position Position, Decimal icuantity)
        {
            return object_move(Object.Id, Position.Id, icuantity);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_move(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_move");
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

        #region ПРИВЕСТИ
        /// <summary>
        /// Метод выполняет приведение объекта к указанному снимку класса
        /// </summary>
        public object_general object_cast(Int64 iid_object, DateTime itimestamp_class)

        {
            object_general Object = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_cast");

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
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;

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
                    Object = object_by_id(iid_object);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_object, eEntity.vobject, error, desc_error, eAction.Cast, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (Object != null)
            {
                //Генерируем событие изменения
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object, eAction.Cast);
                ObjectOnChange(e);
            }
            //Возвращаем Объект
            return Object;
        }

        /// <summary>
        /// Метод выполняет приведение объекта к указанному снимку класса
        /// </summary>
        public object_general object_cast(object_general Object, vclass Class_target)
        {
            return object_cast(Object.Id, Class_target.Timestamp);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_cast(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_cast");
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
        ///  Метод выполняет приведение всех объектов к указанному снимку класса
        /// </summary>
        public List<errarg_cast> object_cast_for_class(Int64 iid_class, DateTime itimestamp_class)
        {
            List<errarg_cast> object_cast_list = new List<errarg_cast>();


            DataTable tbl_result = TableByName("errarg_cast");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_cast_for_class");

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
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;

            cmdk.Fill(tbl_result);
            
            errarg_cast og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new errarg_cast(dr);
                    object_cast_list.Add(og);
                }
            }
            //Генерируем событие изменения представления класса
           /* vclass vclass = class_act_by_id(iid_class);
            ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Cast);
            ClassOnChange(e);*/
            return object_cast_list;
        }

        /// <summary>
        ///  Метод выполняет приведение всех объектов к указанному снимку класса
        /// </summary>
        public List<errarg_cast> object_cast_for_class(vclass Class_target)
        {
            return object_cast_for_class(Class_target.Id, Class_target.Timestamp);
        }
            //-=ACCESS=-***********************************************************************************
            /// <summary>
            /// Проверка прав доступа к методу
            /// </summary>
        public Boolean object_cast_for_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_cast_for_class");
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
        ///  Метод приводит все объекты к активным состояниям классов рекурсивно начиная с указанного
        /// </summary>
        public List<errarg_cast> object_cast_for_class_act(Int64 iid_class)
        {
            List<errarg_cast> object_cast_list = new List<errarg_cast>();


            DataTable tbl_result = TableByName("errarg_cast");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_cast_for_class_act");

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

            cmdk.Fill(tbl_result);
            
            errarg_cast og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new errarg_cast(dr);
                    object_cast_list.Add(og);
                }
            }
            //Генерируем событие изменения представления класса
            /*vclass vclass = class_act_by_id(iid_class);
            ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Cast);
            ClassOnChange(e);*/
            return object_cast_list;
        }

        /// <summary>
        ///  Метод приводит все объекты к активным состояниям классов рекурсивно начиная с указанного
        /// </summary>
        public List<errarg_cast> object_cast_for_class_act(vclass Class_target)
        {
            return object_cast_for_class_act(Class_target.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_cast_for_class_act(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_cast_for_class_act");
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
        ///  Метод приводит все объекты к активным состояниям классов указанной группы
        /// </summary>
        public List<errarg_cast> object_cast_for_class_act_by_id_group(Int64 iid_group)
        {
            List<errarg_cast> object_cast_list = new List<errarg_cast>();

            DataTable tbl_result = TableByName("errarg_cast");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_cast_for_class_act_by_id_group");

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

            cmdk.Fill(tbl_result);
            
            errarg_cast og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new errarg_cast(dr);
                    object_cast_list.Add(og);
                }
            }
            //Генерируем событие изменения представления класса
            /*group group = group_by_id(iid_group);
            GroupChangeEventArgs e = new GroupChangeEventArgs(group, eAction.Cast);
            GroupOnChange(e);*/
            return object_cast_list;
        }

        /// <summary>
        ///  Метод приводит все объекты к активным состояниям классов указанной группы
        /// </summary>
        public List<errarg_cast> object_cast_for_class_act_by_id_group(group Group_target)
        {
            return object_cast_for_class_act_by_id_group(Group_target.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_cast_for_class_act_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_cast_for_class_act_by_id_group");
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
        ///  Метод приводит все объекты позции к активным состояниям классов рекурсивно
        /// </summary>
        public List<errarg_cast> object_cast_for_class_act_by_id_position(Int64 iid_position)
        {
            List<errarg_cast> object_cast_list = new List<errarg_cast>();


            DataTable tbl_result = TableByName("errarg_cast");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_cast_for_class_act_by_id_position");

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

            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_result);
            
            errarg_cast og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new errarg_cast(dr);
                    object_cast_list.Add(og);
                }
            }
            //Генерируем событие изменения представления класса
            /*position position = pos_by_id(iid_position);
            PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Cast);
            PositionOnChange(e);*/
            return object_cast_list;
        }

        /// <summary>
        ///  Метод приводит все объекты позции к активным состояниям классов рекурсивно
        /// </summary>
        public List<errarg_cast> object_cast_for_class_act_by_id_position(position Position_target)
        {
            return object_cast_for_class_act_by_id_position(Position_target.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_cast_for_class_act_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_cast_for_class_act_by_id_position");
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

        #region ОБЪЕДИНИТЬ
        /// <summary>
        /// Метод объединяет массив объектов с совпадающими снимками классов
        /// </summary>
        public object_general object_merging(Int64[] object_merging_array)
        {
            object_general Object_merging = null;

            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********

            if (object_merging_array.Length > 0)
            {
                id = object_merging_array[0];
            }

            //=======================
            cmdk = CommandByKey("object_merging2");

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

            cmdk.Parameters["object_merging_array"].Value = object_merging_array;
            
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
                        Object_merging = object_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.vobject, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения объекта носителя суммы
            if (Object_merging != null)
            {
                //Генерируем событие с действием слияние для результирующего объекта
                ObjectChangeEventArgs eo = new ObjectChangeEventArgs(Object_merging, eAction.Merging);
                ObjectOnChange(eo);

                //Генерируем событие обновления для носителя объекта слияния
                if (Object_merging.Is_inside)
                {
                    object_general Object_carrier = object_by_id(Object_merging.Id_object_carrier);
                    if (Object_carrier != null)
                    {
                        ObjectChangeEventArgs oc = new ObjectChangeEventArgs(Object_carrier, eAction.Update);
                        ObjectOnChange(oc);
                    }
                }
                else
                {
                    position position_carrier = pos_by_id(Object_merging.Id_position);
                    if (position_carrier != null)
                    {
                        PositionChangeEventArgs pc = new PositionChangeEventArgs(position_carrier, eAction.Update);
                        PositionOnChange(pc);
                    }
                }
            }
            //Возвращаем Объект
            return Object_merging;
        }

        /// <summary>
        /// Метод объединяет массив объектов с совпадающими снимками классов
        /// </summary>
        public object_general object_merging(object_general[] Object_merging_array)
        {
            Int64[] id_array;
            if (Object_merging_array.Length > 0)
            {
                id_array = new Int64[Object_merging_array.Length];

                for (int i = 0; i < Object_merging_array.Length; i++)
                {
                    id_array[i] = Object_merging_array[i].Id;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Массив объектов пуст!");
            }
            return object_merging(id_array);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_merging(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_merging2");
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
        /// Метод удаляет объект
        /// </summary>
        public void object_del(Int64 iid)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_del");

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
            object_general Object = object_by_id(iid);

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid, eEntity.vobject, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления представления класса
            if (Object != null)
            {
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object, eAction.Delete);
                ObjectOnChange(e);
            }
        }


        /// <summary>
        /// Метод удаляет объект
        /// </summary>
        public void object_del(object_general Object)
        {
            object_del(Object.Id);
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_del");
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
        ///  Метод удаляет группу объектов по массиву идентификаторов объектов
        /// </summary>
        public List<errarg_action> object_del_by_id_array(Int64[] object_array)
        {
            List<errarg_action> entity_action_list = new List<errarg_action>();


            DataTable tbl_result = TableByName("errarg_action");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_del_by_id_array");

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

            cmdk.Parameters["object_array"].Value = object_array;

            cmdk.Fill(tbl_result);
            
            errarg_action ea;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    ea = new errarg_action(dr);
                    entity_action_list.Add(ea);
                }
            }
            return entity_action_list;
        }

        /// <summary>
        ///  Метод удаляет группу объектов по массиву идентификаторов объектов
        /// </summary>
        public List<errarg_action> object_del_by_id_array(object_general[] object_array)
        {
            Int64[] id_array;
            if (object_array.Length > 0)
            {
                id_array = new Int64[object_array.Length];

                for (int i = 0; i < object_array.Length; i++)
                {
                    id_array[i] = object_array[i].Id;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Массив объектов пуст!");
            }
            return object_del_by_id_array(id_array);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_del_by_id_array(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_del_by_id_array");
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

        #region УНИЧТОЖИТЬ МИНУЯ КОРЗИНУ
        /// <summary>
        /// Метод уничтожает объект минуя корзину
        /// </summary>
        public void object_destroy(Int64 iid)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_destroy");

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
            object_general Object = object_by_id(iid);

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid, eEntity.vobject, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления представления класса
            if (Object != null)
            {
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object, eAction.Delete);
                ObjectOnChange(e);
            }
        }


        /// <summary>
        /// Метод уничтожает объект минуя корзину
        /// </summary>
        public void object_destroy(object_general Object)
        {
            object_destroy(Object.Id);
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_destroy(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_destroy");
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
        /// Представление объекта по идентификатору
        /// </summary>
        public object_general object_by_id(Int64 id)
        {
            object_general object_general = null;

            DataTable tbl_object  = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_id");

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

            cmdk.Fill(tbl_object);
            
            if (tbl_object.Rows.Count > 0)
            {
                object_general = new object_general(tbl_object.Rows[0]);
            }
            return object_general;
        }

        /// <summary>
        /// Представление объекта по идентификатору пути объекта
        /// </summary>
        public object_general object_by_id(object_path Object_path, Boolean Extended = false)
        {
            object_general Result;
            if (Extended)
            {
                Result = object_ext_by_id(Object_path.Id_object);
            }
            else
            {
                Result = object_by_id(Object_path.Id_object);
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_id");
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
        /// Лист представлений объектов по идентификатору позиции
        /// </summary>
        public List<object_general> object_by_id_position(Int64 iid_position)
        {
            List<object_general> object_list = new List<object_general>();

            
            DataTable tbl_object  = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_id_position");

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

            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов по идентификатору позиции
        /// </summary>
        public List<object_general> object_by_id_position(position Position)
        {
            return object_by_id_position(Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_id_position");
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
        /// Лист представлений объектов по идентификатору позиции рекурсивно
        /// </summary>
        public List<object_general> object_by_id_position_full(Int64 iid_position)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_id_position_full");

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

            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов по идентификатору позиции рекурсивно
        /// </summary>
        public List<object_general> object_by_id_position_full(position Position)
        {
            return object_by_id_position_full(Position.Id);
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Лист представлений объектов по идентификатору позиции рекурсивно
        /// </summary>
        public Byte[] object_by_id_position_full(Int64 iid_position, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_id_position_full({0})", iid_position);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_by_id_position_full({0}) f ON f.id = o.id", iid_position);
                    break;
            }
            Result = export_to_excel(command_export);
            return Result;
        }

        /// <summary>
        /// команда экспорта листа представлений объектов по id позиции рекурсивно
        /// </summary>
        public command_export object_by_id_position_full_command_export(Int64 iid_position, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_id_position_full({0})", iid_position);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_by_id_position_full({0}) f ON f.id = o.id", iid_position);
                    break;
            }

            String desc = String.Format(@"Экпорт: Объекты позиции: {0} | Режим: {1}", pos_by_id(iid_position).NamePosition, manager.ExportMode(ExportFormat));
            Result = export_to_excel_get_command(command_export, desc);
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_position_full(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_id_position_full");
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
        /// Лист представлений объектов по id объекта носителя
        /// </summary>
        public List<object_general> object_by_id_object_carrier(Int64 iid_object_carrier)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object  = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_id_object_carrier");

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

            cmdk.Parameters["iid_object_carrier"].Value = iid_object_carrier;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов по id родительского объекта
        /// </summary>
        public List<object_general> object_by_id_object_carrier(object_general Object_parent)
        {
            return object_by_id_object_carrier(Object_parent.Id);
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Лист представлений объектов по id объекта носителя
        /// </summary>
        public Byte[] object_by_id_object_carrier(Int64 iid_object_carrier, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_id_object_carrier({0})", iid_object_carrier);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_by_id_object_carrier({0}) f ON f.id = o.id", iid_object_carrier);
                    break;
            }
            Result = export_to_excel(command_export);
            return Result;
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Команда экспорта лист представлений объектов по id объекта носителя
        /// </summary>
        public command_export object_by_id_object_carrier_command_export(Int64 iid_object_carrier, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_id_object_carrier({0})", iid_object_carrier);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_by_id_object_carrier({0}) f ON f.id = o.id", iid_object_carrier);
                    break;
            }
            
            String desc = String.Format(@"Экпорт: Встроенные объекты объекта носителя: {0} | Режим: {1}", object_by_id(iid_object_carrier).Name, manager.ExportMode(ExportFormat));
            Result = export_to_excel_get_command(command_export, desc);
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_object_carrier(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_id_object_carrier");
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
        /// Лист представлений объектов по маске имени объекта в указанной позиции рекурсивно
        /// </summary>
        public List<object_general> object_by_name_id_pos(String iname, Int64 iid_position, Boolean on_inside)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_name_id_pos");

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

            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["on_inside"].Value = on_inside;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Лист представлений объектов по маске имени объекта в указанной позиции рекурсивно
        /// </summary>
        public Byte[] object_by_name_id_pos(String iname, Int64 iid_position, Boolean on_inside, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_name_id_pos('{0}', {1}, {2})", iname, iid_position, on_inside);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_by_name_id_pos('{0}', {1}, {2}) f ON f.id = o.id", iname, iid_position, on_inside);
                    break;
                default:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_name_id_pos('{0}', {1}, {2})", iname, iid_position, on_inside);
                    break;
            }
            Result = export_to_excel(command_export);
            return Result;
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Команда экспорта лист представлений объектов по id объекта носителя
        /// </summary>
        public command_export object_by_name_id_pos_command_export(String iname, Int64 iid_position, Boolean on_inside, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_name_id_pos('{0}', {1}, {2})", iname, iid_position, on_inside);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_by_name_id_pos('{0}', {1}, {2}) f ON f.id = o.id", iname, iid_position, on_inside);
                    break;
            }
            String desc = String.Format(@"Экпорт: Объекты позиции: {0} по маске имени: {1}| Режим: {2}", pos_by_id(iid_position).NamePosition, iname,  manager.ExportMode(ExportFormat));
            Result = export_to_excel_get_command(command_export, desc);
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_name_id_pos(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_name_id_pos");
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
        /// Лист представлений объектов по маске имени объекта в указанной концепции
        /// </summary>
        public List<object_general> object_by_name(String iname, Int64 iid_conception, Boolean on_inside)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_name");

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

            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["iid_conception"].Value = iid_conception;
            cmdk.Parameters["on_inside"].Value = on_inside;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Лист представлений объектов по маске имени объекта в указанной концепции
        /// </summary>
        public Byte[] object_by_name(String iname, Int64 iid_conception, Boolean on_inside, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_name('{0}', {1}, {2})", iname, iid_conception, on_inside);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_by_name('{0}', {1}, {2}) f ON f.id = o.id", iname, iid_conception, on_inside);
                    break;
            }
            Result = export_to_excel(command_export);
            return Result;
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Команда экспорта лист представлений объектов по маске имени объекта в указанной концепции
        /// </summary>
        public command_export object_by_name_command_export(String iname, Int64 iid_conception, Boolean on_inside, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_name('{0}', {1}, {2})", iname, iid_conception, on_inside);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_by_name('{0}', {1}, {2}) f ON f.id = o.id", iname, iid_conception, on_inside);
                    break;
            }
            String desc = String.Format(@"Экпорт: Объекты концепции: {0} по маске имени: {1}| Режим: {2}", pos_by_id(iid_conception).NamePosition, iname, manager.ExportMode(ExportFormat));
            Result = export_to_excel_get_command(command_export, desc);
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_name");
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
        /// Лист объектов активного представления класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_act(Int64 iid_class)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object  = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_id_class_act");

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

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов активного представления класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_act(vclass Class)
        {
            return object_by_id_class_act(Class.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_class_act(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_id_class_act");
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
        /// Лист объектов всех представления класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_full(Int64 iid_class)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object  = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_id_class_full");

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

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов всех представления класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_full(vclass Class)
        {
            return object_by_id_class_full(Class.Id);
        }

        /// <summary>
        /// Лист объектов всех представления класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_full(object_general Object_general)
        {
            return object_by_id_class_full(Object_general.Id_class);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_class_full(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_id_class_full");
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
        /// Лист объектов снимка класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_snapshot(Int64 iid_class, DateTime itimestamp)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object  = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_id_class_snapshot");

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
            cmdk.Parameters["itimestamp"].Value = itimestamp;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов снимка класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_snapshot(vclass Class)
        {
            return object_by_id_class_snapshot(Class.Id, Class.Timestamp);
        }

        /// <summary>
        /// Лист объектов снимка класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_snapshot(object_general Object_general)
        {
            return object_by_id_class_snapshot(Object_general.Id_class, Object_general.Timestamp_class);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_class_snapshot(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_id_class_snapshot");
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
        /// Лист объектов снимка класса по идентификатору класса и содержащей позиции
        /// </summary>
        public List<object_general> object_by_id_class_snapshot_id_pos(Int64 iid_class, DateTime itimestamp, Int64 iid_position)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_id_class_snapshot_id_pos");

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
            cmdk.Parameters["itimestamp"].Value = itimestamp;
            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов снимка класса по идентификатору класса и содержащей позиции
        /// </summary>
        public List<object_general> object_by_id_class_snapshot_id_pos(vclass Class, position Position_parent)
        {
            return object_by_id_class_snapshot_id_pos(Class.Id, Class.Timestamp, Position_parent.Id);
        }

        /// <summary>
        /// Лист объектов снимка класса по идентификатору класса и содержащей позиции
        /// </summary>
        public List<object_general> object_by_id_class_snapshot_id_pos(vclass Class, Int64 Id_position_parent)
        {
            return object_by_id_class_snapshot_id_pos(Class.Id, Class.Timestamp, Id_position_parent);
        }

        /// <summary>
        /// Лист объектов снимка класса по идентификатору класса и содержащей позиции
        /// </summary>
        public List<object_general> object_by_id_class_snapshot_id_pos(object_general Object_general, position Position_parent)
        {
            return object_by_id_class_snapshot_id_pos(Object_general.Id_class, Object_general.Timestamp_class, Position_parent.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_class_snapshot_id_pos(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_id_class_snapshot_id_pos");
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
        /// Лист объектов класса по идентификатору класса рекурсивно и содержащей позиции
        /// </summary>
        public List<object_general> object_by_id_class_id_pos(Int64 iid_class, Int64 iid_position)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_id_class_id_pos");

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
            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов класса по идентификатору класса рекурсивно и содержащей позиции
        /// </summary>
        public List<object_general> object_by_id_class_id_pos(vclass Class, position Position_parent)
        {
            return object_by_id_class_id_pos(Class.Id, Position_parent.Id);
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_class_id_pos(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_id_class_id_pos");
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
        /// Лист представлений объектов по идентификатору корневого класса
        /// </summary>
        public List<object_general> object_by_id_class_root(Int64 iid_class_root)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object  = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_id_class_root");

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

            cmdk.Parameters["iid_class_root"].Value = iid_class_root;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов по идентификатору корневого класса
        /// </summary>
        public List<object_general> object_by_id_class_root(vclass Class)
        {
            return object_by_id_class_root(Class.Id_root);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_class_root(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_id_class_root");
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
        /// Лист представлений объектов по идентификатору группы
        /// </summary>
        public List<object_general> object_by_id_group(Int64 iid_group)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object  = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_id_group");

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

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов по идентификатору группы
        /// </summary>
        public List<object_general> object_by_id_group(group Group)
        {
            return object_by_id_group(Group.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_id_group");
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
        /// Лист представлений объектов по идентификатору группы
        /// </summary>
        public List<object_general> object_by_id_group_root(Int64 iid_group_root)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object  = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_id_group_root");

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

            cmdk.Parameters["iid_group_root"].Value = iid_group_root;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов по идентификатору группы
        /// </summary>
        public List<object_general> object_by_id_group_root(group Group)
        {
            return object_by_id_group_root(Group.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_group_root(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_id_group_root");
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
        /// Лист объектов по идентификатору правила пересчета
        /// </summary>
        public List<object_general> object_by_id_unit_conversion_rule(Int32 iid_unit_conversion_rule)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_vclass  = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_id_unit_conversion_rule");

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

            cmdk.Fill(tbl_vclass);
            
            object_general o;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    o = new object_general(dr);
                    object_list.Add(o);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов по идентификатору правила пересчета
        /// </summary>
        public List<object_general> object_by_id_unit_conversion_rule(unit_conversion_rule Unit_conversion_rule)
        {
            return object_by_id_unit_conversion_rule(Unit_conversion_rule.Id);
        }

        /// <summary>
        /// Лист объектов по идентификатору правила пересчета
        /// </summary>
        public List<object_general> object_by_id_unit_conversion_rule(class_unit_conversion_rule Unit_conversion_rule)
        {
            return object_by_id_unit_conversion_rule(Unit_conversion_rule.Id_unit_conversion_rule);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_unit_conversion_rule(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_id_unit_conversion_rule");
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
        /// Лист объектов по идентификатору перечисления
        /// </summary>
        public List<object_general> object_by_id_prop_enum(Int64 iid_prop_enum)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_vclass  = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_id_prop_enum");

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

            cmdk.Fill(tbl_vclass);
            
            object_general o;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    o = new object_general(dr);
                    object_list.Add(o);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов по идентификатору перечисления
        /// </summary>
        public List<object_general> object_by_id_prop_enum(prop_enum Prop_enum)
        {
            return object_by_id_prop_enum(Prop_enum.Id_prop_enum);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_prop_enum(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_id_prop_enum");
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
        /// Лист объектов по идентификатору элемента перечисления
        /// </summary>
        public List<object_general> object_by_id_prop_enum_val(Int64 iid_prop_enum_val)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_vclass  = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_id_prop_enum_val");


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

            cmdk.Fill(tbl_vclass);
            
            object_general o;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    o = new object_general(dr);
                    object_list.Add(o);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов по идентификатору элемента перечисления
        /// </summary>
        public List<object_general> object_by_id_prop_enum_val(prop_enum_val Prop_enum_val)
        {
            return object_by_id_prop_enum_val(Prop_enum_val.Id_prop_enum_val);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_prop_enum_val(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_id_prop_enum_val");
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
        /// Лист объектов по идентификатору типа данных свойств концепции
        /// </summary>
        public List<object_general> object_by_id_prop_data_type( Int64 iid_conception, Int64 iid_prop_data_type)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_vclass  = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_id_prop_data_type");


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

            cmdk.Fill(tbl_vclass);
            
            object_general o;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    o = new object_general(dr);
                    object_list.Add(o);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов по идентификатору типа данных свойств концепции
        /// </summary>
        public List<object_general> object_by_id_prop_data_type(con_prop_data_type Con_prop_data_type)
        {
            return object_by_id_prop_data_type(Con_prop_data_type.Id_conception, Con_prop_data_type.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_prop_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_id_prop_data_type");
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

        #region ВЫБРАТЬ ПО ССЫЛКАМ НА ОБЪЕКТ
        //*********************************************************************************************
        /// <summary>
        /// Лист представлений объектов ссылающихся на указанный объект, разрешение обратных ссылок
        /// </summary>
        public List<object_general> object_by_link_object(Int64 iid_object, Boolean on_recursive)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_link_object");

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
            cmdk.Parameters["on_recursive"].Value = on_recursive;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов ссылающихся на указанный объект, разрешение обратных ссылок
        /// </summary>
        public List<object_general> object_by_link_object(object_general Object_link, Boolean on_recursive)
        {
            return object_by_link_object(Object_link.Id, on_recursive);
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Лист представлений объектов ссылающихся на указанный объект, разрешение обратных ссылок
        /// </summary>
        public Byte[] object_by_link_object(Int64 iid_object, Boolean on_recursive, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_link_object({0}, {1})", iid_object, on_recursive);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_by_link_object({0}, {1}) f ON f.id = o.id", iid_object, on_recursive);
                    break;
            }
            Result = export_to_excel(command_export);
            return Result;
        }

        /// <summary>
        /// Команда листа представлений объектов ссылающихся на указанный объект, разрешение обратных ссылок
        /// </summary>
        public command_export object_by_link_object_command_export(Int64 iid_object, Boolean on_recursive, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_link_object({0}, {1})", iid_object, on_recursive);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_by_link_object({0}, {1}) f ON f.id = o.id", iid_object, on_recursive);
                    break;
            }
            
            String desc = String.Format(@"Экпорт: Объекты по ссылкам на объект: {0} | Режим: {1}", object_by_id(iid_object).Name, manager.ExportMode(ExportFormat));
            Result = export_to_excel_get_command(command_export, desc);
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_link_object(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_link_object");
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

        #region ВЫБРАТЬ ПО КРИТЕРИЯМ ПОИСКА

        /// <summary>
        /// Лист представлений объектов соотвествующих набору значений глобальных/определяющих свойств (подбор по критериям)
        /// </summary>
        public List<object_general> object_by_array_prop(PropSearchСondition[] array_prop, Int64 iid_position)
        {
            List<object_general> object_list = new List<object_general>();

            DataTable tbl_object = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_array_prop");

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

            String[] sarray_prop = new String[array_prop.Length];

            for (Int32 i = 0; i < array_prop.Length; i++)
            {
                sarray_prop[i] = JsonConvert.SerializeObject(array_prop[i], Formatting.Indented);
            }

            cmdk.Parameters["array_prop"].Value = sarray_prop;
            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов соотвествующих набору значений глобальных/определяющих свойств (подбор по критериям)
        /// </summary>
        public List<object_general> object_by_array_prop(PropSearchСondition[] array_prop, position Position)
        {
            return object_by_array_prop(array_prop, Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_array_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_array_prop");
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
        /// Расширенное представление объекта по идентификатору
        /// </summary>
        public object_general object_ext_by_id(Int64 id)
        {
            object_general object_general = null;

            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_id");

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

            cmdk.Fill(tbl_object);
            
            if (tbl_object.Rows.Count > 0)
            {
                object_general = new object_general(tbl_object.Rows[0]);
            }
            return object_general;
        }

        /// <summary>
        /// Представление объекта по идентификатору пути объекта
        /// </summary>
        public object_general object_ext_by_id(object_path Object_path)
        {
            return object_ext_by_id(Object_path.Id_object);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_id");
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

        //*********************************************************************************************
        /// <summary>
        /// Лист представлений объектов по идентификатору позиции
        /// </summary>
        public List<object_general> object_ext_by_id_position(Int64 iid_position)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_id_position");

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

            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов по идентификатору позиции
        /// </summary>
        public List<object_general> object_ext_by_id_position(position Position)
        {
            return object_ext_by_id_position(Position.Id);
        }
               
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_id_position");
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
        /// Лист представлений объектов по идентификатору позиции рекурсивно
        /// </summary>
        public List<object_general> object_ext_by_id_position_full(Int64 iid_position)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_id_position_full");

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

            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов по идентификатору позиции рекурсивно
        /// </summary>
        public List<object_general> object_ext_by_id_position_full(position Position)
        {
            return object_ext_by_id_position_full(Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_id_position_full(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_id_position_full");
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
        /// Лист представлений объектов по id объекта носителя
        /// </summary>
        public List<object_general> object_ext_by_id_object_carrier(Int64 iid_object_carrier)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_id_object_carrier");

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

            cmdk.Parameters["iid_object_carrier"].Value = iid_object_carrier;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов по id родительского объекта
        /// </summary>
        public List<object_general> object_ext_by_id_object_carrier(object_general Object_parent)
        {
            return object_ext_by_id_object_carrier(Object_parent.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_id_object_carrier(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_id_object_carrier");
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
        /// Лист представлений объектов по маске имени объекта в указанной позиции рекурсивно
        /// </summary>
        public List<object_general> object_ext_by_name_id_pos(String iname, Int64 iid_position, Boolean on_inside)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_name_id_pos");

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

            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["on_inside"].Value = on_inside;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_name_id_pos(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_name_id_pos");
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
        /// Лист представлений объектов по маске имени объекта в указанной концепции
        /// </summary>
        public List<object_general> object_ext_by_name(String iname, Int64 iid_conception, Boolean on_inside)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_name");

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

            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["iid_conception"].Value = iid_conception;
            cmdk.Parameters["on_inside"].Value = on_inside;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_name");
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
        /// Лист объектов активного представления класса по идентификатору класса
        /// </summary>
        public List<object_general> object_ext_by_id_class_act(Int64 iid_class)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_id_class_act");

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

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов активного представления класса по идентификатору класса
        /// </summary>
        public List<object_general> object_ext_by_id_class_act(vclass Class)
        {
            return object_ext_by_id_class_act(Class.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_id_class_act(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_id_class_act");
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
        /// Лист объектов всех представления класса по идентификатору класса
        /// </summary>
        public List<object_general> object_ext_by_id_class_full(Int64 iid_class)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_id_class_full");

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

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов всех представления класса по идентификатору класса
        /// </summary>
        public List<object_general> object_ext_by_id_class_full(vclass Class)
        {
            return object_ext_by_id_class_full(Class.Id);
        }

        /// <summary>
        /// Лист объектов всех представления класса по идентификатору класса
        /// </summary>
        public List<object_general> object_ext_by_id_class_full(object_general Object_general)
        {
            return object_ext_by_id_class_full(Object_general.Id_class);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_id_class_full(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_id_class_full");
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
        /// Лист объектов снимка класса по идентификатору класса
        /// </summary>
        public List<object_general> object_ext_by_id_class_snapshot(Int64 iid_class, DateTime itimestamp)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_id_class_snapshot");

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
            cmdk.Parameters["itimestamp"].Value = itimestamp;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов снимка класса по идентификатору класса
        /// </summary>
        public List<object_general> object_ext_by_id_class_snapshot(vclass Class)
        {
            return object_ext_by_id_class_snapshot(Class.Id, Class.Timestamp);
        }

        /// <summary>
        /// Лист объектов снимка класса по идентификатору класса
        /// </summary>
        public List<object_general> object_ext_by_id_class_snapshot(object_general Object_general)
        {
            return object_ext_by_id_class_snapshot(Object_general.Id_class, Object_general.Timestamp_class);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_id_class_snapshot(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_id_class_snapshot");
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
        /// Лист объектов снимка класса по идентификатору класса в указанной позиции
        /// </summary>
        public List<object_general> object_ext_by_id_class_snapshot_id_pos(Int64 iid_class, DateTime itimestamp, Int64 iid_position)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_id_class_snapshot_id_pos");

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
            cmdk.Parameters["itimestamp"].Value = itimestamp;
            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов снимка класса по идентификатору класса в указанной позиции
        /// </summary>
        public List<object_general> object_ext_by_id_class_snapshot_id_pos(vclass Class, position Position_parent)
        {
            return object_ext_by_id_class_snapshot_id_pos(Class.Id, Class.Timestamp, Position_parent.Id);
        }

        /// <summary>
        /// Лист объектов снимка класса по идентификатору класса в указанной позиции
        /// </summary>
        public List<object_general> object_ext_by_id_class_snapshot_id_pos(vclass Class, Int64 Id_position_parent)
        {
            return object_ext_by_id_class_snapshot_id_pos(Class.Id, Class.Timestamp, Id_position_parent);
        }

        /// <summary>
        /// Лист объектов снимка класса по идентификатору класса в указанной позиции
        /// </summary>
        public List<object_general> object_ext_by_id_class_snapshot_id_pos(object_general Object_general, position Position_parent)
        {
            return object_ext_by_id_class_snapshot_id_pos(Object_general.Id_class, Object_general.Timestamp_class, Position_parent.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_id_class_snapshot_id_pos(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_id_class_snapshot_id_pos");
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

        
         //*********************************************************************************************
        /// <summary>
        /// Лист объектов класса рекурсивно по идентификатору класса в указанной позиции
        /// </summary>
        public List<object_general> object_ext_by_id_class_id_pos(Int64 iid_class, Int64 iid_position)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_id_class_id_pos");

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
            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов класса рекурсивно по идентификатору класса в указанной позиции
        /// </summary>
        public List<object_general> object_ext_by_id_class_id_pos(vclass Class, position Position_parent)
        {
            return object_ext_by_id_class_id_pos(Class.Id, Position_parent.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_id_class_id_pos(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_id_class_id_pos");
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
        /// Лист представлений объектов по идентификатору корневого класса
        /// </summary>
        public List<object_general> object_ext_by_id_class_root(Int64 iid_class_root)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_id_class_root");

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

            cmdk.Parameters["iid_class_root"].Value = iid_class_root;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов по идентификатору корневого класса
        /// </summary>
        public List<object_general> object_ext_by_id_class_root(vclass Class)
        {
            return object_ext_by_id_class_root(Class.Id_root);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_id_class_root(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_id_class_root");
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
        /// Лист представлений объектов по идентификатору группы
        /// </summary>
        public List<object_general> object_ext_by_id_group(Int64 iid_group)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_id_group");

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

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов по идентификатору группы
        /// </summary>
        public List<object_general> object_ext_by_id_group(group Group)
        {
            return object_ext_by_id_group(Group.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_id_group");
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
        /// Лист представлений объектов по идентификатору группы
        /// </summary>
        public List<object_general> object_ext_by_id_group_root(Int64 iid_group_root)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_id_group_root");

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

            cmdk.Parameters["iid_group_root"].Value = iid_group_root;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов по идентификатору группы
        /// </summary>
        public List<object_general> object_ext_by_id_group_root(group Group)
        {
            return object_ext_by_id_group_root(Group.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_id_group_root(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_id_group_root");
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
        /// Лист объектов по идентификатору правила пересчета
        /// </summary>
        public List<object_general> object_ext_by_id_unit_conversion_rule(Int32 iid_unit_conversion_rule)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_vclass = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_id_unit_conversion_rule");

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

            cmdk.Fill(tbl_vclass);
            
            object_general o;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    o = new object_general(dr);
                    object_list.Add(o);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов по идентификатору правила пересчета
        /// </summary>
        public List<object_general> object_ext_by_id_unit_conversion_rule(unit_conversion_rule Unit_conversion_rule)
        {
            return object_ext_by_id_unit_conversion_rule(Unit_conversion_rule.Id);
        }

        /// <summary>
        /// Лист объектов по идентификатору правила пересчета
        /// </summary>
        public List<object_general> object_ext_by_id_unit_conversion_rule(class_unit_conversion_rule Unit_conversion_rule)
        {
            return object_ext_by_id_unit_conversion_rule(Unit_conversion_rule.Id_unit_conversion_rule);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_id_unit_conversion_rule(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_id_unit_conversion_rule");
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
        /// Лист объектов по идентификатору перечисления
        /// </summary>
        public List<object_general> object_ext_by_id_prop_enum(Int64 iid_prop_enum)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_vclass = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_id_prop_enum");

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

            cmdk.Fill(tbl_vclass);
            
            object_general o;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    o = new object_general(dr);
                    object_list.Add(o);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов по идентификатору перечисления
        /// </summary>
        public List<object_general> object_ext_by_id_prop_enum(prop_enum Prop_enum)
        {
            return object_by_id_prop_enum(Prop_enum.Id_prop_enum);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_id_prop_enum(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_id_prop_enum");
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
        /// Лист объектов по идентификатору элемента перечисления
        /// </summary>
        public List<object_general> object_ext_by_id_prop_enum_val(Int64 iid_prop_enum_val)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_vclass = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_id_prop_enum_val");

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

            cmdk.Fill(tbl_vclass);
            
            object_general o;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    o = new object_general(dr);
                    object_list.Add(o);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов по идентификатору элемента перечисления
        /// </summary>
        public List<object_general> object_ext_by_id_prop_enum_val(prop_enum_val Prop_enum_val)
        {
            return object_ext_by_id_prop_enum_val(Prop_enum_val.Id_prop_enum_val);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_id_prop_enum_val(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_id_prop_enum_val");
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
        /// Лист объектов по идентификатору типа данных свойств концепции
        /// </summary>
        public List<object_general> object_ext_by_id_prop_data_type(Int64 iid_conception, Int64 iid_prop_data_type)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_vclass = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_id_prop_data_type");

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

            cmdk.Fill(tbl_vclass);
            
            object_general o;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    o = new object_general(dr);
                    object_list.Add(o);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов по идентификатору типа данных свойств концепции
        /// </summary>
        public List<object_general> object_ext_by_id_prop_data_type(con_prop_data_type Con_prop_data_type)
        {
            return object_ext_by_id_prop_data_type(Con_prop_data_type.Id_conception, Con_prop_data_type.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_id_prop_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_id_prop_data_type");
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

        #region ВЫБРАТЬ ПО ССЫЛКАМ НА ОБЪЕКТ EXT
        //*********************************************************************************************
        /// <summary>
        /// Лист расширенных представлений объектов ссылающихся на указанный объект, разрешение обратных ссылок
        /// </summary>
        public List<object_general> object_ext_by_link_object(Int64 iid_object, Boolean on_recursive)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_link_object");

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
            cmdk.Parameters["on_recursive"].Value = on_recursive;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист расширенных представлений объектов ссылающихся на указанный объект, разрешение обратных ссылок
        /// </summary>
        public List<object_general> object_ext_by_link_object(object_general Object_link, Boolean on_recursive)
        {
            return object_ext_by_link_object(Object_link.Id, on_recursive);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_link_object(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_link_object");
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

        #region ВЫБРАТЬ ПО КРИТЕРИЯМ ПОИСКА EXT
        /// <summary>
        /// Лист расширенных представлений объектов соотвествующих набору значений глобальных/определяющих свойств (подбор по критериям)
        /// </summary>
        public List<object_general> object_ext_by_array_prop(PropSearchСondition[] array_prop, Int64 iid_position)
        {
            List<object_general> object_list = new List<object_general>();

            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_array_prop");

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

            String[] sarray_prop = new String[array_prop.Length];

            for (Int32 i = 0; i < array_prop.Length; i++)
            {
                sarray_prop[i] = JsonConvert.SerializeObject(array_prop[i], Formatting.Indented);
            }

            cmdk.Parameters["array_prop"].Value = sarray_prop;
            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист расширенных представлений объектов соотвествующих набору значений глобальных/определяющих свойств (подбор по критериям)
        /// </summary>
        public List<object_general> object_ext_by_array_prop(PropSearchСondition[] array_prop, position Position)
        {
            return object_ext_by_array_prop(array_prop, Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_array_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_array_prop");
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

        #region СВОЙСТВА ПОЛУЧАЕМЫЕ ИЗ БД
        //*********************************************************************************************
        /// <summary>
        /// Метод определяет актуальность состояния объекта
        /// </summary>
        public eEntityState object_is_actual(Int64 iid, DateTime mytimestamp)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_is_actual");

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
            cmdk.Parameters["mytimestamp"].Value = mytimestamp;

            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Метод определяет актуальность состояния объекта
        /// </summary>
        public eEntityState object_is_actual(object_general Object)
        {
            return object_is_actual(Object.Id, Object.Timestamp);
        }
        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ ОБЪЕКТАМИ

        /// <summary>
        /// Делегат события изменения объектов
        /// </summary>
        public delegate void ObjectChangeEventHandler(Object sender, ObjectChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении объекта методом доступа к БД
        /// </summary>
        public event ObjectChangeEventHandler ObjectChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения объекта
        /// </summary>
        protected virtual void ObjectOnChange(ObjectChangeEventArgs e)
        {
            ObjectChangeEventHandler temp = ObjectChange;
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
