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
        /// Выбирает снимок представления класса по ключевым параметрам
        /// </summary>
        public vclass class_snapshot_by_id(Int64 iid_class, DateTime timestamp_class)
        {
            vclass vclass_snapshot = null;

            DataTable tbl_vclass_snapshot  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_snapshot_by_id");

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
            cmdk.Parameters["timestamp_class"].Value = timestamp_class;

            cmdk.Fill(tbl_vclass_snapshot);
            
            if (tbl_vclass_snapshot.Rows.Count > 0)
            {
                vclass_snapshot = new vclass(tbl_vclass_snapshot.Rows[0]);
            }
            return vclass_snapshot;
        }

        /// <summary>
        /// Выбирает снимок представления класса по объекту
        /// </summary>
        public vclass class_snapshot_by_id(object_general Object)
        {
            return class_snapshot_by_id(Object.Id_class, Object.Timestamp_class);
        }


        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_by_id");
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
        /// Лист снимков класса по идентификатору класса. без учета активного представлеиня
        /// </summary>
        public List<vclass> class_snapshot_by_id_class(Int64 iid_class)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();

            
            DataTable tbl_vclass_snapshot  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_snapshot_by_id_class");

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

            cmdk.Fill(tbl_vclass_snapshot);
            
            vclass vcs;
            if (tbl_vclass_snapshot.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass_snapshot.Rows)
                {
                    vcs = new vclass(dr);
                    vclass_snapshot_list.Add(vcs);
                }
            }
            return vclass_snapshot_list;
        }

        /// <summary>
        /// Лист снимков класса по идентификатору класса. без учета активного представлеиня
        /// </summary>
        public List<vclass> class_snapshot_by_id_class(vclass Vclass)
        {
            return class_snapshot_by_id_class(Vclass.Id);
        }

        /// <summary>
        /// Лист снимков класса по идентификатору класса. без учета активного представлеиня
        /// </summary>
        public List<vclass> class_snapshot_by_id_class(object_general Object)
        {
            return class_snapshot_by_id_class(Object.Id_class);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_by_id_class");
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
        /// Лист снимков класса по идентификатору класса. c учетом активного представлеиня
        /// </summary>
        public List<vclass> class_snapshot_full_by_id_class(Int64 iid_class)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();


            DataTable tbl_vclass_snapshot  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_snapshot_full_by_id_class");

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

            cmdk.Fill(tbl_vclass_snapshot);
            
            vclass vcs;
            if (tbl_vclass_snapshot.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass_snapshot.Rows)
                {
                    vcs = new vclass(dr);
                    vclass_snapshot_list.Add(vcs);
                }
            }
            return vclass_snapshot_list;
        }

        /// <summary>
        /// Лист снимков класса по идентификатору класса. c учетом активного представлеиня
        /// </summary>
        public List<vclass> class_snapshot_full_by_id_class(vclass Vclass)
        {
            return class_snapshot_full_by_id_class(Vclass.Id);
        }

        /// <summary>
        /// Лист снимков класса по идентификатору класса. c учетом активного представлеиня
        /// </summary>
        public List<vclass> class_snapshot_full_by_id_class(object_general Object)
        {
            return class_snapshot_full_by_id_class(Object.Id_class);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_full_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_full_by_id_class");
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
        /// Лист исторических представлений классов по идентификатору снмика родительского класса
        /// </summary>
        public List<vclass> class_snapshot_by_id_parent_snapshot(Int64 iid_parent_snapshot, DateTime itimestamp_parent_snapshot)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();


            DataTable tbl_vclass_snapshot  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_snapshot_by_id_parent_snapshot");

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

            cmdk.Parameters["iid_parent_snapshot"].Value = iid_parent_snapshot;
            cmdk.Parameters["itimestamp_parent_snapshot"].Value = itimestamp_parent_snapshot;

            cmdk.Fill(tbl_vclass_snapshot);
            
            vclass vcs;
            if (tbl_vclass_snapshot.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass_snapshot.Rows)
                {
                    vcs = new vclass(dr);
                    vclass_snapshot_list.Add(vcs);
                }
            }
            return vclass_snapshot_list;
        }

        /// <summary>
        /// Лист исторических представлений классов по идентификатору снимка родительского класса
        /// </summary>
        public List<vclass> class_snapshot_by_id_parent_snapshot(vclass Vclass_parent)
        {
            List<vclass> Result = null;
            switch (Vclass_parent.StorageType)
            {
                case eStorageType.History:
                    Result = class_snapshot_by_id_parent_snapshot(Vclass_parent.Id, Vclass_parent.Timestamp);
                    break;
                case eStorageType.Active:
                    throw new PgDataException(505, "Тип представления класса не соотвествует сигнатуре функции, требуется историческое представление класса!");
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_by_id_parent_snapshot(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_by_id_parent_snapshot");
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
        /// Лист исторических представлений классов наследуемых объектами (по цепочке) по идентификатору снмика родительского класса
        /// </summary>
        public List<vclass> class_snapshot_on_object_by_id_parent_snapshot_parent_pos(Int64 iid_parent_snapshot, DateTime itimestamp_parent_snapshot, Int64 iid_position)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();
            DataTable tbl_vclass_snapshot = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_snapshot_on_object_by_id_parent_snapshot_parent_pos");

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

            cmdk.Parameters["iid_parent_snapshot"].Value = iid_parent_snapshot;
            cmdk.Parameters["itimestamp_parent_snapshot"].Value = itimestamp_parent_snapshot;
            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_vclass_snapshot);
            
            vclass vcs;
            if (tbl_vclass_snapshot.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass_snapshot.Rows)
                {
                    vcs = new vclass(dr, iid_position);
                    vclass_snapshot_list.Add(vcs);
                }
            }
            return vclass_snapshot_list;
        }

        /// <summary>
        /// Лист исторических представлений классов наследуемых объектами (по цепочке) по идентификатору снмика родительского класса
        /// </summary>
        public List<vclass> class_snapshot_on_object_by_id_parent_snapshot_parent_pos(vclass Vclass_parent, position Position_parent)
        {
            List<vclass> Result = null;
            switch (Vclass_parent.StorageType)
            {
                case eStorageType.History:
                    Result = class_snapshot_on_object_by_id_parent_snapshot_parent_pos(Vclass_parent.Id, Vclass_parent.Timestamp, Position_parent.Id);
                    break;
                case eStorageType.Active:
                    throw new PgDataException(505, "Тип представления класса не соотвествует сигнатуре функции, требуется историческое представление класса!");
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_on_object_by_id_parent_snapshot_parent_pos(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_on_object_by_id_parent_snapshot_parent_pos");
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
        /// Лист исторических представлений базовых классов по идентификатору позиции носителя объектов
        /// </summary>
        public List<vclass> class_snapshot_base_by_id_position(Int64 iid_position, Boolean on_internal = false)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();


            DataTable tbl_vclass_snapshot = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_snapshot_base_by_id_position");

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
            cmdk.Parameters["on_internal"].Value = on_internal;

            cmdk.Fill(tbl_vclass_snapshot);
            
            vclass vcs;
            if (tbl_vclass_snapshot.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass_snapshot.Rows)
                {
                    vcs = new vclass(dr, iid_position);
                    vclass_snapshot_list.Add(vcs);
                }
            }
            return vclass_snapshot_list;
        }

        /// <summary>
        /// Лист исторических представлений базовых классов по идентификатору позиции носителя объектов
        /// </summary>
        public List<vclass> class_snapshot_base_by_id_position(position Position_parent, Boolean On_internal = false)
        {
            return class_snapshot_base_by_id_position(Position_parent.Id, On_internal);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_base_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_base_by_id_position");
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
        /// Лист снимков классов по идентификатору перечисления
        /// </summary>
        public List<vclass> class_snapshot_by_id_prop_enum(Int64 iid_prop_enum)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_snapshot_by_id_prop_enum");

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
        /// Лист снимков классов по идентификатору перечисления
        /// </summary>
        public List<vclass> class_snapshot_by_id_prop_enum(prop_enum Prop_enum)
        {
            return class_snapshot_by_id_prop_enum(Prop_enum.Id_prop_enum);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_by_id_prop_enum(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_by_id_prop_enum");
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
        /// Лист снимков классов по идентификатору элемента перечисления
        /// </summary>
        public List<vclass> class_snapshot_by_id_prop_enum_val(Int64 iid_prop_enum_val)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_snapshot_by_id_prop_enum_val");

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
        /// Лист снимков классов по идентификатору элемента перечисления
        /// </summary>
        public List<vclass> class_snapshot_by_id_prop_enum_val(prop_enum_val Prop_enum_val)
        {
            return class_snapshot_by_id_prop_enum_val(Prop_enum_val.Id_prop_enum_val);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_by_id_prop_enum_val(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_by_id_prop_enum_val");
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
        /// Лист представлений снимков классов по идентификатору правила пересчета
        /// </summary>
        public List<vclass> class_snapshot_by_id_unit_conversion_rule(Int32 iid_unit_conversion_rule)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_snapshot_by_id_unit_conversion_rule");

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
        /// Лист представлений снимков классов по идентификатору правила пересчета
        /// </summary>
        public List<vclass> class_snapshot_by_id_unit_conversion_rule(unit_conversion_rule Unit_conversion_rule)
        {
            return class_snapshot_by_id_unit_conversion_rule(Unit_conversion_rule.Id);
        }

        /// <summary>
        /// Лист представлений снимков классов по идентификатору правила пересчета
        /// </summary>
        public List<vclass> class_snapshot_by_id_unit_conversion_rule(class_unit_conversion_rule Unit_conversion_rule)
        {
            return class_snapshot_by_id_unit_conversion_rule(Unit_conversion_rule.Id_unit_conversion_rule);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_by_id_unit_conversion_rule(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_by_id_unit_conversion_rule");
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
        /// Лист представлений снимков классов по идентификатору типа данных свойства
        /// </summary>
        public List<vclass> class_snapshot_by_id_prop_data_type(Int64 iid_conception, Int64 iid_prop_data_type)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_snapshot_by_id_prop_data_type");

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
        /// Лист представлений снимков классов по идентификатору типа данных свойств концепции
        /// </summary>
        public List<vclass> class_snapshot_by_id_prop_data_type(con_prop_data_type Con_prop_data_type)
        {
            return class_snapshot_by_id_prop_data_type(Con_prop_data_type.Id_conception, Con_prop_data_type.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_by_prop_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_by_id_prop_data_type");
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
        /// Выбирает снимок представления класса по ключевым параметрам
        /// </summary>
        public vclass class_snapshot_ext_by_id(Int64 iid_class, DateTime timestamp_class)
        {
            vclass vclass_snapshot = null;

            DataTable tbl_vclass_snapshot = TableByName("vclass_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_snapshot_ext_by_id");

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
            cmdk.Parameters["timestamp_class"].Value = timestamp_class;

            cmdk.Fill(tbl_vclass_snapshot);
            
            if (tbl_vclass_snapshot.Rows.Count > 0)
            {
                vclass_snapshot = new vclass(tbl_vclass_snapshot.Rows[0]);
            }
            return vclass_snapshot;
        }

        /// <summary>
        /// Выбирает снимок представления класса по объекту
        /// </summary>
        public vclass class_snapshot_ext_by_id(object_general Object)
        {
            return class_snapshot_ext_by_id(Object.Id_class, Object.Timestamp_class);
        }


        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_ext_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_ext_by_id");
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
        /// Лист снимков класса по идентификатору класса. без учета активного представлеиня
        /// </summary>
        public List<vclass> class_snapshot_ext_by_id_class(Int64 iid_class)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();


            DataTable tbl_vclass_snapshot = TableByName("vclass_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_snapshot_ext_by_id_class");

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

            cmdk.Fill(tbl_vclass_snapshot);
            
            vclass vcs;
            if (tbl_vclass_snapshot.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass_snapshot.Rows)
                {
                    vcs = new vclass(dr);
                    vclass_snapshot_list.Add(vcs);
                }
            }
            return vclass_snapshot_list;
        }

        /// <summary>
        /// Лист снимков класса по идентификатору класса. без учета активного представлеиня
        /// </summary>
        public List<vclass> class_snapshot_ext_by_id_class(vclass Vclass)
        {
            return class_snapshot_ext_by_id_class(Vclass.Id);
        }

        /// <summary>
        /// Лист снимков класса по идентификатору класса. без учета активного представлеиня
        /// </summary>
        public List<vclass> class_snapshot_ext_by_id_class(object_general Object)
        {
            return class_snapshot_ext_by_id_class(Object.Id_class);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_ext_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_ext_by_id_class");
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
        /// Лист исторических представлений классов по идентификатору снмика родительского класса
        /// </summary>
        public List<vclass> class_snapshot_ext_by_id_parent_snapshot(Int64 iid_parent_snapshot, DateTime itimestamp_parent_snapshot)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();


            DataTable tbl_vclass_snapshot = TableByName("vclass_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_snapshot_ext_by_id_parent_snapshot");

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

            cmdk.Parameters["iid_parent_snapshot"].Value = iid_parent_snapshot;
            cmdk.Parameters["itimestamp_parent_snapshot"].Value = itimestamp_parent_snapshot;

            cmdk.Fill(tbl_vclass_snapshot);
            
            vclass vcs;
            if (tbl_vclass_snapshot.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass_snapshot.Rows)
                {
                    vcs = new vclass(dr);
                    vclass_snapshot_list.Add(vcs);
                }
            }
            return vclass_snapshot_list;
        }

        /// <summary>
        /// Лист исторических представлений классов по идентификатору снимка родительского класса
        /// </summary>
        public List<vclass> class_snapshot_ext_by_id_parent_snapshot(vclass Vclass_parent)
        {
            List<vclass> Result = null;
            switch (Vclass_parent.StorageType)
            {
                case eStorageType.History:
                    Result = class_snapshot_ext_by_id_parent_snapshot(Vclass_parent.Id, Vclass_parent.Timestamp);
                    break;
                case eStorageType.Active:
                    throw new PgDataException(505, "Тип представления класса не соотвествует сигнатуре функции, требуется историческое представление класса!");
            }
            return Result;
        }


        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_ext_by_id_parent_snapshot(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_ext_by_id_parent_snapshot");
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
        /// Лист исторических представлений классов наследуемых объектами (по цепочке) по идентификатору снмика родительского класса
        /// </summary>
        public List<vclass> class_snapshot_ext_on_object_by_id_parent_snapshot_parent_pos(Int64 iid_parent_snapshot, DateTime itimestamp_parent_snapshot, Int64 iid_position)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();


            DataTable tbl_vclass_snapshot = TableByName("vclass_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_snapshot_ext_on_object_by_id_parent_snapshot_parent_pos");

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

            cmdk.Parameters["iid_parent_snapshot"].Value = iid_parent_snapshot;
            cmdk.Parameters["itimestamp_parent_snapshot"].Value = itimestamp_parent_snapshot;
            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_vclass_snapshot);
            
            vclass vcs;
            if (tbl_vclass_snapshot.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass_snapshot.Rows)
                {
                    vcs = new vclass(dr, iid_position);
                    vclass_snapshot_list.Add(vcs);
                }
            }
            return vclass_snapshot_list;
        }

        /// <summary>
        /// Лист исторических представлений классов наследуемых объектами (по цепочке) по идентификатору снмика родительского класса
        /// </summary>
        public List<vclass> class_snapshot_ext_on_object_by_id_parent_snapshot_parent_pos(vclass Vclass_parent, position Position_parent)
        {
            List<vclass> Result = null;
            switch (Vclass_parent.StorageType)
            {
                case eStorageType.History:
                    Result = class_snapshot_ext_on_object_by_id_parent_snapshot_parent_pos(Vclass_parent.Id, Vclass_parent.Timestamp, Position_parent.Id);
                    break;
                case eStorageType.Active:
                    throw new PgDataException(505, "Тип представления класса не соотвествует сигнатуре функции, требуется историческое представление класса!");
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_ext_on_object_by_id_parent_snapshot_parent_pos(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_ext_on_object_by_id_parent_snapshot_parent_pos");
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
        /// Лист исторических представлений базовых классов по идентификатору позиции носителя объектов
        /// </summary>
        public List<vclass> class_snapshot_base_ext_by_id_position(Int64 iid_position, Boolean on_internal = false)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();


            DataTable tbl_vclass_snapshot = TableByName("vclass_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_snapshot_base_ext_by_id_position");

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
            cmdk.Parameters["on_internal"].Value = on_internal;

            cmdk.Fill(tbl_vclass_snapshot);
            
            vclass vcs;
            if (tbl_vclass_snapshot.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass_snapshot.Rows)
                {
                    vcs = new vclass(dr, iid_position);
                    vclass_snapshot_list.Add(vcs);
                }
            }
            return vclass_snapshot_list;
        }

        /// <summary>
        /// Лист исторических представлений базовых классов по идентификатору позиции носителя объектов
        /// </summary>
        public List<vclass> class_snapshot_base_ext_by_id_position(position Position_parent, Boolean On_internal = false)
        {
            return class_snapshot_base_ext_by_id_position(Position_parent.Id, On_internal);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_base_ext_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_base_ext_by_id_position");
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

        #region ОЧИСТКА КУБА МЕТАДАННЫХ
        /// <summary>
        /// Метод удаляет снимки концепции не содержащие каскадно наследующие объекты и классы значения свойств
        /// </summary>
        public Int64 class_snapshot_clear(Int64 iid_conception )
        {
            Int64 Result = 0;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_snapshot_clear");

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

            conception conception = conception_by_id(iid_conception);
            cmdk.Parameters["iid_conception"].Value = iid_conception;

            //Начало транзакции
            Result = (Int64)cmdk.ExecuteScalar();
            
            //=======================
            if (conception == null)
            {
                //Подготовка исключения метода
                PgDataException pgex = new PgDataException(eEntity.conception, eAction.Clear, eSubClass_ErrID.SCE1_NonExistent_Entity, "Указанная концепция не существует!");
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_conception, eEntity.conception, pgex.ErrID, "Указанная концепция не существует!", eAction.Clear, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                //Генерация исключения
                throw new PgDataException(eEntity.conception,eAction.Clear,eSubClass_ErrID.SCE1_NonExistent_Entity, "Указанная концепция не существует!");
            }

            //Генерируем событие изменения концепции
            if (conception != null)
            {
                ConceptionChangeEventArgs e = new ConceptionChangeEventArgs(conception, eAction.Clear);
                ConceptionOnChange(e);
            }
            return Result;
        }

        /// <summary>
        /// Метод удаляет снимки концепции не содержащие каскадно наследующие объекты и классы значения свойств
        /// </summary>
        public Int64 class_snapshot_clear(conception Conception)
        {
            return class_snapshot_clear(Conception.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_clear(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_clear");
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
        /// Лист неиспользуемых снимков классов концепции по идентификатору концепции
        /// </summary>
        public List<vclass> class_snapshot_clear_info(Int64 iid_conception)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();


            DataTable tbl_vclass_snapshot  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_snapshot_clear_info");

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

            cmdk.Fill(tbl_vclass_snapshot);
            
            vclass vcs;
            if (tbl_vclass_snapshot.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass_snapshot.Rows)
                {
                    vcs = new vclass(dr);
                    vclass_snapshot_list.Add(vcs);
                }
            }
            return vclass_snapshot_list;
        }

        /// <summary>
        /// Лист неиспользуемых снимков классов концепции по идентификатору концепции
        /// </summary>
        public List<vclass> class_snapshot_clear_info(conception Conception)
        {
            return class_snapshot_clear_info(Conception.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_clear_info(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_clear_info");
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
