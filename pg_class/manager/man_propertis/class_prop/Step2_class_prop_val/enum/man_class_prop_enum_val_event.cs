using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения данных значения свойства класса типа перечисление
        /// </summary>
        public delegate void ClassPropEnumValChangeEventHandler(Object sender, ClassPropEnumValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении данных значения свойства класса типа перечисление
        /// </summary>
        public event ClassPropEnumValChangeEventHandler ClassPropEnumValChange;


        /// <summary>
        ///  Метод вызова события изменения перечисления для свойств
        /// </summary>
        protected virtual void ClassPropEnumValOnChange(ClassPropEnumValChangeEventArgs e)
        {
            ClassPropEnumValChangeEventHandler temp = ClassPropEnumValChange;
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
