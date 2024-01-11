using Npgsql;
using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using System.Data;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод применяет к текущей базе конструктора файл обновления схемы данных
        /// </summary>
        public Int32 schema_update(String filename)
        {
            if (this.User_current.RolSuper)
            {
                string strText = System.IO.File.ReadAllText(filename, System.Text.Encoding.UTF8);
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = Connect_Get().CN;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strText;
                return cmd.ExecuteNonQuery();
            }
            else
            {
                throw new AccessDataBaseException(404, String.Format(@"Отказано в доступе к методу обновления схемы данных текущей базы!"));
            }
        }
    }
}