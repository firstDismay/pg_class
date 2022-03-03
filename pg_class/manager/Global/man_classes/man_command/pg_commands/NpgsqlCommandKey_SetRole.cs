using System;
using Npgsql;
using System.Data;
using pg_class.poolcn;
using pg_class.pg_exceptions;

namespace pg_class.pg_commands
{
    /// <summary>
    /// Класс контейнер для инициализированных команд БД
    /// </summary>
    public partial class NpgsqlCommandKey
    {
        #region ОБОЛОЧКИ МЕТОДОВ КОМАНДЫ СО СМЕНОЙ РОЛИ

        /// <summary>
        /// Выполнение команды в режиме без вывода результата, возвращает количество затронутых строк или -1
        /// под указанной ролью
        /// </summary>
        public Int32 ExecuteNonQuery(String RoleName)
        {
            connect connect_;
            DateTime Start;
            DateTime Stop;
            Double LeadTime_ms;
            Int32 Result = -1;
            NpgsqlTransaction trans;
            NpgsqlCommand rcmd;
            String RoleSession;

            if (cmd_ != null)
            {
                connect_ = Manager.Connect_Get();
                Start = DateTime.Now;
                RoleSession = connect_.CN.UserName;

                try
                {
                    lock (connect_.CN)
                    {
                        //Начало транзакции
                        cmd_.Connection = connect_.CN;
                        trans = connect_.CN.BeginTransaction(IsolationLevel.RepeatableRead);

                        //Смена роли
                        rcmd = new NpgsqlCommand();
                        rcmd.Connection = connect_.CN;
                        rcmd.Transaction = trans;
                        rcmd.CommandType = CommandType.Text;
                        rcmd.CommandText = String.Format("SET ROLE '{0}';", RoleName);
                        rcmd.ExecuteNonQuery();

                        //Выполнение команды
                        cmd_.CommandTimeout = connect_.CN.CommandTimeout;
                        cmd_.Transaction = trans;
                        Result = cmd_.ExecuteNonQuery();

                        //Возврат роли
                        rcmd.CommandText = String.Format("SET ROLE '{0}';", RoleSession);
                        rcmd.ExecuteNonQuery();

                        //Завершение транзакции
                        cmd_.Transaction.Commit();
                        connect_.UnLock();
                        cmd_.Connection = null;
                    }
                }
                catch (Npgsql.PostgresException ex)
                {
                    if (cmd_.Transaction != null)
                    {
                        if (!cmd_.Transaction.IsCompleted)
                        {
                            cmd_.Transaction.Rollback();
                        }
                    }
                    connect_.UnLock();
                    cmd_.Connection = null;
                    Manager.PG_exception_hadler(ex, this);
                }
                catch (Exception ex)
                {
                    if (cmd_.Transaction != null)
                    {
                        if (!cmd_.Transaction.IsCompleted)
                        {
                            cmd_.Transaction.Rollback();
                        }
                    }
                    connect_.UnLock();
                    cmd_.Connection = null;
                    Manager.PG_exception_hadler(ex, this);
                }
                finally
                {
                    connect_.UnLock();
                }

                Stop = DateTime.Now;
                LeadTime_ms = (Stop - Start).TotalMilliseconds;
                JournalMessageOnReceived(LeadTime_ms);
            }
            return Result;
        }

