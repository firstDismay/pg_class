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
        /// Выбор глобального свойства по идентификатру свойства
        /// </summary>
        public global_prop global_prop_by_id(Int64 iid_global_prop)
        {
            global_prop global_prop = null;

            DataTable tbl_vglobal_prop  = TableByName("vglobal_prop");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("global_prop_by_id");

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

            cmdk.Fill(tbl_vglobal_prop);
            
            if (tbl_vglobal_prop.Rows.Count > 0)
            {
                global_prop = new global_prop(tbl_vglobal_prop.Rows[0]);
            }
            return global_prop;
        }

        /// <summary>
        /// Выбор глобального свойства по идентификатру свойства
        /// </summary>
        public global_prop global_prop_by_id(global_prop GlobalProp)
        {
            return global_prop_by_id(GlobalProp.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("global_prop_by_id");
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
        /// Лист глобальных свойств по идентификатору концепции
        /// </summary>
        public List<global_prop> global_prop_by_id_conception(Int64 iid_conception)
        {
            List<global_prop> global_prop_list = new List<global_prop>();

            
            DataTable tbl_global_prop  = TableByName("vglobal_prop");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("global_prop_by_id_conception");

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

            cmdk.Fill(tbl_global_prop);
            
            global_prop gp;
            if (tbl_global_prop.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_global_prop.Rows)
                {
                    gp = new global_prop(dr);
                    global_prop_list.Add(gp);
                }
            }
            return global_prop_list;
        }

        /// <summary>
        /// Лист глобальных свойств по идентификатору концепции
        /// </summary>
        public List<global_prop> global_prop_by_id_conception(conception Сonception)
        {
            return global_prop_by_id_conception(Сonception.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("global_prop_by_id_conception");
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
        /// Лист глобальных свойств по идентификатору концепции с учетом видимости
        /// </summary>
        public List<global_prop> global_prop_visible_by_id_conception(Int64 iid_conception)
        {
            List<global_prop> global_prop_list = new List<global_prop>();


            DataTable tbl_global_prop = TableByName("vglobal_prop");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("global_prop_visible_by_id_conception");

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

            cmdk.Fill(tbl_global_prop);
            
            global_prop gp;
            if (tbl_global_prop.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_global_prop.Rows)
                {
                    gp = new global_prop(dr);
                    global_prop_list.Add(gp);
                }
            }
            return global_prop_list;
        }

        /// <summary>
        /// Лист глобальных свойств по идентификатору концепции
        /// </summary>
        public List<global_prop> global_prop_visible_by_id_conception(conception Сonception)
        {
            return global_prop_visible_by_id_conception(Сonception.Id);
        }

        //ACCESS
        /// <summary>
        /// Лист глобальных свойств по идентификатору концепции с учетом видимости
        /// </summary>
        public Boolean global_prop_visible_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("global_prop_visible_by_id_conception");
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
        /// Лист глобальных свойств по идентификатору концепции с учетом видимости и допустимых для поиска
        /// </summary>
        public List<global_prop> global_prop_for_search_by_id_conception(Int64 iid_conception)
        {
            List<global_prop> global_prop_list = new List<global_prop>();


            DataTable tbl_global_prop = TableByName("vglobal_prop");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("global_prop_for_search_by_id_conception");

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

            cmdk.Fill(tbl_global_prop);
            
            global_prop gp;
            if (tbl_global_prop.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_global_prop.Rows)
                {
                    gp = new global_prop(dr);
                    global_prop_list.Add(gp);
                }
            }
            return global_prop_list;
        }

        /// <summary>
        /// Лист глобальных свойств по идентификатору концепции с учетом видимости и допустимых для поиска
        /// </summary>
        public List<global_prop> global_prop_for_search_by_id_conception(conception Сonception)
        {
            return global_prop_for_search_by_id_conception(Сonception.Id);
        }

        //ACCESS
        /// <summary>
        /// Лист глобальных свойств по идентификатору концепции с учетом видимости и допустимых для поиска
        /// </summary>
        public Boolean global_prop_for_search_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("global_prop_for_search_by_id_conception");
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
        /// Лист глобальных свойств по идентификатору класса
        /// </summary>
        public List<global_prop> global_prop_by_id_class(Int64 iid_class)
        {
            List<global_prop> global_prop_list = new List<global_prop>();


            DataTable tbl_global_prop  = TableByName("vglobal_prop");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("global_prop_by_id_class");

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

            cmdk.Fill(tbl_global_prop);
            
            global_prop gp;
            if (tbl_global_prop.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_global_prop.Rows)
                {
                    gp = new global_prop(dr);
                    global_prop_list.Add(gp);
                }
            }
            return global_prop_list;
        }

        /// <summary>
        /// Лист глобальных свойств по идентификатору класса
        /// </summary>
        public List<global_prop> global_prop_by_id_class(vclass Class)
        {
            return global_prop_by_id_class(Class.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("global_prop_by_id_class");
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
        /// Выбор глобального свойства по идентификатру определяющего свойства класса
        /// </summary>
        public global_prop global_prop_by_id_class_prop_definition(Int64 iid_class_prop_definition)
        {
            global_prop global_prop = null;

            DataTable tbl_vglobal_prop  = TableByName("vglobal_prop");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("global_prop_by_id_class_prop_definition");

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
            

            cmdk.Parameters["iid_class_prop_definition"].Value = iid_class_prop_definition;

            cmdk.Fill(tbl_vglobal_prop);
            
            if (tbl_vglobal_prop.Rows.Count > 0)
            {
                global_prop = new global_prop(tbl_vglobal_prop.Rows[0]);
            }
            return global_prop;
        }

        /// <summary>
        /// Выбор глобального свойства по идентификатру определяющего свойства класса
        /// </summary>
        public global_prop global_prop_by_id_class_prop_definition(class_prop ClassProp)
        {
            return global_prop_by_id_class_prop_definition(ClassProp.Id_prop_definition);
        }


        /// <summary>
        /// Выбор глобального свойства по идентификатру определяющего свойства класса
        /// </summary>
        public global_prop global_prop_by_id_class_prop_definition(object_prop ObjectProp)
        {
            return global_prop_by_id_class_prop_definition(ObjectProp.Id_prop_definition);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_by_id_class_prop_definition(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("global_prop_by_id_class_prop_definition");
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
        /// Лист глобальных свойств по идентификатору шаблона позиции
        /// </summary>
        public List<global_prop> global_prop_by_id_pos_temp(Int64 iid_pos_temp)
        {
            List<global_prop> global_prop_list = new List<global_prop>();


            DataTable tbl_global_prop  = TableByName("vglobal_prop");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("global_prop_by_id_pos_temp");

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

            cmdk.Fill(tbl_global_prop);
            
            global_prop gp;
            if (tbl_global_prop.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_global_prop.Rows)
                {
                    gp = new global_prop(dr);
                    global_prop_list.Add(gp);
                }
            }
            return global_prop_list;
        }

        /// <summary>
        /// Лист глобальных свойств по идентификатору шаблона позиции
        /// </summary>
        public List<global_prop> global_prop_by_id_pos_temp(pos_temp PosTemp)
        {
            return global_prop_by_id_pos_temp(PosTemp.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("global_prop_by_id_pos_temp");
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
        /// Выбор глобального свойства по идентификатру свойства шаблона позиции
        /// </summary>
        public global_prop global_prop_by_id_pos_temp_prop(Int64 iid_pos_temp_prop)
        {
            global_prop global_prop = null;

            DataTable tbl_vglobal_prop  = TableByName("vglobal_prop");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("global_prop_by_id_pos_temp_prop");

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
            

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            cmdk.Fill(tbl_vglobal_prop);
            
            if (tbl_vglobal_prop.Rows.Count > 0)
            {
                global_prop = new global_prop(tbl_vglobal_prop.Rows[0]);
            }
            return global_prop;
        }

        /// <summary>
        /// Выбор глобального свойства по идентификатру свойства шаблона позиции
        /// </summary>
        public global_prop global_prop_by_id_pos_temp_prop(pos_temp_prop PosTempProp)
        {
            return global_prop_by_id_pos_temp_prop(PosTempProp.Id);
        }


        /// <summary>
        /// Выбор глобального свойства по идентификатру свойства шаблона позиции
        /// </summary>
        public global_prop global_prop_by_id_pos_temp_prop(position_prop PositionProp)
        {
            return global_prop_by_id_pos_temp_prop(PositionProp.Id_pos_temp_prop);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_by_id_pos_temp_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("global_prop_by_id_pos_temp_prop");
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
