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
        /// <summary>
        /// Идентификатор глобального свойства
        /// </summary>
        public Int64 IdGlobalProp { get; set; }

        /// <summary>
        /// Идентификатор определяющего свойства
        /// </summary>
        public Int64 IdDefinitionProp { get; set; }

        /// <summary>
        /// Условие поиска должно содержать условный предикат переменной propval, 
        /// условие в формате SQL с укзанием предикатов переменных содержащих значения для поиска
        /// valmax, valmin
        /// Пример:
        /// propval BETWEEN valmin AND valmax; propval > valmin; propval = valmin; propval LIKE valmin || '%' 
        /// </summary>
        public String SearchСondition { get; set; }

        /// <summary>
        /// Верхня текущая граница для поска в диапазоне, либо значение, либо маска
        /// </summary>
        public String ValMax { get; set; }

        /// <summary>
        /// Нижняя текущая граница для поска в диапазоне
        /// </summary>
        public String ValMin { get; set; }
    }
}


