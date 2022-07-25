using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Npgsql;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

namespace pg_class
{
	public partial class manager
	{
		/// <summary>
		/// Метод изменяет параметры назначения типа данных в указанной концепции
		/// </summary>
		public con_prop_data_type con_prop_data_type_upd(Int64 iid_conception, Int32 iid_prop_data_type, String ialias, Int32 isort)
		{
			con_prop_data_type con_prop_data_type = null;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("con_prop_data_type_upd");
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

			cmdk.Parameters["iid_conception"].Value = iid_conception;
			cmdk.Parameters["iid_prop_data_type"].Value = iid_prop_data_type;
			cmdk.Parameters["ialias"].Value = ialias;
			cmdk.Parameters["isort"].Value = isort;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					con_prop_data_type = Con_prop_data_type_by_id(iid_conception, iid_prop_data_type);
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(iid_prop_data_type, eEntity.con_prop_data_type, error, desc_error, eAction.Update, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}

			//Вызов события изменения элемента назначения типа данных на концепцию
			Con_Prop_Data_TypeChangeEventArgs e;
			e = new Con_Prop_Data_TypeChangeEventArgs(iid_conception, iid_prop_data_type, eActionRuleList.updaterule);
			OnCon_Prop_Data_TypeChange(e);
			//Возвращаем сущность
			return con_prop_data_type;
		}

		/// <summary>
		/// Метод изменяет параметры назначения типа данных в указанной концепции
		/// </summary>
		public void con_prop_data_type_upd(con_prop_data_type Con_prop_data_type)
		{
			con_prop_data_type_upd(Con_prop_data_type.Id_conception, Con_prop_data_type.Id, Con_prop_data_type.Alias, Con_prop_data_type.Sort);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean con_prop_data_type_upd(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("con_prop_data_type_upd");
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
