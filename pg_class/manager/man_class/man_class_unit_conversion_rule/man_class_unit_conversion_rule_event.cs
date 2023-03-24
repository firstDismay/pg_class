using System;

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
