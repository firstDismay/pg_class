﻿using Npgsql;
using pg_class.pg_exceptions;
using pg_class.poolcn;
using System;
using System.Data;


namespace pg_class.pg_commands
{
    /// <summary>
    /// Класс контейнер для инициализированных команд БД
    /// </summary>
    public partial class NpgsqlCommandKey
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        public NpgsqlCommandKey(UInt32 ProcOID, NpgsqlCommand cmd, String key, Int32 pronargs, String argsignature, UInt32 prorettype, String prorettypename, Boolean proretset, Boolean access)
        {
            procoid_ = ProcOID;
            cmd_ = cmd;
            key_ = key;
            pronargs_ = pronargs;
            argsignature_ = argsignature;
            prorettype_ = prorettype;
            prorettypename_ = prorettypename;
            proretset_ = proretset;
            access_ = access;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private NpgsqlCommand cmd_;
        private String key_;
        private Int32 pronargs_;
        private String argsignature_;
        private Boolean access_;
        private UInt32 procoid_;
        private UInt32 prorettype_;
        private String prorettypename_;
        private Boolean proretset_;

        /// <summary>
        /// OID возвращаемого командой типа данных
        /// </summary>
        public UInt32 ProRetType { get => prorettype_; }

        /// <summary>
        /// Наименование возвращаемого командой типа данных
        /// </summary>
        public String ProRetTypeName { get => prorettypename_; }

        /// <summary>
        /// Признак функции возвращающей кортежи зачений
        /// </summary>
        public Boolean ProRetSet { get => proretset_; }


        /// <summary>
        /// Метод команды используемый для вызова внутренней функции
        /// </summary>
        public eCommandMetod CommandMetod
        {
            get
            {
                eCommandMetod Result = eCommandMetod.ExecuteScalar;

                if (ProRetSet)
                {
                    Result = eCommandMetod.Fill;
                }
                else
                {
                    if (ProRetTypeName == "record")
                    {
                        Result = eCommandMetod.ExecuteNonQuery;
                    }
                }
                return Result;
            }
        }

        /// <summary>
        /// OID процедуры 
        /// </summary>
        public UInt32 ProcOID { get => procoid_; }

        /// <summary>
        /// Ключ/наименование команды без скобок
        /// </summary>
        public string Key { get => key_; }

        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return key_;
        }

        /// <summary>
        /// Колличество аргументов функции
        /// </summary>
        public int Pronargs { get => pronargs_; }

        /// <summary>
        /// Сигнатура вызиваемой функции в формате Postgre SQL
        /// </summary>
        public string Argsignature { get => argsignature_; }
        /// <summary>
        /// Достутупность функции в сессии текущего пользователя
        /// </summary>
        public bool Access { get => access_; }

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

        /// <summary>
        /// Коллекция параметров команды
        /// </summary>
        public NpgsqlParameterCollection Parameters { get => cmd_.Parameters; }

        /// <summary>
        /// Тразакция команды
        /// </summary>
        public NpgsqlTransaction Transaction { get => cmd_.Transaction; }

        /// <summary>
        /// Текстовое представление команды
        /// </summary>
        public String CommandText { get => cmd_.CommandText; }
        #endregion

        #region ОБОЛОЧКИ МЕТОДОВ КОМАНДЫ
        /// <summary>
        /// Метод предварительной подготовки команды к выполнению
        /// </summary>
        public void Prepare()
        {
            connect connect_;
            DateTime Start;
            DateTime Stop;
            Double LeadTime_ms;

            if (!access_)
            {
                String msg = String.Format(@"Отказано в доступе к методу: {0}!", cmd_.CommandText);
                AccessDataBaseException ex = new AccessDataBaseException(404, msg);
                Manager.command_exception_handler(ex, this);
            }

            if (cmd_ != null & access_)
            {
                connect_ = Manager.Connect_Get();
                Start = DateTime.Now;
                try
                {
                    lock (connect_.CN)
                    {
                        cmd_.Connection = connect_.CN;
                        cmd_.CommandTimeout = connect_.CN.CommandTimeout;
                        cmd_.Prepare();
                        cmd_.Connection = null;
                        connect_.UnLock();
                    }
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
                    Manager.command_exception_handler(ex, this);
                }
                finally
                {
                    cmd_.Connection = null;
                    connect_.UnLock();
                }

                Stop = DateTime.Now;
                LeadTime_ms = (Stop - Start).TotalMilliseconds;
                JournalMessageOnReceived(LeadTime_ms);
            }
        }

