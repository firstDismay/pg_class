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
		/// Метод изменяет указанную позицию
		/// </summary>
		public position position_upd(Int64 id, String iname, String idesc, Int32 isort)
		{
			position position = null;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;
			
			cmdk = CommandByKey("position_upd");
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

			cmdk.Parameters["iid"].Value = id;
			cmdk.Parameters["iname"].Value = iname;
			cmdk.Parameters["idesc"].Value = idesc;
			cmdk.Parameters["isort"].Value = isort;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					position = position_by_id(id);
					if (position != null)
					{
						//Генерируем событие изменения позиции
						PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Update);
						PositionOnChange(e);
					}
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(id, eEntity.position, error, desc_error, eAction.Update, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
			
			//Возвращаем Объект
			return position;
		}

		/// <summary>
		/// Метод изменяет указанную позицию
		/// </summary>
		public position position_upd(position pos)
		{
			return position_upd(pos.Id, pos.NamePosition, pos.Desc, pos.Sort);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean position_upd(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("position_upd");
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
		/// Метод переносит дочернюю позицию в новую родительскую позицию
		/// </summary>
		public position position_move(Int64 ChildPos, Int64 ParentPos)
		{
			position position = null;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("position_move");
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

			cmdk.Parameters["iid"].Value = ChildPos;
			cmdk.Parameters["iid_parent"].Value = ParentPos;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					position = position_by_id(ChildPos);
					if (position != null)
					{
						//Генерируем событие изменения позиции
						PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Move);
						PositionOnChange(e);
					}
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(ChildPos, eEntity.position, error, desc_error, eAction.Move, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
			
			//Возвращаем Объект
			return position;
		}

		/// <summary>
		/// Метод переносит дочернюю позицию в новую родительскую позицию
		/// </summary>
		public position position_move(position ChildPos, position ParentPos)
		{
			return position_move(ChildPos.Id, ParentPos.Id);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean position_move(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;
			
			cmdk = CommandByKey("position_move");
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
		/// Метод переносит дочернюю позицию в корень дерева концепции
		/// </summary>
		public position position_move_root(Int64 ChildPos)
		{
			position position = null;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("position_move");
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

			cmdk.Parameters["iid"].Value = ChildPos;
			cmdk.Parameters["iid_parent"].Value = 0;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					position = position_by_id(ChildPos);
					if (position != null)
					{
						//Генерируем событие изменения позиции
						PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Move);
						PositionOnChange(e);
					}

					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(ChildPos, eEntity.position, error, desc_error, eAction.Move, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}

			//Возвращаем Объект
			return position;
		}

		/// <summary>
		/// Метод переносит дочернюю позицию в корень дерева концепции
		/// </summary>
		public position position_move_root(position ChildPos)
		{
			return position_move_root(ChildPos.Id);
		}
		
		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean position_move_root(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;
		
			cmdk = CommandByKey("position_move");
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
		/// Метод изменяет блокировку позиции
		/// </summary>
		public position position_changelock(Int64 iid, Boolean onlock)
		{
			position position = null;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("position_changelock");
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
			cmdk.Parameters["onlock"].Value = onlock;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			eAction Action;
			if (onlock)
			{
				Action = eAction.Lock;
			}
			else
			{
				Action = eAction.UnLock;
			}
			switch (error)
			{
				case 0:
					position = position_by_id(iid);
					if (position != null)
					{
						PositionChangeEventArgs e = new PositionChangeEventArgs(position, Action);
						PositionOnChangeLock(e);
					}
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(iid, eEntity.position, error, desc_error, Action, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}

			//Возвращаем Объект
			return position;
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean position_changelock(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;
			
			cmdk = CommandByKey("position_changelock");
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