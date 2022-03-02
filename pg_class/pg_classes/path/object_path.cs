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
    public class object_path 

    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected object_path()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public object_path(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "path3")
            {
                id_position = (Int64)row["id_position"];
                id_object = (Int64)row["id_object"];
                name_object = (String)row["name_object"];
                id_object_carrier = (Int64)row["id_object_carrier"];
                name_oject_carrier = (String)row["name_oject_carrier"];
                id_class_prop_object_carrier = (Int64)row["id_class_prop_object_carrier"];
                name_class_prop_object_carrier = (String)row["name_class_prop_object_carrier"];
                level = (Int32)row["level"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id_position;
        private Int64 id_object;
        private String name_object;
        private Int64 id_object_carrier;
        private String name_oject_carrier;
        private Int64 id_class_prop_object_carrier;
        private String name_class_prop_object_carrier;
        private Int32 level;
        
        /// <summary>
        /// Идентификатор позиции объекта
        /// </summary>
        public Int64 Id_position { get => id_position; }

        /// <summary>
        /// Идентификатор позиционированного объекта
        /// </summary>
        public Int64 Id_object { get => id_object; }

        /// <summary>
        /// Наименование позиционированного объекта
        /// </summary>
        public String Name_object { get => name_object; }

        /// <summary>
        /// Идентификатор объекта носителя
        /// </summary>
        public Int64 Id_object_carrier { get => id_object_carrier; }

        /// <summary>
        /// Наименование объекта носителя
        /// </summary>
        public String Name_oject_carrier { get => name_oject_carrier; }

        /// <summary>
        /// Идентификатор свойства объекта носителя
        /// </summary>
        public Int64 Id_class_prop_object_carrier { get => id_class_prop_object_carrier; }

        /// <summary>
        /// Наименование свойства объекта носителя
        /// </summary>
        public String Name_class_prop_object_carrier { get => name_class_prop_object_carrier; }


        /// <summary>
        /// Уровень вложенности вложенности элемента
        /// </summary>
        public Int32 Level { get => level; }

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
        /// Метод возвращает представление класса на которое ссылается элемент пути
        /// </summary>
        /// <param name="Extended">Возврат расширенного предстваления классов с заполненным листом свойств STEP1</param>
        public object_general Object_get(Boolean Extended = false)
        {
            object_general Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_id(this);
            }
            else
            {
                Result = Manager.object_by_id(this);
            }
            return Result;
        }

        /// <summary>
        /// Метод возвращает представление класса на которое ссылается элемент пути
        /// </summary>
        /// <param name="Extended">Возврат расширенного предстваления классов с заполненным листом свойств STEP1</param>
        public object_general Object_carrier_get(Boolean Extended = false)
        {
            object_general Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_id(this.Id_object_carrier);
            }
            else
            {
                Result = Manager.object_by_id(this.Id_object_carrier);
            }
            return Result;
        }

        #endregion

        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override String ToString()
        {
            return name_object;
        }
    }
}
