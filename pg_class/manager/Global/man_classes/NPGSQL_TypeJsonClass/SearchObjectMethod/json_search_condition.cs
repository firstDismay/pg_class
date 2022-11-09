using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace pg_class
{
    /// <summary>
    /// Класс условие поиска типа подбор пр критериям преобразования в JSONB
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class PropSearchСondition
    {
     /// <summary>
     /// Конструктор по умолчанию
     /// </summary>
        public PropSearchСondition()
        {
            IdGlobalProp = -1;
            IdDefinitionProp = -1;
        }

        /// <summary>
        /// Идентификатор глобального свойства
        /// </summary>
        [JsonProperty]
        public Int64 IdGlobalProp { get; set; }

        /// <summary>
        /// Идентификатор определяющего свойства, может быть задан при отсуствии глобального свойства
        /// </summary>
        [JsonProperty]
        public Int64 IdDefinitionProp { get; set; }

        private eSearchMethods _SearchMethods;
        /// <summary>
        ///Метод поиска
        /// </summary>
        [JsonProperty]
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
        [JsonProperty]
        public String SearchMethodsToString 
        { get
            {
                return _SearchMethods.ToString();
            } 
        }

        /// <summary>
        /// Верхня граница условия поиска
        /// </summary>
        [JsonProperty]
        public String ValMax { get; set; }

        /// <summary>
        /// Нижняя граница условия поиска
        /// </summary>
        [JsonProperty]
        public String ValMin { get; set; }

        /// <summary>
        /// Запрашиваемое единичное значение или маска
        /// </summary>
        [JsonProperty]
        public String ValReq { get; set; }

        /// <summary>
        /// Запрашиваемый массив значений
        /// </summary>
        [JsonProperty]
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
            String Result = manager.SearchMethodsToString(_SearchMethods);

            switch(_SearchMethods)
            {

                case eSearchMethods.equal:
                    Result = String.Format("{0}{1}", Result, ValReq);
                    break;
                case eSearchMethods.not_equal:
                    Result = String.Format("{0}{1}", Result, ValReq);
                    break;
                case eSearchMethods.less:
                    Result = String.Format("{0}{1}", Result, ValReq);
                    break;
                case eSearchMethods.less_or_equal:
                    Result = String.Format("{0}{1}", Result, ValReq);
                    break;
                case eSearchMethods.more:
                    Result = String.Format("{0}{1}", Result, ValReq);
                    break;
                case eSearchMethods.more_or_equal:
                    Result = String.Format("{0}{1}", Result, ValReq);
                    break;

                case eSearchMethods.more_and_less:
                    Result = String.Format("{0}{1}{2}",ValMin , Result, ValMax);
                    break;
                case eSearchMethods.more_and_less_or_equal:
                    Result = String.Format("{0}{1}{2}", ValMin, Result, ValMax);
                    break;
                case eSearchMethods.more_or_equal_and_less:
                    Result = String.Format("{0}{1}{2}", ValMin, Result, ValMax);
                    break;
                case eSearchMethods.more_or_equal_and_less_or_equal:
                    Result = String.Format("{0}{1}{2}", ValMin, Result, ValMax);
                    break;

                case eSearchMethods.like:
                    Result = String.Format("{0}{1}", Result, ValReq);
                    break;
                case eSearchMethods.like_lower:
                    Result = String.Format("{0}{1}", Result, ValReq);
                    break;

                case eSearchMethods.any_array:
                    Result = String.Format("{0}{1}", Result, Description);
                    break;
                case eSearchMethods.not_any_array:
                    Result = String.Format("{0}{1}", Result, Description);
                    break;
            }
            return Result;
        }
    }
}


