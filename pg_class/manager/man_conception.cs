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
        private void init_conception()
        {
            conception_list_state = eStatus.on;
        }

        #region МЕТОДЫ КЛАССА: КОНЦЕПЦИИ

        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новую концепцию
        /// </summary>
        public conception conception_add(String iname, String idesc)
        {
            conception conception = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("con_add");

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
                        conception = conception_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.conception, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Генерируем событие изменения концепции
            ConceptionChangeEventArgs e = new ConceptionChangeEventArgs(conception, eAction.Insert);
            ConceptionOnChange(e);
            //Возвращаем Объект
            return conception;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean conception_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("con_add");
            if (cmdk != null)
            {
                Result =  cmdk.Access;
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
        /// Метод изменяет указанную концепцию
        /// </summary>
        public conception conception_upd( Int64 iid, String iname, String idesc, Boolean ion, Boolean ion_root_create,  Boolean idefault)
        {
            conception conception = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("con_upd2");

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
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["ion"].Value = ion;
            cmdk.Parameters["ion_root_create"].Value = ion_root_create;
            cmdk.Parameters["idefault"].Value = idefault;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                        conception = conception_by_id(iid);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid, eEntity.conception, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения концепции
            ConceptionChangeEventArgs e = new ConceptionChangeEventArgs(conception, eAction.Update);
            ConceptionOnChange(e);
            //Возвращаем Объект
            return conception;
        }

        /// <summary>
        /// Метод изменяет указанную концепцию
        /// </summary>
        public conception conception_upd(conception Conception)
        {
            //Int64 iid, String iname, String idesc, Boolean ion
            return conception_upd(Conception.Id, Conception.Name, Conception.Desc, Conception.On, Conception.On_root_create, Conception.Default_Conception);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean conception_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("con_upd2");
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
        /// Метод восстанавливает указанную концепцию
        /// </summary>
        public conception conception_restore(Int64 iid)
        {
            conception conception = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********

            //=======================
            cmdk = CommandByKey("con_restore");

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

            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    conception = conception_by_id(iid);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid, eEntity.conception, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения концепции
            //ConceptionChangeEventArgs e = new ConceptionChangeEventArgs(conception, eAction.Update);
            //ConceptionOnChange(e);
            //Возвращаем Объект
            return conception;
        }

        /// <summary>
        /// Метод восстанавливает указанную концепцию
        /// </summary>
        public conception conception_restore(conception Conception)
        {
            //Int64 iid, String iname, String idesc, Boolean ion
            return conception_restore(Conception.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean conception_restore(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("con_restore");
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
        /// Метод удаляет указаную концепцию
        /// </summary>
        public void conception_del(Int64 id)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("con_del");

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

            conception conception = conception_by_id(id);
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
                JournalEventArgs me = new JournalEventArgs(id, eEntity.conception, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие изменения концепции
            if (conception != null)
            {
                ConceptionChangeEventArgs e = new ConceptionChangeEventArgs(conception, eAction.Delete);
                ConceptionOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет указаную концепцию
        /// </summary>
        public void conception_del(conception Conception)
        {
             conception_del(Conception);
        }

            //-=ACCESS=-***********************************************************************************
            /// <summary>
            /// Проверка прав доступа к методу
            /// </summary>
            public Boolean conception_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("con_del");
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
        /// Концепция по идентификатору
        /// </summary>
        public conception conception_by_id(Int64 id)
        {
            conception conception = null;

            DataTable tbl_con  = TableByName("vconception");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("con_by_id");

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

            //DA.SelectCommand = cmdk.Cmd;

            try
            {
                cmdk.Fill(tbl_con);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_con .Rows.Count > 0)
            {
                conception = new conception(tbl_con.Rows[0]);
            }

            return conception;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean conception_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("con_by_id");
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
        /// Лист концепций 
        /// </summary>
        public List<conception> conception_by_all(eStatus status)
        {
            List<conception> con_list = new List<conception>();

            
            DataTable tbl_con  = TableByName("vconception");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("con_by_all");

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

            cmdk.Parameters["status"].Value = status.ToString("g");

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_con);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            conception con;
            if (tbl_con.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_con.Rows)
                {
                    con = new conception(dr);
                    con_list.Add(con);
                }
            }

            return con_list;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean conception_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("con_by_all");
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
        /// Концепция по умолчанию
        /// </summary>
        public conception conception_by_default()
        {
            conception conception = null;

            
            DataTable tbl_con  = TableByName("vconception");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("con_by_default");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_con);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_con.Rows.Count > 0)
            {
                conception = new conception(tbl_con.Rows[0]);
            }

            return conception;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean conception_by_default(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("con_by_defaul");
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
        /// Метод определяет актуальность состояния концепции
        /// </summary>
        public eEntityState con_is_actual(Int64 iid, DateTime mytimestamp)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("con_is_actual2");

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
            
            return  (eEntityState)is_actual;
        }

        /// <summary>
        /// Метод определяет актуальность состояния концепции
        /// </summary>
        public eEntityState con_is_actual(conception Conception)
        {
            return con_is_actual(Conception.Id, Conception.Timestamp);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean con_is_actual(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("con_is_actual2");
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

        #region РАБОТА С ЛИСТАМИ МЕНЕДЖЕРА
        /// <summary>
        /// Инициализация листа концепций
        /// </summary>
        public List<conception> conception_list_get()
        {
            return conception_by_all(conception_list_state);       
        }
        #endregion


        #endregion

        #region ПОЛЯ И ПЕРЕМЕННЫЕ КЛАССА: ШАБЛОНЫ ПОЗИЦИЙ

        private eStatus conception_list_state;

        /// <summary>
        /// Свойство определяет стутус концепций запрашиваемых в лист
        /// </summary>
        public eStatus Conception_list_state { get => conception_list_state; set => conception_list_state = value; }

        /// <summary>
        /// Лист концепций
        /// </summary>
        public List<conception> Conception_list
        { get
            {
                return conception_by_all(conception_list_state);
            }
        }

        


        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ КОНЦЕПЦИЯМИ

        /// <summary>
        /// Делегат события изменения концепции
        /// </summary>
        public delegate void ConceptionChangeEventHandler(Object sender, ConceptionChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении концепции методом доступа к БД
        /// </summary>
        public event ConceptionChangeEventHandler ConceptionChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения концепции
        /// </summary>
        protected virtual void ConceptionOnChange(ConceptionChangeEventArgs e)
        {
            ConceptionChangeEventHandler temp = ConceptionChange;
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
