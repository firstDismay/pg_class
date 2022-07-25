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
		/// Делегат события изменения назначения типа данных концепции
		/// </summary>
		public delegate void Con_Prop_Data_TypeChangeEventHandler(Object sender, Con_Prop_Data_TypeChangeEventArgs e);

		/// <summary>
		/// Событие возникает при изменении элемента назначения типа данных концепции
		/// </summary>
		public event Con_Prop_Data_TypeChangeEventHandler Con_Prop_Data_TypeChange;

		/// <summary>
		///  Метод вызова события
		/// </summary>
		protected virtual void OnCon_Prop_Data_TypeChange(Con_Prop_Data_TypeChangeEventArgs e)
		{
			Con_Prop_Data_TypeChangeEventHandler temp = this.Con_Prop_Data_TypeChange;

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