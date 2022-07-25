﻿using System;
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
		/// Метод добавляет разрешающее правило уровня 2 класс на шаблон
		/// </summary>
		public void Rulel2_class_on_position_add(Int64 iid_class, Int64 iid_position)
		{
			Int32 error;
			String desc_error;
			NpgsqlCommandKey cmdk;
			
			cmdk = CommandByKey("rulel2_class_on_position_add");
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

			cmdk.Parameters["iid_class"].Value = iid_class;
			cmdk.Parameters["iid_position"].Value = iid_position;
			cmdk.ExecuteNonQuery();

			error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
			desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
			switch (error)
			{
				case 0:
					//Вызов события изменения списка вложенности
					Rulel2_Class_On_PositionListChangeEventArgs e;
					e = new Rulel2_Class_On_PositionListChangeEventArgs(iid_position, iid_class, eActionRuleList.addrule);
					OnRulel2_Class_On_PositionListChange(e);
					break;
				default:
					//Вызов события журнала
					JournalEventArgs me = new JournalEventArgs(iid_position, eEntity.rulel2_class_on_position, error, desc_error, eAction.Insert, eJournalMessageType.error);
					JournalMessageOnReceived(me);
					throw new PgDataException(error, desc_error);
			}
		}

		/// <summary>
		/// Метод добавляет разрешение на вложение для объектов классов в позиции указанного шаблона
		/// </summary>
		public void Rulel2_class_on_position_add(vclass Vclass, position Position)
		{
			Rulel2_class_on_position_add(Vclass.Id, Position.Id);
		}

		/// <summary>
		/// Метод добавляет разрешение на вложение для объектов классов в позиции указанного шаблона
		/// </summary>
		public void Rulel2_class_on_position_add(rulel2_class_on_position RuleL2)
		{
			Rulel2_class_on_position_add(RuleL2.Id_class, RuleL2.Id_position);
		}
		
		//ACCESS
		/// <summary>
		/// Проверка прав доступа к методу
		/// </summary>
		public Boolean Rulel2_class_on_position_add(out eAccess Access)
		{
			Boolean Result = false;
			Access = eAccess.NotFound;
			NpgsqlCommandKey cmdk;
			
			cmdk = CommandByKey("rulel2_class_on_position_add");
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