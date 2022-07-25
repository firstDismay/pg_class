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
using pg_class.pg_classes.calendar;

namespace pg_class
{
	public partial class manager
	{
		/// <summary>
		/// Метод добавляет новую ссылку планового диапазона
		/// </summary>
		public plan_range_link plan_range_link_add(Int64 iid_plan_range, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
		{
			plan_range_link centity = null;
			Int64 id = 0;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("plan_range_link_add");
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

			cmdk.Parameters["iid_plan_range"].Value = iid_plan_range;
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
						centity = plan_range_link_by_id(id);
					}
					if (centity != null)
					{
						//Генерируем событие изменения плана
						PlanRangeLinkChangeEventArgs e = new PlanRangeLinkChangeEventArgs(centity, eAction.Insert);
						PlanRangeLinkOnChange(e);
					}
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(id, eEntity.plan_range_link, error, desc_error, eAction.Insert, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
			
			//Возвращаем сущность
			return centity;
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean plan_range_link_add(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("plan_range_link_add");
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