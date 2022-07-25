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
using Newtonsoft.Json;

namespace pg_class
{
	public partial class manager
	{
		/// <summary>
		/// Метод изменяет указанное представление класса
		/// </summary>
		public object_general object_upd(Int64 iid, Int32 iid_unit_conversion_rule, Decimal icquantity)

		{
			object_general Object = null;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("object_upd");
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
			cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
			cmdk.Parameters["icquantity"].Value = icquantity;
			cmdk.Parameters["setname"].Value = true;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					Object = object_by_id(iid);
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(iid, eEntity.vobject, error, desc_error, eAction.Update, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
			if (Object != null)
			{
				//Генерируем событие изменения
				ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object, eAction.Update);
				ObjectOnChange(e);
			}
			//Возвращаем сущность
			return Object;
		}

		/// <summary>
		/// Метод изменяет указанное представление класса
		/// </summary>
		public object_general object_upd(object_general Object)
		{
			return object_upd(Object.Id, Object.Id_unit_conversion_rule, Object.Quantity_curent);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean object_upd(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("object_upd");
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
		/// Метод переносит объект в новое расположение
		/// </summary>
		public object_general object_move(Int64 iid_object, Int64 iid_position, Decimal icquantity)
		{
			object_general Object_move = null;
			object_general Object_change = null;

			Int64 id = 0;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("object_move");
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
			cmdk.Parameters["iid_position"].Value = iid_position;
			cmdk.Parameters["icquantity"].Value = icquantity;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
					if (id > 0)
					{
						Object_move = object_by_id(id);
					}

					//Если идет частичное встраивание с созданием нового объекта находим остаток
					if (id != iid_object)
					{
						Object_change = object_by_id(iid_object);
					}
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(iid_object, eEntity.vobject, error, desc_error, eAction.Move, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
			//Генерируем событие изменения объекта
			ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object_move, eAction.Move);
			ObjectOnChange(e);

			//Если есть остаток то генерируем изменение остатка
			if (Object_change != null)
			{
				ObjectChangeEventArgs e3 = new ObjectChangeEventArgs(Object_change, eAction.Update);
				ObjectOnChange(e3);
			}
			//Возвращаем сущность
			return Object_move;
		}

		/// <summary>
		/// Метод переносит объект в новое расположение
		/// </summary>
		public object_general object_move(object_general Object, position Position, Decimal icuantity)
		{
			return object_move(Object.Id, Position.Id, icuantity);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean object_move(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;
			
			cmdk = CommandByKey("object_move");
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