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
		/// Правило пересчета единиц измерения объектов по id
		/// </summary>
		public unit_conversion_rule unit_conversion_rule_by_id(Int32 id)
		{
			unit_conversion_rule rule = null;
			DataTable tbl_rule = TableByName("vunit_conversion_rules");
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("unit_conversion_rule_by_id");
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
			cmdk.Fill(tbl_rule);
			if (tbl_rule.Rows.Count > 0)
			{
				rule = new unit_conversion_rule(tbl_rule.Rows[0]);
			}
			return rule;
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean unit_conversion_rule_by_id(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("unit_conversion_rule_by_id");
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
		/// Базовое правило пересчета по идентификатору измеряемой величины
		/// </summary>
		public unit_conversion_rule unit_conversion_rule_base_by_id_unit(Int64 iid_con, Int32 iid_unit)
		{
			unit_conversion_rule rule = null;
			DataTable tbl_rule = TableByName("vunit_conversion_rules");
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("unit_conversion_rule_base_by_id_unit");
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
			cmdk.Fill(tbl_rule);

			if (tbl_rule.Rows.Count > 0)
			{
				rule = new unit_conversion_rule(tbl_rule.Rows[0]);
			}
			return rule;
		}

		/// <summary>
		/// Базовое правило пересчета по идентификатору измеряемой величины
		/// </summary>
		public unit_conversion_rule unit_conversion_rule_base_by_id_unit(Int64 id_conception, unit Unit)
		{
			return unit_conversion_rule_base_by_id_unit(id_conception, Unit.Id);
		}

		/// <summary>
		/// Базовое правило пересчета по идентификатору измеряемой величины
		/// </summary>
		public unit_conversion_rule unit_conversion_rule_base_by_id_unit(conception Conception, unit Unit)
		{
			return unit_conversion_rule_base_by_id_unit(Conception.Id, Unit.Id);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean unit_conversion_rule_base_by_id_unit(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("unit_conversion_rule_base_by_id_unit");
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
		/// Лист правил пересчета по идентификатору величины измерения
		/// </summary>
		public List<unit_conversion_rule> unit_conversion_rule_by_id_unit(Int64 iid_con, Int32 iid_unit)
		{
			List<unit_conversion_rule> rule_list = new List<unit_conversion_rule>();
			DataTable tbl_rule = TableByName("vunit_conversion_rules");
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("unit_conversion_rule_by_id_unit");
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
			cmdk.Fill(tbl_rule);

			unit_conversion_rule rule;
			if (tbl_rule.Rows.Count > 0)
			{
				foreach (System.Data.DataRow dr in tbl_rule.Rows)
				{
					rule = new unit_conversion_rule(dr);
					rule_list.Add(rule);
				}
			}

			return rule_list;
		}

		/// <summary>
		/// Лист правил пересчета по идентификатору величины измерения
		/// </summary>
		public List<unit_conversion_rule> unit_conversion_rule_by_id_unit(Int64 id_conception, unit Unit)
		{
			return unit_conversion_rule_by_id_unit(id_conception, Unit.Id);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean unit_conversion_rule_by_id_unit(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("unit_conversion_rule_by_id_unit");
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
		/// Лист правил пересчета по идентификатору активного представления вещественного класса
		/// </summary>
		public List<unit_conversion_rule> unit_conversion_rule_by_id_class(Int64 iid_class)
		{
			List<unit_conversion_rule> rule_list = new List<unit_conversion_rule>();
			DataTable tbl_rule = TableByName("vunit_conversion_rules");
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("unit_conversion_rule_by_id_class");
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
			cmdk.Fill(tbl_rule);

			unit_conversion_rule rule;
			if (tbl_rule.Rows.Count > 0)
			{
				foreach (System.Data.DataRow dr in tbl_rule.Rows)
				{
					rule = new unit_conversion_rule(dr);
					rule_list.Add(rule);
				}
			}

			return rule_list;
		}

		/// <summary>
		/// Лист правил пересчета по идентификатору активного представления вещественного класса
		/// </summary>
		public List<unit_conversion_rule> unit_conversion_rule_by_id_class(vclass Class)
		{
			return unit_conversion_rule_by_id_class(Class.Id);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean unit_conversion_rule_by_id_class(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("unit_conversion_rule_by_id_class");
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
		/// Правила пересчета по идентификатору объекта
		/// </summary>
		public List<unit_conversion_rule> unit_conversion_rule_by_id_object(Int64 iid_object)
		{
			List<unit_conversion_rule> rule_list = new List<unit_conversion_rule>();
			DataTable tbl_rule = TableByName("vunit_conversion_rules");
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("unit_conversion_rule_by_id_object");
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
			cmdk.Fill(tbl_rule);

			unit_conversion_rule rule;
			if (tbl_rule.Rows.Count > 0)
			{
				foreach (System.Data.DataRow dr in tbl_rule.Rows)
				{
					rule = new unit_conversion_rule(dr);
					rule_list.Add(rule);
				}
			}

			return rule_list;
		}

		/// <summary>
		/// Лист правил пересчета по идентификатору объекта
		/// </summary>
		public List<unit_conversion_rule> unit_conversion_rule_by_id_object(object_general Object)
		{
			return unit_conversion_rule_by_id_object(Object.Id);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean unit_conversion_rule_by_id_object(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("unit_conversion_rule_by_id_object");
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