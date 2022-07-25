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

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					//Генерируем событие изменения правила пересчета
					UnitConversionRuleChangeEventArgs e = new UnitConversionRuleChangeEventArgs(id, eAction.Delete);
					UnitConversionRuleOnChange(e);
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(id, eEntity.unit_conversion_rule, error, desc_error, eAction.Delete, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
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