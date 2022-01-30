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
        #region МЕТОДЫ КЛАССА: УПРАВЛЕНИЯ СПИСКОМ ПРАВИЛ ВЛОЖЕННОСТИ УРОВНЯ 1 ГРУППА НА ШАБЛОН

        #region ВКЛЮЧИТЬ
        /// <summary>
        /// Метод добавляет разрешающее правило уровня 1 группа на шаблон
        /// </summary>
        public void rulel1_group_on_pos_temp_add(Int64 iid_group, Int64 iid_pos_temp)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("rulel1_group_on_pos_temp_add");

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

            cmdk.Parameters["iid_group"].Value = iid_group;
            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;

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
                    JournalEventArgs me = new JournalEventArgs(iid_group, eEntity.rulel1_group_on_pos_temp, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Вызов события изменения списка правил вложенности вложенности
            Rulel1_Group_On_Pos_tempListChangeEventArgs e;
            e = new Rulel1_Group_On_Pos_tempListChangeEventArgs(iid_group, iid_pos_temp, eActionRuleList.addrule);
            OnRulel1_Group_On_Pos_tempListChange(e);
        }

        /// <summary>
        /// Метод добавляет разрешающее правило уровня 1 группа на шаблон
        /// </summary>
        public void rulel1_group_on_pos_temp_add(group Group, pos_temp Pos_temp)
        {
            rulel1_group_on_pos_temp_add(Group.Id, Pos_temp.Id);
        }


        /// <summary>
        /// Метод добавляет разрешающее правило уровня 1 группа на шаблон
        /// </summary>
        public void rulel1_group_on_pos_temp_add(rulel1_group_on_pos_temp RuleL1)
        {
            rulel1_group_on_pos_temp_add(RuleL1.Id_group, RuleL1.Id_pos_temp);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel1_group_on_pos_temp_add");
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
        /// Метод удаляет разрешающее правило уровня 1 группа на шаблон
        /// </summary>
        public void rulel1_group_on_pos_temp_del(Int64 iid_group, Int64 iid_pos_temp)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("rulel1_group_on_pos_temp_del");

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

            cmdk.Parameters["iid_group"].Value = iid_group;
            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;

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
                    JournalEventArgs me = new JournalEventArgs(iid_pos_temp, eEntity.rulel1_group_on_pos_temp, error, desc_error, eAction.Delete, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Вызов события изменения списка правил вложенности вложенности
            Rulel1_Group_On_Pos_tempListChangeEventArgs e;
            e = new Rulel1_Group_On_Pos_tempListChangeEventArgs(iid_group, iid_pos_temp, eActionRuleList.delrule);
            OnRulel1_Group_On_Pos_tempListChange(e);
        }



        /// <summary>
        /// Метод удаляет разрешающее правило уровня 1 группа на шаблон
        /// </summary>
        public void rulel1_group_on_pos_temp_del(group Group, pos_temp Pos_temp)
        {
            rulel1_group_on_pos_temp_del(Group.Id, Pos_temp.Id);
        }

        /// <summary>
        /// Метод удаляет разрешающее правило уровня 1 группа на шаблон
        /// </summary>
        public void rulel1_group_on_pos_temp_del(rulel1_group_on_pos_temp RuleL1)
        {
            rulel1_group_on_pos_temp_del(RuleL1.Id_group, RuleL1.Id_pos_temp);
        }

        
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel1_group_on_pos_temp_del");
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

        #region ВЫБРАТЬ ПРАВИЛА ВЛОЖЕННОСТИ УРОВНЯ 1 ГРУППА НА ШАБЛОН
        //*********************************************************************************************
        /// <summary>
        /// Правило уровня 1 группа на шаблон по идентификатору правила
        /// </summary>
        public rulel1_group_on_pos_temp rulel1_group_on_pos_temp_by_id(Int64 iid_group, Int64 iid_pos_temp)
        {
            rulel1_group_on_pos_temp rulel1 = null;
            
            DataTable tbl_rl1  = TableByName("vrulel1_group_on_pos_temp");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("rulel1_group_on_pos_temp_by_id");

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

            cmdk.Parameters["iid_group"].Value = iid_group;
            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;

            cmdk.Fill(tbl_rl1);
            
            if (tbl_rl1.Rows.Count > 0)
            {
                rulel1 = new rulel1_group_on_pos_temp(tbl_rl1.Rows[0]);
            }
            return rulel1;
        }


        /// <summary>
        /// Правило уровня 1 группа на шаблон по идентификатору правила
        /// </summary>
        public rulel1_group_on_pos_temp rulel1_group_on_pos_temp_by_id(group Group, pos_temp Pos_temp)
        {
            return rulel1_group_on_pos_temp_by_id(Group.Id, Pos_temp.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel1_group_on_pos_temp_by_id");
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
        /// Лист правил уровня 1 группа на шаблон по идентификатору группы
        /// </summary>
        public List<rulel1_group_on_pos_temp> rulel1_group_on_pos_temp_by_id_group(Int64 iid_group)
        {
            List<rulel1_group_on_pos_temp> rulel1_list = new List<rulel1_group_on_pos_temp>();


            DataTable tbl_rulel1  = TableByName("vrulel1_group_on_pos_temp");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("rulel1_group_on_pos_temp_by_id_group");

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

            cmdk.Parameters["iid_group"].Value = iid_group;

            cmdk.Fill(tbl_rulel1);
            
            rulel1_group_on_pos_temp rl1;
            if (tbl_rulel1.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rulel1.Rows)
                {
                    rl1 = new rulel1_group_on_pos_temp(dr);
                    rulel1_list.Add(rl1);
                }
            }
            return rulel1_list;
        }

        /// <summary>
        /// Лист правил уровня 1 группа на шаблон по идентификатору группы
        /// </summary>
        public List<rulel1_group_on_pos_temp> rulel1_group_on_pos_temp_by_id_group(group Group)
        {
            return rulel1_group_on_pos_temp_by_id_group(Group.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel1_group_on_pos_temp_by_id_group");
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
        /// Лист правил уровня 1 группа на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<rulel1_group_on_pos_temp> rulel1_group_on_pos_temp_by_id_pos_temp(Int64 iid_pos_temp)
        {
            List<rulel1_group_on_pos_temp> rulel1_list = new List<rulel1_group_on_pos_temp>();

            DataTable tbl_rulel1  = TableByName("vrulel1_group_on_pos_temp");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("rulel1_group_on_pos_temp_by_id_pos_temp");

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

            cmdk.Fill(tbl_rulel1);
            
            rulel1_group_on_pos_temp rl1;
            if (tbl_rulel1.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rulel1.Rows)
                {
                    rl1 = new rulel1_group_on_pos_temp(dr);
                    rulel1_list.Add(rl1);
                }
            }
            return rulel1_list;
        }

        /// <summary>
        /// Лист правил уровня 1 группа на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<rulel1_group_on_pos_temp> rulel1_group_on_pos_temp_by_id_pos_temp(pos_temp Pos_temp)
        {
            return rulel1_group_on_pos_temp_by_id_pos_temp(Pos_temp.Id);
        }

        /// <summary>
        /// Лист правил уровня 1 группа на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<rulel1_group_on_pos_temp> rulel1_group_on_pos_temp_by_id_pos_temp(position Position)
        {
            return rulel1_group_on_pos_temp_by_id_pos_temp(Position.Id_pos_temp);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel1_group_on_pos_temp_by_id_pos_temp");
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

        #region ВЫБРАТЬ РАЗРЕШЕНИЯ ВЛОЖЕННОСТИ УРОВНЯ 1 ГРУППА НА ШАБЛОН

        /// <summary>
        /// Лист разрешений уровня 1 группа на шаблон по идентификатору группы
        /// </summary>
        public List<rulel1_group_on_pos_temp_access> rulel1_group_on_pos_temp_access_by_id_group(Int64 iid_group)
        {
            List<rulel1_group_on_pos_temp_access> rulel1_list = new List<rulel1_group_on_pos_temp_access>();


            DataTable tbl_rulel1  = TableByName("vrulel1_group_on_pos_temp_tbl_access");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("rulel1_group_on_pos_temp_access_by_id_group");

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

            cmdk.Parameters["iid_group"].Value = iid_group;

            cmdk.Fill(tbl_rulel1);
            
            rulel1_group_on_pos_temp_access rl1;
            if (tbl_rulel1.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rulel1.Rows)
                {
                    rl1 = new rulel1_group_on_pos_temp_access(dr);
                    rulel1_list.Add(rl1);
                }
            }
            return rulel1_list;
        }

        /// <summary>
        /// Лист разрешений уровня 1 группа на шаблон по идентификатору группы
        /// </summary>
        public List<rulel1_group_on_pos_temp_access> rulel1_group_on_pos_temp_access_by_id_group(group Group)
        {
            return rulel1_group_on_pos_temp_access_by_id_group(Group.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_access_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel1_group_on_pos_temp_access_by_id_group");
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
        /// Лист разрешений уровня 1 группа на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<rulel1_group_on_pos_temp_access> rulel1_group_on_pos_temp_access_by_id_pos_temp(Int64 iid_pos_temp)
        {
            List<rulel1_group_on_pos_temp_access> rulel1_list = new List<rulel1_group_on_pos_temp_access>();

            DataTable tbl_rulel1  = TableByName("vrulel1_group_on_pos_temp_tbl_access");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("rulel1_group_on_pos_temp_access_by_id_pos_temp");

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

            cmdk.Fill(tbl_rulel1);
            
            rulel1_group_on_pos_temp_access rl1;
            if (tbl_rulel1.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rulel1.Rows)
                {
                    rl1 = new rulel1_group_on_pos_temp_access(dr);
                    rulel1_list.Add(rl1);
                }
            }
            return rulel1_list;
        }

        /// <summary>
        /// Лист правил уровня 1 группа на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<rulel1_group_on_pos_temp_access> rulel1_group_on_pos_temp_access_by_id_pos_temp(pos_temp Pos_temp)
        {
            return rulel1_group_on_pos_temp_access_by_id_pos_temp(Pos_temp.Id);
        }

        /// <summary>
        /// Лист правил уровня 1 группа на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<rulel1_group_on_pos_temp_access> rulel1_group_on_pos_temp_access_by_id_pos_temp(position Position)
        {
            return rulel1_group_on_pos_temp_access_by_id_pos_temp(Position.Id_pos_temp);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_access_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel1_group_on_pos_temp_access_by_id_pos_temp");
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

        #region МЕТОДЫ ГРУПП ДОСТУПНЫХ ИЛИ НАЗНАЧЕННЫХ ПРАИЛАМИ ВЛОЖЕННОСТИ УРОВНЯ 1 ГРУППА НА ШАБЛОН
        //*********************************************************************************************
        /// <summary>
        /// Лист разрешенных групп на основе разрешения уровня 1 группа на шаблон по идентификатору позиции
        /// </summary>
        public List<group> group_allowed_rl1_by_id_position(Int64 iid_position)
        {
            List<group> group_list = new List<group>();

            DataTable tbl_group  = TableByName("vgroup");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("group_allowed_rl1_by_id_position");

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

            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_group);
            
            group gt;
            if (tbl_group.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_group.Rows)
                {
                    gt = new group(dr);
                    group_list.Add(gt);
                }
            }

            return group_list;
        }

        /// <summary>
        /// Лист разрешенных групп на основе разрешения уровня 1 группа на шаблон по идентификатору позиции
        /// </summary>
        public List<group> group_allowed_rl1_by_id_position(position Position)
        {
            return group_allowed_rl1_by_id_position(Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_allowed_rl1_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("group_allowed_rl1_by_id_position");
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
        /// Лист разрешенных групп на основе разрешения уровня 1 группа на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<group> group_allowed_rl1_by_id_pos_temp(Int64 iid_pos_temp)
        {
            List<group> group_list = new List<group>();


            DataTable tbl_group  = TableByName("vgroup");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("group_allowed_rl1_by_id_pos_temp");

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

            cmdk.Fill(tbl_group);
            
            group gt;
            if (tbl_group.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_group.Rows)
                {
                    gt = new group(dr);
                    group_list.Add(gt);
                }
            }

            return group_list;
        }

        /// <summary>
        /// Лист разрешенных групп на основе разрешения уровня 1 группа на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<group> group_allowed_rl1_by_id_pos_temp(pos_temp Pos_temp)
        {
            return group_allowed_rl1_by_id_pos_temp(Pos_temp.Id);
        }
                

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_allowed_rl1_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("group_allowed_rl1_by_id_pos_temp");
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
        /// Лист назначенных групп на основе разрешения уровня 1 группа на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<group> group_assigned_rl1_by_id_pos_temp(Int64 iid_pos_temp)
        {
            List<group> group_list = new List<group>();


            DataTable tbl_group  = TableByName("vgroup");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("group_assigned_rl1_by_id_pos_temp");

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

            cmdk.Fill(tbl_group);
            
            group gt;
            if (tbl_group.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_group.Rows)
                {
                    gt = new group(dr);
                    group_list.Add(gt);
                }
            }

            return group_list;
        }

        /// <summary>
        /// Лист назначенных групп на основе разрешения уровня 1 группа на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<group> group_assigned_rl1_by_id_pos_temp(pos_temp Pos_temp)
        {
            return group_assigned_rl1_by_id_pos_temp(Pos_temp.Id);
        }

        /// <summary>
        /// Лист назначенных групп на основе разрешения уровня 1 группа на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<group> group_assigned_rl1_by_id_pos_temp(position Position)
        {
            return group_assigned_rl1_by_id_pos_temp(Position.Id_pos_temp);
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_assigned_rl1_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("group_assigned_rl1_by_id_pos_temp");
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
        /// Лист назначенных групп на основе разрешения уровня 1 группа на шаблон по идентификатору позиции
        /// </summary>
        public List<group> group_assigned_rl1_by_id_position(Int64 iid_position)
        {
            List<group> group_list = new List<group>();


            DataTable tbl_group = TableByName("vgroup");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("group_assigned_rl1_by_id_position");

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

            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_group);
            
            group gt;
            if (tbl_group.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_group.Rows)
                {
                    gt = new group(dr);
                    group_list.Add(gt);
                }
            }

            return group_list;
        }

        /// <summary>
        /// Лист назначенных групп на основе разрешения уровня 1 группа на шаблон по идентификатору позиции
        /// </summary>
        public List<group> group_assigned_rl1_by_id_position(position Position)
        {
            return group_assigned_rl1_by_id_position(Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_assigned_rl1_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("group_assigned_rl1_by_id_position");
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

        #region МЕТОДЫ ШАБЛОНОВ ДОСТУПНЫХ ИЛИ НАЗНАЧЕННЫХ ПРАИЛАМИ ВЛОЖЕННОСТИ УРОВНЯ 1 ГРУППА НА ШАБЛОН
        /// <summary>
        /// Метод возвращает список шаблонов которым разрешена указанная группа 
        /// на основе разрешений уровня 1 группа на шаблон по идентификатору шаблона
        /// </summary>
        public List<pos_temp> pos_temp_allowed_rl1_by_id_group(Int64 iid_group)
        {
            List<pos_temp> pos_temp_list = new List<pos_temp>();

            DataTable tbl_pos_temp  = TableByName("vpos_temp");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_allowed_rl1_by_id_group");

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

            cmdk.Parameters["iid_group"].Value = iid_group;

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
        /// Метод возвращает список шаблонов которым разрешена указанная группа 
        /// на основе разрешений уровня 1 группа на шаблон по идентификатору шаблона
        /// </summary>
        public List<pos_temp> pos_temp_allowed_rl1_by_id_group(group Group)
        {
            return pos_temp_allowed_rl1_by_id_group(Group.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_allowed_rl1_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_allowed_rl1_by_id_group");
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
        /// Метод возвращает список шаблонов которым назнечена указанная группа 
        /// на основе разрешений уровня 1 группа на шаблон по идентификатору шаблона
        /// </summary>
        public List<pos_temp> pos_temp_assigned_rl1_by_id_group(Int64 iid_group)
        {
            List<pos_temp> pos_temp_list = new List<pos_temp>();

            DataTable tbl_pos_temp  = TableByName("vpos_temp");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_assigned_rl1_by_id_group");

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

            cmdk.Parameters["iid_group"].Value = iid_group;

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
        /// Метод возвращает список шаблонов которым назнечена указанная группа 
        /// на основе разрешений уровня 1 группа на шаблон по идентификатору шаблона
        /// </summary>
        public List<pos_temp> pos_temp_assigned_rl1_by_id_group(group Group)
        {
            return pos_temp_assigned_rl1_by_id_group(Group.Id);
        }

        /// <summary>
        /// Метод возвращает список шаблонов которым назнечена указанная группа 
        /// на основе разрешений уровня 1 группа на шаблон по идентификатору шаблона
        /// </summary>
        public List<pos_temp> pos_temp_assigned_rl1_by_id_group(vclass Class)
        {
            return pos_temp_assigned_rl1_by_id_group(Class.Id_group);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_assigned_rl1_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_assigned_rl1_by_id_group");
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

        #region МЕТОДЫ ПРОВЕРКИ РАЗРЕШЕНИЙ
        //*********************************************************************************************
        /// <summary>
        /// Метод определяет наличие разрешения RL1 группа на шаблон для переданной пары
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_check_access(Int64 iid_pos_temp, Int64 iid_group)
        {
            //=======================
            NpgsqlCommandKey cmdk;
            //**********

            //=======================
            cmdk = CommandByKey("rulel1_group_on_pos_temp_check_access");

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
            cmdk.Parameters["iid_group"].Value = iid_group;

            //Начало транзакции
            return (Boolean)cmdk.ExecuteScalar();
        }

        /// <summary>
        /// Метод определяет наличие разрешения RL1 группа на шаблон для переданной пары
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_check_access(pos_temp Pos_temp, group Group)
        {
            return rulel1_group_on_pos_temp_check_access(Pos_temp.Id, Group.Id);
        }
        #endregion

        #region СОБЫТИЕ ИЗМЕНЕНИЯ СПИСКА ОГРАНИЧЕНИЯ ВЛОЖЕННОСТИ

        /// <summary>
        /// Делегат события изменения
        /// </summary>
        public delegate void Rulel1_Group_On_Pos_tempListChangeEventHandler(Object sender, Rulel1_Group_On_Pos_tempListChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении списка разрешений уровня 1 группа на шаблон
        /// </summary>
        public event Rulel1_Group_On_Pos_tempListChangeEventHandler Rulel1_Group_On_Pos_tempListChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события списка правил вложенности объектов
        /// </summary>
        protected virtual void OnRulel1_Group_On_Pos_tempListChange(Rulel1_Group_On_Pos_tempListChangeEventArgs e)
        {
            Rulel1_Group_On_Pos_tempListChangeEventHandler temp = this.Rulel1_Group_On_Pos_tempListChange;

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
