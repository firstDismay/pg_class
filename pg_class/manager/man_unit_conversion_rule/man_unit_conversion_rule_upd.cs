using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет правило пересчета единиц измерения колличества объектов
        /// </summary>
        public unit_conversion_rule unit_conversion_rule_upd(Int32 iid, String icunit, Decimal imc, Boolean ion_single, Boolean ion, Int32 iround, String idesc)
        {
            unit_conversion_rule rule = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

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

            cmdk.Parameters["iid"].Value = iid;
            cmdk.Parameters["icunit"].Value = icunit;
            cmdk.Parameters["imc"].Value = imc;
            cmdk.Parameters["ion_single"].Value = ion_single;
            cmdk.Parameters["ion"].Value = ion;
            cmdk.Parameters["iround"].Value = iround;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    rule = unit_conversion_rule_by_id(iid);
                    //Генерируем событие изменения правила пересчета
                    UnitConversionRuleChangeEventArgs e = new UnitConversionRuleChangeEventArgs(iid, eAction.Update);
                    UnitConversionRuleOnChange(e);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid, eEntity.unit_conversion_rule, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Возвращаем сущность
            return rule;
        }

        /// <summary>
        /// Метод изменяет указанную группу
        /// </summary>
        public unit_conversion_rule unit_conversion_rule_upd(unit_conversion_rule Rule)
        {
            return unit_conversion_rule_upd(Rule.Id, Rule.Cunit, Rule.Mc, Rule.On_single, Rule.On, Rule.Round, Rule.Desc);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean unit_conversion_rule_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

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
    }
}