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
		/// Метод определяет актуальность состояния свойства активного класса 
		/// </summary>
		public eEntityState pos_temp_prop_is_actual(Int64 iid, DateTime itimestamp)
		{
			Int32 is_actual = 3;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("pos_temp_prop_is_actual");
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
			cmdk.Parameters["itimestamp"].Value = itimestamp;
			is_actual = (Int32)cmdk.ExecuteScalar();

			return (eEntityState)is_actual;
		}

		/// <summary>
		/// Метод определяет актуальность состояния свойства активного класса 
		/// </summary>
		public eEntityState pos_temp_prop_is_actual(pos_temp_prop PosTempProp)
		{
			return pos_temp_prop_is_actual(PosTempProp.Id, PosTempProp.Timestamp);
		}
	}
}