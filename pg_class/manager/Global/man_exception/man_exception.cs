using Newtonsoft.Json;
using Npgsql;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using System.Net.Sockets;
using System.Text;

namespace pg_class
{
    public partial class manager
    {
        #region ОБРАБОТКА ИСКЛЮЧЕНИЙ ВРЕМЕНИ ВЫПОЛНЕНИЯ

        /// <summary>
        /// Обобщенный метод обработки исключений выполнения команд сервера
        /// </summary>
        internal void command_exception_handler(Exception e, NpgsqlCommandKey cmdk)
        {
            StringBuilder sb;
            JournalEventArgs me;
            PgFunctionMessage Message;
            switch (e)
            {
                case Npgsql.PostgresException cpe:
                    Message = JsonConvert.DeserializeObject<PgFunctionMessage>(cpe.MessageText);
                    eEntity entity;
                    if (!Enum.TryParse(Message.entity, out entity))
                    {
                        entity = eEntity.entity;
                    }
                    if (Message.codeerr == null)
                    {
                        Message.func = "unknown_function";
                        Message.codeerr = "unknown_error";
                        Message.messageerr = "Еhe error is not mapped to API logic";
                        Message.classerr = "unknown_class";
                        Message.hinterr = "The error is probably a system error of the database server";
                    }
                    
                    eAction action;
                    if (!Enum.TryParse(Message.actionerr, out action))
                    {
                        action = eAction.AnyAction;
                    }
                    //Вызов события журнала
                    me = new JournalEventArgs(0, entity, Message.codeerr, e.Message, action, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw (new PgDataException(Message));

                case Npgsql.NpgsqlException cne:

                    sb = new StringBuilder();
                    sb.Append("Активное соединение разорвано, ошибка: ");
                    sb.Append(e.Message);
                    //Вызов события журнала
                    me = new JournalEventArgs(0, eEntity.manager, cne.HResult.ToString(), cne.Message, eAction.Execute, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw (new PgManagerException(cne.HResult, cne.Message, sb.ToString()));

                case AccessDataBaseException cbe:

                    //Вызов события журнала
                    me = new JournalEventArgs(0, eEntity.manager, cbe.HResult.ToString(), e.Message, eAction.Execute, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw (new PgManagerException(cbe.HResult, cbe.Message, cbe.ErrorDesc));
                default:
                    sb = new StringBuilder();
                    sb.Append("Неизвестная ошибка ошибка: ");
                    sb.Append(e.Message);
                    //Вызов события журнала
                    me = new JournalEventArgs(0, eEntity.manager, "unknown_error", e.Message, eAction.Execute, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw (new PgManagerException(e.HResult, e.Message, sb.ToString()));
            }
        }

        /// <summary>
        /// Обобщенный метод обработки исключений методов подключения к серверу
        /// </summary>
        internal void man_exception_handler(Exception e)
        {
            String ResultDesc;
            Int32 ResultID;
            JournalEventArgs me;
            StringBuilder sb;
            if (e is PostgresException)
            {
                PostgresException pe = (PostgresException)e;
                switch (pe.SqlState)
                {
                    case "28P01":
                        ResultID = 1404;
                        ResultDesc = "Неверная пара пользователь/пароль или неверны параметры авторизации";
                        //Вызов события журнала
                        me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, pe.MessageText, eAction.Connect, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgManagerException(ResultID, ResultDesc, pe.MessageText);

                    case "3D000":
                        sb = new StringBuilder();
                        sb.Append("Указанный каталог: '");
                        sb.Append(Pg_ManagerSettings.DataBase);
                        sb.Append("' не существует в базе данных");

                        ResultID = 1405;
                        ResultDesc = sb.ToString();
                        //Вызов события журнала
                        me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, pe.MessageText, eAction.Connect, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgManagerException(ResultID, ResultDesc, pe.MessageText);

                    case "28000":
                        sb = new StringBuilder();
                        sb.Append("Указанный пользователь: '");
                        sb.Append(Pg_ManagerSettings.UserName);
                        sb.Append("' не зарегистрирован в базе данных");

                        ResultID = 1406;
                        ResultDesc = sb.ToString();
                        //Вызов события журнала
                        me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, pe.MessageText, eAction.Connect, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgManagerException(ResultID, ResultDesc, pe.MessageText);

                    default:
                        ResultID = pe.HResult;
                        ResultDesc = "Необработанная ошибка подключения";
                        //Вызов события журнала
                        me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, pe.MessageText, eAction.Connect, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgManagerException(ResultID, ResultDesc, pe.MessageText);
                }
            }
            else if (e is PgManagerException)
            {
                PgManagerException pe = (PgManagerException)e;
                switch (pe.ErrorID)
                {
                    case 5003:
                        ResultID = pe.ErrorID;
                        ResultDesc = pe.ErrorDesc;
                        //Вызов события журнала
                        me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, pe.ErrorDesc, eAction.Connect, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgManagerException(ResultID, ResultDesc, pe.ErrorDesc);

                    default:
                        ResultID = pe.ErrorID;
                        ResultDesc = "Необработанная ошибка подключения";
                        //Вызов события журнала
                        me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, pe.ErrorDesc, eAction.Connect, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgManagerException(ResultID, ResultDesc, pe.ErrorDesc);
                }
            }
            else if (e is SocketException)
            {
                SocketException se = (SocketException)e;
                switch (se.ErrorCode)
                {
                    case 11001:
                        ResultID = se.ErrorCode;
                        ResultDesc = "Указанный сервер недоступен!";
                        //Вызов события журнала
                        me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, se.Message, eAction.Connect, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgManagerException(ResultID, ResultDesc, se.Message);
                    case 10061:
                        ResultID = se.ErrorCode;
                        ResultDesc = "Указанный сервер отклонил запрос на подключение!";
                        //Вызов события журнала
                        me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, se.Message, eAction.Connect, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgManagerException(ResultID, ResultDesc, se.Message);
                    case 10060:
                        ResultID = se.ErrorCode;
                        ResultDesc = "Превышено время ожидания ответа сервера, соединение разорвано или не может быть установлено!";
                        //Вызов события журнала
                        me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, se.Message, eAction.Connect, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgManagerException(ResultID, ResultDesc, se.Message);
                    case 10013:
                        ResultID = se.ErrorCode;
                        ResultDesc = "Запрет доступа к сокету, проверьте настройки межсетевого экрана!";
                        //Вызов события журнала
                        me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, se.Message, eAction.Connect, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgManagerException(ResultID, ResultDesc, se.Message);
                    default:
                        ResultID = se.ErrorCode;
                        ResultDesc = "Необработанная ошибка подключения";
                        //Вызов события журнала
                        me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, se.Message, eAction.Connect, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgManagerException(ResultID, ResultDesc, se.Message);
                }
                //0x80004005
            }
            else if (e is NpgsqlException)
            {
                NpgsqlException ne = (NpgsqlException)e;
                switch (ne.ErrorCode)
                {
                    case -2147467259:
                        ResultID = ne.ErrorCode;
                        ResultDesc = "Ошибка подключения к серверу";
                        //Вызов события журнала
                        me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, ne.Message, eAction.Connect, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgManagerException(ResultID, ResultDesc, ne.Message);

                    case 80004005:
                        ResultID = ne.ErrorCode;
                        ResultDesc = "Ошибка подключения к серверу";
                        //Вызов события журнала
                        me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, ne.Message, eAction.Connect, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgManagerException(ResultID, ResultDesc, ne.Message);

                    default:
                        ResultID = ne.HResult;
                        ResultDesc = "Необработанная ошибка подключения";
                        //Вызов события журнала
                        me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, ne.Message, eAction.Connect, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgManagerException(ResultID, ResultDesc, ne.Message);
                }
            }
            else if (e is System.ArgumentException)
            {
                System.ArgumentException ne = (System.ArgumentException)e;
                switch (ne.HResult)
                {
                    case -2147024809:
                        ResultID = ne.HResult;
                        ResultDesc = "Ошибка выполнения операции, неопределенность в аргументах функции сопоставления типов";
                        //Вызов события журнала
                        me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, ne.Message, eAction.Connect, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgManagerException(ResultID, ResultDesc, ne.Message);

                    default:
                        ResultID = ne.HResult;
                        ResultDesc = "Необработанная ошибка подключения";
                        //Вызов события журнала
                        me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, ne.Message, eAction.Connect, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgManagerException(ResultID, ResultDesc, ne.Message);
                }
            }
            else
            {
                ResultID = e.HResult;
                ResultDesc = "Необработанная ошибка подключения";
                //Вызов события журнала
                me = new JournalEventArgs(0, eEntity.manager, ResultID.ToString(), ResultDesc, e.Message, eAction.Connect, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgManagerException(ResultID, ResultDesc, e.Message);
            }
        }
        #endregion
    }
}