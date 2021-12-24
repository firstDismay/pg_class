using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент события изменения списка разрешений уровня 1 класс на шаблон
    /// </summary>
    public class Rulel1_Class_On_Pos_tempListChangeEventArgs: EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public Rulel1_Class_On_Pos_tempListChangeEventArgs(Int64 Id_Class, Int64 Id_Pos_temp, eActionRuleList Action) : base()
        {
            action = Action;
            id_class = Id_Class;
            id_pos_temp = Id_Pos_temp;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eActionRuleList action;
        Int64 id_class;
        Int64 id_pos_temp;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eActionRuleList Action { get => action;}
        /// <summary>
        /// Идентификатор класса включенной в правило вложенности уровня 1
        /// </summary>
        public Int64 Id_class { get => id_class; }

        /// <summary>
        /// Идентификатор шаблона позиции включенного в правило вложенности уровня 1
        /// </summary>
        public Int64 Id_pos_temp { get => id_pos_temp; }

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
        public rulel1_class_on_pos_temp GetRule()
        {
            throw new Exception("Метод не реализован!");
            //return Manager.rulel1_class_on_pos_temp_by_id(id_class, id_pos_temp);
        }
        #endregion
    }
}
