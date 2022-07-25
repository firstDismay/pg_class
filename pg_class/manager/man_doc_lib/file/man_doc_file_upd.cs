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
		/// Метод изменяет атрибуты файла документа
		/// </summary>
		public doc_file doc_file_upd(Int64 iid_doc_file, String ifilename, String iversion, DateTime iversiondate, String iextension, Boolean ifulltxtsrch_on)
		{
			doc_file doc_file = null;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("doc_file_upd");
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

			// Подготавливаем имя файла документа
			char[] charInvalidFileChars = Path.GetInvalidFileNameChars();
			foreach (char charInvalid in charInvalidFileChars)
			{
				ifilename = ifilename.Replace(charInvalid, ' ');
			}
			ifilename = ifilename.Replace(';', ' ');
			ifilename = ifilename.Replace("  ", " ");

			cmdk.Parameters["iid_doc_file"].Value = iid_doc_file;
			cmdk.Parameters["ifilename"].Value = ifilename;
			cmdk.Parameters["iversion"].Value = iversion;
			cmdk.Parameters["iversiondate"].Value = iversiondate;
			cmdk.Parameters["iextension"].Value = iextension;
			cmdk.Parameters["ifulltxtsrch_on"].Value = ifulltxtsrch_on;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					doc_file = doc_file_by_id(iid_doc_file);
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(iid_doc_file, eEntity.doc_file, error, desc_error, eAction.Update, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
			if (doc_file != null)
			{
				//Генерируем событие изменения файла документов
				DocFileChangeEventArgs e = new DocFileChangeEventArgs(doc_file, eAction.Update);
				DocFileOnChange(e);
			}
			//Возвращаем сущность
			return doc_file;
		}

		/// <summary>
		/// Метод изменяет атрибуты файла документа
		/// </summary>
		public doc_file doc_file_upd(doc_file Doc_file)
		{
			return doc_file_upd(Doc_file.Id, Doc_file.Name, Doc_file.Version, Doc_file.Versiondate, Doc_file.Extension, Doc_file.Fulltxtsrch_on);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean doc_file_upd(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("doc_file_upd");
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
		/// Метод заменяет файл документа
		/// </summary>
		public doc_file doc_file_change(Int64 iid_doc_file, String ifilename, String iversion, DateTime iversiondate, String iextension, Byte[] file_data, eSizeTransferPage isizepage)
		{
			doc_file doc_file = null;
			String imd5 = "";
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;
			NpgsqlCommandKey cmdk_next;

			cmdk = CommandByKey("doc_file_change");
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
			cmdk_next = CommandByKey("doc_file_add_next");
			if (cmdk_next != null)
			{
				if (!cmdk_next.Access)
				{
					throw new AccessDataBaseException(404, String.Format(@"Отказано в доступе к методу: {0}!", cmdk_next.CommandText));
				}
			}
			else
			{
				throw new AccessDataBaseException(405, String.Format(@"Не найден метод: {0}!", cmdk_next.CommandText));
			}

			Int32 SizePage;
			Int32 SizeEndPage;
			Int32 CountPage;
			Byte[] buffer;
			MemoryStream ms;

			if (file_data == null || file_data.Length == 0)
			{
				String err = String.Format("Передан пустой массив данных!");
				throw new PgManagerException(101, err, err);
			}

			ms = new MemoryStream(file_data);
			if (file_data.Length > (Int32)isizepage)
			{
				SizePage = (Int32)isizepage;
				CountPage = Math.DivRem(file_data.Length, SizePage, out SizeEndPage);

				buffer = new Byte[SizePage];
				ms.Read(buffer, 0, SizePage);
			}
			else
			{
				SizePage = 0;
				SizeEndPage = 0;
				CountPage = 0;
				buffer = file_data;
			}

			//Расчитываем чексумму массива
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] checkSum = md5.ComputeHash(file_data);
			imd5 = BitConverter.ToString(checkSum).Replace("-", String.Empty);

			//Инициализируем методы первичной записи
			cmdk.Parameters["iid_doc_file"].Value = iid_doc_file;
			cmdk.Parameters["ifilename"].Value = ifilename;
			cmdk.Parameters["iversion"].Value = iversion;
			cmdk.Parameters["iversiondate"].Value = iversiondate;
			cmdk.Parameters["iextension"].Value = iextension;
			cmdk.Parameters["file_data"].Size = buffer.Length;
			cmdk.Parameters["file_data"].Value = buffer;
			cmdk.Parameters["imd5"].Value = imd5;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					//Этап №02 Циклическая дозаливка документа
					if (CountPage > 1)
					{
						for (int i = 1; i < CountPage; i++)
						{
							buffer = new Byte[SizePage];
							ms.Position = i * SizePage;
							ms.Read(buffer, 0, SizePage);

							cmdk_next.Parameters["iid_doc_file"].Value = iid_doc_file;
							cmdk_next.Parameters["file_data"].Size = buffer.Length;
							cmdk_next.Parameters["file_data"].Value = buffer;
							cmdk_next.ExecuteNonQuery();
						}
					}

					//Этап №03 Заливка остатка документа
					if (SizeEndPage > 0)
					{
						buffer = new Byte[SizeEndPage];
						ms.Position = CountPage * SizePage;
						ms.Read(buffer, 0, SizeEndPage);

						cmdk_next.Parameters["iid_doc_file"].Value = iid_doc_file;
						cmdk_next.Parameters["file_data"].Size = buffer.Length;
						cmdk_next.Parameters["file_data"].Value = buffer;
						cmdk_next.ExecuteNonQuery();
					}
					doc_file = doc_file_by_id(iid_doc_file);
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(iid_doc_file, eEntity.doc_file, error, desc_error, eAction.Update, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
			if (doc_file != null)
			{
				//Генерируем событие изменения файла документов
				DocFileChangeEventArgs e = new DocFileChangeEventArgs(doc_file, eAction.Update);
				DocFileOnChange(e);
			}
			//Возвращаем сущность
			return doc_file;
		}

		/// <summary>
		/// Метод заменяет файл документа
		/// </summary>
		public doc_file doc_file_change(doc_file Doc_file, String ifilename, Byte[] file_data, String iversion, DateTime iversiondate, String iextension, eSizeTransferPage isizepage)
		{
			return doc_file_change(Doc_file.Id, ifilename, iversion, iversiondate, iextension, file_data, isizepage);
		}

		/// <summary>
		/// Метод заменяет файл документа
		/// </summary>
		public doc_file doc_file_change(Int64 iid_doc_file, String iversion, DateTime iversiondate, String Path, eSizeTransferPage isizepage)
		{
			doc_file Result = null;
			Byte[] file_data = null;
			String iextension = "";
			String ifilename = "";
			using (FileStream fs = System.IO.File.OpenRead(Path))
			{
				file_data = new byte[fs.Length];
				fs.Read(file_data, 0, (int)fs.Length);
				iextension = System.IO.Path.GetExtension(Path);
				ifilename = System.IO.Path.GetFileNameWithoutExtension(Path);
				Result = doc_file_change(iid_doc_file, ifilename, iversion, iversiondate, iextension, file_data, isizepage);
			}
			return Result;
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean doc_file_change(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("doc_file_change");
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