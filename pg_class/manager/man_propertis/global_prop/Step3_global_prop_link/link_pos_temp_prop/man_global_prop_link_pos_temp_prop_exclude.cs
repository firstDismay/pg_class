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
		/// Метод удаляет свойство класса из глобального свойства
		/// </summary>
		public global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop_exclude(Int64 iid_global_prop, Int64 iid_pos_temp_prop)
		{
			Int32 error;
			String desc_error;
			global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop;
			pos_temp_prop prop_link;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("global_prop_link_pos_temp_prop_exclude");
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
			global_prop_link_pos_temp_prop = global_prop_link_pos_temp_prop_by_id(iid_global_prop, iid_pos_temp_prop);

			cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
			cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			if (error == 0)
			{
				prop_link = pos_temp_prop_by_id(iid_pos_temp_prop);
			}
			else
			{
				//Вызов события журнала
				JournalEventArgs me = new JournalEventArgs(iid_global_prop, iid_pos_temp_prop, eEntity.global_prop_link_class_prop, error, desc_error, eAction.Delete, eJournalMessageType.error);
				JournalMessageOnReceived(me);
				throw new PgDataException(error, desc_error);
			}
			if (global_prop_link_pos_temp_prop != null)
			{
				//Генерируем событие изменения
				GlobalPropLinkPosTempPropChangeEventArgs e = new GlobalPropLinkPosTempPropChangeEventArgs(global_prop_link_pos_temp_prop, eAction.Delete);
				GlobalPropLinkPosTempPropOnChange(e);
			}

			if (prop_link != null)
			{
				//Генерируем событие изменения свойства шаблона
				PosTempPropChangeEventArgs e2 = new PosTempPropChangeEventArgs(prop_link, eAction.Update);
				PosTempPropOnChange(e2);
			}
			//Возвращаем Объект
			return global_prop_link_pos_temp_prop;
		}

		/// <summary>
		/// Метод удаляет свойство класса из глобального свойства
		/// </summary>
		public global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop_exclude(global_prop GlobalProp, pos_temp_prop PosTempProp)
		{
			global_prop_link_pos_temp_prop Result = null;
			if ((GlobalProp != null) & (PosTempProp != null))
			{
				Result = global_prop_link_pos_temp_prop_exclude(GlobalProp.Id, PosTempProp.Id);
			}
			return Result;
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean global_prop_link_pos_temp_prop_exclude(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("global_prop_link_pos_temp_prop_exclude");
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