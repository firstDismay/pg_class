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
        #region МЕТОДЫ КЛАССА: UNIT
        #region ВЫБРАТЬ

        //*********************************************************************************************
        /// <summary>
        /// Лист измеряемых величин
        /// </summary>
        public List<unit> units_by_all()
        {
            List<unit>  units_list = new List<unit>();

            
            DataTable tbl_unit  = TableByName("vunits");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("units_by_all");

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

            try
            {
                cmdk.Fill(tbl_unit);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            unit u;
            if (tbl_unit.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_unit.Rows)
                {
                    u = new unit(dr);
                    units_list.Add(u);
                }
            }

            return units_list;
        }

        /// <summary>
        /// Лист измеряемых величин
        /// </summary>
        public List<unit_conception> unit_conception_by_all(Int64 Id_conception)
        {
            List<unit_conception> units_list = new List<unit_conception>();


            DataTable tbl_unit  = TableByName("vunits");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("units_by_all");

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

            try
            {
                cmdk.Fill(tbl_unit);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            unit_conception u;
            if (tbl_unit.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_unit.Rows)
                {
                    u = new unit_conception(Id_conception, dr);
                    units_list.Add(u);
                }
            }
            return units_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean unit_conception_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("units_by_all");
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
        /// Измеряемая величина по id
        /// </summary>
        public unit units_by_id(Int32 id)
        {
            unit unit = null;

            DataTable tbl_unit  = TableByName("vunits");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("units_by_id");

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
                cmdk.Fill(tbl_unit);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_unit.Rows.Count > 0)
            {
                unit = new unit(tbl_unit.Rows[0]);
            }
            return unit;
        }

        /// <summary>
        /// Измеряемая величина по id
        /// </summary>
        public unit_conception unit_conception_by_id(Int32 id, Int64 Id_conception)
        {
            unit_conception unit = null;

            DataTable tbl_unit  = TableByName("vunits");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("units_by_id");

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
                cmdk.Fill(tbl_unit);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_unit.Rows.Count > 0)
            {
                unit = new unit_conception(Id_conception, tbl_unit.Rows[0]);
            }
            return unit;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean units_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("units_by_id");
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
        #endregion

        #region МЕТОДЫ КЛАССА: UNIT CONVERSION RULE
        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет правило пересчета единиц измерения колличества объектов
        /// </summary>
        public unit_conversion_rule unit_conversion_rule_add(Int64 iid_con, Int32 iid_unit, String icunit, Decimal imc, Boolean ion_single, Int32 iround, String idesc)
        {
            unit_conversion_rule rule = null;
            Int32 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("unit_conversion_rule_add");

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
            cmdk.Parameters["iid_unit"].Value = iid_unit;
            cmdk.Parameters["icunit"].Value = icunit;
            cmdk.Parameters["imc"].Value = imc;
            cmdk.Parameters["ion_single"].Value = ion_single;
            cmdk.Parameters["iround"].Value = iround;
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
                    id = Convert.ToInt32(cmdk.Parameters["outid"].Value);
                    if (id > 0)
                    {
                        rule = unit_conversion_rule_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.unit_conversion_rule, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения правила пересчета
            UnitConversionRuleChangeEventArgs e = new UnitConversionRuleChangeEventArgs(id, eAction.Insert);
            UnitConversionRuleOnChange(e);
            //Возвращаем Объект
            return rule;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean unit_conversion_rule_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("unit_conversion_rule_add");
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
        /// Метод изменяет правило пересчета единиц измерения колличества объектов
        /// </summary>
        public unit_conversion_rule unit_conversion_rule_upd(Int32 iid, String icunit, Decimal imc, Boolean ion_single, Boolean ion, Int32 iround, String  idesc)
        {
            unit_conversion_rule rule = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("unit_conversion_rule_upd");

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
            cmdk.Parameters["icunit"].Value = icunit;
            cmdk.Parameters["imc"].Value = imc;
            cmdk.Parameters["ion_single"].Value = ion_single;
            cmdk.Parameters["ion"].Value = ion;
            cmdk.Parameters["iround"].Value = iround;
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
                    rule = unit_conversion_rule_by_id(iid);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid, eEntity.unit_conversion_rule, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения правила пересчета
            UnitConversionRuleChangeEventArgs e = new UnitConversionRuleChangeEventArgs(iid, eAction.Update);
            UnitConversionRuleOnChange(e);
            //Возвращаем Объект
            return rule;
        }

        /// <summary>
        /// Метод изменяет указанную группу
        /// </summary>
        public unit_conversion_rule unit_conversion_rule_upd(unit_conversion_rule Rule)
        {
            return unit_conversion_rule_upd(Rule.Id, Rule.Cunit, Rule.Mc, Rule.On_single, Rule.On, Rule.Round, Rule.Desc);
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean unit_conversion_rule_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("unit_conversion_rule_upd");
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
        /// Метод удаляет правило пересчета единиц измерения колличества объектов
        /// </summary>
        public void unit_conversion_rule_del(Int32 id)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("unit_conversion_rule_del");

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
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.unit_conversion_rule, error, desc_error, eAction.Delete, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Генерируем событие изменения правила пересчета
            UnitConversionRuleChangeEventArgs e = new UnitConversionRuleChangeEventArgs(id, eAction.Delete);
            UnitConversionRuleOnChange(e);
        }

        /// <summary>
        /// Метод удаляет правило пересчета единиц измерения колличества объектов
        /// </summary>
        public void unit_conversion_rule_del(unit_conversion_rule Rule)
        {
            unit_conversion_rule_del(Rule.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean unit_conversion_rule_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("unit_conversion_rule_del");
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
        /// Правило пересчета единиц измерения объектов по id
        /// </summary>
        public unit_conversion_rule unit_conversion_rule_by_id(Int32 id)
        {
            unit_conversion_rule rule = null;

            DataTable tbl_rule  = TableByName("vunit_conversion_rules");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("unit_conversion_rule_by_id");

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
                cmdk.Fill(tbl_rule);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_rule.Rows.Count > 0)
            {
                rule = new unit_conversion_rule(tbl_rule.Rows[0]);
            }
            return rule;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean unit_conversion_rule_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("unit_conversion_rule_by_id");
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
        /// Базовое правило пересчета по идентификатору измеряемой величины
        /// </summary>
        public unit_conversion_rule unit_conversion_rule_base_by_id_unit(Int64 iid_con, Int32 iid_unit)
        {
            unit_conversion_rule rule = null;

            DataTable tbl_rule  = TableByName("vunit_conversion_rules");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("unit_conversion_rule_base_by_id_unit");

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
            cmdk.Parameters["iid_unit"].Value = iid_unit;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_rule);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_rule.Rows.Count > 0)
            {
                rule = new unit_conversion_rule(tbl_rule.Rows[0]);
            }
            return rule;
        }

        //*********************************************************************************************
        /// <summary>
        /// Базовое правило пересчета по идентификатору измеряемой величины
        /// </summary>
        public unit_conversion_rule unit_conversion_rule_base_by_id_unit(Int64 id_conception, unit Unit)
        {
            return unit_conversion_rule_base_by_id_unit(id_conception, Unit.Id);
        }

        /// <summary>
        /// Базовое правило пересчета по идентификатору измеряемой величины
        /// </summary>
        public unit_conversion_rule unit_conversion_rule_base_by_id_unit(conception Conception, unit Unit)
        {
            return unit_conversion_rule_base_by_id_unit(Conception.Id, Unit.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean unit_conversion_rule_base_by_id_unit(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("unit_conversion_rule_base_by_id_unit");
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
        /// Лист правил пересчета по идентификатору величины измерения
        /// </summary>
        public List<unit_conversion_rule> unit_conversion_rule_by_id_unit(Int64 iid_con, Int32 iid_unit)
        {
            List<unit_conversion_rule> rule_list = new List<unit_conversion_rule>();


            DataTable tbl_rule  = TableByName("vunit_conversion_rules");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("unit_conversion_rule_by_id_unit");

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
            cmdk.Parameters["iid_unit"].Value = iid_unit;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_rule);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            unit_conversion_rule rule;
            if (tbl_rule.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule.Rows)
                {
                    rule = new unit_conversion_rule(dr);
                    rule_list.Add(rule);
                }
            }

            return rule_list;
        }

        /// <summary>
        /// Лист правил пересчета по идентификатору величины измерения
        /// </summary>
        public List<unit_conversion_rule> unit_conversion_rule_by_id_unit(Int64 id_conception, unit Unit)
        {
            return unit_conversion_rule_by_id_unit(id_conception, Unit.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean unit_conversion_rule_by_id_unit(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("unit_conversion_rule_by_id_unit");
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
        /// Лист правил пересчета по идентификатору активного представления вещественного класса
        /// </summary>
        public List<unit_conversion_rule> unit_conversion_rule_by_id_class(Int64 iid_class)
        {
            List<unit_conversion_rule> rule_list = new List<unit_conversion_rule>();


            DataTable tbl_rule  = TableByName("vunit_conversion_rules");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("unit_conversion_rule_by_id_class");

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
                cmdk.Fill(tbl_rule);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            unit_conversion_rule rule;
            if (tbl_rule.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule.Rows)
                {
                    rule = new unit_conversion_rule(dr);
                    rule_list.Add(rule);
                }
            }

            return rule_list;
        }

        /// <summary>
        /// Лист правил пересчета по идентификатору активного представления вещественного класса
        /// </summary>
        public List<unit_conversion_rule> unit_conversion_rule_by_id_class(vclass Class)
        {
            return unit_conversion_rule_by_id_class(Class.Id);
        }

            //-=ACCESS=-***********************************************************************************
            /// <summary>
            /// Проверка прав доступа к методу
            /// </summary>
            public Boolean unit_conversion_rule_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("unit_conversion_rule_by_id_class");
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
        /// Правила пересчета по идентификатору объекта
        /// </summary>
        public List<unit_conversion_rule> unit_conversion_rule_by_id_object(Int64 iid_object)
        {
            List<unit_conversion_rule> rule_list = new List<unit_conversion_rule>();


            DataTable tbl_rule  = TableByName("vunit_conversion_rules");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("unit_conversion_rule_by_id_object");

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

            cmdk.Parameters["iid_object"].Value = iid_object;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_rule);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            unit_conversion_rule rule;
            if (tbl_rule.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule.Rows)
                {
                    rule = new unit_conversion_rule(dr);
                    rule_list.Add(rule);
                }
            }

            return rule_list;
        }

        /// <summary>
        /// Лист правил пересчета по идентификатору объекта
        /// </summary>
        public List<unit_conversion_rule> unit_conversion_rule_by_id_object(object_general Object)
        {
            return unit_conversion_rule_by_id_object(Object.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean unit_conversion_rule_by_id_object(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("unit_conversion_rule_by_id_object");
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
        /// Метод определяет актуальность состояния правила пересчета
        /// </summary>
        public eEntityState unit_conversion_rules_is_actual(Int64 iid, DateTime mytimestamp)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("unit_conversion_rules_is_actual");

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
        /// Метод определяет актуальность состояния правила пересчета
        /// </summary>
        public eEntityState unit_conversion_rules_is_actual(unit_conversion_rule Rule)
        {
            return unit_conversion_rules_is_actual(Rule.Id, Rule.Timestamp);
        }
        #endregion
        #endregion 

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ ПРАВИЛАМИ ПЕРЕСЧЕТА

        /// <summary>
        /// Делегат события изменения правила пересчета колличества объектов
        /// </summary>
        public delegate void UnitConversionRuleChangeEventHandler(Object sender, UnitConversionRuleChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении  правила пересчета колличества объектов в БД
        /// </summary>
        public event UnitConversionRuleChangeEventHandler UnitConversionRuleChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения правила пересчета колличества объектов
        /// </summary>
        protected virtual void UnitConversionRuleOnChange(UnitConversionRuleChangeEventArgs e)
        {
            UnitConversionRuleChangeEventHandler temp = UnitConversionRuleChange;
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
