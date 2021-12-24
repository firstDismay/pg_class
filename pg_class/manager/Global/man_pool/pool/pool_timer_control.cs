using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.poolcn
{
    internal partial class pool
    {
        #region ТАЙМЕР БЛОКА УЧЕТА ВРЕМЕНИ ПРОСТОЯ
        /// <summary>
        /// Переменная таймера учета времени простоя
        /// </summary>
        private static System.Timers.Timer MyTimer;

        /// <summary>
        /// Запуск контрольного таймера управляющего соединением с БД
        /// </summary>
        private void StartControlTimer()
        {
            //ИНИЦИАЛИЗАЦИЯ ТАЙМЕРА
            if (MyTimer == null)
            {
                MyTimer = new System.Timers.Timer(60000);
                MyTimer.Elapsed += new System.Timers.ElapsedEventHandler(MyTimer_Elapsed);
                MyTimer.Start();
            }
        }

        /// <summary>
        /// Останов контрольного таймера управляющего соединением с БД
        /// </summary>
        private void StopControlTimer()
        {
            //ИНИЦИАЛИЗАЦИЯ ТАЙМЕРА
            if (MyTimer != null)
            {
                MyTimer.Stop();
                MyTimer.Elapsed -= new System.Timers.ElapsedEventHandler(MyTimer_Elapsed);
                MyTimer = null;
            }
        }

        /// <summary>
        /// Обработчик события таймера
        /// </summary>
        void MyTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            List<connect> CN = null;

            lock (cn_list)
            {
                if (cn_list.Count > 0)
                {
                    CN = cn_list.FindAll(x => !x.IsUse & (x.GetTimeOutUsing() > Session_Settings.SessionTimeOut));
                    if (CN.Count > 0)
                    {
                        foreach (connect c in CN)
                        {
                            lock (c)
                            {
                                c.Lock();
                                c.Drop();
                                cn_list.Remove(c);
                            }
                            //Вызов события изменения количества подключений
                            PoolConnectEventArgs pc = new PoolConnectEventArgs(cn_list.Count, manager.PoolConnectMaxStatic);
                            manager.PoolConnectCountOnChangeStatic(this, pc);
                        }
                    }
                }
                else
                {
                    if (manager.StateInstance != eManagerState.Disconnected)
                    {
                        Manager.ManagerStateInstanceSet(eManagerState.Disconnected);
                        //Генерируем событие изменения состояния менеджера данных
                        ManagerStateChangeEventArgs e2 = new ManagerStateChangeEventArgs(eEntity.pool, eManagerState.Disconnected);
                        manager.OnManagerStateChange(e2);
                        
                        //Вызов события журнала
                        JournalEventArgs me = new JournalEventArgs(0, eEntity.manager, 0, "Все соединения менеджера закрыты по таймауту", eAction.DisConnect, eJournalMessageType.information);
                        manager.JournalMessageOnReceivedStatic(this, me);
                    }
                }
            }
        }
        #endregion
    }
}
