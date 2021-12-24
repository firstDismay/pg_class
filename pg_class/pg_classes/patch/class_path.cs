using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Квантовый класс определящий узловую структуру представления классов
    /// </summary>
    public class class_path 
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected class_path()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public class_path(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "path2")
            {
                id = (Int64)row["id"];
                timestamp = (DateTime)row["timestamp"];
                tablename = (String)row["tablename"];
                id_parent = (Int64)row["id_parent"];
                timestamp_parent = (DateTime)row["timestamp_parent"];
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

        #region МЕТОДЫ КЛАССА

        /// <summary>
        /// Метод возвращает представление класса на которое ссылается элемент пути
        /// </summary>
        /// <returns></returns>
        public vclass GetClass()
        {
            return Manager.class_act_by_class_path(this);
        }

        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id = 0;
        private DateTime timestamp;
        private String tablename;
        private Int64 id_parent;
        private DateTime timestamp_parent;
        private Int64 id_root;
        private String name;
        private Int32 level;
        /// <summary>
        /// Идентификатор класса
        /// </summary>
        public Int64 Id { get => id; }

        /// <summary>
        /// Штамп времени класса
        /// </summary>
        public DateTime Timestamp { get => timestamp; }

        /// <summary>
        /// Имя таблицы базы ассистента, содержащей запись о классе
        /// </summary>
        public String Tablename
        {
            get
            {
                return tablename;
            }
        }

        /// <summary>
        /// Тип хранилища данных сущности
        /// </summary>
        public eStorageType StorageType
        {
            get
            {
                String pattern = "snapshot";
                eStorageType tmp = eStorageType.Active;
                if (System.Text.RegularExpressions.Regex.IsMatch(tablename, pattern))
                {
                    tmp = eStorageType.History;
                }
                return tmp;
            }
        }

        /// <summary>
        /// Идентификатор родительскго класса, если 0 то класс root
        /// </summary>
        public long Id_parent { get => id_parent; }

        /// <summary>
        /// Штамп времени класса
        /// </summary>
        public DateTime Timestamp_parent { get => timestamp_parent; }

        /// <summary>
        /// Идентификатор корневого класса
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

        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return name;
        }
    }
}
