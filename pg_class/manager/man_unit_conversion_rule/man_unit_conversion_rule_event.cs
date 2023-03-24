using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения правила пересчета колличества объектов
        /// </summary>
        public delegate void UnitConversionRuleChangeEventHandler(Object sender, UnitConversionRuleChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении  правила пересчета колличества объектов в БД
        /// </summary>
        public event UnitConversionRuleChangeEventHandler UnitConversionRuleChange;

        /// <summary>
        ///  Метод вызова события изменения правила пересчета колличества объектов
        /// </summary>
        protected virtual void UnitConversionRuleOnChange(UnitConversionRuleChangeEventArgs e)
        {
            UnitConversionRuleChangeEventHandler temp = UnitConversionRuleChange;
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