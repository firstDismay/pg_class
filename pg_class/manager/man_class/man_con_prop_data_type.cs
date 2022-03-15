using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Npgsql;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

namespace pg_class
{
    public partial class manager
    {

        #region УПРАВЛЕНИЕ НАЗНАЧЕНИЯМИ ТИПОВ ДАННЫХ СВОЙСТВ НА КОНЦЕПЦИЮ

        #region ВКЛЮЧИТЬ
        /// <summary>
        /// Метод добавляет выбранный тип данных в указанную концепцию
        /// </summary>
        public void Con_prop_data_type_add(Int64 iid_conception, Int32 iid_prop_data_type, String ialias, Int32 isort)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("con_prop_data_type_add");

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
            cmdk.Parameters["ialias"].Value = ialias;
            cmdk.Parameters["isort"].Value = isort;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_prop_data_type, eEntity.con_prop_data_type, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Вызов события изменения списка вложенности
            Con_Prop_Data_TypeListChangeEventArgs e;
            e = new Con_Prop_Data_TypeListChangeEventArgs(iid_conception, iid_prop_data_type, eActionRuleList.addrule);
            OnCon_Prop_Data_TypeListChange(e);
        }

        /// <summary>
        /// Метод добавляет выбранный тип данных в указанную концепцию
        /// </summary>
        public void Con_prop_data_type_add(con_prop_data_type Con_prop_data_type)
        {
            Con_prop_data_type_add(Con_prop_data_type.Id_conception, Con_prop_data_type.Id, Con_prop_data_type.Alias, Con_prop_data_type.Sort);
        }

