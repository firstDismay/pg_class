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
using System.Security.Cryptography;
using System.IO;

namespace pg_class
{
	public partial class manager
	{
		/// <summary>
		/// Метод удаляет запись журнала указанный по идентификатору
		/// </summary>
		public void log_del(Int64 iid_log)
		{
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;
			
			cmdk = CommandByKey("log_del");
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

			//Запрос удаляемой сущности
			log log = log_by_id(iid_log);

			cmdk.Parameters["iid_log"].Value = iid_log;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			if (error > 0)
			{
				//Вызов события журнала
				JournalEventArgs me = new JournalEventArgs(iid_log, eEntity.log, error, desc_error, eAction.Delete, eJournalMessageType.error);
				JournalMessageOnReceived(me);
				throw new PgDataException(error, desc_error);
			}

			//Генерируем событие изменения концепции
			if (log != null)
			{
				LogChangeEventArgs e = new LogChangeEventArgs(log, eAction.Delete);
				LogOnChange(e);
			}
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean log_del(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("log_del");
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