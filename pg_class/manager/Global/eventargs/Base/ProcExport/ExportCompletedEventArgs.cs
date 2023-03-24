using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий завершения команд экспорта
    /// </summary>
    public class ExportCompletedEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ExportCompletedEventArgs(String Command_export, Byte[] ExportByteArray) : base()
        {
            command_export = Command_export;
            bytearray = ExportByteArray;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        String command_export;
        Byte[] bytearray;

        /// <summary>
        /// Команда экспорта данных
        /// </summary>
        public String Сommand_export { get => command_export; }

        /// <summary>
        /// Результирующий батовый массив (файл Excel)
        /// </summary>
        public Byte[] ByteArray { get => bytearray; }
        #endregion
    }
}