        /// <summary>
        /// Выполнение команды в режиме без вывода результата, возвращает количество затронутых строк или -1
        /// </summary>
        public Int32 ExecuteNonQuery()
        {
            connect connect_;
            DateTime Start;
            DateTime Stop;
            Double LeadTime_ms;
            Int32 Result = -1;
            NpgsqlTransaction trans;

            if (!access_)
            {
                String msg = String.Format(@"Отказано в доступе к методу: {0}!", cmd_.CommandText);
                AccessDataBaseException ex = new AccessDataBaseException(404, msg);
                Manager.command_exception_handler(ex, this);
            }

            if (cmd_ != null && access_)
            {
                connect_ = Manager.Connect_Get();
                Start = DateTime.Now;

                try
                {
                    lock (connect_.CN)
                    {
                        //Начало транзакции
                        cmd_.Connection = connect_.CN;
                        trans = connect_.CN.BeginTransaction(IsolationLevel.RepeatableRead);
                        cmd_.CommandTimeout = connect_.CN.CommandTimeout;
                        cmd_.Transaction = trans;
                        Result = cmd_.ExecuteNonQuery();
                        cmd_.Transaction.Commit();
                        cmd_.Connection = null;
                        connect_.UnLock();
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
                    cmd_.Connection = null;
                    connect_.UnLock();
                    Manager.command_exception_handler(ex, this);
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
                    cmd_.Connection = null;
                    connect_.UnLock();
                    Manager.command_exception_handler(ex, this);
                }
                finally
                {
                    cmd_.Connection = null;
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
        /// </summary>
        public DataTable Fill(DataTable tbl_data)
        {
            connect connect_;
            DateTime Start;
            DateTime Stop;
            Double LeadTime_ms;
            NpgsqlDataAdapter DA;
            NpgsqlTransaction trans;
            Start = DateTime.Now;

            if (!access_)
            {
                String msg = String.Format(@"Отказано в доступе к методу: {0}!", cmd_.CommandText);
                AccessDataBaseException ex = new AccessDataBaseException(404, msg);
                Manager.command_exception_handler(ex, this);
            }

            if (cmd_ != null && access_)
            {
                connect_ = Manager.Connect_Get();
                DA = new NpgsqlDataAdapter();
                try
                {
                    lock (connect_.CN)
                    {
                        //Начало транзакции
                        cmd_.Connection = connect_.CN;
                        DA.SelectCommand = cmd_;
                        trans = connect_.CN.BeginTransaction(IsolationLevel.ReadCommitted);

                        cmd_.CommandTimeout = connect_.CN.CommandTimeout;
                        cmd_.Transaction = trans;

                        DA.Fill(tbl_data);
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
                    cmd_.Connection = null;
                    connect_.UnLock();
                    Manager.command_exception_handler(ex, this);
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
                    cmd_.Connection = null;
                    connect_.UnLock();
                    Manager.command_exception_handler(ex, this);
                }
                finally
                {
                    cmd_.Connection = null;
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
        /// </summary>
        public Object ExecuteScalar()
        {
            connect connect_;
            DateTime Start;
            DateTime Stop;
            Double LeadTime_ms;
            Object Result = null;
            NpgsqlTransaction trans;

            if (!access_)
            {
                String msg = String.Format(@"Отказано в доступе к методу: {0}!", cmd_.CommandText);
                AccessDataBaseException ex = new AccessDataBaseException(404, msg);
                Manager.command_exception_handler(ex, this);
            }

            Start = DateTime.Now;
            if (cmd_ != null && access_)
            {
                connect_ = Manager.Connect_Get();
                try
                {
                    lock (connect_.CN)
                    {
                        //Начало транзакции
                        cmd_.Connection = connect_.CN;
                        trans = connect_.CN.BeginTransaction(IsolationLevel.RepeatableRead);
                        cmd_.CommandTimeout = connect_.CN.CommandTimeout;
                        cmd_.Transaction = trans;
                        Result = cmd_.ExecuteScalar();
                        trans.Commit();
                        cmd_.Connection = null;
                        connect_.UnLock();
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
                    cmd_.Connection = null;
                    connect_.UnLock();
                    Manager.command_exception_handler(ex, this);
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
                    cmd_.Connection = null;
                    connect_.UnLock();
                    Manager.command_exception_handler(ex, this);
                }
                finally
                {
                    cmd_.Connection = null;
                    connect_.UnLock();
                }

                Stop = DateTime.Now;
                LeadTime_ms = (Stop - Start).TotalMilliseconds;
                JournalMessageOnReceived(LeadTime_ms);
            }
            return Result;
        }

        /// <summary>
        /// Безусловная отмена выполнения доступного оператора
        /// </summary>
        public void Cancel()
        {
            if (!access_)
            {
                String msg = String.Format(@"Отказано в доступе к методу: {0}!", cmd_.CommandText);
                AccessDataBaseException ex = new AccessDataBaseException(404, msg);
                Manager.command_exception_handler(ex, this);
            }

            if (cmd_ != null && access_)
            {
                cmd_.Cancel();

            }
        }
        #endregion

        #region ВЗАИМОДЕЙСТВИЕ С ЖУРНАЛОМ ОТЛАДКИ

        private void JournalMessageOnReceived()
        {
            String Message;
            String ParamVal = "null";

            if (manager.Mode == eManagerMode.DebugMode)
            {
                Message = String.Format("Выполнение команды: {0} с параметрами: ", cmd_.CommandText);
                foreach (NpgsqlParameter p in cmd_.Parameters)
                {
                    if (p.NpgsqlValue != null && p.NpgsqlValue != DBNull.Value)
                    {
                        switch (p.NpgsqlDbType)
                        {
                            case NpgsqlTypes.NpgsqlDbType.Array:
                                ParamVal = "Массив";
                                break;
                            case NpgsqlTypes.NpgsqlDbType.Bytea:
                                ParamVal = "Двоичные данные";
                                break;
                            case NpgsqlTypes.NpgsqlDbType.Text:
                                if (p.NpgsqlValue.ToString().Length < 2024)
                                {
                                    ParamVal = p.NpgsqlValue.ToString();
                                }
                                else
                                {
                                    ParamVal = "Текст";
                                }
                                break;
                            case NpgsqlTypes.NpgsqlDbType.Json:
                                if (p.NpgsqlValue.ToString().Length < 2024)
                                {
                                    ParamVal = p.NpgsqlValue.ToString();
                                }
                                else
                                {
                                    ParamVal = "Тип Json";
                                }
                                break;
                            case NpgsqlTypes.NpgsqlDbType.Timestamp:
                                ParamVal = Convert.ToDateTime(p.NpgsqlValue).ToString("yyyy-MM-dd HH:mm:ss.fff");
                                break;
                            default:
                                ParamVal = p.NpgsqlValue.ToString();
                                break;
                        }
                    }
                    else
                    {
                        ParamVal = "null";
                    }
                    Message = String.Format("{0} {1} = {2}; ", Message, p.ParameterName, ParamVal);
                }

                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(-1, eEntity.entity, "action_allowed", Message, eAction.Execute, eJournalMessageType.debug);
                manager.JournalMessageOnReceivedStatic(this, me);
            }
        }

        private void JournalMessageOnReceived(Double LeadTime_ms)
        {
            String Message;
            String ParamVal = "null";

            if (manager.Mode == eManagerMode.DebugMode)
            {
                Message = String.Format("Выполнение команды: '{0}' с параметрами: ", cmd_.CommandText);
                foreach (NpgsqlParameter p in cmd_.Parameters)
                {
                    if (p.NpgsqlValue != null && p.NpgsqlValue != DBNull.Value)
                    {
                        switch (p.NpgsqlDbType)
                        {
                            case NpgsqlTypes.NpgsqlDbType.Array:
                                ParamVal = "Массив";
                                break;
                            case NpgsqlTypes.NpgsqlDbType.Bytea:
                                ParamVal = "Двоичные данные";
                                break;
                            case NpgsqlTypes.NpgsqlDbType.Text:
                                if (p.NpgsqlValue.ToString().Length < 2024)
                                {
                                    ParamVal = p.NpgsqlValue.ToString();
                                }
                                else
                                {
                                    ParamVal = "Текст";
                                }
                                break;
                            case NpgsqlTypes.NpgsqlDbType.Json:
                                if (p.NpgsqlValue.ToString().Length < 2024)
                                {
                                    ParamVal = p.NpgsqlValue.ToString();
                                }
                                else
                                {
                                    ParamVal = "Тип Json";
                                }
                                break;
                            case NpgsqlTypes.NpgsqlDbType.Timestamp:
                                ParamVal = Convert.ToDateTime(p.NpgsqlValue).ToString("yyyy-MM-dd HH:mm:ss.fff");
                                break;
                            default:
                                ParamVal = p.NpgsqlValue.ToString();
                                break;
                        }
                    }
                    else
                    {
                        ParamVal = "null";
                    }
                    Message = String.Format("{0} {1} = {2}; ", Message, p.ParameterName, ParamVal);
                }

                Message = String.Format("{0}| Время выполнения: {1}мс", Message, LeadTime_ms);
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(procoid_, eEntity.entity, "action_allowed", Message, eAction.Execute, eJournalMessageType.debug);
                manager.JournalMessageOnReceivedStatic(this, me);
            }
        }
        #endregion
    }
}