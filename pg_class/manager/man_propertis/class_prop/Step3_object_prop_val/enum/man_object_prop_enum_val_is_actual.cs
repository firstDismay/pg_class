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
		/// Определить актуальность состояния данных значения свойства объекта
		/// </summary>
		public eEntityState object_prop_enum_val_is_actual(Int64 iid_object, Int64 iid_class_prop, DateTime itimestamp_val)
		{
			Int32 is_actual = 3;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("object_prop_enum_val_is_actual");
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

			cmdk.Parameters["iid_object"].Value = iid_object;
			cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
			cmdk.Parameters["itimestamp_val"].Value = itimestamp_val;
			is_actual = (Int32)cmdk.ExecuteScalar();

			return (eEntityState)is_actual;
		}

		/// <summary>
		/// Определить актуальность состояния значения свойства активного представления класса 
		/// </summary>
		public eEntityState object_prop_enum_val_is_actual(object_prop_enum_val ObjectPropEnumValClass)
		{
			eEntityState Result = eEntityState.History;
			Result = object_prop_enum_val_is_actual(ObjectPropEnumValClass.Id_object, ObjectPropEnumValClass.Id_class_prop, ObjectPropEnumValClass.Timestamp_val);
			return Result;
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean object_prop_enum_val_is_actual(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("object_prop_enum_val_is_actual");
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