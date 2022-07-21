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
		/// Метод добавляет новый документ
		/// </summary>
		public document document_add(Int64 iid_category, Int64 iid_parent,
									 String iname, String idesc, String iregnum, DateTime iregdate,
									 Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
		{
			document document = null;
			Int64 id = 0;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("document_add");
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

			cmdk.Parameters["iid_category"].Value = iid_category;
			cmdk.Parameters["iid_parent"].Value = iid_parent;
			cmdk.Parameters["iname"].Value = iname;
			cmdk.Parameters["idesc"].Value = idesc;
			cmdk.Parameters["iregnum"].Value = iregnum;
			cmdk.Parameters["iregdate"].Value = iregdate;
			cmdk.Parameters["iid_entity"].Value = iid_entity;
			cmdk.Parameters["iid_entity_instance"].Value = iid_entity_instance;
			cmdk.Parameters["iid_sub_entity_instance"].Value = iid_sub_entity_instance;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
					if (id > 0)
					{
						document = document_by_id(id);
					}
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(id, eEntity.document, error, desc_error, eAction.Insert, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
			if (document != null)
			{
				//Генерируем событие изменения 
				DocumentChangeEventArgs e = new DocumentChangeEventArgs(document, eAction.Insert);
				DocumentOnChange(e);
			}
			//Возвращаем Объект
			return document;
		}

		/// <summary>
		/// Метод добавляет новый документ
		/// </summary>
		public document document_add(Int64 iid_category, Int64 iid_parent,
									 String iname, String idesc, String iregnum, DateTime iregdate,
									 user User)
		{
			return document_add(iid_category, iid_parent,
									 iname, idesc, iregnum, iregdate,
									 User.EntityID, User.Id, -1);
		}

		/// <summary>
		/// Метод добавляет новый документ
		/// </summary>
		public document document_add(Int64 iid_category, Int64 iid_parent,
									 String iname, String idesc, String iregnum, DateTime iregdate,
									 pos_temp Pos_temp)
		{
			return document_add(iid_category, iid_parent,
									 iname, idesc, iregnum, iregdate,
									 Pos_temp.EntityID, Pos_temp.Id, -1);
		}

		/// <summary>
		/// Метод добавляет новый документ
		/// </summary>
		public document document_add(Int64 iid_category, Int64 iid_parent,
									 String iname, String idesc, String iregnum, DateTime iregdate,
									 pos_temp_prop Pos_temp_prop)
		{
			return document_add(iid_category, iid_parent,
									 iname, idesc, iregnum, iregdate,
									 Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
		}

		/// <summary>
		/// Метод добавляет новый документ
		/// </summary>
		public document document_add(Int64 iid_category, Int64 iid_parent,
									 String iname, String idesc, String iregnum, DateTime iregdate,
									 position Position)
		{
			return document_add(iid_category, iid_parent,
									 iname, idesc, iregnum, iregdate,
									 Position.EntityID, Position.Id, -1);
		}

		/// <summary>
		/// Метод добавляет новый документ
		/// </summary>
		public document document_add(Int64 iid_category, Int64 iid_parent,
									 String iname, String idesc, String iregnum, DateTime iregdate,
									 position_prop Position_prop)
		{
			return document_add(iid_category, iid_parent,
									 iname, idesc, iregnum, iregdate,
									 Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
		}

		/// <summary>
		/// Метод добавляет новый документ
		/// </summary>
		public document document_add(Int64 iid_category, Int64 iid_parent,
									 String iname, String idesc, String iregnum, DateTime iregdate,
									 object_general Object_general)
		{
			return document_add(iid_category, iid_parent,
									 iname, idesc, iregnum, iregdate,
									 Object_general.EntityID, Object_general.Id, -1);
		}

		/// <summary>
		/// Метод добавляет новый документ
		/// </summary>
		public document document_add(Int64 iid_category, Int64 iid_parent,
									 String iname, String idesc, String iregnum, DateTime iregdate,
									 object_prop Object_prop)
		{
			return document_add(iid_category, iid_parent,
									 iname, idesc, iregnum, iregdate,
									 Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
		}

		/// <summary>
		/// Метод добавляет новый документ
		/// </summary>
		public document document_add(Int64 iid_category, Int64 iid_parent,
									 String iname, String idesc, String iregnum, DateTime iregdate,
									 group Group)
		{
			return document_add(iid_category, iid_parent,
									 iname, idesc, iregnum, iregdate,
									 Group.EntityID, Group.Id, -1);
		}

		/// <summary>
		/// Метод добавляет новый документ
		/// </summary>
		public document document_add(Int64 iid_category, Int64 iid_parent,
									 String iname, String idesc, String iregnum, DateTime iregdate,
									 vclass Class)
		{
			return document_add(iid_category, iid_parent,
									 iname, idesc, iregnum, iregdate,
									 Class.EntityID, Class.Id, -1);
		}

		/// <summary>
		/// Метод добавляет новый документ
		/// </summary>
		public document document_add(Int64 iid_category, Int64 iid_parent,
									 String iname, String idesc, String iregnum, DateTime iregdate,
									 class_prop Class_prop)
		{
			return document_add(iid_category, iid_parent,
									 iname, idesc, iregnum, iregdate,
									 Class_prop.EntityID, Class_prop.Id, -1);
		}

		/// <summary>
		/// Метод добавляет новый документ
		/// </summary>
		public document document_add(Int64 iid_category,
									 String iname, String idesc, String iregnum, DateTime iregdate,
									 document document_parent)
		{
			return document_add(iid_category, document_parent.Id,
									 iname, idesc, iregnum, iregdate,
									 -1, -1, -1);
		}
		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean document_add(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("document_add");
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