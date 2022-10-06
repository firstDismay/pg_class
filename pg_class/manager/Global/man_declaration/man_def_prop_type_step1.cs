using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pg_class
{
	#region Перечисления типов свойств Шаг №1
	/// <summary>
	/// Перечисление допустимых типов свойств
	/// </summary>
	public enum ePropType
    {
        /// <summary>
        /// Свободно определяемое свойство
        /// </summary>
        PropUser = 1,
        /// <summary>
        /// Перечислимое свойство
        /// </summary>
        PropEnum = 2,
        /// <summary>
        /// Объектное свойство
        /// </summary>
        PropObject = 3,
        /// <summary>
        /// Свойство-ссылка
        /// </summary>
        PropLink = 4
    }

    /// <summary>
    /// Перечисление размеров типов данных свойств
    /// </summary>
    public enum eDataSize
    {
        /// <summary>
        /// Свойство малых типов данных
        /// </summary>
        BigData = 1,
        /// <summary>
        /// Свойство больших типов данных
        /// </summary>
        SmallData = 2
    }

    /// <summary>
    /// Состояние свойства в отношении готовности к линковке с глобальным свойством
    /// </summary>
    public enum ePropStateForGlobalPropLink
    {
        /// <summary>
        /// Свойство готово к линковке
        /// </summary>
        ready=0,
        /// <summary>
        /// Свойство не готово к линковке содержит различные имена в снимках метаданных
        /// </summary>
        different_names = 1,
        /// <summary>
        /// Свойство не готово к линковке содержит различные типы свойства в снимках метаданных
        /// </summary>
        different_prop_types = 2,
        /// <summary>
        /// Свойство не готово к линковке содержит различные типы данных свойства в снимках метаданных
        /// </summary>
        different_data_types = 3
    }
    #endregion
}
