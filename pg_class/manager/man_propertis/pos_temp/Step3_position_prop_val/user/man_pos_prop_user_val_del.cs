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
		/// Удалить значение пользовательского свойства позиции
		/// </summary>
		public void position_prop_user_val_del(Int64 iid_position, Int64 iid_pos_temp_prop)
		{
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;
	
			cmdk = CommandByKey("position_prop_user_val_del");
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

			position_prop position_prop = position_prop_by_id(iid_position, iid_pos_temp_prop);
			position_prop_user_val position_prop_user_val = position_prop_user_val_by_id_prop(position_prop);

			cmdk.Parameters["iid_position"].Value = iid_position;
			cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					if (position_prop_user_val != null)
					{
						//Генерируем событие изменения значения свойства объекта
						PositionPropUserValChangeEventArgs e = new PositionPropUserValChangeEventArgs(position_prop_user_val, eAction.Delete);
						PositionPropUserValOnChange(e);
					}
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(position_prop_user_val.Id_position_carrier, position_prop_user_val.Id_pos_temp_prop, eEntity.position_prop_user_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
		}

		/// <summary>
		/// Удалить значение объектного свойства активного представления класса
		/// </summary>
		public void position_prop_user_val_del(position_prop PositionProp)
		{
			position_prop_user_val_del(PositionProp.Id_position_carrier, PositionProp.Id_pos_temp_prop);
		}

		/// <summary>
		/// Удалить значение объектного свойства активного представления класса
		/// </summary>
		public void position_prop_user_val_del(position_prop_user_val ObjectPropUserVal)
		{
			position_prop_user_val_del(ObjectPropUserVal.Id_position_carrier, ObjectPropUserVal.Id_pos_temp_prop);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean position_prop_user_val_del(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;
			
			cmdk = CommandByKey("position_prop_user_val_del");
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