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
		/// Лист измеряемых величин
		/// </summary>
		public List<unit> units_by_all()
		{
			List<unit> units_list = new List<unit>();
			DataTable tbl_unit = TableByName("vunits");
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("units_by_all");
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

			cmdk.Fill(tbl_unit);

			unit u;
			if (tbl_unit.Rows.Count > 0)
			{
				foreach (System.Data.DataRow dr in tbl_unit.Rows)
				{
					u = new unit(dr);
					units_list.Add(u);
				}
			}

			return units_list;
		}

		/// <summary>
		/// Лист измеряемых величин
		/// </summary>
		public List<unit_conception> unit_conception_by_all(Int64 Id_conception)
		{
			List<unit_conception> units_list = new List<unit_conception>();
			DataTable tbl_unit = TableByName("vunits");
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("units_by_all");
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

			cmdk.Fill(tbl_unit);

			unit_conception u;
			if (tbl_unit.Rows.Count > 0)
			{
				foreach (System.Data.DataRow dr in tbl_unit.Rows)
				{
					u = new unit_conception(Id_conception, dr);
					units_list.Add(u);
				}
			}
			return units_list;
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean unit_conception_by_all(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("units_by_all");
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
		/// Измеряемая величина по id
		/// </summary>
		public unit units_by_id(Int32 id)
		{
			unit unit = null;
			DataTable tbl_unit = TableByName("vunits");
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("units_by_id");
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
			cmdk.Fill(tbl_unit);
			if (tbl_unit.Rows.Count > 0)
			{
				unit = new unit(tbl_unit.Rows[0]);
			}
			return unit;
		}

		/// <summary>
		/// Измеряемая величина по id
		/// </summary>
		public unit_conception unit_conception_by_id(Int32 id, Int64 Id_conception)
		{
			unit_conception unit = null;
			DataTable tbl_unit = TableByName("vunits");
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("units_by_id");
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
			cmdk.Fill(tbl_unit);

			if (tbl_unit.Rows.Count > 0)
			{
				unit = new unit_conception(Id_conception, tbl_unit.Rows[0]);
			}
			return unit;
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean units_by_id(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("units_by_id");
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