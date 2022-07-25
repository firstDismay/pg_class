﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;
using System.Windows.Forms;

namespace pg_class
{
	public partial class manager
	{
		/// <summary>
		/// Метод определяет актуальность состояния шаблона позиции
		/// </summary>
		public eEntityState pos_temp_is_actual(Int64 iid, DateTime mytimestamp)
		{
			Int32 is_actual = 3;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("pos_temp_is_actual2");
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
		/// Метод определяет актуальность состояния шаблона позиции
		/// </summary>
		public eEntityState pos_temp_is_actual(pos_temp Pos_temp)
		{
			return pos_temp_is_actual(Pos_temp.Id, Pos_temp.Timestamp);
		}

		/// <summary>
		/// Метод проверяет свойства шаблона на готовность к созданию позиций
		/// </summary>
		public Boolean pos_temp_prop_check(Int64 iid_pos_temp)
		{
			Boolean Result = false;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("pos_temp_prop_check");
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

			cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;
			Result = (Boolean)cmdk.ExecuteScalar();

			return Result;
		}

		/// <summary>
		/// Метод проверяет свойства шаблона на готовность к созданию позиций
		/// </summary>
		public Boolean pos_temp_prop_check(pos_temp PosTemp)
		{
			return pos_temp_prop_check(PosTemp.Id);
		}

		/// <summary>
		/// Метод проверяет шаблон на готовность к созданию позиций
		/// </summary>
		public Boolean pos_temp_ready_check(Int64 iid_pos_temp)
		{
			Boolean Result = false;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("pos_temp_ready_check");
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

			cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;
			Result = (Boolean)cmdk.ExecuteScalar();

			return Result;
		}

		/// <summary>
		/// Метод проверяет шаблон на готовность к созданию позиций
		/// </summary>
		public Boolean pos_temp_ready_check(pos_temp PosTemp)
		{
			return pos_temp_ready_check(PosTemp.Id);
		}
	}
}