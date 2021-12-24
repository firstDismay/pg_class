using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения файла документа
    /// </summary>
    public class DocFileChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public DocFileChangeEventArgs(doc_file DocFile, eAction Action) : base()
        {
            action = Action;
            if (DocFile != null)
            {
                doc_file = DocFile;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        doc_file doc_file;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public doc_file DocFile { get => doc_file; }
        #endregion
    }
}
