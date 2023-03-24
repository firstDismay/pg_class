using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения ссылки на документа
    /// </summary>
    public class DocLinkChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public DocLinkChangeEventArgs(doc_link Doclink, eAction Action) : base()
        {
            action = Action;
            if (Doclink != null)
            {
                doc_link = Doclink;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        doc_link doc_link;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public doc_link DocLink { get => doc_link; }
        #endregion
    }
}
