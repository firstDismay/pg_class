using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class conception
    {
        #region МЕТОДЫ РАБОТЫ С КАТЕГОРИЯМИ ЗАПИСЕЙ ЖУРНЛА

        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новую категорию записей
        /// log_category_add
        /// </summary>
        public log_category log_category_add(String iname, String idesc, Int32 ilevel, Boolean ion)
        {
            return Manager.log_category_add(Id, iname, idesc, ilevel, ion);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанную категорию записей
        /// log_category_del
        /// </summary>
        public void log_category_del(Int64 iid)
        {
            Manager.log_category_del(iid);
        }

        /// <summary>
        /// Метод удаляет указанную категорию записей
        /// doc_category_del
        /// </summary>
        public void log_category_del(doc_category Doc_category)
        {
            Manager.log_category_del(Doc_category.Id);
        }
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист категорий записей по идентификатору концепции
        /// log_category_on_by_id_conception
        /// </summary>
        public List<log_category> log_category_list_get()
        {
            return Manager.log_category_on_by_id_conception(Id);
        }

        /// <summary>
        /// Лист включенных категорий записей по идентификатору концепции
        /// log_category_on_by_id_conception
        /// </summary>
        public List<log_category> log_category_on_list_get()
        {
            return Manager.log_category_on_by_id_conception(Id);
        }
        #endregion
        #endregion
    }
}