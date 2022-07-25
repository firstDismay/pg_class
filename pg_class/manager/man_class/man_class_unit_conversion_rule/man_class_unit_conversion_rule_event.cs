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
        public delegate void ClassUnitConversionRuleChangeEventHandler(Object sender, ClassUnitConversionRuleChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении списка правил назначения вещественному классу правил пересчета колличества объектов
        /// </summary>
        public event ClassUnitConversionRuleChangeEventHandler ClassUnitConversionRuleListChange;

        /// <summary>
        ///  Метод вызова события изменения списка правил
        /// </summary>
        protected virtual void OnClassUnitConversionRuleListChange(ClassUnitConversionRuleChangeEventArgs e)
        {
            ClassUnitConversionRuleChangeEventHandler temp = this.ClassUnitConversionRuleListChange;

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
