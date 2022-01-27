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
        #region МЕТОДЫ КЛАССА: ШАБЛОНЫ ПОЗИЦИЙ УПРАВЛЕНИЕ БЕЛЫМ СПИСКОМ

        #region ДОБАВИТЬ ПРАВИЛО
        /// <summary>
        /// Метод добавляет шаблон позиции в лист ограничений вложенности
        /// </summary>
        public pos_temp pos_temp_nested_include(Int64 iid_pos_temp, Int64 id_pos_temp_nested, Int32 ipos_temp_nested_limit = 0)
        {
            pos_temp pos_temp = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
            
            //=======================
            cmdk = CommandByKey("pos_temp_nested_include");

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
            cmdk.Parameters["iid_pos_temp_nested"].Value = id_pos_temp_nested;
            cmdk.Parameters["ipos_temp_nested_limit"].Value = ipos_temp_nested_limit;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    pos_temp = pos_temp_by_id(iid_pos_temp);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_pos_temp, eEntity.pos_temp_nested_rule, error, desc_error, eAction.Include, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            
            //Вызов события изменения списка вложенности
            PosTempNestedListChangeEventArgs e;
            e = new PosTempNestedListChangeEventArgs(pos_temp, eActionPosTempNestedList.addrule);
            OnPosTempNestedListChange(e);
            //Возвращаем Объект
            return pos_temp;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_include(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_nested_include");
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

        #region УДАЛИТЬ ПРАВИЛО
        /// <summary>
        /// Метод исключает шаблон позиции из листа ограничений вложенности
        /// </summary>
        public pos_temp pos_temp_nested_exclude(Int64 iid_pos_temp, Int64 iid_pos_temp_nested)
        {
            pos_temp pos_temp = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
            
            //=======================
            cmdk = CommandByKey("pos_temp_nested_exclude");

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
            cmdk.Parameters["iid_pos_temp_nested"].Value = iid_pos_temp_nested;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    pos_temp = pos_temp_by_id(iid_pos_temp);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_pos_temp, eEntity.pos_temp_nested_rule, error, desc_error, eAction.Exclude, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения шаблона позиции
            /*PosTempChangeEventArgs e = new PosTempChangeEventArgs(pos_temp, eAction.Update);
            PosTempOnChange(e);*/
            //Вызов события изменения списка вложенности
            PosTempNestedListChangeEventArgs e;
            e = new PosTempNestedListChangeEventArgs(pos_temp, eActionPosTempNestedList.delrule);
            OnPosTempNestedListChange(e);
            //Возвращаем Объект
            return pos_temp;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_exclude(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_nested_exclude");
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
        /// Метод исключает все шаблоны позиции из листа ограничений вложенности
        /// </summary>
        public pos_temp pos_temp_nested_exclude_all(Int64 iid_pos_temp)
        {
            pos_temp pos_temp = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
            
            //=======================
            cmdk = CommandByKey("pos_temp_nested_exclude_all");

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
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    pos_temp = pos_temp_by_id(iid_pos_temp);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_pos_temp, eEntity.pos_temp_nested_rule, error, desc_error, eAction.Exclude, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения шаблона позиции
            /*PosTempChangeEventArgs e = new PosTempChangeEventArgs(pos_temp, eAction.Update);
            PosTempOnChange(e);*/
            PosTempNestedListChangeEventArgs e;
            e = new PosTempNestedListChangeEventArgs(pos_temp, eActionPosTempNestedList.delallrule);
            OnPosTempNestedListChange(e);
            //Возвращаем Объект
            return pos_temp;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_exclude_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_nested_exclude_all");
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

        #region ВЫБРАТЬ ПРАВИЛА
        //*********************************************************************************************
        /// <summary>
        /// Правило вложенности шаблонов позиций по полному идентификатору
        /// </summary>
        public pos_temp_nested_rule pos_temp_nested_whitelist_by_id( Int64 iid_pos_temp, Int64 iid_pos_temp_nested)
        {
            pos_temp_nested_rule pos_temp_rule = null;

            DataTable tbl_con  = TableByName("vpos_temp_nested_rule");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_nested_whitelist_by_id");

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
            cmdk.Parameters["iid_pos_temp_nested"].Value = iid_pos_temp_nested;

            cmdk.Fill(tbl_con);
            
            if (tbl_con.Rows.Count > 0)
            {
                pos_temp_rule = new pos_temp_nested_rule(tbl_con.Rows[0]);
            }

            return pos_temp_rule;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_whitelist_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_nested_whitelist_by_id");
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
        /// Полный перечень потенциально доступных Правил вложенности шаблонов позиций для указанного шаблона позиции
        /// </summary>
        public List<pos_temp_nested_rule> pos_temp_nested_whitelist_full( Int64 iid_pos_temp , Int64 iid_con )
        {
            List<pos_temp_nested_rule> rule_list = new List<pos_temp_nested_rule>();


            DataTable tbl_rule_list  = TableByName("vpos_temp_nested_rule");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_nested_whitelist_full");

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
            cmdk.Parameters["iid_con"].Value = iid_con;

            cmdk.Fill(tbl_rule_list);
            
            pos_temp_nested_rule rule;
            if (tbl_rule_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule_list.Rows)
                {
                    rule = new pos_temp_nested_rule(dr);
                    rule_list.Add(rule);
                }
            }

            return rule_list;
        }


        /// <summary>
        /// Полный перечень потенциально доступных Правил вложенности шаблонов позиций для указанного шаблона позиции
        /// </summary>
        public List<pos_temp_nested_rule> pos_temp_nested_whitelist_full(pos_temp Pos_temp)
        {
            return pos_temp_nested_whitelist_full(Pos_temp.Id, Pos_temp.Id_conception);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_whitelist_full(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_nested_whitelist_full");
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
        /// Перечень существующих Правил вложенности шаблонов позиции по идентификатору шаблона
        /// </summary>
        public List<pos_temp_nested_rule>pos_temp_nested_whitelist(Int64 iid_pos_temp)
        {
            List<pos_temp_nested_rule> rule_list = new List<pos_temp_nested_rule>();


            DataTable tbl_rule_list  = TableByName("vpos_temp_nested_rule");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_nested_whitelist");

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

            cmdk.Fill(tbl_rule_list);
            
            pos_temp_nested_rule rule;
            if (tbl_rule_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule_list.Rows)
                {
                    rule = new pos_temp_nested_rule(dr);
                    rule_list.Add(rule);
                }
            }

            return rule_list;
        }

        /// <summary>
        /// Перечень Правил вложенности шаблонов позиции по идентификатору шаблона
        /// </summary>
        public List<pos_temp_nested_rule> pos_temp_nested_whitelist(pos_temp Pos_temp)
        {
            return pos_temp_nested_whitelist(Pos_temp.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_whitelist(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_nested_whitelist");
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

        #region ПАРАМЕТРЫ ОГРАНИЧЕНИЙ ВЛОЖЕННОСТИ
        //*********************************************************************************************
        /// <summary>
        /// Метод определяет текущее количество позиций указанного шаблона вложенных в указанную позицию
        /// </summary>
        public Int32 pos_temp_nested_limit_curent(Int64 id_pos, Int64 id_pos_temp)
        {
            Int32 nested_limit_curent = 0;
            //=======================   
            NpgsqlCommandKey cmdk;
            //**********
            
            //=======================
            cmdk = CommandByKey("pos_temp_nested_limit_curent");

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

            cmdk.Parameters["iid_pos"].Value = id_pos;
            cmdk.Parameters["iid_pos_temp"].Value = id_pos_temp;

            //Начало транзакции
            nested_limit_curent = (Int32)cmdk.ExecuteScalar();
            
            return nested_limit_curent;
        }

        //*********************************************************************************************
        /// <summary>
        /// Метод определяет текущее количество позиций указанного шаблона вложенных в указанную позицию
        /// </summary>
        public Int32 pos_temp_nested_limit_curent(position position, pos_temp pos_temp)
        {
            return pos_temp_nested_limit_curent(position.Id, pos_temp.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_limit_curent(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_nested_limit_curent");
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
        /// Метод определяет максимальное количество позиций указанного шаблона доступных к вложению в указанную позицию, 0 без ограничений
        /// </summary>
        public Int32 pos_temp_nested_limit_max(Int64 id_pos_temp, Int64 id_pos_temp_nested)
        {
            Int32 nested_limit_max = 0;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
            
            //=======================
            cmdk = CommandByKey("pos_temp_nested_limit_max");

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

            cmdk.Parameters["iid_pos_temp"].Value = id_pos_temp;
            cmdk.Parameters["iid_pos_temp_nested"].Value = id_pos_temp_nested;

            //Начало транзакции
            nested_limit_max = (Int32)cmdk.ExecuteScalar();
            
            return nested_limit_max;
        }

        //************************************
        /// <summary>
        /// Метод определяет максимальное количество позиций указанного шаблона доступных к вложению в указанную позицию, 0 без ограничений
        /// </summary>
        public Int32 pos_temp_nested_limit_max(pos_temp pos_temp, pos_temp pos_temp_nested)
        {
            return pos_temp_nested_limit_max(pos_temp.Id, pos_temp_nested.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_limit_max(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_nested_limit_max");
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
        /// Метод возвращает минимальное значение параметра nested_limit_max определяемого по фактическому количеству вложенных позиций 
        /// </summary>
        public Int32 pos_temp_nested_limit_min(Int64 id_pos_temp, Int64 id_pos_temp_nested)
        {
            Int32 nested_limit_min = 0;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
            
            //=======================
            cmdk = CommandByKey("pos_temp_nested_limit_min");

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

            cmdk.Parameters["iid_pos_temp"].Value = id_pos_temp;
            cmdk.Parameters["iid_pos_temp_nested"].Value = id_pos_temp_nested;

            //Начало транзакции
            nested_limit_min = (Int32)cmdk.ExecuteScalar();
            
            return nested_limit_min;
        }

        //*********************************************************************************************
        /// <summary>
        /// Метод определяет текущее количество позиций указанного шаблона вложенных в указанную позицию
        /// </summary>
        public Int32 pos_temp_nested_limit_min(pos_temp pos_temp, pos_temp pos_temp_nested)
        {
            return pos_temp_nested_limit_curent(pos_temp.Id, pos_temp_nested.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_limit_min(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_nested_limit_min");
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
        /// Метод выполняет проверку доступности вложения позиции выбранного шаблона в родительскую позицию 
        /// </summary>
        public Boolean pos_nested_limit_control(Int64 id_parent, Int64 id_pos_temp)
        {
            Boolean is_nested = false;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
            
            //=======================
            cmdk = CommandByKey("position_nested_limit_control");

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

            cmdk.Parameters["iid_parent"].Value = id_parent;
            cmdk.Parameters["iid_pos_temp"].Value = id_pos_temp;

            //Начало транзакции
            is_nested = (Boolean)cmdk.ExecuteScalar();
            
            return is_nested;
        }

        //*********************************************************************************************
        /// <summary>
        /// Метод выполняет проверку доступности вложения позиции выбранного шаблона в родительскую позицию
        /// </summary>
        public Boolean pos_nested_limit_control(position position_parent, pos_temp pos_temp_nested)
        {
            return pos_nested_limit_control(position_parent.Id, pos_temp_nested.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_nested_limit_control(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_nested_limit_control");
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

        #region ПАРАМЕТРЫ ОГРАНИЧЕНИЙ ИЗМЕНЕНИЙ СВОЙСТВ ШАБЛОНА
        //*********************************************************************************************
       /* /// <summary>
        /// Метод определяет наличие расширенных свойств у позиций указанного шаблона
        /// </summary>
        public Boolean pos_temp_check_pos_prop_ext(Int64 id_pos_temp)
        {
            Boolean onposcheckext;
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_check_pos_prop_ext");
            if (cmdk != null)
            {
                if (!cmdk.Access)
                {
                    throw new AccessDataBaseException(404, "Доступ к методу 'pos_temp_check_pos_prop_ext' запрещен!");
                }
            }
            else
            {
                throw new AccessDataBaseException(405, "Метод 'pos_temp_check_pos_prop_ext' не существует!");
            }
            cmdk.Parameters["iid_pos_temp"].Value = id_pos_temp;

            onposcheckext = (Boolean)cmdk.ExecuteScalar();
            //SetLastTimeUsing();
            return onposcheckext;
            ;
        }

        //*****************************************************
        /// <summary>
        /// Метод определяет наличие расширенных свойств у позиций указанного шаблона
        /// </summary>
        public Boolean pos_temp_check_pos_prop_ext(pos_temp pos_temp)
        {
            return pos_temp_check_pos_prop_ext(pos_temp.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_check_pos_prop_ext(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_check_pos_prop_ext");
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
        }*/
        //*********************************************************************************************
        #endregion

        #region СОБЫТИЕ ИЗМЕНЕНИЯ СПИСКА ОГРАНИЧЕНИЯ ВЛОЖЕННОСТИ

        /// <summary>
        /// Делегат события изменения
        /// </summary>
        public delegate void PosTempNestedListChangeEventHandler(Object sender, PosTempNestedListChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении списка ограничения вложенности
        /// </summary>
        public event PosTempNestedListChangeEventHandler PosTempNestedListChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения концепции
        /// </summary>
        protected virtual void OnPosTempNestedListChange(PosTempNestedListChangeEventArgs e)
        {
            PosTempNestedListChangeEventHandler temp = this.PosTempNestedListChange;

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
