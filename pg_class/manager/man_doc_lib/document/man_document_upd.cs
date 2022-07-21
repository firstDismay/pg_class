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
		/// Метод изменяет атрибуты документа
		/// </summary>
		public document document_upd(Int64 iid_document, Int64 iid_category, String iname, String idesc, String iregnum, DateTime iregdate)
		{
			document document = null;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("document_upd");
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

			cmdk.Parameters["iid_document"].Value = iid_document;
			cmdk.Parameters["iid_category"].Value = iid_category;
			cmdk.Parameters["iname"].Value = iname;
			cmdk.Parameters["idesc"].Value = idesc;
			cmdk.Parameters["iregnum"].Value = iregnum;
			cmdk.Parameters["iregdate"].Value = iregdate;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					document = document_by_id(iid_document);
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(iid_document, eEntity.document, error, desc_error, eAction.Update, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
			if (document != null)
			{
				//Генерируем событие изменения
				DocumentChangeEventArgs e = new DocumentChangeEventArgs(document, eAction.Update);
				DocumentOnChange(e);
			}
			//Возвращаем Объект
			return document;
		}

		/// <summary>
		/// Метод изменяет атрибуты документа
		/// </summary>
		public document document_upd(document Document)
		{
			return document_upd(Document.Id, Document.Id_category, Document.Name, Document.Desc, Document.Regnum, Document.Regdate);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean document_upd(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("document_upd");
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
		/// Метод добавляет документ в пакет документов
		/// </summary>
		public document document_include_in_pack(Int64 iid_document_pack, Int64 iid_document)
		{
			document document = null;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("document_include_in_pack");
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

			cmdk.Parameters["iid_document_pack"].Value = iid_document_pack;
			cmdk.Parameters["iid_document"].Value = iid_document;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					document = document_by_id(iid_document);
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(iid_document, eEntity.document, error, desc_error, eAction.Include, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
			if (document != null)
			{
				//Генерируем событие изменения
				DocumentChangeEventArgs e = new DocumentChangeEventArgs(document, eAction.Include);
				DocumentOnChange(e);
			}
			//Возвращаем Объект
			return document;
		}

		/// <summary>
		/// Метод добавляет документ в пакет документов
		/// </summary>
		public document document_include_in_pack(document DocumentPack, document Document)
		{
			return document_include_in_pack(DocumentPack.Id, Document.Id);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean document_include_in_pack(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("document_include_in_pack");
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
		/// Метод исключает документ из пакета документов
		/// </summary>
		public document document_exclude_from_pack(Int64 iid_document)
		{
			document document = null;
			document document_old = null;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("document_exclude_from_pack");
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

			//Запрос потенциально удаляемой сущности
			document_old = document_by_id(iid_document);

			cmdk.Parameters["iid_document"].Value = iid_document;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					document = document_by_id(iid_document);
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(iid_document, eEntity.document, error, desc_error, eAction.Exclude, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
			//Генерируем событие изменения файла документов
			if (document != null)
			{
				DocumentChangeEventArgs e = new DocumentChangeEventArgs(document, eAction.Exclude);
				DocumentOnChange(e);
			}
			else
			{
				DocumentChangeEventArgs e = new DocumentChangeEventArgs(document_old, eAction.Delete);
				DocumentOnChange(e);
			}
			//Возвращаем Объект
			return document;
		}

		/// <summary>
		/// Метод исключает документ из пакета документов
		/// </summary>
		public document document_exclude_from_pack(document Document)
		{
			return document_exclude_from_pack(Document.Id);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean document_exclude_from_pack(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("document_exclude_from_pack");
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