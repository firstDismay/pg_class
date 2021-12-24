using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Модуль взаимодействия сущности и ссылки на документ
    /// </summary>
    public partial class user
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ СO ССФЛКАМИ НА ДОКУМЕНТЫ

        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет ссылку на документ для текущей сущности
        /// </summary>
        public doc_link doc_link_add(Int64 iid_document)
        {
            return Manager.doc_link_add(iid_document, this);
        }
        //*********************************************************************************************
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет ссылку на документ для текущей сущности
        /// </summary>
        public void doc_link_del(Int64 iid_document)
        {
            Manager.doc_link_del_by_entity(iid_document, this);
        }
        //*********************************************************************************************
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document)
        {
            return Manager.doc_link_by_entity(iid_document, this);
        }
        #endregion
        #endregion
    }
}
