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
		/// Метод изменяет сортировку свойства шаблона позиции поднимая указанное свойство вверх
		/// </summary>
		public pos_temp_prop pos_temp_prop_sort_top(Int64 iid_pos_temp_prop)
		{
			pos_temp_prop pos_temp_prop = null;
			pos_temp pos_temp_sort = null;
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;
			
			cmdk = CommandByKey("pos_temp_prop_sort_top");
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

			cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					pos_temp_prop = pos_temp_prop_by_id(iid_pos_temp_prop);
					pos_temp_sort = pos_temp_by_id(pos_temp_prop.Id_pos_temp);
					//Генерируем событие применения метода сортировки
					if (pos_temp_sort != null)
					{
						PosTempChangeEventArgs e = new PosTempChangeEventArgs(pos_temp_sort, eAction.Update);
						PosTempPropSortOnChange(e);
					}

					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(iid_pos_temp_prop, eEntity.pos_temp_prop, error, desc_error, eAction.Update, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}

			//Возвращаем сущность
			return pos_temp_prop;
		}

		/// <summary>
		/// Метод изменяет сортировку свойства активного класса поднимая указанное свойство вверх
		/// </summary>
		public pos_temp_prop pos_temp_prop_sort_top(pos_temp_prop Pos_temp_prop)
		{
			return pos_temp_prop_sort_top(Pos_temp_prop.Id); ;
		}

		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean pos_temp_prop_sort_top(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;

			cmdk = CommandByKey("pos_temp_prop_sort_top");
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