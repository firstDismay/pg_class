using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;
using pg_class.pg_exceptions;

namespace pg_class.pg_commands
{
    /// <summary>
    /// Класс отложенных команд экспорта данных
    /// </summary>
    public class command_export
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Закрытый конструктор класса
        /// </summary>
        protected command_export() { }

        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        internal command_export(NpgsqlCommandKey CommandExport, String CommandExportText, String CommandExportDesc)
        {
            command_export_text_ = CommandExportText;
            command_export_desc_ = CommandExportDesc;
            cmdk = CommandExport;
        }

        #endregion

        #region СВОЙСТВА КЛАССА
        
        private String command_export_text_;
        private String command_export_desc_;
        private NpgsqlCommandKey cmdk;

        /// <summary>
        /// Ключ/наименование команды без скобок
        /// </summary>
        public String CommandExportText { get => command_export_text_; }

        private String desc_;
        /// <summary>
        /// Ключ/наименование команды без скобок
        /// </summary>
        public String CommandExportDesc { get => command_export_desc_;}


        private String path_;
        /// <summary>
        /// Поле для взаимодействия с интерфейсом
        /// </summary>
        public String Path { get => path_; set => path_ = value; }

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
        /// Команда отложенного экспорта данных
        /// </summary>
        public Byte[] Export()
        {
            Byte[] Result = null;

            if (cmdk != null)
            {
                if (!cmdk.Access)
                {
                    throw new AccessDataBaseException(404, String.Format(@"Доступ к методу '{0}' запрещен!", cmdk.CommandText));
                }
            }
            else
            {
                throw new AccessDataBaseException(404, String.Format(@"Доступ к методу '{0}' запрещен!", cmdk.CommandText));
            }

            object tmp = cmdk.ExecuteScalar();

            if (tmp != DBNull.Value)
            {
                Result = (Byte[])tmp;
            }
            //Генерируем событие завершения процедуры экспорта
            ExportCompletedEventArgs e = new ExportCompletedEventArgs(command_export_text_, Result);
            Manager.ExportOnCompleted(e);
            return Result;
        }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return desc_;
        }
        #endregion
    }
}
