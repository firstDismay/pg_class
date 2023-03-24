using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс измеряемой величины
    /// </summary>
    public partial class unit_conception : unit
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected unit_conception()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public unit_conception(Int64 Id_conception, System.Data.DataRow row) : base(row)
        {
            id_conception = Id_conception;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private Int64 id_conception;

        /// <summary>
        /// Идентификатор измеряемой величины
        /// </summary>
        public Int64 Id_Conception { get => id_conception; }


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

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return base.Name;
        }
        #endregion

    }
}
