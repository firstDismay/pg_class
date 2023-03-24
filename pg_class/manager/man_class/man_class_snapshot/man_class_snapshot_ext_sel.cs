using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using System.Collections.Generic;
using System.Data;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Выбирает снимок представления класса по ключевым параметрам
        /// </summary>
        public vclass class_snapshot_ext_by_id(Int64 iid_class, DateTime timestamp_class)
        {
            vclass vclass_snapshot = null;
            DataTable tbl_vclass_snapshot = TableByName("vclass_ext");
            NpgsqlCommandKey cmdk;

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

        /// <summary>
        /// Лист снимков класса по идентификатору класса. без учета активного представлеиня
        /// </summary>
        public List<vclass> class_snapshot_ext_by_id_class(Int64 iid_class)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();
            DataTable tbl_vclass_snapshot = TableByName("vclass_ext");
            NpgsqlCommandKey cmdk;

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

        /// <summary>
        /// Лист исторических представлений классов по идентификатору снмика родительского класса
        /// </summary>
        public List<vclass> class_snapshot_ext_by_id_parent_snapshot(Int64 iid_parent_snapshot, DateTime itimestamp_parent_snapshot)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();
            DataTable tbl_vclass_snapshot = TableByName("vclass_ext");
            NpgsqlCommandKey cmdk;

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
            NpgsqlCommandKey cmdk;

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

        /// <summary>
        /// Лист исторических представлений базовых классов по идентификатору позиции носителя объектов
        /// </summary>
        public List<vclass> class_snapshot_ext_base_by_id_position(Int64 iid_position, Boolean on_internal = false)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();
            DataTable tbl_vclass_snapshot = TableByName("vclass_ext");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_ext_base_by_id_position");
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
        public List<vclass> class_snapshot_ext_base_by_id_position(position Position_parent, Boolean On_internal = false)
        {
            return class_snapshot_ext_base_by_id_position(Position_parent.Id, On_internal);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_ext_base_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_ext_base_by_id_position");
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