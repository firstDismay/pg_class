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
        public delegate void Rulel2_Class_On_PositionListChangeEventHandler(Object sender, Rulel2_Class_On_PositionListChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении списка правил вложенности уровня 2 класс на позицию
        /// </summary>
        public event Rulel2_Class_On_PositionListChangeEventHandler Rulel2_Class_On_PositionListChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события
        /// </summary>
        protected virtual void OnRulel2_Class_On_PositionListChange(Rulel2_Class_On_PositionListChangeEventArgs e)
        {
            Rulel2_Class_On_PositionListChangeEventHandler temp = this.Rulel2_Class_On_PositionListChange;

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