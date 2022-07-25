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
		/// Метод добавляет новую группу
		/// </summary>
		public group group_add(Int64 iid_parent, Int64 iid_con, String iname, String idesc, Boolean ion_class, Int32 isort)
		{
			group group = null;
			Int64 id = 0;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("group_add");
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

			cmdk.Parameters["iid_parent"].Value = iid_parent;
			cmdk.Parameters["iid_con"].Value = iid_con;
			cmdk.Parameters["iname"].Value = iname;
			cmdk.Parameters["idesc"].Value = idesc;
			cmdk.Parameters["ion_class"].Value = ion_class;
			cmdk.Parameters["isort"].Value = isort;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
					if (id > 0)
					{
						group = group_by_id(id);
					}
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(id, eEntity.group, error, desc_error, eAction.Insert, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
			if (group != null)
			{
				//Генерируем событие изменения группы
				GroupChangeEventArgs e = new GroupChangeEventArgs(group, eAction.Insert);
				GroupOnChange(e);
			}
			//Возвращаем сущность
			return group;
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean group_add(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("group_add");
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
		/// Метод копирует группу в новую родительскую группу
		/// </summary>
		public group group_copy(Int64 iid_pattern, Int64 iid_parent)
		{
			group group = null;
			Int64 id = 0;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("group_copy");
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

			cmdk.Parameters["iid_pattern"].Value = iid_pattern;
			cmdk.Parameters["iid_parent"].Value = iid_parent;
			cmdk.Parameters["recursivecall"].Value = false;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
					if (id > 0)
					{
						group = group_by_id(id);
					}
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(id, eEntity.group, error, desc_error, eAction.Copy, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
			if (group != null)
			{
				//Генерируем событие изменения позиции
				GroupChangeEventArgs e = new GroupChangeEventArgs(group, eAction.Move);
				GroupOnChange(e);
			}
			//Возвращаем сущность
			return group;
		}

		/// <summary>
		/// Метод копирует группу в новую родительскую группу
		/// </summary>
		public group group_copy(group Pattern, group Parent)
		{
			if (Parent != null)
			{
				return group_copy(Pattern.Id, Parent.Id);
			}
			else
			{
				return group_copy(Pattern.Id, 0);
			}
		}
		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean group_copy(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("group_copy");
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