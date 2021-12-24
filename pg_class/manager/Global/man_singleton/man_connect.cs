using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using pg_class.pg_exceptions;
using System.Data;
using System.Net.Sockets;
using pg_class.pg_commands;
using pg_class.poolcn;

namespace pg_class
{
    public partial class manager
    {
        #region ОСНОВНЫЕ СВОЙСТВА СОЕДИНЕНИЯ

        internal static pg_settings Pg_ManagerSettings;
        /// <summary>
        /// Параметры текущей сесии пользователя, хранимые независимо от состояния экземпляра менеджера
        /// </summary>
        public static pg_settings Session_Settings
        {
            get
            {
                return Pg_ManagerSettings;
            }
        }

        /// <summary>
        /// Максимальное количество подключений в сесии менеджера
        /// </summary>
        public static int PoolConnectMaxStatic
        {
            get
            {
                Int32 Result = -1;
                if (Pg_ManagerSettings != null)
                {
                    Result = Pg_ManagerSettings.PoolConnectMax;
                }
                return Result;
            }
        }

        /// <summary>
        /// Текущее количество подключений в сесии менеджера
        /// </summary>
        public static int PoolConnectCurrentStatic
        {
            get
            {
                Int32 Result = 0;
                if (Me != null)
                {
                    Result = Me.PoolConnectCurrent;
                }
                return Result;
            }
        }

        #endregion

        #region ДОСТУП К СОЕДИНЕНИЯМ ПУЛА

        internal connect Connect_Get()
        {
            connect Result = null;
            if (pool_ != null)
            {
                Result =  pool_.Connect_Get();
            }
            return Result;
        }

        #endregion

        #region ЗАКРЫТИЕ СОЕДИНЕНИЯ

        /// <summary>
        /// Метод закрывает менеджер конфигуратора БД и освобождает ресурсы и очищает подписки на события менеджера
        /// </summary>
        static public void Close()
        {
            if (Me != null)
            {
                //===========
                Me.Pool_drop();
                //===========
                //Очищаем листы подписчиков на события менеджеров данных
                Me.InvocationListClear();
                //Обнуление переменной одиночки
                GC.SuppressFinalize(Me);
                Me = null;
            }
        }
    #endregion
    }
}