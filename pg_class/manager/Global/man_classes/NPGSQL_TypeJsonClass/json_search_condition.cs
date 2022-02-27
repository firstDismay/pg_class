﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class
{
    /// <summary>
    /// Класс условие поиска типа подбор пр критериям преобразования в JSONB
    /// </summary>
    public class PropSearchСondition
    {
        private Int64 _IdGlobalProp;
        /// <summary>
        /// Идентификатор глобального свойства
        /// </summary>
        public Int64 IdGlobalProp 
        { 
            get 
            { 
                return _IdGlobalProp; 
            }
            set 
            { 
                _IdGlobalProp = value;
                _IdDefinitionProp = -1;
            }
        }

        private Int64 _IdDefinitionProp;
        /// <summary>
        /// Идентификатор определяющего свойства, может быть задан при отсуствии глобального свойства
        /// </summary>
        public Int64 IdDefinitionProp 
        {
            get
            {
                return _IdDefinitionProp; 
            }
            set
            {
                _IdDefinitionProp = value;
                _IdGlobalProp = -1;
            }
        }

        private eSearchMethods _SearchMethods;
        /// <summary>
        ///Метод поиска
        /// </summary>
        public eSearchMethods SearchMethods
        {
            get
            {
                return _SearchMethods;
            }
            set
            {
                _SearchMethods = value;
            }
        }

        /// <summary>
        ///Метод поиска строковое представление
        /// </summary>
        public String SearchMethodsToString 
        { get
            {
                return _SearchMethods.ToString();
            } 
        }

        /// <summary>
        /// Верхня граница условия поиска
        /// </summary>
        public String ValMax { get; set; }

        /// <summary>
        /// Нижняя граница условия поиска
        /// </summary>
        public String ValMin { get; set; }

        /// <summary>
        /// Запрашиваемое единичное значение или маска
        /// </summary>
        public String ValReq { get; set; }

        /// <summary>
        /// Запрашиваемый массив значений
        /// </summary>
        public String[] ValReqArray { get; set; }

        /// <summary>
        /// Строковое описание условия поиска
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Строковое описание условия поиска
        /// </summary>
        public override string ToString()
        {
            return Description;
        }
    }
}


