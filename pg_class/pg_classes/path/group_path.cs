using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Квантовый класс определящий узловую структуру пути в ветви дерева
    /// </summary>
    public class group_path 
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected group_path()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public group_path(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "path")
            {
                id = (Int64)row["id"];
                id_parent = (Int64)row["id_parent"];
                id_root = (Int64)row["id_root"];
                name = (String)row["name"];
                level = (Int32)row["level"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id = 0;
        private Int64 id_parent;
        private Int64 id_root;
        private String name;
        private Int32 level;
        /// <summary>
        /// Идентификатор позиций
        /// </summary>
        public long Id { get => id; }

        /// <summary>
        /// Идентификатор родительскго элемента, если 0 то элемент root
        /// </summary>
        public long Id_parent { get => id_parent; }
        /// <summary>
        /// Идентификатор корневой ветви элементов
        /// </summary>
        public long Id_root { get => id_root; }


        /// <summary>
        /// Наименование элемента
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Уровень вложенности вложенности элемента
        /// </summary>
        public int Level { get => level; }


        /// <summary>
        /// Ссылка на менеджера данных
        /// </summary>
        private manager Manager
        {
            get
            {
                return manager.Instance();
            }
        }
        #endregion

        #region МЕТОДЫ КЛАССА

        /// <summary>
        /// Метод возвращает группу на которую ссылается элемент пути
        /// </summary>
        /// <returns></returns>
        public group GetGroup()
        {
            return Manager.group_by_group_path(this);
        }

        #endregion

        

        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return name;
        }
    }
}
