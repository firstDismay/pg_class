using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс сущностей БД
    /// </summary>
    public class entity
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected entity()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public entity(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "ventity")
            {
                id = (Int32)row["id"];
                entity_ = (String)row["entity"];
                name = (String)row["name"];
                desc = (String)row["desc"];
                errid = (Int32)row["errid"];
                can_link = (Boolean)row["can_link"];
                on_export = (Boolean)row["can_link"];
                sec_point = (Boolean)row["sec_point"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int32 id;
        private String entity_;
        private String name;
        private String desc;
        private Int32 errid;
        private Boolean can_link;
        private Boolean on_export;
        private Boolean sec_point;


        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public Int32 Id { get => id; }

        /// <summary>
        /// Сущность
        /// </summary>
        public String Entity { get => entity_; }

        /// <summary>
        /// Наименование сущности локализованное
        /// </summary>
        public String Name { get => name; }

        /// <summary>
        /// Описание сущности локализованное
        /// </summary>
        public String Desc { get => desc; }


        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public Int32 ErrId { get => errid; }

        /// <summary>
        /// Признак линкуемой сущности
        /// </summary>
        public Boolean Can_link { get => can_link; }

        /// <summary>
        /// Признак доступности операций экспорта для сущности
        /// </summary>
        public Boolean On_export { get => on_export; }

        /// <summary>
        /// Признак доступности установки точки контроля доступа для сущности
        /// </summary>
        public Boolean Sec_point { get => sec_point; }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return name;
        }
        #endregion

    }
}
