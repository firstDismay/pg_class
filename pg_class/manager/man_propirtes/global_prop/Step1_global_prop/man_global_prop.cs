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
        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новое глобальное свойство
        /// </summary>
        public global_prop global_prop_add( Int64 iid_conception, Int32 iid_prop_type, Int32 iid_data_type, String iname, String idesc, Boolean ivisible)
        {
            global_prop global_prop = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("global_prop_add2");

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
            cmdk.Parameters["iid_prop_type"].Value = iid_prop_type;
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["ivisible"].Value = ivisible;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);

            //=======================
            switch (error)
            {
                case 0:
                    id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                    if (id > 0)
                    {
                        global_prop = global_prop_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.global_prop, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            GlobalPropChangeEventArgs e = new GlobalPropChangeEventArgs(global_prop, eAction.Insert);
            GlobalPropOnChange(e);
            //Возвращаем Объект
            return global_prop;
        }

        /// <summary>
        /// Метод добавляет новое глобальное свойство
        /// </summary>
        public global_prop global_prop_add(conception Conception, prop_type Prop_type, con_prop_data_type Data_type, String iname, String idesc, Boolean ivisible)
        {
            global_prop Result = null;
            if (Conception != null)
            {
                Result = global_prop_add(Conception.Id, Prop_type.Id, Data_type.Id, iname, idesc, ivisible);
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_add2");
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
        /// Метод добавляет новое глобальное свойство по свойству класса
        /// </summary>
        public global_prop global_prop_add_as_class_prop(Int64 iid_conception, Int64 iid_class_prop)
        {
            global_prop global_prop = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("global_prop_add_as_class_prop");

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
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                    if (id > 0)
                    {
                        global_prop = global_prop_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.global_prop, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            GlobalPropChangeEventArgs e = new GlobalPropChangeEventArgs(global_prop, eAction.Insert);
            GlobalPropOnChange(e);
            //Возвращаем Объект
            return global_prop;
        }

        /// <summary>
        /// Метод добавляет новое глобальное свойство по свойству класса
        /// </summary>
        public global_prop global_prop_add_as_class_prop(conception Conception, class_prop ClassProp)
        {
            global_prop Result = null;
            if (Conception != null)
            {
                Result = global_prop_add_as_class_prop(Conception.Id, ClassProp.Id);
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_add_as_class_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_add_as_class_prop");
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
        /// Метод добавляет новое глобальное свойство по свойству шаблона
        /// </summary>
        public global_prop global_prop_add_as_pos_temp_prop(Int64 iid_conception, Int64 iid_pos_temp_prop)
        {
            global_prop global_prop = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
           
            //=======================
            cmdk = CommandByKey("global_prop_add_as_pos_temp_prop");

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
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                    if (id > 0)
                    {
                        global_prop = global_prop_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.global_prop, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            GlobalPropChangeEventArgs e = new GlobalPropChangeEventArgs(global_prop, eAction.Insert);
            GlobalPropOnChange(e);
            //Возвращаем Объект
            return global_prop;
        }

        /// <summary>
        /// Метод добавляет новое глобальное свойство по свойству шаблона
        /// </summary>
        public global_prop global_prop_add_as_pos_temp_prop(conception Conception, pos_temp_prop PosTempProp)
        {
            global_prop Result = null;
            if (Conception != null)
            {
                Result = global_prop_add_as_pos_temp_prop(Conception.Id, PosTempProp.Id);
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_add_as_pos_temp_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_add_as_pos_temp_prop");
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

        #region ИЗМЕНИТЬ
        /// <summary>
        /// Метод изменяет глобальное свойство
        /// </summary>
        public global_prop global_prop_upd(Int64 iid_global_prop, Int32 iid_prop_type, Int32 iid_data_type, String iname, String idesc, Boolean ivisible)
             
        {
            global_prop global_prop = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
            
            //=======================
            cmdk = CommandByKey("global_prop_upd2");

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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Parameters["iid_prop_type"].Value = iid_prop_type;
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["ivisible"].Value = ivisible;
            
            //=======================

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    global_prop = global_prop_by_id(iid_global_prop);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_global_prop, eEntity.global_prop, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            GlobalPropChangeEventArgs e = new GlobalPropChangeEventArgs(global_prop, eAction.Update);
            GlobalPropOnChange(e);
            //Возвращаем Объект
            return global_prop;
        }

        /// <summary>
        /// Метод изменяет свойство активного представления класса
        /// </summary>
        public global_prop global_prop_upd(global_prop Global_prop)
        {

            global_prop Result = null;
            if (Global_prop != null)
            {
                Result = global_prop_upd(Global_prop.Id, Global_prop.Id_prop_type, Global_prop.Id_data_type, Global_prop.Name, Global_prop.Desc, Global_prop.Visible);
            } 
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_upd2");
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

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет глобальное свойство
        /// </summary>
        public void global_prop_del(Int64 iid_global_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            global_prop global_prop;

            //**********
            //=======================
            cmdk = CommandByKey("global_prop_del");

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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;

            //Запрос удаляемой сущности
            global_prop = global_prop_by_id(iid_global_prop);
            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_global_prop, eEntity.global_prop, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления свойства класса
            if (global_prop != null)
            {
                GlobalPropChangeEventArgs e = new GlobalPropChangeEventArgs(global_prop, eAction.Delete);
                GlobalPropOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет глобальное свойство
        /// </summary>
        public void global_prop_del(global_prop Global_Prop)
        {
            if (Global_Prop != null)
            {
                global_prop_del(Global_Prop.Id);
            }
            
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_del");
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

        #region ВЫБРАТЬ

        //*********************************************************************************************
        /// <summary>
        /// Выбор глобального свойства по идентификатру свойства
        /// </summary>
        public global_prop global_prop_by_id(Int64 iid_global_prop)
        {
            global_prop global_prop = null;

            DataTable tbl_vglobal_prop  = TableByName("vglobal_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
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
            //=======================

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vglobal_prop);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            
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

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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

        //*********************************************************************************************
        /// <summary>
        /// Лист глобальных свойств по идентификатору концепции
        /// </summary>
        public List<global_prop> global_prop_by_id_conception(Int64 iid_conception)
        {
            List<global_prop> global_prop_list = new List<global_prop>();

            
            DataTable tbl_global_prop  = TableByName("vglobal_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
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
            //=======================

            cmdk.Parameters["iid_conception"].Value = iid_conception;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_global_prop);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
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

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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

        
        //*********************************************************************************************
        /// <summary>
        /// Лист глобальных свойств по идентификатору концепции с учетом видимости
        /// </summary>
        public List<global_prop> global_prop_visible_by_id_conception(Int64 iid_conception)
        {
            List<global_prop> global_prop_list = new List<global_prop>();


            DataTable tbl_global_prop = TableByName("vglobal_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
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
            //=======================

            cmdk.Parameters["iid_conception"].Value = iid_conception;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_global_prop);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
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

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Лист глобальных свойств по идентификатору концепции с учетом видимости
        /// </summary>
        public Boolean global_prop_visible_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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

        
        //*********************************************************************************************
        /// <summary>
        /// Лист глобальных свойств по идентификатору концепции с учетом видимости и допустимых для поиска
        /// </summary>
        public List<global_prop> global_prop_for_search_by_id_conception(Int64 iid_conception)
        {
            List<global_prop> global_prop_list = new List<global_prop>();


            DataTable tbl_global_prop = TableByName("vglobal_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
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
            //=======================

            cmdk.Parameters["iid_conception"].Value = iid_conception;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_global_prop);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
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

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Лист глобальных свойств по идентификатору концепции с учетом видимости и допустимых для поиска
        /// </summary>
        public Boolean global_prop_for_search_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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




        //*********************************************************************************************
        /// <summary>
        /// Лист глобальных свойств по идентификатору класса
        /// </summary>
        public List<global_prop> global_prop_by_id_class(Int64 iid_class)
        {
            List<global_prop> global_prop_list = new List<global_prop>();


            DataTable tbl_global_prop  = TableByName("vglobal_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
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
            //=======================

            cmdk.Parameters["iid_class"].Value = iid_class;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_global_prop);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
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

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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

        
        //*********************************************************************************************
        /// <summary>
        /// Выбор глобального свойства по идентификатру определяющего свойства класса
        /// </summary>
        public global_prop global_prop_by_id_class_prop_definition(Int64 iid_class_prop_definition)
        {
            global_prop global_prop = null;

            DataTable tbl_vglobal_prop  = TableByName("vglobal_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
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
            //=======================

            cmdk.Parameters["iid_class_prop_definition"].Value = iid_class_prop_definition;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vglobal_prop);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

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

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_by_id_class_prop_definition(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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
        
        //*********************************************************************************************
        /// <summary>
        /// Лист глобальных свойств по идентификатору шаблона позиции
        /// </summary>
        public List<global_prop> global_prop_by_id_pos_temp(Int64 iid_pos_temp)
        {
            List<global_prop> global_prop_list = new List<global_prop>();


            DataTable tbl_global_prop  = TableByName("vglobal_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
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
            //=======================

            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_global_prop);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
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

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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

        //*********************************************************************************************
        /// <summary>
        /// Выбор глобального свойства по идентификатру свойства шаблона позиции
        /// </summary>
        public global_prop global_prop_by_id_pos_temp_prop(Int64 iid_pos_temp_prop)
        {
            global_prop global_prop = null;

            DataTable tbl_vglobal_prop  = TableByName("vglobal_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
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
            //=======================

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vglobal_prop);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

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

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_by_id_pos_temp_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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

        #endregion

        #region ВЫБРАТЬ ПО КРИТЕРИЯМ
        /// <summary>
        /// Лист глобальных свойств концепции по строкгому соотвествию имени
        /// </summary>
        public global_prop global_prop_by_name(Int64 iid_conception , String iname)
        {
            global_prop global_prop = null;

            DataTable tbl_vglobal_prop  = TableByName("vglobal_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("global_prop_by_name");

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
            cmdk.Parameters["iname"].Value = iname;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vglobal_prop);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_vglobal_prop.Rows.Count > 0)
            {
                global_prop = new global_prop(tbl_vglobal_prop.Rows[0]);
            }
            return global_prop;
        }

        /// <summary>
        /// Выбор глобального свойства по идентификатру свойства
        /// </summary>
        public global_prop global_prop_by_name(conception Conception, String iname)
        {
            return global_prop_by_name(Conception.Id, iname);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_by_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_by_name");
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
        /// Метод определяет актуальность глобального свойства концепции
        /// </summary>
        public eEntityState global_prop_is_actual(Int64 iid, DateTime timestamp_entity)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("global_prop_is_actual");

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

            cmdk.Parameters["iid"].Value = iid;
            cmdk.Parameters["timestamp_entity"].Value = timestamp_entity;
            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Метод определяет актуальность глобального свойства концепции
        /// </summary>
        public eEntityState global_prop_is_actual(global_prop GlobalProp)
        {
            return global_prop_is_actual(GlobalProp.Id, GlobalProp.Timestamp); ;
        }
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ СВОЙСТВАМИ КЛАССОВ

        /// <summary>
        /// Делегат события изменения глобального свойства
        /// </summary>
        public delegate void GlobalPropChangeEventHandler(Object sender, GlobalPropChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении глобального свойства
        /// </summary>
        public event GlobalPropChangeEventHandler GlobalPropChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения глобального свойства
        /// </summary>
        protected virtual void GlobalPropOnChange(GlobalPropChangeEventArgs e)
        {
            GlobalPropChangeEventHandler temp = GlobalPropChange;
            if (temp != null)
            {
                temp(this, e);
            }
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(e);
            JournalMessageOnReceived(me);
        }
        #endregion
    }
}
