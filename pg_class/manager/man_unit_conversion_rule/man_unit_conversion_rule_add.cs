using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
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

            cmdk.Parameters["iid_con"].Value = iid_con;
            cmdk.Parameters["iid_unit"].Value = iid_unit;
            cmdk.Parameters["icunit"].Value = icunit;
            cmdk.Parameters["imc"].Value = imc;
            cmdk.Parameters["ion_single"].Value = ion_single;
            cmdk.Parameters["iround"].Value = iround;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    id = Convert.ToInt32(cmdk.Parameters["outid"].Value);
                    rule = unit_conversion_rule_by_id(id);
                    //Генерируем событие изменения правила пересчета
                    UnitConversionRuleChangeEventArgs e = new UnitConversionRuleChangeEventArgs(id, eAction.Insert);
                    UnitConversionRuleOnChange(e);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.unit_conversion_rule, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Возвращаем сущность
            return rule;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean unit_conversion_rule_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

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
    }
}