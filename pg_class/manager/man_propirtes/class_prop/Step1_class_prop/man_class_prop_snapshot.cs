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
        #region МЕТОДЫ КЛАССА: ПРЕДСТАВЛЕНИЯ СНИМКОВ КЛАССА
        #region ВЫБРАТЬ

        //*********************************************************************************************
        /// <summary>
        /// Выбирает снимок свойства класса по ключевым параметрам
        /// </summary>
        public class_prop class_prop_snapshot_by_id(Int64 iid_class_prop, DateTime itimestamp_class)
        {
            class_prop class_prop_snapshot = null;

            DataTable tbl_class_prop_snapshot  = TableByName("vclass_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_snapshot_by_id");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_class_prop_snapshot);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            
            if (tbl_class_prop_snapshot.Rows.Count > 0)
            {
                class_prop_snapshot = new class_prop(tbl_class_prop_snapshot.Rows[0]);
            }
            return class_prop_snapshot;
        }

        /// <summary>
        /// Выбирает снимок свойства класса по ключевым параметрам
        /// </summary>
        public class_prop class_prop_snapshot_by_id(object_prop ObjectProp)
        {
            return class_prop_snapshot_by_id(ObjectProp.Id_class_prop, ObjectProp.Timestamp_class);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_snapshot_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_snapshot_by_id");
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
        /// Выбирает снимок свойства класса объекта носителя по идентификатору объекта значения свойства
        /// </summary>
        public class_prop class_prop_snapshot_by_id_object_val(Int64 iid_object_val)
        {
            class_prop class_prop_snapshot = null;

            DataTable tbl_class_prop_snapshot  = TableByName("vclass_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_snapshot_by_id_object_val");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_class_prop_snapshot);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_class_prop_snapshot.Rows.Count > 0)
            {
                class_prop_snapshot = new class_prop(tbl_class_prop_snapshot.Rows[0]);
            }
            return class_prop_snapshot;
        }


        /// <summary>
        /// Выбирает снимок свойства класса объекта носителя по идентификатору объекта значения свойства
        /// </summary>
        public class_prop class_prop_snapshot_by_id_object_val(object_general Object_val)
        {
            return class_prop_snapshot_by_id_object_val(Object_val.Id);
        }

        
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_snapshot_by_id_object_val(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_snapshot_by_id_object_val");
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
        /// Выбор свойства снимка класса по идентификатору глобального свойства
        /// </summary>
        public class_prop class_prop_snapshot_by_id_global_prop(Int64 iid_class_snapshot, DateTime itimestamp_class_snapshot, Int64 iid_global_prop)
        {
            class_prop class_prop = null;

            DataTable tbl_vclass_prop  = TableByName("vclass_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_snapshot_by_id_global_prop");

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

            cmdk.Parameters["iid_class_snapshot"].Value = iid_class_snapshot;
            cmdk.Parameters["itimestamp_class_snapshot"].Value = itimestamp_class_snapshot;
            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass_prop);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_vclass_prop.Rows.Count > 0)
            {
                class_prop = new class_prop(tbl_vclass_prop.Rows[0]);
            }
            return class_prop;
        }

        /// <summary>
        /// Выбор свойства снимка класса по идентификатору глобального свойства
        /// </summary>
        public class_prop class_prop_snapshot_by_id_global_prop(vclass Class, global_prop Global_prop)
        {
            return class_prop_snapshot_by_id_global_prop(Class.Id, Class.Timestamp, Global_prop.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_snapshot_by_id_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_snapshot_by_id_global_prop");
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
        /// Лист снимков свойств класса по идентификатору снимка класса с пустым тэгом
        /// </summary>
        public List<class_prop> class_prop_snapshot_by_id_class_snapshot(Int64 iid_class_snapshot, DateTime itimestamp_class_snapshot)
        {
            List<class_prop> class_prop_snapshot_list = new List<class_prop>();

            DataTable tbl_class_prop_snapshot  = TableByName("vclass_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_snapshot_by_id_class_snapshot");

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

            cmdk.Parameters["iid_class_snapshot"].Value = iid_class_snapshot;
            cmdk.Parameters["itimestamp_class_snapshot"].Value = itimestamp_class_snapshot;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_class_prop_snapshot);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            class_prop vcps;
            if (tbl_class_prop_snapshot.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_class_prop_snapshot.Rows)
                {
                    vcps = new class_prop(dr);
                    class_prop_snapshot_list.Add(vcps);
                }
            }
            return class_prop_snapshot_list;
        }

        /// <summary>
        /// Лист снимков свойств класса по идентификатору снимка класса с пустым тэгом
        /// </summary>
        public List<class_prop> class_prop_snapshot_by_id_class_snapshot(vclass Vclass)
        {
            return class_prop_snapshot_by_id_class_snapshot(Vclass.Id, Vclass.Timestamp);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_snapshot_by_id_class_snapshot(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_snapshot_by_id_class_snapshot");
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
        #endregion
    }
}
