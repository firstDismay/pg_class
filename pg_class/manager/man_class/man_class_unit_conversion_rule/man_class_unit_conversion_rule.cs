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
        //УПРАВЛЕНИЕ ПРАВИЛАМИ НАЗНАЧЕНИЯ ПРАВИЛ ПЕРЕСЧЕТА КОЛЛИЧЕСТВА ОБЪЕКТОВ
        #region ВКЛЮЧИТЬ
        /// <summary>
        /// Метод добавляет правило пресчета к списку правил вещественного класса
        /// </summary>
        public void class_unit_conversion_rules_add(Int64 iid_class, Int32 iid_unit_conversion_rule)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_add");
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
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.ExecuteNonQuery();

            //Вызов события изменения списка вложенности
            ClassUnitConversionRuleChangeEventArgs e;
            e = new ClassUnitConversionRuleChangeEventArgs(iid_class, eAction.Insert);
            OnClassUnitConversionRuleListChange(e);
        }

        /// <summary>
        /// Метод добавляет правило пресчета к списку правил вещественного класса
        /// </summary>
        public void class_unit_conversion_rules_add(vclass Class, unit_conversion_rule Rule)
        {
            class_unit_conversion_rules_add(Class.Id, Rule.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_unit_conversion_rules_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_add");
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

        #region ИСКЛЮЧИТЬ
        /// <summary>
        /// Метод исключает правило пресчета из списка правил вещественного класса
        /// </summary>
        public void class_unit_conversion_rules_del(Int64 iid_class, Int32 iid_unit_conversion_rule)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_del");
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
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.ExecuteNonQuery();

            //Вызов события изменения списка вложенности
            ClassUnitConversionRuleChangeEventArgs e;
            e = new ClassUnitConversionRuleChangeEventArgs(iid_class, eAction.Delete);
            OnClassUnitConversionRuleListChange(e);
        }

        /// <summary>
        /// Метод исключает правило пресчета из списка правил вещественного класса
        /// </summary>
        public void class_unit_conversion_rules_del(vclass Class, unit_conversion_rule Rule)
        {
            class_unit_conversion_rules_del(Class.Id, Rule.Id);
        }

        /// <summary>
        /// Метод исключает правило пресчета из списка правил вещественного класса
        /// </summary>
        public void class_unit_conversion_rules_del(class_unit_conversion_rule ClassRule)
        {
            class_unit_conversion_rules_del(ClassRule.Id_class, ClassRule.Id_unit_conversion_rule);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_unit_conversion_rules_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_del");
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

        #region ВЫБРАТЬ
        /// <summary>
        /// Правило назначения правила пересчета объектов вещественного класса по ключу
        /// </summary>
        public class_unit_conversion_rule class_unit_conversion_rules_by_id(Int64 iid_class, Int32 iid_unit_conversion_rule)
        {
            class_unit_conversion_rule class_unit_conversion_rule = null;
            DataTable tbl_rule = TableByName("vclass_unit_conversion_rules");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_by_id");
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
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.Fill(tbl_rule);

            if (tbl_rule.Rows.Count > 0)
            {
                class_unit_conversion_rule = new class_unit_conversion_rule(tbl_rule.Rows[0]);
            }

            return class_unit_conversion_rule;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_unit_conversion_rules_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_by_id");
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
        /// Лист правил назначения правил пересчета объектов вещественного класса
        /// </summary>
        public List<class_unit_conversion_rule> class_unit_conversion_rules_by_id_class(Int64 iid_class)
        {
            List<class_unit_conversion_rule> rule_list = new List<class_unit_conversion_rule>();
            DataTable tbl_rule_list = TableByName("vclass_unit_conversion_rules");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_by_id_class");
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
            cmdk.Fill(tbl_rule_list);

            class_unit_conversion_rule rule;
            if (tbl_rule_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule_list.Rows)
                {
                    rule = new class_unit_conversion_rule(dr);
                    rule_list.Add(rule);
                }
            }
            return rule_list;
        }

        /// <summary>
        /// Лист правил назначения правил пересчета объектов вещественного класса
        /// </summary>
        public List<class_unit_conversion_rule> class_unit_conversion_rules_by_id_class(vclass Class)
        {
            return class_unit_conversion_rules_by_id_class(Class.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_unit_conversion_rules_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_by_id_class");
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
        /// Полный список доступных назначений правил пересчета объектов вещественного класса
        /// </summary>
        public List<class_unit_conversion_rule> class_unit_conversion_rules_full(Int64 iid_class)
        {
            List<class_unit_conversion_rule> rule_list = new List<class_unit_conversion_rule>();
            DataTable tbl_rule_list = TableByName("vclass_unit_conversion_rules");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_full");
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
            cmdk.Fill(tbl_rule_list);

            class_unit_conversion_rule rule;
            if (tbl_rule_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule_list.Rows)
                {
                    rule = new class_unit_conversion_rule(dr);
                    rule_list.Add(rule);
                }
            }
            return rule_list;
        }

        /// <summary>
        /// Полный список доступных назначений правил пересчета объектов вещественного класса
        /// </summary>
        public List<class_unit_conversion_rule> class_unit_conversion_rules_full(vclass Class)
        {
            return class_unit_conversion_rules_full(Class.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_unit_conversion_rules_full(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_full");
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
        /// Полный список доступных назначений правил пересчета объектов вещественного класса по идентификатору измеряемой величины
        /// </summary>
        public List<class_unit_conversion_rule> class_unit_conversion_rules_by_unit(Int32 iid_unit)
        {
            List<class_unit_conversion_rule> rule_list = new List<class_unit_conversion_rule>();
            DataTable tbl_rule_list = TableByName("vclass_unit_conversion_rules");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_by_unit");
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

            cmdk.Parameters["iid_unit"].Value = iid_unit;
            cmdk.Fill(tbl_rule_list);

            class_unit_conversion_rule rule;
            if (tbl_rule_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule_list.Rows)
                {
                    rule = new class_unit_conversion_rule(dr);
                    rule_list.Add(rule);
                }
            }
            return rule_list;
        }

        /// <summary>
        /// Полный список доступных назначений правил пересчета объектов вещественного класса по идентификатору измеряемой величины
        /// </summary>
        public List<class_unit_conversion_rule> class_unit_conversion_rules_by_unit(unit Unit)
        {
            return class_unit_conversion_rules_by_unit(Unit.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_unit_conversion_rules_by_unit(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_by_unit");
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
    }
}
