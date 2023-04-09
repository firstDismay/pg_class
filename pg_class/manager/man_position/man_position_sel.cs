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
        /// Позиция по идентификатору
        /// </summary>
        public position position_by_id(Int64 id)
        {
            position position = null;

            DataTable tbl_pos = TableByName("vposition");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_id");

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

            cmdk.Fill(tbl_pos);

            if (tbl_pos.Rows.Count > 0)
            {
                position = new position(tbl_pos.Rows[0]);
            }
            return position;
        }

        /// <summary>
        /// Позиция по объекту pos_path
        /// </summary>
        public position position_by_pos_path(pos_path pos_path)
        {
            return position_by_id(pos_path.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_by_id");
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
        /// Лист позиций по идентификатору родительской позиции
        /// position_by_id_parent
        /// </summary>
        public List<position> position_by_id_parent(Int64 id_parent)
        {
            List<position> pos_list = new List<position>();


            DataTable tbl_pos = TableByName("vposition");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_id_parent");

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

            cmdk.Fill(tbl_pos);

            position pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = new position(dr);
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист позиций по идентификатору родительской позиции
        /// position_by_id_parent
        /// </summary>
        public List<position> position_by_id_parent(position Position)
        {
            return position_by_id_parent(Position.Id);
        }

        /// <summary>
        /// Лист позиций по идентификатору родительской позиции с учетом шаблона позиции
        /// position_by_id_parent
        /// </summary>
        public List<position> position_by_id_parent(Int64 id_parent, Int64 id_pos_temp)
        {
            return position_by_id_parent(id_parent).FindAll(x => x.Id_pos_temp == id_pos_temp);
        }

        /// <summary>
        /// Лист позиций по идентификатору родительской позиции с учетом шаблона позиции
        /// position_by_id_parent
        /// </summary>
        public List<position> position_by_id_parent(position Position, pos_temp Pos_temp)
        {
            return position_by_id_parent(Position.Id, Pos_temp.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// position_by_id_parent
        /// </summary>
        public Boolean position_by_id_parent(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_id_parent");
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
        /// Лист позиций по идентификатору родительской позиции
        /// position_by_id_parent
        /// </summary>
        public List<position> position_root_by_id_conception(Int64 iid_conception)
        {
            List<position> pos_list = new List<position>();


            DataTable tbl_pos = TableByName("vposition");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_root_by_id_conception");

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

            cmdk.Fill(tbl_pos);

            position pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = new position(dr);
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист позиций по идентификатору родительской позиции
        /// position_by_id_parent
        /// </summary>
        public List<position> position_root_by_id_conception(conception Conception)
        {
            return position_root_by_id_conception(Conception.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// position_by_id_parent
        /// </summary>
        public Boolean position_root_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_root_by_id_conception");
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
        /// Лист позиций по идентификатору шаблона позиции
        /// </summary>
        public List<position> position_by_id_pos_temp(Int64 id_pos_temp)
        {
            List<position> pos_list = new List<position>();
            DataTable tbl_pos = TableByName("vposition");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_id_pos_temp");

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


            cmdk.Parameters["iid_pos_temp"].Value = id_pos_temp;

            cmdk.Fill(tbl_pos);

            position pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = new position(dr);
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист позиций по идентификатору шаблона позиции
        /// </summary>
        public List<position> position_by_id_pos_temp(pos_temp pos_temp)
        {
            return position_by_id_pos_temp(pos_temp.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_id_pos_temp");
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
        /// Лист позиций по идентификатору глобального свойства
        /// </summary>
        public List<position> position_by_id_global_prop(Int64 iid_global_prop)
        {
            List<position> pos_list = new List<position>();
            DataTable tbl_pos = TableByName("vposition");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_id_global_prop");

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

            cmdk.Fill(tbl_pos);

            position pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = new position(dr);
                    pos_list.Add(pt);
                }
            }
            return pos_list;
        }

        /// <summary>
        /// Лист позиций по идентификатору глобального свойства
        /// </summary>
        public List<position> position_by_id_global_prop(global_prop Global_prop)
        {
            return position_by_id_global_prop(Global_prop.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_by_id_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_id_global_prop");
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
        /// Лист позиций по идентификатору типа данных свойств
        /// </summary>
        public List<position> position_by_id_prop_data_type(Int64 iid_conception, Int64 iid_prop_data_type)
        {
            List<position> pos_list = new List<position>();
            DataTable tbl_pos = TableByName("vposition");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_id_prop_data_type");

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

            cmdk.Fill(tbl_pos);

            position pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = new position(dr);
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист позиций по идентификатору типа данных свойств
        /// </summary>
        public List<position> position_by_id_prop_data_type(con_prop_data_type Con_prop_data_type)
        {
            return position_by_id_prop_data_type(Con_prop_data_type.Id_conception, Con_prop_data_type.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_by_id_prop_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_id_prop_data_type");
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
        /// Лист позиций по идентификатору перечисления
        /// </summary>
        public List<position> position_by_id_prop_enum(Int64 iid_prop_enum)
        {
            List<position> pos_list = new List<position>();
            DataTable tbl_pos = TableByName("vposition");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_id_prop_enum");

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

            cmdk.Fill(tbl_pos);

            position pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = new position(dr);
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист позиций по идентификатору перечисления
        /// </summary>
        public List<position> position_by_id_prop_enum(prop_enum Prop_enum)
        {
            return position_by_id_prop_enum(Prop_enum.Id_prop_enum);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_by_id_prop_enum(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_id_prop_enum");
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
        /// Лист позиций по идентификатору элемента перечисления
        /// </summary>
        public List<position> position_by_id_prop_enum_val(Int64 iid_prop_enum_val)
        {
            List<position> pos_list = new List<position>();
            DataTable tbl_pos = TableByName("vposition");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_id_prop_enum_val");

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

            cmdk.Fill(tbl_pos);

            position pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = new position(dr);
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист шаблонов по идентификатору элемента перечисления
        /// </summary>
        public List<position> position_by_id_prop_enum_val(prop_enum_val Prop_enum_val)
        {
            return position_by_id_prop_enum_val(Prop_enum_val.Id_prop_enum_val);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_by_id_prop_enum_val(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_id_prop_enum_val");
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
        /// Лист макетов наименований позиций по идентификатору шаблона позиции
        /// </summary>
        public List<String> position_name_layout_by_id_pos_temp(Int64 iid_pos_temp)
        {
            List<String> pos_list = new List<String>();
            DataTable tbl_pos = new DataTable();


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_name_layout_by_id_pos_temp");

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


            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;

            cmdk.Fill(tbl_pos);

            String pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = (String)dr[0];
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист макетов наименований позиций по идентификатору шаблона позиции
        /// </summary>
        public List<String> position_name_layout_by_id_pos_temp(pos_temp pos_temp)
        {
            return position_name_layout_by_id_pos_temp(pos_temp.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_name_layout_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_name_layout_by_id_pos_temp");
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
        /// Лист дочерних позиций по строгому соотвествию имени
        /// </summary>
        public List<position> position_by_name(Int64 iid_parent, String iname)
        {
            List<position> pos_list = new List<position>();


            DataTable tbl_pos = TableByName("vposition");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_name");

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


            cmdk.Parameters["iid_parent"].Value = iid_parent;
            cmdk.Parameters["iname"].Value = iname;

            cmdk.Fill(tbl_pos);

            position pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = new position(dr);
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист дочерних позиций по строгому соотвествию имени
        /// </summary>
        public List<position> position_by_name(position Position, String iname)
        {
            return position_by_name(Position.Id, iname);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_by_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_name");
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
