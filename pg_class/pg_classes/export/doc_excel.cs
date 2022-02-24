using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Квантовый класс для работы с файлами excel
    /// </summary>
    public class doc_excel : IDisposable
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected doc_excel() { }

        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы ТаблицаДокументов
        /// </summary>
        public doc_excel(String Command_export)
        {
            command_export = Command_export;
        }
        #endregion

        #region ПОЛЯ КЛАССА
        String command_export;
        /// <summary>
        /// Строка для запроса данных экспорта
        /// </summary>
        public String Command_export
        {
            get { return Command_export; }
        }

        /// <summary>
        /// Ссылка на менеджера данных
        /// </summary>
        private manager Manager
        {
            get
            {
                return manager.Instance();
            }
        }

        #endregion

        #region МЕТОДЫ КЛАССА

        /// <summary>
        /// Метод экспортирует рабочу книгу Excel с данными экпорта в батовый массив
        /// </summary>
        public Byte[] ExportExcelWorkBook_to_ByteArray()
        {
            return Manager.export_to_excel(command_export);
        }

        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ

        /// <summary>
        /// Формирует батовый массив готовой книги Excel.xlsx для сохранения на диск
        /// </summary>
        public Byte[] Export()
        {
            return Manager.export_to_excel(command_export);
        }
        #endregion


        /// <summary>
        /// Метод обеспечивает удаление связанных документов
        /// </summary>
        public void Dispose()
        {
            try
            {
               //Удаляем ранее выгруженный файл если он есть
               //System.IO.File.Delete(this.ЛокальныйПуть);
            }
            catch (System.IO.IOException) { }
        }


        /// <summary>
        /// Метод обеспечивает удаление связанных документов
        /// </summary>
        public void Close()
        {
            try
            {
                //Удаляем ранее выгруженный файл если он есть
                //System.IO.File.Delete(this.ЛокальныйПуть);
            }
            catch (System.IO.IOException) { }
        }

    }
}
