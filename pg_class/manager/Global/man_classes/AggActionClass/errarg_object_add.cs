using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Квантовый класс для возврата результатов групповых операций приведения объектов
    /// </summary>
    public class errarg_object_add
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected errarg_object_add()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public errarg_object_add(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "errarg_object_add")
            {
                err_id = (Int32)row["err_id"];
                errdesc = (String)row["errdesc"];

                class_id = (Int64)row["class_id"];
                class_name = (String)row["class_name"];

                object_id = (Int64)row["object_id"];
                object_name = (String)row["object_name"];

                action_id = (Int32)row["action_id"];
                action_desc = (String)row["action_desc"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int32 err_id;
        private String errdesc;

        private Int64 class_id;
        private String class_name;

        private Int64 object_id;
        private String object_name;

        private Int32 action_id;
        private String action_desc;

        /// <summary>
        /// Идентификатор ошибки
        /// </summary>
        public Int32 Err_id { get => err_id; }

        /// <summary>
        /// Описание ошибки
        /// </summary>
        public String Errdesc { get => errdesc; }

        /// <summary>
        /// Идентификатор класса
        /// </summary>
        public Int64 Class_id { get => class_id; }

        /// <summary>
        /// Наименование класса
        /// </summary>
        public String Class_name { get => class_name; }

        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public Int64 Object_id { get => object_id; }

        /// <summary>
        /// Наименование объекта
        /// </summary>
        public String Object_name { get => object_name; }


        /// <summary>
        /// Идентификатор действия
        /// </summary>
        public Int32 Action_id { get => action_id; }

        /// <summary>
        /// Действие
        /// </summary>
        public eAction Action { get => (eAction)action_id; }

        /// <summary>
        /// Описание дейсвтвия
        /// </summary>
        public String Action_desc { get => action_desc; }

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
        /// Созданный объект
        /// </summary>
        public object_general Object_get()
        {
            return Manager.object_by_id(object_id);
        }

        /// <summary>
        /// Исходный активный класс
        /// </summary>
        public vclass Class_act_get()
        {
            return Manager.class_act_by_id(class_id);
        }

        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return String.Format("Действие: {0} Объект: {1} ИД: {2} Класса: {3} ИД: {4} Код завершения: {5} Описание: {6}",
                Action_desc,
                object_name,
                object_id,
                class_name,
                class_id,
                Err_id,
                Errdesc);
        }
        #endregion
    }
}
