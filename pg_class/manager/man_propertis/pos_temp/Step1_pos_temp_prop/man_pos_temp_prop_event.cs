using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

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
