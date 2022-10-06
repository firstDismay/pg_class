using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pg_class
{
    #region Перечисления для функций экспорта импорта данных
    /// <summary>
    /// Перечисление базовых форматов экспорта данных сущностей
    /// </summary>
    public enum eExportMode
    {
        /// <summary>
        /// Экспорт в формате доступном для импорта
        /// </summary>
        ImportReport = 0,
        /// <summary>
        /// Экспорт в формате простого списка
        /// </summary>
        SimplyReport = 1,
        /// <summary>
        /// Экспорт в формаие расширенного списка со свойствами
        /// </summary>
        AdvancedReport = 2,
        /// <summary>
        /// Экспорт в формате табличного представления
        /// </summary>
        TableReport = 3,
        /// <summary>
        /// Экспорт в формате представления
        /// </summary>
        ViewReport = 4
    }
    #endregion
}
