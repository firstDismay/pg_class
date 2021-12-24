using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения документа
    /// </summary>
    public class DocumentChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public DocumentChangeEventArgs(document Document, eAction Action) : base()
        {
            action = Action;
            if (Document != null)
            {
                document = Document;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        document document;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public document Document { get => document; }
        #endregion
    }
}
