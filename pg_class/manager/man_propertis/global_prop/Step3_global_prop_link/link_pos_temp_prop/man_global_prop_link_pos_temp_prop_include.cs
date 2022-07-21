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
		/// Метод добавляет свойство класса к глобальному свойству
		/// </summary>
		public global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop_include(Int64 iid_global_prop, Int64 iid_pos_temp_prop)
		{
			global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop = null;
			pos_temp_prop prop_link;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;
		
			cmdk = CommandByKey("global_prop_link_pos_temp_prop_include");
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

			cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
			cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					global_prop_link_pos_temp_prop = global_prop_link_pos_temp_prop_by_id(iid_global_prop, iid_pos_temp_prop);
					prop_link = pos_temp_prop_by_id(iid_pos_temp_prop);
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(iid_global_prop, iid_pos_temp_prop, eEntity.global_prop_link_pos_temp_prop, error, desc_error, eAction.Include, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
			if (global_prop_link_pos_temp_prop != null)
			{
				//Генерируем событие изменения
				GlobalPropLinkPosTempPropChangeEventArgs e = new GlobalPropLinkPosTempPropChangeEventArgs(global_prop_link_pos_temp_prop, eAction.Include);
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
		/// Метод добавляет свойство класса к глобальному свойству
		/// </summary>
		public global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop_include(global_prop GlobalProp, pos_temp_prop PosTempProp)
		{
			global_prop_link_pos_temp_prop Result = null;
			if ((GlobalProp != null) & (PosTempProp != null))
			{
				Result = global_prop_link_pos_temp_prop_include(GlobalProp.Id, PosTempProp.Id);
			}
			return Result;
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean global_prop_link_pos_temp_prop_include(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("global_prop_link_pos_temp_prop_include");
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