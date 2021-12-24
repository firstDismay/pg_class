﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения шаблонов позиций
    /// </summary>
    public class PosTempNestedListChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PosTempNestedListChangeEventArgs(pos_temp PosTemp, eActionPosTempNestedList Action) : base()
        {
            action = Action;
            if (PosTemp != null)
            {
                postemp = PosTemp;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eActionPosTempNestedList action;
        pos_temp postemp;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eActionPosTempNestedList Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public pos_temp PosTemp { get => postemp; }
        #endregion
    }
}
