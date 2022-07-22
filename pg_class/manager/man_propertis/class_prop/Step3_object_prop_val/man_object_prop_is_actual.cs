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
		/// Метод определяет актуальность состояния свойства объекта
		/// </summary>
		public eEntityState object_prop_is_actual(Int64 iid_class_prop, Int64 iid_object_carrier, DateTime itimestamp_object_carrier)
		{
			Int32 is_actual = 3;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("object_prop_is_actual");
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

			cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
			cmdk.Parameters["iid_object_carrier"].Value = iid_object_carrier;
			cmdk.Parameters["itimestamp_object_carrier"].Value = itimestamp_object_carrier;
			is_actual = (Int32)cmdk.ExecuteScalar();

			return (eEntityState)is_actual;
		}

		/// <summary>
		/// Метод определяет актуальность состояния свойства объекта
		/// </summary>
		public eEntityState object_prop_is_actual(object_prop ObjectProp)
		{
			eEntityState Result = eEntityState.NotFound;
			Result = object_prop_is_actual(ObjectProp.Id_class_prop, ObjectProp.Id_object_carrier, ObjectProp.Timestamp_object_carrier);
			return Result;
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean object_prop_is_actual(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("object_prop_is_actual");
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