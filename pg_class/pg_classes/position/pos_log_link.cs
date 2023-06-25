using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Модуль взаимодействия сущности и записей журнала
    /// </summary>
    public partial class position
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ СO ССФЛКАМИ НА ДОКУМЕНТЫ

        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет ссылку на запись журнала
        /// </summary>
        public log_link log_link_add(Int64 iid_log)
        {
            return Manager.log_link_add(iid_log, this);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет ссылку запись журнала
        /// </summary>
        public void log_link_del(Int64 iid_log)
        {
            Manager.log_link_del_by_entity(iid_log, this);
        }
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Метод выбирает ссылку на запись журнала
        /// </summary>
        public log_link log_link_by_entity(Int64 iid_log)
        {
            return Manager.log_link_by_entity(iid_log, this);
        }
        #endregion
        #endregion
    }
}
