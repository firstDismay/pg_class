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
            cmdk = CommandByKey("class_is_actual");

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

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_is_actual(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_is_actual");
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

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_prop_check(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_prop_check");
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

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ready_check(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_ready_check");
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
