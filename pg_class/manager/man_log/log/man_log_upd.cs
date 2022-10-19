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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Runtime.Remoting.Messaging;

namespace pg_class
{
	public partial class manager
	{
		/// <summary>
		/// Метод изменяет данные записи журнала
		/// </summary>
		public log log_upd(Int64 iid_log, Int64 iid_category, String iuser_author, DateTime idatetime, 
										String ititle, String imessage, String iclass_body, String ibody)
		{
			log log = null;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("log_upd");
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

			cmdk.Parameters["iid_log"].Value = iid_log;
			cmdk.Parameters["iid_category"].Value = iid_category;
			cmdk.Parameters["iuser_author"].Value = iuser_author;
			cmdk.Parameters["idatetime"].Value = idatetime;
			cmdk.Parameters["ititle"].Value = ititle;
			cmdk.Parameters["imessage"].Value = imessage;
			cmdk.Parameters["iclass_body"].Value = iclass_body;
			cmdk.Parameters["ibody"].Value = ibody;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					log = log_by_id(iid_log);
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(iid_log, eEntity.log, error, desc_error, eAction.Update, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
			if (log != null)
			{
				//Генерируем событие изменения
				LogChangeEventArgs e = new LogChangeEventArgs(log, eAction.Update);
				LogOnChange(e);
			}
			//Возвращаем сущность
			return log;
		}

		/// <summary>
		/// Метод изменяет данные записи журнала
		/// </summary>
		public log log_upd(log log)
		{
			return log_upd(log.Id, log.Id_category, log.User_author, log.Datetime,
										log.Title, log.Message, log.Class_body, log.Body);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean log_upd(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("log_upd");
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