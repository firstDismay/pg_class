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

namespace pg_class
{
	public partial class manager
	{
		/// <summary>
		/// Метод удаляет указаную ссылку записи журнала
		/// </summary>
		public void log_link_del( Int64 iid_log_link)
		{
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;
			
			cmdk = CommandByKey("log_link_del");
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

			log_link log_link = log_link_by_id(iid_log_link);
			
			cmdk.Parameters["iid_log_link"].Value = iid_log_link;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			if (error > 0)
			{
				//Вызов события журнала
				JournalEventArgs me = new JournalEventArgs(iid_log_link, eEntity.log_link, error, desc_error, eAction.Delete, eJournalMessageType.error);
				JournalMessageOnReceived(me);
				throw new PgDataException(error, desc_error);
			}

			if (log_link != null)
			{
				//Генерируем событие изменения
				LogLinkChangeEventArgs e = new LogLinkChangeEventArgs(log_link, eAction.Delete);
				LogLinkOnChange(e);
			}
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean log_link_del(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;
			
			cmdk = CommandByKey("log_link_del");
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
		/// Метод удаляет указаную ссылку записи журнала по идентификатору сущности
		/// </summary>
		public void log_link_del_by_entity(Int64 iid_log, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
		{
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;
			Int64 iid_log_link = -1;

			cmdk = CommandByKey("log_link_del_by_entity");
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

			log_link log_link = log_link_by_entity(iid_log, iid_entity, iid_entity_instance, iid_sub_entity_instance);
			if (log_link != null)
			{
				iid_log_link = log_link.Id;
			}

			cmdk.Parameters["iid_log"].Value = iid_log;
			cmdk.Parameters["iid_entity"].Value = iid_entity;
			cmdk.Parameters["iid_entity_instance"].Value = iid_entity_instance;
			cmdk.Parameters["iid_sub_entity_instance"].Value = iid_sub_entity_instance;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			if (error > 0)
			{
				//Вызов события журнала
				JournalEventArgs me = new JournalEventArgs(iid_log_link, eEntity.log_link, error, desc_error, eAction.Delete, eJournalMessageType.error);
				JournalMessageOnReceived(me);
				throw new PgDataException(error, desc_error);
			}

			if (log_link != null)
			{
				//Генерируем событие изменения
				LogLinkChangeEventArgs e = new LogLinkChangeEventArgs(log_link, eAction.Delete);
				LogLinkOnChange(e);
			}
		}

		/// <summary>
		/// Метод удаляет указаную ссылку записи журнала по идентификатору сущности
		/// </summary>
		public void log_link_del_by_entity(Int64 iid_log, user User)
		{
			log_link_del_by_entity(iid_log, User.EntityID, User.Id, -1);
		}

		/// <summary>
		/// Метод удаляет указаную ссылку записи журнала по идентификатору сущности
		/// </summary>
		public void log_link_del_by_entity(Int64 iid_log, pos_temp Pos_temp)
		{
			log_link_del_by_entity(iid_log, Pos_temp.EntityID, Pos_temp.Id, -1);
		}

		/// <summary>
		/// Метод удаляет указаную ссылку записи журнала по идентификатору сущности
		/// </summary>
		public void log_link_del_by_entity(Int64 iid_log, pos_temp_prop Pos_temp_prop)
		{
			log_link_del_by_entity(iid_log, Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
		}

		/// <summary>
		/// Метод удаляет указаную ссылку записи журнала по идентификатору сущности
		/// </summary>
		public void log_link_del_by_entity(Int64 iid_log, position Position)
		{
			log_link_del_by_entity(iid_log, Position.EntityID, Position.Id, -1);
		}

		/// <summary>
		/// Метод удаляет указаную ссылку записи журнала по идентификатору сущности
		/// </summary>
		public void log_link_del_by_entity(Int64 iid_log, position_prop Position_prop)
		{
			log_link_del_by_entity(iid_log, Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
		}

		/// <summary>
		/// Метод удаляет указаную ссылку записи журнала по идентификатору сущности
		/// </summary>
		public void log_link_del_by_entity(Int64 iid_log, object_general Object_general)
		{
			log_link_del_by_entity(iid_log, Object_general.EntityID, Object_general.Id, -1);
		}

		/// <summary>
		/// Метод удаляет указаную ссылку записи журнала по идентификатору сущности
		/// </summary>
		public void log_link_del_by_entity(Int64 iid_log, object_prop Object_prop)
		{
			log_link_del_by_entity(iid_log, Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
		}

		/// <summary>
		/// Метод удаляет указаную ссылку записи журнала по идентификатору сущности
		/// </summary>
		public void log_link_del_by_entity(Int64 iid_log, group Group)
		{
			log_link_del_by_entity(iid_log, Group.EntityID, Group.Id, -1);
		}

		/// <summary>
		/// Метод удаляет указаную ссылку записи журнала по идентификатору сущности
		/// </summary>
		public void log_link_del_by_entity(Int64 iid_log, vclass Class)
		{
			log_link_del_by_entity(iid_log, Class.EntityID, Class.Id, -1);
		}

		/// <summary>
		/// Метод удаляет указаную ссылку записи журнала по идентификатору сущности
		/// </summary>
		public void log_link_del_by_entity(Int64 iid_log, class_prop Class_prop)
		{
			log_link_del_by_entity(iid_log, Class_prop.EntityID, Class_prop.Id, -1);
		}

		/// <summary>
		/// Метод удаляет указаную ссылку записи журнала по идентификатору сущности
		/// </summary>
		public void log_link_del_by_entity(Int64 iid_log, document Document)
		{
			log_link_del_by_entity(iid_log, Document.EntityID, Document.Id, -1);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean log_link_del_by_entity(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("log_link_del_by_entity");
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