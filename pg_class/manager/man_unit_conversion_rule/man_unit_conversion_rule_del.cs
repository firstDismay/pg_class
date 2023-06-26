using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод удаляет правило пересчета единиц измерения колличества объектов
        /// </summary>
        public void unit_conversion_rule_del(Int32 id)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

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

            cmdk.Parameters["iid"].Value = id;
            cmdk.ExecuteNonQuery();

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

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean unit_conversion_rule_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

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
    }
}