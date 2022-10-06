using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pg_class
{
    #region Режимы работы менеджера
    /// <summary>
    /// Перечисление Режимов работы менеджера
    /// </summary>
    public enum eManagerMode
    {
        /// <summary>
        /// Основной режим работы менеджера
        /// </summary>
        NormalMode = 1,
        /// <summary>
        /// Отладочный режим работы менеджера
        /// </summary>
        DebugMode = 2
    }
    #endregion
}
