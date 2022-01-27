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
        #region МЕТОДЫ СВОЙСТВ ОБЪЕКТОВ
        #region ВЫБРАТЬ 
        //*********************************************************************************************
        /// <summary>
        /// Выбор свойства позиции носителя по идентификатору позиции и свойства шаблона
        /// </summary>
        public position_prop position_prop_by_id(Int64 iid_position_carrier, Int64 iid_pos_temp_prop)
        {
            position_prop position_prop = null;

            DataTable tbl_position_prop  = TableByName("vposition_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_prop_by_id");

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

            cmdk.Parameters["iid_position_carrier"].Value = iid_position_carrier;
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            cmdk.Fill(tbl_position_prop);
            
            if (tbl_position_prop.Rows.Count > 0)
            {
                position_prop = new position_prop(tbl_position_prop.Rows[0]);
            }
            return position_prop;
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбор свойства позиции носителя по идентификатору позиции и свойства шаблона
        /// </summary>
        public position_prop position_prop_by_id(position Position_carrier, Int64 iid_pos_temp_prop)
        {
            return position_prop_by_id(Position_carrier.Id, iid_pos_temp_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_prop_by_id");
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
        /// Лист свойств позиции по идентификатору позиции
        /// </summary>
        public List<position_prop> position_prop_by_id_position(Int64 iid_position_carrier)
        {
            List<position_prop> position_prop_list = new List<position_prop>();


            DataTable tbl_position_prop  = TableByName("vposition_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_prop_by_id_position");

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

            cmdk.Parameters["iid_position_carrier"].Value = iid_position_carrier;

            cmdk.Fill(tbl_position_prop);
            
            position_prop cp;
            if (tbl_position_prop.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_position_prop.Rows)
                {
                    cp = new position_prop(dr);
                    position_prop_list.Add(cp);
                }
            }
            return position_prop_list;
        }

        /// <summary>
        /// Лист свойств позиции по идентификатору позиции
        /// </summary>
        public List<position_prop> position_prop_by_id_position(position Position)
        {
            return position_prop_by_id_position(Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_prop_by_id_position");
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
        /// Выбирает свойства позиции носителя по идентификатору объекта значения
        /// </summary>
        public position_prop position_prop_by_id_object_val(Int64 iid_object_val)
        {
            position_prop position_prop = null;

            DataTable tbl_position_prop  = TableByName("vposition_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_prop_by_id_object_val");

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

            cmdk.Parameters["iid_object_val"].Value = iid_object_val;

            cmdk.Fill(tbl_position_prop);
            
            if (tbl_position_prop.Rows.Count > 0)
            {
                position_prop = new position_prop( tbl_position_prop.Rows[0]);
            }
            return position_prop;
        }

        /// <summary>
        /// Выбирает свойства позиции носителя по идентификатору объекта значения
        /// </summary>
        public position_prop position_prop_by_id_object_val(object_general  Object_val)
        {
            return position_prop_by_id_object_val(Object_val.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_by_id_object_val(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_prop_by_id_object_val");
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
        /// Метод определяет актуальность состояния свойства позиции
        /// </summary>
        public eEntityState position_prop_is_actual(Int64 iid_pos_temp_prop, Int64 iid_position_carrier,  DateTime itimestamp_position_carrier)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("position_prop_is_actual");

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

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
            cmdk.Parameters["iid_position_carrier"].Value = iid_position_carrier;
            cmdk.Parameters["itimestamp_position_carrier"].Value = itimestamp_position_carrier;

            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;
            ;
        }

        /// <summary>
        /// Метод определяет актуальность состояния свойства объекта
        /// </summary>
        public eEntityState position_prop_is_actual(position_prop PositionProp)
        {
            eEntityState Result = eEntityState.NotFound;
            Result = position_prop_is_actual(PositionProp.Id_pos_temp_prop, PositionProp.Id_position_carrier, PositionProp.Timestamp_position_carrier);
            return Result;
        }
        #endregion
        #endregion
    }
}
