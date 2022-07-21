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
		/// Метод удаляет глобальное свойство
		/// </summary>
		public void global_prop_del(Int64 iid_global_prop)
		{
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;
			global_prop global_prop;

			cmdk = CommandByKey("global_prop_del");
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
			global_prop = global_prop_by_id(iid_global_prop);

			cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			if (error > 0)
			{
				//Вызов события журнала
				JournalEventArgs me = new JournalEventArgs(iid_global_prop, eEntity.global_prop, error, desc_error, eAction.Delete, eJournalMessageType.error);
				JournalMessageOnReceived(me);
				throw new PgDataException(error, desc_error);
			}

			//Генерируем событие удаления свойства класса
			if (global_prop != null)
			{
				GlobalPropChangeEventArgs e = new GlobalPropChangeEventArgs(global_prop, eAction.Delete);
				GlobalPropOnChange(e);
			}
		}

		/// <summary>
		/// Метод удаляет глобальное свойство
		/// </summary>
		public void global_prop_del(global_prop Global_Prop)
		{
			if (Global_Prop != null)
			{
				global_prop_del(Global_Prop.Id);
			}

		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean global_prop_del(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("global_prop_del");
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