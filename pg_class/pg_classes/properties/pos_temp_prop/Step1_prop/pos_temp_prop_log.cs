﻿using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс шаблонов позиций
    /// </summary>
    public partial class pos_temp_prop
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
        public List<log> log_list_get()
        {
            return Manager.log_by_id_pos_temp_prop(this);
        }
        #endregion
        #endregion
    }
}