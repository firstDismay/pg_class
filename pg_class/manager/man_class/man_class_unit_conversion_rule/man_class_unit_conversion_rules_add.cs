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
    }
}
