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

namespace pg_class
{
	public partial class manager
	{
		/// <summary>
		/// Метод удаляет указанную категорию записей журнала
		/// </summary>
		public void log_category_del(Int64 iid)
		{
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("log_category_del");
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

			log_category log_category = log_category_by_id(iid);

			cmdk.Parameters["iid"].Value = iid;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			if (error > 0)
			{
				//Вызов события журнала
				JournalEventArgs me = new JournalEventArgs(iid, eEntity.log_category, error, desc_error, eAction.Delete, eJournalMessageType.error);
				JournalMessageOnReceived(me);
				throw new PgDataException(error, desc_error);
			}

			//Генерируем событие изменения концепции
			if (log_category != null)
			{
				LogCategoryChangeEventArgs e = new LogCategoryChangeEventArgs(log_category, eAction.Delete);
				LogCategoryOnChange(e);
			}
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean log_category_del(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("log_category_del");
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