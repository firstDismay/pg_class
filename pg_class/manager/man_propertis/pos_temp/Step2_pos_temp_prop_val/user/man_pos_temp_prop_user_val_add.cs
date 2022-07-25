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
		/// Добавить новое значение пользовательского свойства шаблона
		/// </summary>
		public pos_temp_prop_user_val pos_temp_prop_user_val_add(pos_temp_prop_user_val newPosTempPropUserVal)
		{
			pos_temp_prop_user_val PosTempPropUserVal = null;
			pos_temp_prop pos_temp_prop = null;
			Int64 id = 0;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk = null;

			if (newPosTempPropUserVal != null)
			{
				switch (newPosTempPropUserVal.DataSize)
				{
					case eDataSize.BigData:
						cmdk = CommandByKey("pos_temp_prop_user_big_val_add");

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

						cmdk.Parameters["iid_pos_temp_prop"].Value = newPosTempPropUserVal.Id_pos_temp_prop;
						cmdk.Parameters["imin_val"].Value = newPosTempPropUserVal.Min_val;
						cmdk.Parameters["imin_on"].Value = newPosTempPropUserVal.Min_on;
						cmdk.Parameters["imax_val"].Value = newPosTempPropUserVal.Max_val;
						cmdk.Parameters["imax_on"].Value = newPosTempPropUserVal.Max_on;
						cmdk.Parameters["ival_text"].Value = DBNull.Value;
						cmdk.Parameters["ival_bytea"].Value = DBNull.Value;
						cmdk.Parameters["ival_json"].Value = DBNull.Value;

						if (newPosTempPropUserVal.On_val)
						{
							switch (newPosTempPropUserVal.DataType)
							{
								case eDataType.val_text:
									if (newPosTempPropUserVal.Val_text != null)
									{
										cmdk.Parameters["ival_text"].Value = newPosTempPropUserVal.Val_text;
									}
									break;
								case eDataType.val_bytea:
									if (newPosTempPropUserVal.Val_bytea != null)
									{
										cmdk.Parameters["ival_bytea"].Size = newPosTempPropUserVal.Val_bytea.Length;
										cmdk.Parameters["ival_bytea"].Value = newPosTempPropUserVal.Val_bytea;
									}
									break;
								case eDataType.val_json:
									if (newPosTempPropUserVal.Val_json != null)
									{
										cmdk.Parameters["ival_json"].Value = newPosTempPropUserVal.Val_json;
									}
									break;
							}
						}
						break;
					case eDataSize.SmallData:
						cmdk = CommandByKey("pos_temp_prop_user_small_val_add");

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

						cmdk.Parameters["iid_pos_temp_prop"].Value = newPosTempPropUserVal.Id_pos_temp_prop;
						cmdk.Parameters["imin_val"].Value = newPosTempPropUserVal.Min_val;
						cmdk.Parameters["imin_on"].Value = newPosTempPropUserVal.Min_on;
						cmdk.Parameters["imax_val"].Value = newPosTempPropUserVal.Max_val;
						cmdk.Parameters["imax_on"].Value = newPosTempPropUserVal.Max_on;
						cmdk.Parameters["iround"].Value = newPosTempPropUserVal.Round_val;
						cmdk.Parameters["iround_on"].Value = newPosTempPropUserVal.Round_on;
						cmdk.Parameters["ival_varchar"].Value = DBNull.Value;
						cmdk.Parameters["ival_int"].Value = DBNull.Value;
						cmdk.Parameters["ival_numeric"].Value = DBNull.Value;
						cmdk.Parameters["ival_real"].Value = DBNull.Value;
						cmdk.Parameters["ival_double"].Value = DBNull.Value;
						cmdk.Parameters["ival_money"].Value = DBNull.Value;
						cmdk.Parameters["ival_boolean"].Value = DBNull.Value;
						cmdk.Parameters["ival_date"].Value = DBNull.Value;
						cmdk.Parameters["ival_time"].Value = DBNull.Value;
						cmdk.Parameters["ival_interval"].Value = DBNull.Value;
						cmdk.Parameters["ival_timestamp"].Value = DBNull.Value;
						cmdk.Parameters["ival_bigint"].Value = 0;

						if (newPosTempPropUserVal.On_val)
						{
							switch (newPosTempPropUserVal.DataType)
							{
								case eDataType.val_varchar:
									if (newPosTempPropUserVal.Val_varchar != null)
									{
										cmdk.Parameters["ival_varchar"].Value = newPosTempPropUserVal.Val_varchar;
									}
									break;
								case eDataType.val_int:
									cmdk.Parameters["ival_int"].Value = newPosTempPropUserVal.Val_int;
									break;
								case eDataType.val_numeric:
									cmdk.Parameters["ival_numeric"].Value = newPosTempPropUserVal.Val_numeric;
									break;
								case eDataType.val_real:
									cmdk.Parameters["ival_real"].Value = newPosTempPropUserVal.Val_real;
									break;
								case eDataType.val_double:
									cmdk.Parameters["ival_double"].Value = newPosTempPropUserVal.Val_double;
									break;
								case eDataType.val_money:
									cmdk.Parameters["ival_money"].Value = newPosTempPropUserVal.Val_money;
									break;
								case eDataType.val_boolean:
									cmdk.Parameters["ival_boolean"].Value = newPosTempPropUserVal.Val_boolean;
									break;
								case eDataType.val_date:
									cmdk.Parameters["ival_date"].Value = newPosTempPropUserVal.Val_date;
									break;
								case eDataType.val_time:
									cmdk.Parameters["ival_time"].Value = newPosTempPropUserVal.Val_time;
									break;
								case eDataType.val_interval:
									cmdk.Parameters["ival_interval"].Value = newPosTempPropUserVal.Val_interval;
									break;
								case eDataType.val_timestamp:
									cmdk.Parameters["ival_timestamp"].Value = newPosTempPropUserVal.Val_timestamp;
									break;
								case eDataType.val_bigint:
									cmdk.Parameters["ival_bigint"].Value = newPosTempPropUserVal.Val_bigint;
									break;
							}
						}
						break;
				}
				cmdk.ExecuteNonQuery();

				error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
				desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
				switch (error)
				{
					case 0:
						id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
						if (id > 0)
						{
							pos_temp_prop = pos_temp_prop_by_id(newPosTempPropUserVal.Id_pos_temp_prop);
							PosTempPropUserVal = pos_temp_prop_user_val_by_id_prop(pos_temp_prop);
						}
						if (PosTempPropUserVal != null)
						{
							//Генерируем событие изменения значения свойства шаблона
							PosTempPropUserValChangeEventArgs e = new PosTempPropUserValChangeEventArgs(PosTempPropUserVal, eAction.Insert);
							PosTempPropUserValOnChange(e);
						}
						break;
					default:
						//Вызов события журнала
						JournalEventArgs me = new JournalEventArgs(newPosTempPropUserVal.Id_pos_temp_prop, eEntity.pos_temp_prop_user_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
						JournalMessageOnReceived(me);
						throw new PgDataException(error, desc_error);
				}
			}
			//Возвращаем сущность
			return PosTempPropUserVal;
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean pos_temp_prop_user_val_add(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;
			
			cmdk = CommandByKey("pos_temp_prop_user_small_val_add");
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