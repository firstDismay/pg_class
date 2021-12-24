using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения категории документа
    /// </summary>
    public class DocCategoryChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public DocCategoryChangeEventArgs(doc_category DocCategory, eAction Action) : base()
        {
            action = Action;
            if (DocCategory != null)
            {
                doc_category = DocCategory;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        doc_category doc_category;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public doc_category DocCategory { get => doc_category; }
        #endregion
    }
}
