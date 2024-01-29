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
        /// Выбор активного представления класса по идентификатору
        /// </summary>
        public vclass class_act_by_id(Int64 id)
        {
            vclass vclass = null;

            DataTable tbl_vclass = TableByName("vclass"); //TableByName("vclass");


            NpgsqlCommandKey cmdk;


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


            cmdk.Parameters["iid"].Value = id;

            cmdk.Fill(tbl_vclass);

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
                    throw new ArgumentOutOfRangeException(
                        "Исторический класс не допустим методе class_act_by_class_path!");
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
                    throw new ArgumentOutOfRangeException(
                        "Исторический класс class_path не допустим методе class_act_by_class_path!");
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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


        /// <summary>
        /// Лист представлений активных классов по идентификатору родительского класса
        /// </summary>
        public List<vclass> class_act_by_id_parent(Int64 id_parent)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");


            NpgsqlCommandKey cmdk;


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
                    throw new ArgumentOutOfRangeException("Тип представления класса не соответствует сигнатуре функции, требуется активное представление класса");
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_parent(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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


            NpgsqlCommandKey cmdk;


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
        /// Лист представлений активных классов по идентификатору родительского класса
        /// </summary>
        public List<vclass> class_act_by_id_global_prop(global_prop Global_prop)
        {
            return class_act_by_id_global_prop(Global_prop.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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

            DataTable tbl_vclass = TableByName("vclass");


            NpgsqlCommandKey cmdk;


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
                    throw new ArgumentOutOfRangeException("Тип представления класса не соответствует сигнатуре функции, требуется активное представление класса");
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_real_by_id_parent(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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


        /// <summary>
        /// Лист представлений активных базовых классов по идентификатору группы
        /// </summary>
        public List<vclass> class_act_by_id_group(Int64 id_group)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");


            NpgsqlCommandKey cmdk;


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
        /// Лист представлений активных базовых классов по идентификатору группы
        /// </summary>
        public List<vclass> class_act_by_id_group(group Group)
        {
            return class_act_by_id_group(Group.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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

        /// <summary>
        /// Лист представлений активных вещественных классов по идентификатору группы
        /// </summary>
        public List<vclass> class_act_real_by_id_group(Int64 id_group)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");


            NpgsqlCommandKey cmdk;


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
        /// Лист представлений активных вещественных классов по идентификатору группы
        /// </summary>
        public List<vclass> class_act_real_by_id_group(group Group)
        {
            return class_act_real_by_id_group(Group.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_real_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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


        /// <summary>
        /// Лист разрешенных активных представлений вещественных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_real_allowed_by_id_group(Int64 iid_group, Int64 iid_position)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");


            NpgsqlCommandKey cmdk;


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
        /// Лист разрешенных активных представлений вещественных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_real_allowed_by_id_group(group Group, position Position)
        {
            return class_act_real_allowed_by_id_group(Group.Id, Position.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_real_allowed_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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



        /// <summary>
        /// Лист разрешенных представлений базовых абстрактных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_base_allowed_by_id_group(Int64 iid_group, Int64 iid_position)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");


            NpgsqlCommandKey cmdk;


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
        /// Лист разрешенных представлений базовых абстрактных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_base_allowed_by_id_group(group Group, position Position)
        {
            return class_act_base_allowed_by_id_group(Group.Id, Position.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_base_allowed_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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




        /// <summary>
        /// Класс носитель свойства, указанного по идентификатору
        /// </summary>
        public vclass class_carrier_by_id_class_prop(Int64 iid_class_prop, DateTime itimestamp_class, eStorageType storagetype)
        {
            vclass vclass = null;

            DataTable tbl_vclass = TableByName("vclass");


            NpgsqlCommandKey cmdk;


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


            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;
            cmdk.Parameters["storagetype"].Value = storagetype.ToString("G");

            cmdk.Fill(tbl_vclass);

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

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_carrier_by_id_class_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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


        /// <summary>
        /// Лист потерянных активных классов концепции
        /// </summary>
        public List<vclass> class_act_lost_info(Int64 iid_conception)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");


            NpgsqlCommandKey cmdk;


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
        /// Лист потерянных активных классов концепции
        /// </summary>
        public List<vclass> class_act_lost_info(conception Conception)
        {
            return class_act_lost_info(Conception.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_lost_info(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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


            DataTable tbl_vclass = TableByName("vclass");


            NpgsqlCommandKey cmdk;


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

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_unit_conversion_rule(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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


        /// <summary>
        /// Лист представлений активных классов по идентификатору перечисления
        /// </summary>
        public List<vclass> class_act_by_id_prop_enum(Int64 iid_prop_enum)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");


            NpgsqlCommandKey cmdk;


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
        /// Лист представлений активных классов по идентификатору перечисления
        /// </summary>
        public List<vclass> class_act_by_id_prop_enum(prop_enum Prop_enum)
        {
            return class_act_by_id_prop_enum(Prop_enum.Id_prop_enum);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_prop_enum(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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



        /// <summary>
        /// Лист представлений активных классов по идентификатору элемента перечисления
        /// </summary>
        public List<vclass> class_act_by_id_prop_enum_val(Int64 iid_prop_enum_val)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");


            NpgsqlCommandKey cmdk;


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
        /// Лист представлений активных классов по идентификатору элемента перечисления
        /// </summary>
        public List<vclass> class_act_by_id_prop_enum_val(prop_enum_val Prop_enum_val)
        {
            return class_act_by_id_prop_enum_val(Prop_enum_val.Id_prop_enum_val);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_prop_enum_val(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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

        /// <summary>
        /// Лист представлений активных классов по идентификатору типа данных свойств концепции
        /// </summary>
        public List<vclass> class_act_by_id_prop_data_type(Int64 iid_conception, Int64 iid_prop_data_type)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");


            NpgsqlCommandKey cmdk;


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
        /// Лист представлений активных классов по идентификатору типа данных свойств концепции
        /// </summary>
        public List<vclass> class_act_by_id_prop_data_type(con_prop_data_type Con_prop_data_type)
        {
            return class_act_by_id_prop_data_type(Con_prop_data_type.Id_conception, Con_prop_data_type.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_prop_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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

        /// <summary>
        /// Метод возвращает список активных базовых классов по идентификатору концепции
        /// </summary>
        public List<vclass> class_act_base_by_id_conception(Int64 iid_conception)
        {
            List<vclass> vclass_list = new List<vclass>();
            DataTable tbl_vclass = TableByName("vclass");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_act_base_by_id_conception");
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
        public List<vclass> class_act_base_by_id_conception(conception Conception)
        {
            return class_act_base_by_id_conception(Conception.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_base_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_act_base_by_id_conception");
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