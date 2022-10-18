using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения списка правил разрешения вложения классов в позиции указанных шаблонов
    /// </summary>
    public class Rulel2_Class_On_PositionListChangeEventArgs:EventArgs

    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public Rulel2_Class_On_PositionListChangeEventArgs(Int64 Id_Position, Int64 Id_Class, eActionRuleList Action) : base()
        {
            action = Action;
            id_position = Id_Position;
            id_class = Id_Class;
        }

        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public Rulel2_Class_On_PositionListChangeEventArgs(Int64 Id_Position, eActionRuleList Action) : base()
        {
            action = Action;
            id_position = Id_Position;
            id_class = -1;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eActionRuleList action;
        Int64 id_class;
        Int64 id_position;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eActionRuleList Action { get => action;}
        /// <summary>
        /// Идентификатор класса включенного в разрешающее правило уровня 2 класс на позицию
        /// </summary>
        public Int64 Id_class { get => id_class; }

        /// <summary>
        /// Идентификатор позиции включенной в разрешающее правило уровня 2 класс на позицию
        /// </summary>
        public Int64 Id_position { get => id_position; }

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
        /// Метод возвращает связанное правило из БД (при наличии)
        /// </summary>
        public rulel2_class_on_position GetRule()
        {
            return Manager.Rulel2_class_on_position_by_id(id_class, id_position);
        }
        #endregion
    }
}
