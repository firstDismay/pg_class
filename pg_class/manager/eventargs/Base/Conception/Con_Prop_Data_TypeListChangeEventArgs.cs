using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения списка правил назначения типов данных на концепцию
    /// </summary>
    public class Con_Prop_Data_TypeListChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public Con_Prop_Data_TypeListChangeEventArgs(Int64 Id_Conception, Int32 Id_Prop_Data_Type, eActionRuleList Action) : base()
        {
            action = Action;
            id_conception = Id_Conception;
            id_prop_data_type = Id_Prop_Data_Type;
        }
        
        #endregion

        #region СВОЙСТВА КЛАССА
        eActionRuleList action;
        Int64 id_conception;
        Int32 id_prop_data_type;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eActionRuleList Action { get => action;}
        /// <summary>
        /// Идентификатор концепции для которой определено правилом назначение типа данных
        /// </summary>
        public Int64 Id_Conception { get => id_conception; }

        /// <summary>
        /// Идентификатор позиции включенной в разрешающее правило уровня 2 класс на позицию
        /// </summary>
        public Int32 Id_Prop_Data_Type { get => id_prop_data_type; }


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
        /// Метод возвращает связанное назначение типа данных на концепцию из БД (при наличии)
        /// </summary>
        public con_prop_data_type GetCon_Prop_Data_Type()
        {
            return Manager.Con_prop_data_type_by_id(Id_Conception, Id_Prop_Data_Type);
        }
        #endregion
    }
}
