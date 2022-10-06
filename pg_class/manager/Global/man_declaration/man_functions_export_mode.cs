using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace pg_class
{
    partial class manager
    {
        #region Функции экспорта/импорта данных
        /// <summary>
        /// Описание режима базового экспорта данных
        /// </summary>
        public static String ExportMode(eExportMode ExportMode)
        {
            String mode = "Таблица";
            switch (ExportMode)
            {
                case eExportMode.ImportReport:
                    mode = "Экспорт в формате доступном для импорта";
                    break;
                case eExportMode.SimplyReport:
                    mode = "Экспорт в формате простого списка";
                    break;
                case eExportMode.AdvancedReport:
                    mode = "Экспорт в формаие расширенного списка со свойствами";
                    break;
                case eExportMode.TableReport:
                    mode = "Экспорт в формате таблицы";
                    break;
                case eExportMode.ViewReport:
                    mode = "Экспорт в формате представления";
                    break;
            }
            return mode;
        }
        #endregion
    }
}
