using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class
{
    /// <summary>
    /// Класс аргумент для поиска типа подбор пр критериям преобразования в JSONB
    /// </summary>
    public class json_array_prop
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
        /// Режим поиска
        /// strong - строое соотвествие значению
        /// mask - поиск по маске
        /// range - поиск в диапазоне
        /// rangemax - поиск больше максимума
        /// rangemin - поиск меньше минимма
        /// </summary>
        public String FindType { get; set; }

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


