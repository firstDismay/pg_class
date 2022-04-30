using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Npgsql;
using System.Data;
using System.Windows.Forms;
using pg_class.pg_exceptions;
using System.Net.Sockets;
using System.Linq;

namespace pg_class
{
    /// <summary>
    /// Класс одиночка предоставляющий общий доступ к БД Ассистента"
    /// </summary>
    public partial class manager
    {
        /// <summary>
        /// Максимально допустимый предел для байтовых опреаций с сервером
        /// 1Gb
        /// </summary>
        private const Int32 filesizelimit = 1073741823;

        /// <summary>
        /// Коэффициент перевода мегабайт в байты
        /// </summary>
        private const Int32 mb_to_byte = 1048576;
    }
}
