using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения свойства шаблона позиции
        /// </summary>
        public delegate void PosTempPropChangeEventHandler(Object sender, PosTempPropChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении свойства шаблона позиции методом доступа к БД
        /// </summary>
        public event PosTempPropChangeEventHandler PosTempPropChange;


        /// <summary>
        ///  Метод вызова события изменения свойства позиции
        /// </summary>
        protected virtual void PosTempPropOnChange(PosTempPropChangeEventArgs e)
        {
            PosTempPropChangeEventHandler temp = PosTempPropChange;

            if (temp != null)
            {
                temp(this, e);
            }
        }
    }
}
