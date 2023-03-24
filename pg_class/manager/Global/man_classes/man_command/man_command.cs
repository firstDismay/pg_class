using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using System.Data;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод доступа к копиям квантовых таблиц данных
        /// </summary>
        public DataTable TableByName(String Name)
        {
            DataTable Result;
            if (datatable_list == null)
            {
                throw new PgManagerException(303, "Первичная инициализация менеджера не выполнена или не завершена!", "н/д");
            }
            lock (datatable_list)
            {
                Result = datatable_list.Find(x => x.TableName == Name);
            }

            if (Result != null)
            {
                Result = Result.Clone();
            }
            else
            {
                Result = new DataTable("noname");
            }
            return Result;
        }

        /// <summary>
        /// Метод доступа к копиям команд класса для многопоточного выполнения
        /// </summary>
        public NpgsqlCommandKey CommandByKey(String Command_Key, Boolean Clone = false)
        {
            NpgsqlCommandKey cmd = null;
            NpgsqlCommandKey Result = null;
            System.Threading.Thread tr1 = System.Threading.Thread.CurrentThread;

            if (command_list == null)
            {
                throw new PgManagerException(303, "Первичная инициализация менеджера не выполнена или не завершена!", "н/д");
            }

            lock (command_list)
            {
                cmd = command_list.Find(x => x.Key == Command_Key);
            }
            if (cmd != null)
            {
                lock (cmd)
                {
                    if (!Clone)
                    {
                        if (tr1.ManagedThreadId != 1)
                        {
                            Result = cmd.Clone();
                        }
                        else
                        {
                            //Result = cmd.Clone();
                            Result = cmd;
                        }
                    }
                    else
                    {
                        Result = cmd.Clone();
                    }
                }
            }
            else
            {
                throw new PgManagerException(505, String.Format("Команда '{0}' не найдена в листе доступных команд!", Command_Key), "н/д");
            }
            return Result;
        }
    }
}
