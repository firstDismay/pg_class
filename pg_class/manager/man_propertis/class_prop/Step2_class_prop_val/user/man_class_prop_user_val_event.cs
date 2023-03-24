using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения данных значения пользовательского свойства класса
        /// </summary>
        public delegate void ClassPropUserValChangeEventHandler(Object sender, ClassPropUserValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения пользовательского свойства класса методом доступа к БД
        /// </summary>
        public event ClassPropUserValChangeEventHandler ClassPropUserValChange;


        /// <summary>
        ///  Метод вызова события изменения данных значения пользовательского свойства класса
        /// </summary>
        protected virtual void ClassPropUserValOnChange(ClassPropUserValChangeEventArgs e)
        {
            ClassPropUserValChangeEventHandler temp = ClassPropUserValChange;
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
