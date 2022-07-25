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
		/// Метод добавляет новое свойство шаблона
		/// </summary>
		public pos_temp_prop pos_temp_prop_add(Int64 iid_pos_temp, Int32 iid_prop_type, Boolean ion_override, Int32 iid_data_type, String iname, String idesc, Int32 isort)
		{
			pos_temp_prop pos_temp_prop = null;
			Int64 id = 0;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("pos_temp_prop_add");
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

			cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;
			cmdk.Parameters["iid_prop_type"].Value = iid_prop_type;
			cmdk.Parameters["ion_override"].Value = ion_override;
			cmdk.Parameters["iid_data_type"].Value = iid_data_type;
			cmdk.Parameters["iname"].Value = iname;
			cmdk.Parameters["idesc"].Value = idesc;
			cmdk.Parameters["isort"].Value = isort;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
					if (id > 0)
					{
						pos_temp_prop = pos_temp_prop_by_id(id);
						if (pos_temp_prop != null)
						{
							//Генерируем событие изменения свойства
							PosTempPropChangeEventArgs e = new PosTempPropChangeEventArgs(pos_temp_prop, eAction.Insert);
							PosTempPropOnChange(e);
						}
					}
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(id, eEntity.pos_temp_prop, error, desc_error, eAction.Insert, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
			
			//Возвращаем сущность
			return pos_temp_prop;
		}

		/// <summary>
		/// Метод добавляет новое свойство класса
		/// </summary>
		public pos_temp_prop pos_temp_prop_add(pos_temp PosTemp, prop_type Prop_type, Boolean On_Override, con_prop_data_type Data_type, String iname, String idesc, Int32 isort)
		{
			return pos_temp_prop_add(PosTemp.Id, Prop_type.Id, On_Override, Data_type.Id, iname, idesc, isort);
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean pos_temp_prop_add(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("pos_temp_prop_add");
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