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
		/// Метод удаляет документ указанный по идентификатору
		/// </summary>
		public void document_del(Int64 iid_document)
		{
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;
			
			cmdk = CommandByKey("document_del");
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
			document document = document_by_id(iid_document);

			cmdk.Parameters["iid_document"].Value = iid_document;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			if (error > 0)
			{
				//Вызов события журнала
				JournalEventArgs me = new JournalEventArgs(iid_document, eEntity.document, error, desc_error, eAction.Delete, eJournalMessageType.error);
				JournalMessageOnReceived(me);
				throw new PgDataException(error, desc_error);
			}

			//Генерируем событие изменения концепции
			if (document != null)
			{
				DocumentChangeEventArgs e = new DocumentChangeEventArgs(document, eAction.Delete);
				DocumentOnChange(e);
			}
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean document_del(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("document_del");
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
		/// Метод удаляет документ и все вложенные документы по идентификатору документа
		/// </summary>
		public void document_del_all(Int64 iid_document)
		{
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("document_del_all");
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

			document document = document_by_id(iid_document);

			cmdk.Parameters["iid_document"].Value = iid_document;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			if (error > 0)
			{
				//Вызов события журнала
				JournalEventArgs me = new JournalEventArgs(iid_document, eEntity.document, error, desc_error, eAction.Delete, eJournalMessageType.error);
				JournalMessageOnReceived(me);
				throw new PgDataException(error, desc_error);
			}

			//Генерируем событие изменения концепции
			if (document != null)
			{
				DocumentChangeEventArgs e = new DocumentChangeEventArgs(document, eAction.Delete);
				DocumentOnChange(e);
			}
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean document_del_all(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("document_del_all");
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