        /// <summary>
        /// Выполнение команды в режиме с выводом результата в указанный контейнер
        /// под указанной ролью
        /// </summary>
        public DataTable Fill(DataTable tbl_data, String RoleName)
        {
            connect connect_;
            DateTime Start;
            DateTime Stop;
            Double LeadTime_ms;
            NpgsqlDataAdapter DA;
            NpgsqlTransaction trans;
            NpgsqlCommand rcmd;
            String RoleSession;

            if (cmd_ != null)
            {
                connect_ = Manager.Connect_Get();
                Start = DateTime.Now;
                RoleSession = connect_.CN.UserName;
                DA = new NpgsqlDataAdapter();

                try
                {
                    lock (connect_.CN)
                    {
                        //Начало транзакции
                        cmd_.Connection = connect_.CN;
                        DA.SelectCommand = cmd_;
                        trans = connect_.CN.BeginTransaction(IsolationLevel.ReadCommitted);

                        //Смена роли
                        rcmd = new NpgsqlCommand();
                        rcmd.Connection = connect_.CN;
                        rcmd.Transaction = trans;
                        rcmd.CommandType = CommandType.Text;
                        rcmd.CommandText = String.Format("SET ROLE '{0}';", RoleName);
                        rcmd.ExecuteNonQuery();

                        //Выполнение команды
                        cmd_.CommandTimeout = connect_.CN.CommandTimeout;
                        cmd_.Transaction = trans;
                        DA.Fill(tbl_data);

                        //Возврат роли
                        rcmd.CommandText = String.Format("SET ROLE '{0}';", RoleSession);
                        rcmd.ExecuteNonQuery();

                        //Завершение транзакции
                        trans.Commit();
                        connect_.UnLock();
                        cmd_.Connection = null;
                    }
                }
                catch (Npgsql.PostgresException ex)
                {
                    if (cmd_.Transaction != null)
                    {
                        if (!cmd_.Transaction.IsCompleted)
                        {
                            cmd_.Transaction.Rollback();
                        }
                    }
                    connect_.UnLock();
                    cmd_.Connection = null;
                    Manager.PG_exception_hadler(ex, this);
                }
                catch (Exception ex)
                {
                    if (cmd_.Transaction != null)
                    {
                        if (!cmd_.Transaction.IsCompleted)
                        {
                            cmd_.Transaction.Rollback();
                        }
                    }
                    connect_.UnLock();
                    cmd_.Connection = null;
                    Manager.PG_exception_hadler(ex, this);
                }
                finally
                {
                    connect_.UnLock();
                }

                Stop = DateTime.Now;
                LeadTime_ms = (Stop - Start).TotalMilliseconds;
                JournalMessageOnReceived(LeadTime_ms);
            }
            return tbl_data;
        }

        /// <summary>
        /// Выполнение команды в режиме без вывода результата, возвращает содержимое первой строки первого столбца результата команды
        /// под указанной ролью
        /// </summary>
        public Object ExecuteScalar(String RoleName)
        {
            connect connect_;
            DateTime Start;
            DateTime Stop;
            Double LeadTime_ms;
            Object Result = null;
            NpgsqlTransaction trans;
            NpgsqlCommand rcmd;
            String RoleSession;

            Start = DateTime.Now;
            if (cmd_ != null)
            {
                connect_ = Manager.Connect_Get();
                Start = DateTime.Now;
                RoleSession = connect_.CN.UserName;

                try
                {
                    lock (connect_.CN)
                    {
                        //Начало транзакции
                        cmd_.Connection = connect_.CN;
                        trans = connect_.CN.BeginTransaction(IsolationLevel.RepeatableRead);

                        //Смена роли
                        rcmd = new NpgsqlCommand();
                        rcmd.Connection = connect_.CN;
                        rcmd.Transaction = trans;
                        rcmd.CommandType = CommandType.Text;
                        rcmd.CommandText = String.Format("SET ROLE '{0}';", RoleName);
                        rcmd.ExecuteNonQuery();

                        //Выполнение команды
                        cmd_.CommandTimeout = connect_.CN.CommandTimeout;
                        cmd_.Transaction = trans;
                        Result = cmd_.ExecuteScalar();

                        //Возврат роли
                        rcmd.CommandText = String.Format("SET ROLE '{0}';", RoleSession);
                        rcmd.ExecuteNonQuery();

                        //Завершение транзакции
                        trans.Commit();
                        connect_.UnLock();
                        cmd_.Connection = null;
                    }
                }
                catch (Npgsql.PostgresException ex)
                {
                    if (cmd_.Transaction != null)
                    {
                        if (!cmd_.Transaction.IsCompleted)
                        {
                            cmd_.Transaction.Rollback();
                        }
                    }
                    connect_.UnLock();
                    Manager.PG_exception_hadler(ex, this);
                }
                catch (Exception ex)
                {
                    if (cmd_.Transaction != null)
                    {
                        if (!cmd_.Transaction.IsCompleted)
                        {
                            cmd_.Transaction.Rollback();
                        }
                    }
                    connect_.UnLock();
                    Manager.PG_exception_hadler(ex, this);
                }
                finally
                {
                    connect_.UnLock();
                }

                Stop = DateTime.Now;
                LeadTime_ms = (Stop - Start).TotalMilliseconds;
                JournalMessageOnReceived(LeadTime_ms);
            }
            return Result;
        }
        #endregion
    }
}
