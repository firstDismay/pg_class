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
        /// Выбрать перечисление для свойства по идентификатору перечисления
        /// </summary>
        public prop_enum prop_enum_by_id(Int64 iid_prop_enum)
        {
            prop_enum prop_enum = null;

            DataTable tbl_entity = TableByName("vprop_enum");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("prop_enum_by_id");

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

            cmdk.Fill(tbl_entity);

            if (tbl_entity.Rows.Count > 0)
            {
                prop_enum = new prop_enum(tbl_entity.Rows[0]);
            }
            return prop_enum;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("prop_enum_by_id");
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
        ///  Выбрать все перечисления для свойства по идентификатору концепции
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception(Int64 iid_conception)
        {
            List<prop_enum> entity_list = new List<prop_enum>();

            DataTable tbl_entity = TableByName("vprop_enum");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("prop_enum_by_id_conception");

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

            cmdk.Fill(tbl_entity);

            prop_enum prop_enum;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    prop_enum = new prop_enum(dr);
                    entity_list.Add(prop_enum);
                }
            }
            return entity_list;
        }

        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception(conception Conception)
        {
            return prop_enum_by_id_conception(Conception.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("prop_enum_by_id_conception");
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

        //=-***********************************************************************************
        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом области применения
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception_use_area(Int64 iid_conception, Int32 iid_prop_enum_use_area)
        {
            List<prop_enum> entity_list = new List<prop_enum>();

            DataTable tbl_entity = TableByName("vprop_enum");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("prop_enum_by_id_conception_use_area");

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
            cmdk.Parameters["iid_prop_enum_use_area"].Value = iid_prop_enum_use_area;

            cmdk.Fill(tbl_entity);

            prop_enum prop_enum;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    prop_enum = new prop_enum(dr);
                    entity_list.Add(prop_enum);
                }
            }
            return entity_list;
        }

        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом области применения
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception_use_area(conception Conception, prop_enum_use_area Prop_enum_use_area)
        {
            return prop_enum_by_id_conception_use_area(Conception.Id, Prop_enum_use_area.Id);
        }

        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом области применения
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception_use_area(conception Conception, eProp_enum_use_area Prop_enum_use_area)
        {
            return prop_enum_by_id_conception_use_area(Conception.Id, (Int32)Prop_enum_use_area);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_by_id_conception_use_area(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("prop_enum_by_id_conception_use_area");
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

        //=-***********************************************************************************
        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом области применения и типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception_use_area_data_type(Int64 iid_conception, Int32 iid_prop_enum_use_area, Int32 iid_data_type)
        {
            List<prop_enum> entity_list = new List<prop_enum>();

            DataTable tbl_entity = TableByName("vprop_enum");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("prop_enum_by_id_conception_use_area_data_type");

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
            cmdk.Parameters["iid_prop_enum_use_area"].Value = iid_prop_enum_use_area;
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;

            cmdk.Fill(tbl_entity);

            prop_enum prop_enum;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    prop_enum = new prop_enum(dr);
                    entity_list.Add(prop_enum);
                }
            }
            return entity_list;
        }

        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом области применения и типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception_use_area_data_type(conception Conception, prop_enum_use_area Prop_enum_use_area, con_prop_data_type Data_type)
        {
            return prop_enum_by_id_conception_use_area_data_type(Conception.Id, Prop_enum_use_area.Id, Data_type.Id);
        }

        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом области применения и типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception_use_area_data_type(conception Conception, eProp_enum_use_area Prop_enum_use_area, eDataType DataType)
        {
            return prop_enum_by_id_conception_use_area_data_type(Conception.Id, (Int32)Prop_enum_use_area, (Int32)DataType);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_by_id_conception_use_area_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("prop_enum_by_id_conception_use_area_data_type");
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
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом типа денных
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception_data_type(Int64 iid_conception, Int32 iid_data_type)
        {
            List<prop_enum> entity_list = new List<prop_enum>();

            DataTable tbl_entity = TableByName("vprop_enum");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("prop_enum_by_id_conception_data_type");

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
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;

            cmdk.Fill(tbl_entity);

            prop_enum prop_enum;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    prop_enum = new prop_enum(dr);
                    entity_list.Add(prop_enum);
                }
            }
            return entity_list;
        }

        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом типа денных
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception_data_type(conception Conception, con_prop_data_type Data_type)
        {
            return prop_enum_by_id_conception_data_type(Conception.Id, Data_type.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_by_id_conception_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("prop_enum_by_id_conception_data_type");
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

        //=-***********************************************************************************
        /// <summary>
        ///  Выбрать все перечисления для свойств объектов по идентификатору концепции с типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_for_object_by_id_conception_data_type(Int64 iid_conception, Int32 iid_data_type)
        {
            List<prop_enum> entity_list = new List<prop_enum>();

            DataTable tbl_entity = TableByName("vprop_enum");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("prop_enum_for_object_by_id_conception_data_type");

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

            cmdk.Parameters["iid_data_type"].Value = iid_data_type;

            cmdk.Fill(tbl_entity);

            prop_enum prop_enum;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    prop_enum = new prop_enum(dr);
                    entity_list.Add(prop_enum);
                }
            }
            return entity_list;
        }

        /// <summary>
        ///  Выбрать все перечисления для свойств объектов по идентификатору концепции с типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_for_object_by_id_conception_data_type(conception Conception, con_prop_data_type Data_type)
        {
            return prop_enum_for_object_by_id_conception_data_type(Conception.Id, Data_type.Id);
        }

        /// <summary>
        ///  Выбрать все перечисления для свойств объектов по идентификатору концепции с типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_for_object_by_id_conception_data_type(conception Conception, eDataType DataType)
        {
            return prop_enum_for_object_by_id_conception_data_type(Conception.Id, (Int32)DataType);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_for_object_by_id_conception_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("prop_enum_for_object_by_id_conception_data_type");
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

        //=-***********************************************************************************
        /// <summary>
        ///  Выбрать все перечисления для свойств позиций по идентификатору концепции с типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_for_position_by_id_conception_data_type(Int64 iid_conception, Int32 iid_data_type)
        {
            List<prop_enum> entity_list = new List<prop_enum>();

            DataTable tbl_entity = TableByName("vprop_enum");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("prop_enum_for_position_by_id_conception_data_type");

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

            cmdk.Parameters["iid_data_type"].Value = iid_data_type;

            cmdk.Fill(tbl_entity);

            prop_enum prop_enum;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    prop_enum = new prop_enum(dr);
                    entity_list.Add(prop_enum);
                }
            }
            return entity_list;
        }

        /// <summary>
        ///  Выбрать все перечисления для свойств позиций по идентификатору концепции с типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_for_position_by_id_conception_data_type(conception Conception, con_prop_data_type Data_type)
        {
            return prop_enum_for_position_by_id_conception_data_type(Conception.Id, Data_type.Id);
        }

        /// <summary>
        ///  Выбрать все перечисления для свойств позиций по идентификатору концепции с типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_for_position_by_id_conception_data_type(conception Conception, eDataType DataType)
        {
            return prop_enum_for_position_by_id_conception_data_type(Conception.Id, (Int32)DataType);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_for_position_by_id_conception_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("prop_enum_for_position_by_id_conception_data_type");
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
