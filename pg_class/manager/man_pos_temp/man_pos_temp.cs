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
using System.Windows.Forms;

namespace pg_class
{
    public partial class manager
    {
        #region МЕТОДЫ КЛАССА: ШАБЛОНЫ ПОЗИЦИЙ

        #region ДОБАВИТЬ
        
        /// <summary>
        /// Метод добавляет новый шаблон позиций
        /// </summary>
        public pos_temp pos_temp_add( String iname, Int64 iid_con, Int32 iid_prototype, Boolean inested_limit, String idesc)
        {
            pos_temp pos_temp = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_add");

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

            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["iid_con"].Value = iid_con;
            cmdk.Parameters["iid_prototype"].Value = iid_prototype;
            cmdk.Parameters["inested_limit"].Value = inested_limit;
            cmdk.Parameters["idesc"].Value = idesc;

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
                        pos_temp = pos_temp_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.pos_temp, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (pos_temp != null)
            {
                //Генерируем событие изменения концепции
                PosTempChangeEventArgs e = new PosTempChangeEventArgs(pos_temp, eAction.Insert);
                PosTempOnChange(e);
            }
            //Возвращаем Объект
            return pos_temp;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_add");
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
        /// Метод копирует указанный шаблон позиций
        /// </summary>
        public pos_temp pos_temp_copy(Int64 iid_pattern)
        {
            pos_temp pos_temp = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_copy");

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

            cmdk.Parameters["iid_pattern"].Value = iid_pattern;

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
                        pos_temp = pos_temp_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_pattern, eEntity.pos_temp, error, desc_error, eAction.Copy, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (pos_temp != null)
            {
                //Генерируем событие изменения шаблона позиции
                PosTempChangeEventArgs e = new PosTempChangeEventArgs(pos_temp, eAction.Insert);
                PosTempOnChange(e);
            }
            //Возвращаем Объект
            return pos_temp;
        }

        /// <summary>
        /// Метод копирует указанный шаблон позиций
        /// </summary>
        public pos_temp pos_temp_copy(pos_temp pos_temp_pattern)
        {
            return pos_temp_copy(pos_temp_pattern.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_copy(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_copy");
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
        /// Метод изменяет указанный указанный позиций
        /// </summary>
        public pos_temp pos_temp_upd(Int64 iid, String iname, Boolean ion, Boolean inested_limit, String idesc)
        {
            pos_temp pos_temp = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_upd");

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
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["ion"].Value = ion;
            cmdk.Parameters["inested_limit"].Value = inested_limit;
            cmdk.Parameters["idesc"].Value = idesc;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                        pos_temp = pos_temp_by_id(iid);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid, eEntity.pos_temp, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (pos_temp != null)
            {
                //Генерируем событие изменения
                PosTempChangeEventArgs e = new PosTempChangeEventArgs(pos_temp, eAction.Update);
                PosTempOnChange(e);
            }
            //Возвращаем Объект
            return pos_temp;
        }

        /// <summary>
        /// Метод изменяет указанный указанный позиций
        /// </summary>
        public pos_temp pos_temp_upd(pos_temp pos_temp) 
        {
            return pos_temp_upd(pos_temp.Id, pos_temp.Name_pos_temp, pos_temp.On, pos_temp.Nested_limit, pos_temp.Desc);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_upd");
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
        /// Метод удаляет указанный шаблон позиций
        /// </summary>
        public void pos_temp_del(Int64 id)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_del");

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

            pos_temp pos_temp = pos_temp_by_id(id);

            cmdk.Parameters["iid"].Value = id;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(id, eEntity.pos_temp, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие изменения концепции
            if (pos_temp != null)
            { 
                PosTempChangeEventArgs e = new PosTempChangeEventArgs(pos_temp, eAction.Delete);
                PosTempOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет указанный шаблон позиций
        /// </summary>
        public void pos_temp_del(pos_temp pos_temp)
        {
            pos_temp_del(pos_temp.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            cmdk = CommandByKey("pos_temp_del");
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
        /// Шаблонов позиции по идентификатору
        /// </summary>
        public pos_temp pos_temp_by_id(Int64 id)
        {
            pos_temp pos_temp = null;

            DataTable tbl_pos_temp  = TableByName("vpos_temp");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_by_id");

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

            cmdk.Parameters["iid"].Value = id;
            
            cmdk.Fill(tbl_pos_temp);
            
            if (tbl_pos_temp.Rows.Count > 0)
            {
                pos_temp = new pos_temp(tbl_pos_temp.Rows[0]);
            }

            return pos_temp;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_by_id");
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
        /// Лист шаблонов позиции по идентификатору текущего шаблона
        /// </summary>
        public List<pos_temp> pos_temp_nestedlist_by_id(Int64 id, Int64 id_con, eStatus status=eStatus.all, Boolean ignore_nested_limit = false)
        {
            List<pos_temp>  pos_temp_list = new List<pos_temp>();
            DataTable tbl_pos_temp  = TableByName("vpos_temp");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_nestedlist_by_id");

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

            cmdk.Parameters["iid"].Value = id;
            cmdk.Parameters["iid_con"].Value = id_con;
            cmdk.Parameters["status"].Value = status.ToString("g");
            cmdk.Parameters["ignore_nested_limit"].Value = ignore_nested_limit;
            
            cmdk.Fill(tbl_pos_temp);
            
            pos_temp pt;
            if (tbl_pos_temp.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos_temp.Rows)
                {
                    pt = new pos_temp(dr);
                    pos_temp_list.Add(pt);
                }
            }

            return pos_temp_list;
        }

        /// <summary>
        /// Лист шаблонов позиции по идентификатору родительского шаблона
        /// </summary>
        public List<pos_temp> pos_temp_nestedlist_by_id(pos_temp pos_temp, Boolean ignore_nested_limit = false)
        {
            return pos_temp_nestedlist_by_id(pos_temp.Id, pos_temp.Id_conception, pos_temp.Nested_status, ignore_nested_limit);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nestedlist_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_nestedlist_by_id");
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
        /// Лист шаблонов позиции входящих в белый список текущего шаблона
        /// </summary>
        public List<pos_temp> pos_temp_white_nestedlist_by_id(Int64 id, Int64 id_con)
        {
            List<pos_temp> pos_temp_list = new List<pos_temp>();
            DataTable tbl_pos_temp  = TableByName("vpos_temp");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_white_nestedlist_by_id");

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

            cmdk.Parameters["iid"].Value = id;
            cmdk.Parameters["iid_con"].Value = id_con;
            
            cmdk.Fill(tbl_pos_temp);
            
            pos_temp pt;
            if (tbl_pos_temp.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos_temp.Rows)
                {
                    pt = new pos_temp(dr);
                    pos_temp_list.Add(pt);
                }
            }
            return pos_temp_list;
        }

        /// <summary>
        /// Лист шаблонов позиции входящих в белый список текущего шаблона
        /// </summary>
        public List<pos_temp> pos_temp_white_nestedlist_by_id(pos_temp pos_temp)
        {
            return pos_temp_white_nestedlist_by_id(pos_temp.Id, pos_temp.Id_conception);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_white_nestedlist_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_white_nestedlist_by_id");
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
        /// Лист шаблонов позиции по идентификатору прототипа
        /// </summary>
        public List<pos_temp> pos_temp_by_id_prototype(Int64 iid_con, Int32 iid_prototype)
        {
            List<pos_temp> pos_temp_list = new List<pos_temp>();

            DataTable tbl_pos_temp  = TableByName("vpos_temp");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_by_id_prototype");

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

            cmdk.Parameters["iid_con"].Value = iid_con;
            cmdk.Parameters["iid_prototype"].Value = iid_prototype;
            
            cmdk.Fill(tbl_pos_temp);

            pos_temp pt;
            if (tbl_pos_temp.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos_temp.Rows)
                {
                    pt = new pos_temp(dr);
                    pos_temp_list.Add(pt);
                }
            }

            return pos_temp_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_by_id_prototype(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_by_id_prototype");
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
        /// Лист всех шаблонов позиции по идентификатору прототипа, без учета концепции
        /// </summary>
        public List<pos_temp> pos_temp_by_id_prototype_all(Int32 iid_prototype)
        {
            List<pos_temp> pos_temp_list = new List<pos_temp>();

            DataTable tbl_pos_temp  = TableByName("vpos_temp");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_by_id_prototype_all");

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

            cmdk.Parameters["iid_prototype"].Value = iid_prototype;
            
            cmdk.Fill(tbl_pos_temp);           

            pos_temp pt;
            if (tbl_pos_temp.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos_temp.Rows)
                {
                    pt = new pos_temp(dr);
                    pos_temp_list.Add(pt);
                }
            }

            return pos_temp_list;
        }

        /// <summary>
        /// Лист всех шаблонов позиции по идентификатору прототипа, без учета концепции
        /// </summary>
        public List<pos_temp> pos_temp_by_id_prototype_all(pos_prototype Prototype)
        {
            return pos_temp_by_id_prototype_all(Prototype.Id);
        }

            //-=ACCESS=-***********************************************************************************
            /// <summary>
            /// Проверка прав доступа к методу
            /// </summary>
            public Boolean pos_temp_by_id_prototype_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_by_id_prototype_all");
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
        /// Лист шаблонов позиции по маске имени шаблона позиции
        /// </summary>
        public List<pos_temp> pos_temp_by_like_name(Int64 iid_con, String iname)
        {
            

            List<pos_temp> pos_temp_list = new List<pos_temp>();

            DataTable tbl_pos_temp  = TableByName("vpos_temp");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_by_like_name");

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

            cmdk.Parameters["iid_con"].Value = iid_con;
            cmdk.Parameters["iname"].Value = iname;
            
            cmdk.Fill(tbl_pos_temp);
            
            pos_temp pt;
            if (tbl_pos_temp.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos_temp.Rows)
                {
                    pt = new pos_temp(dr);
                    pos_temp_list.Add(pt);
                }
            }

            return pos_temp_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_by_like_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_by_like_name");
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
        /// Лист шаблонов позиции концепции
        /// </summary>
        public List<pos_temp> pos_temp_by_id_con(Int64 iid_con)
        {


            List<pos_temp> pos_temp_list = new List<pos_temp>();

            DataTable tbl_pos_temp  = TableByName("vpos_temp");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_by_id_con");

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

            cmdk.Parameters["iid_con"].Value = iid_con;
            
            cmdk.Fill(tbl_pos_temp);
            
            pos_temp pt;
            if (tbl_pos_temp.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos_temp.Rows)
                {
                    pt = new pos_temp(dr);
                    pos_temp_list.Add(pt);
                }
            }

            return pos_temp_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_by_id_con(out eAccess Access )
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_by_id_con");
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
        /// Лист шаблонов по идентификатору перечисления
        /// </summary>
        public List<pos_temp> pos_temp_by_id_prop_enum(Int64 iid_prop_enum)
        {
            List<pos_temp> ventity_list = new List<pos_temp>();


            DataTable tbl_entity  = TableByName("vpos_temp");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_by_id_prop_enum");

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

            cmdk.Fill(tbl_entity);

            pos_temp pt;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    pt = new pos_temp(dr);
                    ventity_list.Add(pt);
                }
            }
            return ventity_list;
        }

        /// <summary>
        /// Лист шаблонов по идентификатору перечисления
        /// </summary>
        public List<pos_temp> pos_temp_by_id_prop_enum(prop_enum Prop_enum)
        {
            return pos_temp_by_id_prop_enum(Prop_enum.Id_prop_enum);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_by_id_prop_enum(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_by_id_prop_enum");
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
        /// Лист шаблонов по идентификатору глобального свойства
        /// </summary>
        public List<pos_temp> pos_temp_by_id_global_prop(Int64 iid_global_prop)
        {
            List<pos_temp> ventity_list = new List<pos_temp>();


            DataTable tbl_entity = TableByName("vpos_temp");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_by_id_global_prop");

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
            
            cmdk.Fill(tbl_entity);
            
            pos_temp pt;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    pt = new pos_temp(dr);
                    ventity_list.Add(pt);
                }
            }
            return ventity_list;
        }

        /// <summary>
        /// Лист шаблонов по идентификатору глобального свойства
        /// </summary>
        public List<pos_temp> pos_temp_by_id_global_prop(global_prop Global_prop)
        {
            return pos_temp_by_id_global_prop(Global_prop.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_by_id_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_by_id_global_prop");
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
        /// Лист шаблонов по идентификатору элемента перечисления
        /// </summary>
        public List<pos_temp> pos_temp_by_id_prop_enum_val(Int64 iid_prop_enum_val)
        {
            List<pos_temp> ventity_list = new List<pos_temp>();


            DataTable tbl_entity  = TableByName("vpos_temp");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_by_id_prop_enum_val");

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
            
            cmdk.Fill(tbl_entity);
            
            pos_temp pt;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    pt = new pos_temp(dr);
                    ventity_list.Add(pt);
                }
            }
            return ventity_list;
        }

        /// <summary>
        /// Лист шаблонов по идентификатору элемента перечисления
        /// </summary>
        public List<pos_temp> pos_temp_by_id_prop_enum_val(prop_enum_val Prop_enum_val)
        {
            return pos_temp_by_id_prop_enum_val(Prop_enum_val.Id_prop_enum_val);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_by_id_prop_enum_val(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_by_id_prop_enum_val");
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
        /// Лист шаблонов по идентификатору типа данных свойств концепции
        /// </summary>
        public List<pos_temp> pos_temp_by_id_prop_data_type(Int64 iid_conception, Int64 iid_prop_data_type)
        {
            List<pos_temp> ventity_list = new List<pos_temp>();


            DataTable tbl_entity  = TableByName("vpos_temp");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_by_id_prop_data_type");

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

            cmdk.Fill(tbl_entity);
            
            pos_temp pt;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    pt = new pos_temp(dr);
                    ventity_list.Add(pt);
                }
            }
            return ventity_list;
        }

        /// <summary>
        /// Лист шаблонов по идентификатору типа данных свойств концепции
        /// </summary>
        public List<pos_temp> pos_temp_by_id_prop_data_type(con_prop_data_type Con_prop_data_type)
        {
            return pos_temp_by_id_prop_data_type(Con_prop_data_type.Id_conception, Con_prop_data_type.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_by_id_prop_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_by_id_prop_data_type");
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
        /// Метод определяет актуальность состояния шаблона позиции
        /// </summary>
        public eEntityState pos_temp_is_actual(Int64 iid, DateTime mytimestamp)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_is_actual2");

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
            cmdk.Parameters["mytimestamp"].Value = mytimestamp;

            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Метод определяет актуальность состояния шаблона позиции
        /// </summary>
        public eEntityState pos_temp_is_actual(pos_temp Pos_temp)
        {
            return pos_temp_is_actual(Pos_temp.Id, Pos_temp.Timestamp);
        }

        /// <summary>
        /// Метод проверяет свойства шаблона на готовность к созданию позиций
        /// </summary>
        public Boolean pos_temp_prop_check(Int64 iid_pos_temp)
        {
            Boolean Result = false;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_prop_check");

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

            //Начало транзакции
            Result = (Boolean)cmdk.ExecuteScalar();
            
            return Result;
        }

        /// <summary>
        /// Метод проверяет свойства шаблона на готовность к созданию позиций
        /// </summary>
        public Boolean pos_temp_prop_check(pos_temp PosTemp)
        {
            return pos_temp_prop_check(PosTemp.Id);
        }

        /// <summary>
        /// Метод проверяет шаблон на готовность к созданию позиций
        /// </summary>
        public Boolean pos_temp_ready_check(Int64 iid_pos_temp)
        {
            Boolean Result = false;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_ready_check");

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

            //Начало транзакции
            Result = (Boolean)cmdk.ExecuteScalar();
            
            return Result;
        }

        /// <summary>
        /// Метод проверяет шаблон на готовность к созданию позиций
        /// </summary>
        public Boolean pos_temp_ready_check(pos_temp PosTemp)
        {
            return pos_temp_ready_check(PosTemp.Id);
        }
        #endregion

        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ ШАБЛОНАМИ ПОЗИЦИЙ

        /// <summary>
        /// Делегат события изменения шаблона позиции
        /// </summary>
        public delegate void PosTempChangeEventHandler(Object sender, PosTempChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении шаблона позиции методом доступа к БД
        /// </summary>
        public event PosTempChangeEventHandler PosTempChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения шаблона позиции
        /// </summary>
        protected virtual void PosTempOnChange(PosTempChangeEventArgs e)
        {
            PosTempChangeEventHandler temp = PosTempChange;

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
