﻿using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс шаблонов позиций
    /// </summary>
    public partial class user
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ С ДОКУМЕНТАМИ
        #region ДОБАВИТЬ [ФАЙЛ МАССИВ]

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_category, Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate)
        {
            return Manager.document_add(iid_category, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     this);
        }

        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанный документ, вложенные документы не имеющие ссылок и их файлы
        /// </summary>
        public void document_del(Int64 iid_document)
        {
            Manager.document_del(iid_document);
        }

        /// <summary>
        /// Метод удаляет указанный документ, вложенные документы не имеющие ссылок и их файлы
        /// </summary>
        public void document_del(document Document)
        {
            Manager.document_del(Document.Id);
        }
        

        /// <summary>
        /// Метод удаляет указанный документ, все вложенные документы их файлы
        /// </summary>
        public void document_del_all(Int64 iid_document)
        {
            Manager.document_del_all(iid_document);
        }

        /// <summary>
        /// Метод удаляет указанный документ, все вложенные документы их файлы
        /// </summary>
        public void document_del_all(document Document)
        {
            Manager.document_del_all(Document.Id);
        }
        
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист документов по идентификатору пользователя
        /// document_ext_by_id_user
        /// document_by_id_user
        /// </summary>
        public List<document> document_list_get(Boolean Extended = false)
        {
            if (Extended)
            {
                return Manager.document_ext_by_id_user(this);
            }
            else
            {
                return Manager.document_by_id_user(this);
            }
        }
        #endregion

        #endregion
    }
}
