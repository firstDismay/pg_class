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
		/// Делегат события изменения списка назначенных типоа данных концепции
		/// </summary>
		public delegate void Con_Prop_Data_TypeListChangeEventHandler(Object sender, Con_Prop_Data_TypeListChangeEventArgs e);

		/// <summary>
		/// Событие возникает при изменении списка назначений типов данных концепции
		/// </summary>
		public event Con_Prop_Data_TypeListChangeEventHandler Con_Prop_Data_TypeListChange;
		
		/// <summary>
		///  Метод вызова события
		/// </summary>
		protected virtual void OnCon_Prop_Data_TypeListChange(Con_Prop_Data_TypeListChangeEventArgs e)
		{
			Con_Prop_Data_TypeListChangeEventHandler temp = this.Con_Prop_Data_TypeListChange;

			if (temp != null)
			{
				temp(this, e);
			}
			//Вызов события журнала
			JournalEventArgs me = new JournalEventArgs(e);
			JournalMessageOnReceived(me);
		}
	}
}
