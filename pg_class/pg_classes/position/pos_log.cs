using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс шаблонов позиций
    /// </summary>
    public partial class position
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ ЗАПИСЯМИ ЖУРНАЛА
        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новую запись
        /// </summary>
        public log log_add(Int64 iid_category, String iuser_author, DateTime idatetime,
                                     String ititle, String imessage, String iclass_body, String ibody)
        {
            return Manager.log_add(iid_category, iuser_author, idatetime,
                                     ititle, imessage, iclass_body, ibody,
                                     this);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанную запись
        /// </summary>
        public void log_del(Int64 iid_log)
        {
            Manager.log_del(iid_log);
        }

        /// <summary>
        /// Метод удаляет указанную запись
        /// </summary>
        public void log_del(log Log)
        {
            Manager.document_del(Log.Id);
        }
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист записей журнала
        /// </summary>
        public List<log> log_list_get(Boolean object_on, Boolean recursive_on)
        {
            return Manager.log_by_id_position(this, object_on, recursive_on);
        }
        #endregion
        #endregion
    }
}