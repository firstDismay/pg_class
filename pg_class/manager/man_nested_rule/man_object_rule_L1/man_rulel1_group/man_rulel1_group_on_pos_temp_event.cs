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
        /// Делегат события изменения
        /// </summary>
        public delegate void Rulel1_Group_On_Pos_tempListChangeEventHandler(Object sender, Rulel1_Group_On_Pos_tempListChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении списка разрешений уровня 1 группа на шаблон
        /// </summary>
        public event Rulel1_Group_On_Pos_tempListChangeEventHandler Rulel1_Group_On_Pos_tempListChange;

        /// <summary>
        ///  Метод вызова события списка правил вложенности объектов
        /// </summary>
        protected virtual void OnRulel1_Group_On_Pos_tempListChange(Rulel1_Group_On_Pos_tempListChangeEventArgs e)
        {
            Rulel1_Group_On_Pos_tempListChangeEventHandler temp = this.Rulel1_Group_On_Pos_tempListChange;

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