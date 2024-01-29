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
        /// Выбор активного представления класса с признаком готовности к созданию объектов по идентификатору
        /// class_act_ready_by_id
        /// </summary>
        public vclass class_act_ext_by_id(Int64 iid)
        {
            vclass vclass = null;

            DataTable tbl_vclass = TableByName("vclass_ext");  //new DataTable("vclass_ext")


            NpgsqlCommandKey cmdk;


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


            cmdk.Parameters["iid"].Value = iid;

            cmdk.Fill(tbl_vclass);

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
                    throw new ArgumentOutOfRangeException(
                        "Исторический класс class_path не допустим методе class_act_by_class_path!");
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
                    throw new ArgumentOutOfRangeException(
                        "Исторический класс не допустим методе class_act_ext_by_class_path!");
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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


        /// <summary>
        /// Лист представлений активных классов  с признаком готовности к созданию объектов по идентификатору родительского класса
        /// </summary>
        public List<vclass> class_act_ext_by_id_parent(Int64 id_parent)
        {
            List<vclass> vclass_list = new List<vclass>();

            DataTable tbl_vclass = new DataTable(); // TableByName("vclass_ext");
            tbl_vclass.TableName = "vclass_ext";


            NpgsqlCommandKey cmdk;


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


            cmdk.Parameters["iid_parent"].Value = id_parent;

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
                    throw new ArgumentOutOfRangeException("Тип представления класса не соответствует сигнатуре функции, требуется активное представление класса");
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_by_id_parent(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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


            NpgsqlCommandKey cmdk;


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


            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;

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
        /// Лист представлений активных классов  с признаком готовности к созданию объектов по идентификатору глобального свойства
        /// </summary>
        public List<vclass> class_act_ext_by_id_global_prop(global_prop Global_prop)
        {
            return class_act_ext_by_id_global_prop(Global_prop.Id); ;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_by_id_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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


            NpgsqlCommandKey cmdk;


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


            cmdk.Parameters["iid_group"].Value = iid_group;

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
        /// Лист представлений активных классов  с признаком готовности к созданию объектов по идентификатору родительского класса
        /// </summary>
        public List<vclass> class_act_ext_by_id_group(group Group)
        {
            return class_act_ext_by_id_group(Group.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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


        /// <summary>
        /// Лист расширенных представлений активных вещественных классов по идентификатору группы
        /// </summary>
        public List<vclass> class_act_real_ext_by_id_group(Int64 id_group)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass_ext");


            NpgsqlCommandKey cmdk;


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


            cmdk.Parameters["iid_group"].Value = id_group;

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
        /// Лист расширенных представлений активных вещественных классов по идентификатору группы
        /// </summary>
        public List<vclass> class_act_real_ext_by_id_group(group Group)
        {
            return class_act_real_ext_by_id_group(Group.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_real_ext_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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


            NpgsqlCommandKey cmdk;


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


            cmdk.Parameters["iid_group"].Value = iid_group;
            cmdk.Parameters["iid_position"].Value = iid_position;

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
        /// Лист разрешенных активных расширенных представлений вещественных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_real_ext_allowed_by_id_group(group Group, position Position)
        {
            return class_act_real_ext_allowed_by_id_group(Group.Id, Position.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_real_ext_allowed_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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


        /// <summary>
        /// Лист разрешенных расширенных представлений базовых абстрактных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_ext_base_allowed_by_id_group(Int64 iid_group, Int64 iid_position)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass_ext");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_act_ext_base_allowed_by_id_group");

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


            cmdk.Parameters["iid_group"].Value = iid_group;
            cmdk.Parameters["iid_position"].Value = iid_position;

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
        /// Лист разрешенных расширенных представлений базовых абстрактных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_ext_base_allowed_by_id_group(group Group, position Position)
        {
            return class_act_ext_base_allowed_by_id_group(Group.Id, Position.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_base_allowed_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_act_ext_base_allowed_by_id_group");
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
        /// Метод возвращает список активных базовых классов по идентификатору концепции
        /// </summary>
        public List<vclass> class_act_ext_base_by_id_conception(Int64 iid_conception)
        {
            List<vclass> vclass_list = new List<vclass>();
            DataTable tbl_vclass = TableByName("vclass");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_act_ext_base_by_id_conception");
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

            cmdk.Parameters["iid_conception"].Value = iid_conception;
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
        /// Лист представлений активных классов по идентификатору типа данных свойств концепции
        /// </summary>
        public List<vclass> class_act_ext_base_by_id_conception(conception Conception)
        {
            return class_act_ext_base_by_id_conception(Conception.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_base_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_act_ext_base_by_id_conception");
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
