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
        /// Метод определяет актуальность состояния свойства активного класса 
        /// </summary>
        public eEntityState class_prop_is_actual(Int64 iid, DateTime timestamp_class)
        {
            Int32 is_actual = 3;
            NpgsqlCommandKey cmdk;
            cmdk = CommandByKey("class_prop_is_actual");

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

            cmdk.Parameters["iid"].Value = iid;
            cmdk.Parameters["timestamp_class"].Value = timestamp_class;
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Метод определяет актуальность состояния свойства активного класса 
        /// </summary>
        public eEntityState class_prop_is_actual(class_prop ClassProp)
        {
            eEntityState Result = eEntityState.History;
            if (ClassProp.StorageType == eStorageType.Active)
            {
                Result = class_prop_is_actual(ClassProp.Id, ClassProp.Timestamp_class);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_is_actual(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_is_actual");
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
        /// Метод определяет готовность свойства к линковке с глобальными свойствами
        /// </summary>
        public ePropStateForGlobalPropLink class_prop_state_for_global_prop_link(Int64 iid_class_prop)
        {
            Int32 class_prop_state = 0;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_state_for_global_prop_link");
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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            class_prop_state = (Int32)cmdk.ExecuteScalar();
            
            return (ePropStateForGlobalPropLink)class_prop_state;
        }

        /// <summary>
        /// Метод определяет готовность свойства к линковке с глобальными свойствами
        /// </summary>
        public ePropStateForGlobalPropLink class_prop_state_for_global_prop_link(class_prop ClassProp)
        {
            ePropStateForGlobalPropLink Result = ePropStateForGlobalPropLink.ready;
            if (ClassProp.StorageType == eStorageType.Active)
            {
                Result = class_prop_state_for_global_prop_link(ClassProp.Id);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_state_for_global_prop_link(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_state_for_global_prop_link");
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
        /// Метод определяет наличие свойств вещественных классов переопределяемых по значению в объектах указанной позиции
        /// </summary>
        public Boolean class_prop_has_object_prop_override_by_id_pos(Int64 iid_position, Int64 iid_class_prop, DateTime itimestamp_class, Boolean on_internal = false)
        {
            Boolean Result = false;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_has_object_prop_override_by_id_pos");
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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;
            cmdk.Parameters["on_internal"].Value = on_internal;
            Result = (Boolean)cmdk.ExecuteScalar();

            return Result;
        }

        /// <summary>
        /// Метод определяет наличие свойств вещественных классов переопределяемых по значению в объектах указанной позиции
        /// </summary>
        public Boolean class_prop_has_object_prop_override_by_id_pos(position Position_parent, class_prop Class_prop, Boolean on_internal = false)
        {
            return class_prop_has_object_prop_override_by_id_pos(Position_parent.Id, Class_prop.Id, Class_prop.Timestamp_class, on_internal); 
        }

        /// <summary>
        /// Метод определяет наличие свойств вещественных классов переопределяемых по значению в объектах указанной позиции
        /// </summary>
        public Boolean class_prop_has_object_prop_override_by_id_pos(Int64 Id_position_parent, class_prop Class_prop, Boolean on_internal = false)
        {
            return class_prop_has_object_prop_override_by_id_pos(Id_position_parent, Class_prop.Id, Class_prop.Timestamp_class, on_internal);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_has_object_prop_override_by_id_pos(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_has_object_prop_override_by_id_pos");
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