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
		/// Метод определяет актуальность состояния правила пересчета
		/// </summary>
		public eEntityState unit_conversion_rules_is_actual(Int64 iid, DateTime mytimestamp)
		{
			Int32 is_actual = 3;
			NpgsqlCommandKey cmdk;

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

			cmdk.Parameters["iid"].Value = iid;
			cmdk.Parameters["mytimestamp"].Value = mytimestamp;
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
	}
}