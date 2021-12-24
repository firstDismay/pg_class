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

        #region УПРАВЛЕНИЕ ПРАВИЛАМИ ВЛОЖЕННОСТИ УРОВНЯ 2 КЛАСС НА ПОЗИЦИЮ

        #region ВКЛЮЧИТЬ
        /// <summary>
        /// Метод добавляет разрешающее правило уровня 2 класс на шаблон
        /// </summary>
        public void Rulel2_class_on_position_add(Int64 iid_class, Int64 iid_position)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("rulel2_class_on_position_add");

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
            cmdk.Parameters["iid_position"].Value = iid_position;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            ////SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_position, eEntity.rulel2_class_on_position, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Вызов события изменения списка вложенности
            Rulel2_Class_On_PositionListChangeEventArgs e;
            e = new Rulel2_Class_On_PositionListChangeEventArgs(iid_position, iid_class, eActionRuleList.addrule);
            OnRulel2_Class_On_PositionListChange(e);
        }

        /// <summary>
        /// Метод добавляет разрешение на вложение для объектов классов в позиции указанного шаблона
        /// </summary>
        public void Rulel2_class_on_position_add(vclass Vclass, position Position)
        {
            Rulel2_class_on_position_add(Vclass.Id, Position.Id);
        }

        /// <summary>
        /// Метод добавляет разрешение на вложение для объектов классов в позиции указанного шаблона
        /// </summary>
        public void Rulel2_class_on_position_add(rulel2_class_on_position RuleL2)
        {
            Rulel2_class_on_position_add(RuleL2.Id_class, RuleL2.Id_position);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Rulel2_class_on_position_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel2_class_on_position_add");
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
        /// Метод удаляет разрешающее правило уровня 2 класс на позицию
        /// </summary>
        public void Rulel2_class_on_position_del(Int64 iid_class, Int64 iid_position)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("rulel2_class_on_position_del");

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
            cmdk.Parameters["iid_position"].Value = iid_position;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            ////SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_position, eEntity.rulel2_class_on_position, error, desc_error, eAction.Delete, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Вызов события изменения списка вложенности
            Rulel2_Class_On_PositionListChangeEventArgs e;
            e = new Rulel2_Class_On_PositionListChangeEventArgs(iid_position, iid_class,  eActionRuleList.delrule);
            OnRulel2_Class_On_PositionListChange(e);
        }

        /// <summary>
        /// Метод удаляет разрешающее правило уровня 2 класс на позицию
        /// </summary>
        public void Rulel2_class_on_position_del(vclass Vclass, position Position)
        {
            Rulel2_class_on_position_del(Vclass.Id, Position.Id);
        }

        /// <summary>
        /// Метод удаляет разрешающее правило уровня 2 класс на позицию
        /// </summary>
        public void Rulel2_class_on_position_del(rulel2_class_on_position RuleL2)
        {
            Rulel2_class_on_position_del(RuleL2.Id_class, RuleL2.Id_position);
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Rulel2_class_on_position_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel2_class_on_position_del");
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
        /// Метод удаляет разрешающие правила уровня 2 класс на позицию для указанной позиции
        /// </summary>
        public void Rulel2_class_on_position_all_del(Int64 iid_position)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("rulel2_class_on_position_all_del");

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

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            ////SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_position, eEntity.rulel2_class_on_position, error, desc_error, eAction.Delete, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Вызов события изменения списка вложенности
            Rulel2_Class_On_PositionListChangeEventArgs e;
            e = new Rulel2_Class_On_PositionListChangeEventArgs(iid_position, eActionRuleList.delallrule);
            OnRulel2_Class_On_PositionListChange(e);
        }

        /// <summary>
        /// Метод удаляет разрешающие правила уровня 2 класс на позицию для указанной позиции
        /// </summary>
        public void Rulel2_class_on_position_all_del(position Position)
        {
            Rulel2_class_on_position_all_del(Position.Id);
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Rulel2_class_on_position_all_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel2_class_on_position_all_del");
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

        #region ВЫБРАТЬ РАЗРЕШАЮЩИЕ ПРАИВИЛА УРОВНЯ 2 КЛАСС НА ПОЗИЦИЮ
        /// <summary>
        /// Метод возвращает правило уровня 2 класс на позицию по идентификатору правила
        /// </summary>
        public rulel2_class_on_position Rulel2_class_on_position_by_id(Int64 iid_class, Int64 iid_position)
        {
            rulel2_class_on_position rulel2 = null;

            DataTable tbl_rulel2  = TableByName("vrulel2_class_on_position");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("rulel2_class_on_position_by_id");

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
            cmdk.Parameters["iid_position"].Value = iid_position;

            //DA.SelectCommand = cmdk.Cmd;

            try
            {
                cmdk.Fill(tbl_rulel2);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            ////SetLastTimeUsing();

            if (tbl_rulel2.Rows.Count > 0)
            {
                rulel2 = new rulel2_class_on_position(tbl_rulel2.Rows[0]);
            }

            return rulel2;
        }

        /// <summary>
        /// Метод возвращает правило уровня 2 класс на позицию по идентификатору правила
        /// </summary>
        public rulel2_class_on_position Rulel2_class_on_position_by_id(vclass Class, position Position)
        { 
            return Rulel2_class_on_position_by_id(Class.Id, Position.Id);
        }

        /// <summary>
        /// Метод возвращает правило уровня 2 класс на позицию по идентификатору правила
        /// </summary>
        public rulel2_class_on_position Rulel2_class_on_position_by_id(object_general Object)
        {
            if (Object.Is_inside)
            {
                throw (new PgDataException(404, "Метод не применим для встроенных объектов входящих в состав объектных агрегатов!"));
            }
            return Rulel2_class_on_position_by_id(Object.Id_class, Object.Id_position);
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Rulel2_class_on_position_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel2_class_on_position_by_id");
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
        /// Метод возвращает правила уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<rulel2_class_on_position> Rulel2_class_on_position_by_id_position(Int64 iid_position)
        {
            List<rulel2_class_on_position> rule_list = new List<rulel2_class_on_position>();


            DataTable tbl_rule_list  = TableByName("vrulel2_class_on_position");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("rulel2_class_on_position_by_id_position");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_rule_list);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            ////SetLastTimeUsing();
            rulel2_class_on_position rule;
            if (tbl_rule_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule_list.Rows)
                {
                    rule = new rulel2_class_on_position(dr);
                    rule_list.Add(rule);
                }
            }
            return rule_list;
        }

        /// <summary>
        /// Метод возвращает правила уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<rulel2_class_on_position> Rulel2_class_on_position_by_id_position(position Position)
        {
            return Rulel2_class_on_position_by_id_position(Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Rulel2_class_on_position_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel2_class_on_position_by_id_position");
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
        /// Метод возвращает все доступные правила уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<rulel2_class_on_position> Rulel2_class_on_position_full_by_id_position(Int64 iid_position)
        {
            List<rulel2_class_on_position> rule_list = new List<rulel2_class_on_position>();


            DataTable tbl_rule_list  = TableByName("vrulel2_class_on_position");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("rulel2_class_on_position_full_by_id_position");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_rule_list);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            ////SetLastTimeUsing();
            rulel2_class_on_position rule;
            if (tbl_rule_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule_list.Rows)
                {
                    rule = new rulel2_class_on_position(dr);
                    rule_list.Add(rule);
                }
            }
            return rule_list;
        }

        /// <summary>
        /// Метод возвращает все доступные правила уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<rulel2_class_on_position> Rulel2_class_on_position_full_by_id_position(position Position)
        {
            return Rulel2_class_on_position_full_by_id_position(Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Rulel2_class_on_position_full_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel2_class_on_position_full_by_id_position");
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

        #region  ВЫБРАТЬ ИСТОРИЧЕСКИЕ ПРЕДСТАВЛЕНИЯ РАЗРЕШАЮЩИХ ПРАИВИЛ УРОВНЯ 2 КЛАСС НА ПОЗИЦИЮ (СВЕТ ЭАРЕНДИЛА)
        /// <summary>
        /// Метод возвращает историческое правило уровня 2 класс на позицию по идентификатору правила
        /// </summary>
        public rulel2_class_snapshot_on_position Rulel2_class_snapshot_on_position_by_id(Int64 iid_class, DateTime itimestamp_class, Int64 iid_position)
        {
            rulel2_class_snapshot_on_position rulel2 = null;

            DataTable tbl_rulel2  = TableByName("vrulel2_class_snapshot_on_position");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("rulel2_class_snapshot_on_position_by_id");

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
            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;

            //DA.SelectCommand = cmdk.Cmd;

            try
            {
                cmdk.Fill(tbl_rulel2);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            ////SetLastTimeUsing();

            if (tbl_rulel2.Rows.Count > 0)
            {
                rulel2 = new rulel2_class_snapshot_on_position(tbl_rulel2.Rows[0]);
            }

            return rulel2;
        }

        /// <summary>
        /// Метод возвращает историческое правило уровня 2 класс на позицию по идентификатору правила
        /// </summary>
        public rulel2_class_snapshot_on_position Rulel2_class_snapshot_on_position_by_id(vclass Class, position Position)
        {
            return Rulel2_class_snapshot_on_position_by_id(Class.Id, Class.Timestamp, Position.Id);
        }

        /// <summary>
        /// Метод возвращает историческое правило уровня 2 класс на позицию по идентификатору правила
        /// </summary>
        public rulel2_class_snapshot_on_position Rulel2_class_snapshot_on_position_by_id(object_general Object)
        {
            if (Object.Is_inside)
            {
                throw (new PgDataException(404,"Метод не применим для встроенных объектов входящих в состав объектных агрегатов!"));
            }
            return Rulel2_class_snapshot_on_position_by_id(Object.Id_class, Object.Timestamp_class, Object.Id_position);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Rulel2_class_snapshot_on_position_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel2_class_snapshot_on_position_by_id");
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
        /// Метод возвращает исторические правила уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<rulel2_class_snapshot_on_position> Rulel2_class_snapshot_on_position_by_id_position(Int64 iid_position)
        {
            List<rulel2_class_snapshot_on_position> rule_list = new List<rulel2_class_snapshot_on_position>();


            DataTable tbl_rule_list  = TableByName("vrulel2_class_snapshot_on_position");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("rulel2_class_snapshot_on_position_by_id_position");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_rule_list);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            ////SetLastTimeUsing();
            rulel2_class_snapshot_on_position rule;
            if (tbl_rule_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule_list.Rows)
                {
                    rule = new rulel2_class_snapshot_on_position(dr);
                    rule_list.Add(rule);
                }
            }
            return rule_list;
        }

        /// <summary>
        /// Метод возвращает исторические правила уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<rulel2_class_snapshot_on_position> Rulel2_class_snapshot_on_position_by_id_position(position Position)
        {
            return Rulel2_class_snapshot_on_position_by_id_position(Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Rulel2_class_snapshot_on_position_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel2_class_snapshot_on_position_by_id_position");
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

        #region  МЕТОДЫ КЛАССОВ ДОСТУПНЫХ ИЛИ НАЗНАЧЕННЫХ РАЗРЕШАЮЩИМИ ПРАВИЛАМ УРОВНЯ 2 КЛАСС НА ПОЗИЦИЮ
        /// <summary>
        /// Метод возвращает классы разрешенные с учетом правил уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<vclass> Class_allowed_rl2_by_id_position(Int64 iid_position)
        {
            List<vclass> class_list = new List<vclass>();


            DataTable tbl_class_list  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_allowed_rl2_by_id_position");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_class_list);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            ////SetLastTimeUsing();
            vclass Class;
            if (tbl_class_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_class_list.Rows)
                {
                    Class = new vclass(dr);
                    class_list.Add(Class);
                }
            }
            return class_list;
        }

        /// <summary>
        /// Метод возвращает классы разрешенные с учетом правил уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<vclass> Class_allowed_rl2_by_id_position(position Position)
        {
            return Class_allowed_rl2_by_id_position(Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Class_allowed_rl2_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_allowed_rl2_by_id_position");
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
        /// Метод возвращает классы назначенные с учетом правил уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<vclass> Class_assigned_rl2_by_id_position(Int64 iid_position)
        {
            List<vclass> class_list = new List<vclass>();


            DataTable tbl_class_list = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_assigned_rl2_by_id_position");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_class_list);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            ////SetLastTimeUsing();
            vclass Class;
            if (tbl_class_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_class_list.Rows)
                {
                    Class = new vclass(dr);
                    class_list.Add(Class);
                }
            }
            return class_list;
        }

        /// <summary>
        /// Метод возвращает классы назначенные с учетом правил уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<vclass> Class_assigned_rl2_by_id_position(position Position)
        {
            return Class_assigned_rl2_by_id_position(Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Сlass_assigned_rl2_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_assigned_rl2_by_id_position");
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
        /// Метод возвращает классы назначенные с учетом правил уровня 2 класс на позицию для выбранной группы по идентификатору позиции
        /// </summary>
        public List<vclass> Class_allowed_rl2_for_group_by_id_position(Int64 iid_position, Int64 iid_group)
        {
            List<vclass> class_list = new List<vclass>();


            DataTable tbl_class_list  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_allowed_rl2_for_group_by_id_position");

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
            cmdk.Parameters["iid_group"].Value = iid_group;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_class_list);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            ////SetLastTimeUsing();
            vclass Class;
            if (tbl_class_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_class_list.Rows)
                {
                    Class = new vclass(dr);
                    class_list.Add(Class);
                }
            }
            return class_list;
        }

        /// <summary>
        /// Метод возвращает классы назначенные с учетом правил уровня 2 класс на позицию для выбранной группы по идентификатору позиции
        /// </summary>
        public List<vclass> Class_allowed_rl2_for_group_by_id_position(position Position, group Group)
        {
            return Class_allowed_rl2_for_group_by_id_position(Position.Id, Group.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Class_allowed_rl2_for_group_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_allowed_rl2_for_group_by_id_position");
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
        /// Метод возвращает классы назначенные с учетом правил уровня 2 класс на позицию для выбранного класса по идентификатору позиции
        /// </summary>
        public List<vclass> class_allowed_rl2_for_class_by_id_position(Int64 iid_position, Int64 iid_class)
        {
            List<vclass> class_list = new List<vclass>();


            DataTable tbl_class_list = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_allowed_rl2_for_class_by_id_position");

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
            cmdk.Parameters["iid_class"].Value = iid_class;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_class_list);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            ////SetLastTimeUsing();
            vclass Class;
            if (tbl_class_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_class_list.Rows)
                {
                    Class = new vclass(dr);
                    class_list.Add(Class);
                }
            }
            return class_list;
        }

        /// <summary>
        /// Метод возвращает классы назначенные с учетом правил уровня 2 класс на позицию для выбранного класса по идентификатору позиции
        /// </summary>
        public List<vclass> class_allowed_rl2_for_class_by_id_position(position Position, vclass Class)
        {
            return class_allowed_rl2_for_class_by_id_position(Position.Id, Class.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_allowed_rl2_for_class_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_allowed_rl2_for_class_by_id_position");
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

        #region МЕТОДЫ ПОЗИЦИЙ ДОСТУПНЫХ ИЛИ НАЗНАЧЕННЫХ РАЗРЕШАЮЩИМИ ПРАВИЛАМ УРОВНЯ 2 КЛАСС НА ПОЗИЦИЮ
        /// <summary>
        /// Метод возвращает список разрешенных позиций с учетом разрешения уровня 2 класс на позицию по идентификатору класса
        /// </summary>
        public List<position> Position_allowed_rl2_by_id_class(Int64 iid_class)
        {
            List<position> position_list = new List<position>();


            DataTable tbl_position_list  = TableByName("vposition");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_allowed_rl2_by_id_class");

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
                cmdk.Fill(tbl_position_list);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            ////SetLastTimeUsing();
            position Position;
            if (tbl_position_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_position_list.Rows)
                {
                    Position = new position(dr);
                    position_list.Add(Position);
                }
            }
            return position_list;
        }

        /// <summary>
        /// Метод возвращает список разрешенных позиций с учетом разрешения уровня 2 класс на позицию по идентификатору класса
        /// </summary>
        public List<position> Position_allowed_rl2_by_id_class(vclass Class)
        {
            return Position_allowed_rl2_by_id_class(Class.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Position_allowed_rl2_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_allowed_rl2_by_id_class");
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

        #region МЕТОДЫ ПРОВЕРКИ РАЗРЕШЕНИЙ
        //*********************************************************************************************
        /// <summary>
        /// Метод определяет наличие разрешения RL2 класс на позицию для переданной пары
        /// </summary>
        public Boolean rulel2_class_on_position_check_access(Int64 iid_position, Int64 iid_class)
        {
            //=======================
            NpgsqlCommandKey cmdk;
            //**********

            //=======================
            cmdk = CommandByKey("rulel2_class_on_position_check_access");

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
            cmdk.Parameters["iid_class"].Value = iid_class;

            //Начало транзакции
            return (Boolean)cmdk.ExecuteScalar();
        }

        /// <summary>
        /// Метод определяет наличие разрешения RL2 класс на позицию для переданной пары
        /// </summary>
        public Boolean rulel2_class_on_position_check_access(position Position, vclass Class)
        {
            return rulel2_class_on_position_check_access(Position.Id, Class.Id);
        }
        #endregion

        #region СОБЫТИЕ ИЗМЕНЕНИЯ СПИСКА ОГРАНИЧЕНИЯ ВЛОЖЕННОСТИ

        /// <summary>
        /// Делегат события изменения
        /// </summary>
        public delegate void Rulel2_Class_On_PositionListChangeEventHandler(Object sender, Rulel2_Class_On_PositionListChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении списка правил вложенности уровня 2 класс на позицию
        /// </summary>
        public event Rulel2_Class_On_PositionListChangeEventHandler Rulel2_Class_On_PositionListChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события
        /// </summary>
        protected virtual void OnRulel2_Class_On_PositionListChange(Rulel2_Class_On_PositionListChangeEventArgs e)
        {
            Rulel2_Class_On_PositionListChangeEventHandler temp = this.Rulel2_Class_On_PositionListChange;

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