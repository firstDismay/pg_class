using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Npgsql;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

namespace pg_class
{
	public partial class manager
	{
		/// <summary>
		/// Метод определяет текущее количество позиций указанного шаблона вложенных в указанную позицию
		/// </summary>
		public Int32 pos_temp_nested_limit_curent(Int64 id_pos, Int64 id_pos_temp)
		{
			Int32 nested_limit_curent = 0;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("pos_temp_nested_limit_curent");
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

			cmdk.Parameters["iid_pos"].Value = id_pos;
			cmdk.Parameters["iid_pos_temp"].Value = id_pos_temp;
			nested_limit_curent = (Int32)cmdk.ExecuteScalar();

			return nested_limit_curent;
		}

		/// <summary>
		/// Метод определяет текущее количество позиций указанного шаблона вложенных в указанную позицию
		/// </summary>
		public Int32 pos_temp_nested_limit_curent(position position, pos_temp pos_temp)
		{
			return pos_temp_nested_limit_curent(position.Id, pos_temp.Id);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean pos_temp_nested_limit_curent(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("pos_temp_nested_limit_curent");
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
		/// Метод определяет максимальное количество позиций указанного шаблона доступных к вложению в указанную позицию, 0 без ограничений
		/// </summary>
		public Int32 pos_temp_nested_limit_max(Int64 id_pos_temp, Int64 id_pos_temp_nested)
		{
			Int32 nested_limit_max = 0;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("pos_temp_nested_limit_max");
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

			cmdk.Parameters["iid_pos_temp"].Value = id_pos_temp;
			cmdk.Parameters["iid_pos_temp_nested"].Value = id_pos_temp_nested;
			nested_limit_max = (Int32)cmdk.ExecuteScalar();

			return nested_limit_max;
		}

		/// <summary>
		/// Метод определяет максимальное количество позиций указанного шаблона доступных к вложению в указанную позицию, 0 без ограничений
		/// </summary>
		public Int32 pos_temp_nested_limit_max(pos_temp pos_temp, pos_temp pos_temp_nested)
		{
			return pos_temp_nested_limit_max(pos_temp.Id, pos_temp_nested.Id);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean pos_temp_nested_limit_max(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("pos_temp_nested_limit_max");
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
		/// Метод возвращает минимальное значение параметра nested_limit_max определяемого по фактическому количеству вложенных позиций 
		/// </summary>
		public Int32 pos_temp_nested_limit_min(Int64 id_pos_temp, Int64 id_pos_temp_nested)
		{
			Int32 nested_limit_min = 0;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("pos_temp_nested_limit_min");
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

			cmdk.Parameters["iid_pos_temp"].Value = id_pos_temp;
			cmdk.Parameters["iid_pos_temp_nested"].Value = id_pos_temp_nested;
			nested_limit_min = (Int32)cmdk.ExecuteScalar();

			return nested_limit_min;
		}

		/// <summary>
		/// Метод определяет текущее количество позиций указанного шаблона вложенных в указанную позицию
		/// </summary>
		public Int32 pos_temp_nested_limit_min(pos_temp pos_temp, pos_temp pos_temp_nested)
		{
			return pos_temp_nested_limit_curent(pos_temp.Id, pos_temp_nested.Id);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean pos_temp_nested_limit_min(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("pos_temp_nested_limit_min");
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
		/// Метод выполняет проверку доступности вложения позиции выбранного шаблона в родительскую позицию 
		/// </summary>
		public Boolean pos_nested_limit_control(Int64 id_parent, Int64 id_pos_temp)
		{
			Boolean is_nested = false;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("position_nested_limit_control");
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

			cmdk.Parameters["iid_parent"].Value = id_parent;
			cmdk.Parameters["iid_pos_temp"].Value = id_pos_temp;
			is_nested = (Boolean)cmdk.ExecuteScalar();

			return is_nested;
		}

		/// <summary>
		/// Метод выполняет проверку доступности вложения позиции выбранного шаблона в родительскую позицию
		/// </summary>
		public Boolean pos_nested_limit_control(position position_parent, pos_temp pos_temp_nested)
		{
			return pos_nested_limit_control(position_parent.Id, pos_temp_nested.Id);
		}
		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean pos_nested_limit_control(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("position_nested_limit_control");
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