        /// <summary>
        /// Метод добавляет выбранный тип данных в указанную концепцию
        /// </summary>
        public void Con_prop_data_type_add(conception Conception, prop_data_type Con_prop_data_type, String Alias, Int32 Sort)
        {
            Con_prop_data_type_add(Conception.Id, Con_prop_data_type.Id, Alias, Sort);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Con_prop_data_type_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("con_prop_data_type_add");
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
        /// Метод изменяет параметры назначения типа данных в указанной концепции
        /// </summary>
        public con_prop_data_type con_prop_data_type_upd(Int64 iid_conception, Int32 iid_prop_data_type, String ialias, Int32 isort)
        {
            con_prop_data_type con_prop_data_type = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("con_prop_data_type_upd");

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
            cmdk.Parameters["ialias"].Value = ialias;
            cmdk.Parameters["isort"].Value = isort;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    con_prop_data_type = Con_prop_data_type_by_id(iid_conception, iid_prop_data_type);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_prop_data_type, eEntity.con_prop_data_type, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Вызов события изменения элемента назначения типа данных на концепцию
            Con_Prop_Data_TypeChangeEventArgs e;
            e = new Con_Prop_Data_TypeChangeEventArgs(iid_conception, iid_prop_data_type, eActionRuleList.updaterule);
            OnCon_Prop_Data_TypeChange(e);
            //Возвращаем Объект
            return con_prop_data_type;
        }

        /// <summary>
        /// Метод изменяет параметры назначения типа данных в указанной концепции
        /// </summary>
        public void con_prop_data_type_upd(con_prop_data_type Con_prop_data_type)
        {
            con_prop_data_type_upd(Con_prop_data_type.Id_conception, Con_prop_data_type.Id, Con_prop_data_type.Alias, Con_prop_data_type.Sort);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean con_prop_data_type_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("con_prop_data_type_upd");
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

        #region ИСКЛЮЧИТЬ
        /// <summary>
        /// Метод удаляет назначение типа данных из указанной концепции
        /// </summary>
        public void Con_prop_data_type_del(Int64 iid_conception, Int32 iid_prop_data_type)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("con_prop_data_type_del");

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

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_prop_data_type, eEntity.con_prop_data_type, error, desc_error, eAction.Delete, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Вызов события изменения списка вложенности
            Con_Prop_Data_TypeListChangeEventArgs e;
            e = new Con_Prop_Data_TypeListChangeEventArgs(iid_conception, iid_prop_data_type, eActionRuleList.delrule);
            OnCon_Prop_Data_TypeListChange(e);
        }


        /// <summary>
        /// Метод удаляет назначение типа данных из указанной концепции
        /// </summary>
        public void Con_prop_data_type_del(con_prop_data_type Con_prop_data_type)
        {
            Con_prop_data_type_del(Con_prop_data_type.Id_conception, Con_prop_data_type.Id);
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Con_prop_data_type_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("con_prop_data_type_del");
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
        /// <summary>
        /// Метод возвращает назначение типа данных на указанную концепцию по идентификатору концепции и типа данных
        /// </summary>
        public con_prop_data_type Con_prop_data_type_by_id(Int64 iid_conception, Int32 iid_prop_data_type)
        {
            con_prop_data_type prop_data_type = null;

            DataTable tbl_rulel2  = TableByName("vcon_prop_data_type");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("con_prop_data_type_by_id");

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

            cmdk.Fill(tbl_rulel2);
            
            if (tbl_rulel2.Rows.Count > 0)
            {
                prop_data_type = new con_prop_data_type(tbl_rulel2.Rows[0]);
            }

            return prop_data_type;
        }


        /// <summary>
        /// Метод возвращает назначение типа данных на указанную концепцию по идентификатору свойства
        /// </summary>
        public con_prop_data_type Con_prop_data_type_by_id(class_prop Class_prop)
        {
            return Con_prop_data_type_by_id(Class_prop.Id_conception, Class_prop.Id_data_type);
        }

        /// <summary>
        /// Метод возвращает назначение типа данных на указанную концепцию по идентификатору свойства
        /// </summary>
        public con_prop_data_type Con_prop_data_type_by_id(object_prop Object_prop)
        {
            return Con_prop_data_type_by_id(Object_prop.Id_conception, Object_prop.Id_data_type);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Con_prop_data_type_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("con_prop_data_type_by_id");
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
        /// Метод возвращает полный перечень доступных назначений типов данных для указанной концепции
        /// </summary>
        public List<con_prop_data_type> Con_prop_data_type_full_by_id_con(Int64 iid_conception)
        {
            List<con_prop_data_type> rule_list = new List<con_prop_data_type>();


            DataTable tbl_rule_list  = TableByName("vcon_prop_data_type");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("con_prop_data_type_full_by_id_con");

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

            cmdk.Fill(tbl_rule_list);
            
            con_prop_data_type rule;
            if (tbl_rule_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule_list.Rows)
                {
                    rule = new con_prop_data_type(dr);
                    rule_list.Add(rule);
                }
            }
            return rule_list;
        }

        /// <summary>
        /// Метод возвращает полный перечень доступных назначений типов данных для указанной концепции
        /// </summary>
        public List<con_prop_data_type> Con_prop_data_type_full_by_id_con(conception Conception)
        {
            return Con_prop_data_type_full_by_id_con(Conception.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Con_prop_data_type_full_by_id_con(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("con_prop_data_type_full_by_id_con");
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
        /// Метод возвращает список назначений типов данных для указанной концепции по идентификатору типа свойства
        /// </summary>
        public List<con_prop_data_type> Con_prop_data_type_by_id_prop_type(Int64 iid_conception, Int32 iid_prop_type)
        {
            List<con_prop_data_type> rule_list = new List<con_prop_data_type>();


            DataTable tbl_rule_list  = TableByName("vcon_prop_data_type");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("con_prop_data_type_by_id_prop_type");

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

            cmdk.Fill(tbl_rule_list);
            
            con_prop_data_type rule;
            if (tbl_rule_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule_list.Rows)
                {
                    rule = new con_prop_data_type(dr);
                    rule_list.Add(rule);
                }
            }
            return rule_list;
        }

        /// <summary>
        /// Метод возвращает список назначений типов данных для указанной концепции по идентификатору типа свойства
        /// </summary>
        public List<con_prop_data_type> Con_prop_data_type_by_id_prop_type(conception Conception, prop_type Prop_type)
        {
            return Con_prop_data_type_by_id_prop_type(Conception.Id, Prop_type.Id);
        }

        /// <summary>
        /// Метод возвращает список назначений типов данных для указанной концепции по идентификатору типа свойства
        /// </summary>
        public List<con_prop_data_type> Con_prop_data_type_by_id_prop_type(Int64 iid_conception, prop_type Prop_type)
        {
            return Con_prop_data_type_by_id_prop_type(iid_conception, Prop_type.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Con_prop_data_type_by_id_prop_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("con_prop_data_type_by_id_prop_type");
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

        #endregion

        #region СОБЫТИЕ ИЗМЕНЕНИЯ СПИСКА НАЗНАЧЕНИЯ ТИПОВ ДАННЫХ КОНЦЕПЦИИ

        /// <summary>
        /// Делегат события изменения списка назначенных типоа данных концепции
        /// </summary>
        public delegate void Con_Prop_Data_TypeListChangeEventHandler(Object sender, Con_Prop_Data_TypeListChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении списка назначений типов данных концепции
        /// </summary>
        public event Con_Prop_Data_TypeListChangeEventHandler Con_Prop_Data_TypeListChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события
        /// </summary>
        protected virtual void OnCon_Prop_Data_TypeListChange(Con_Prop_Data_TypeListChangeEventArgs e)
        {
            Con_Prop_Data_TypeListChangeEventHandler temp = this.Con_Prop_Data_TypeListChange;

            if (temp != null)
            {
                temp(this, e);
            }
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(e);
            JournalMessageOnReceived(me);
        }

        #endregion

        #region СОБЫТИЕ ИЗМЕНЕНИЯ НАЗНАЧЕНИЯ ТИПА ДАННЫХ НА КОНЦЕПЦИЮ

        /// <summary>
        /// Делегат события изменения назначения типа данных концепции
        /// </summary>
        public delegate void Con_Prop_Data_TypeChangeEventHandler(Object sender, Con_Prop_Data_TypeChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении элемента назначения типа данных концепции
        /// </summary>
        public event Con_Prop_Data_TypeChangeEventHandler Con_Prop_Data_TypeChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события
        /// </summary>
        protected virtual void OnCon_Prop_Data_TypeChange(Con_Prop_Data_TypeChangeEventArgs e)
        {
            Con_Prop_Data_TypeChangeEventHandler temp = this.Con_Prop_Data_TypeChange;

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
