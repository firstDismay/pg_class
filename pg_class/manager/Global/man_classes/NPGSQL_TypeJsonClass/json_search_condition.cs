using System;
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

        /// <summary>
        /// Условие поиска должно содержать условный предикат переменной propval, 
        /// условие в формате SQL с укзанием предикатов переменных содержащих значения для поиска
        /// valmax, valmin
        /// Пример:
        /// propval BETWEEN valmin AND valmax; propval > valreq; propval = valreq; propval LIKE valreq || '%' 
        /// </summary>
        public String SearchСondition { get; set; }

        /// <summary>
        /// Верхня граница условия поиска
        /// </summary>
        public String ValMax { get; set; }

        /// <summary>
        /// Нижняя граница условия поиска
        /// </summary>
        public String ValMin { get; set; }

        /// <summary>
        /// Запрашиваемое значение или маска
        /// </summary>
        public String ValReq { get; set; }
    }
}


