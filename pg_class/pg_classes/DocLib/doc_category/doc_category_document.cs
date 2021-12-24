using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data;
using System.Security.Cryptography;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс файла документов 
    /// </summary>
    public partial class doc_category
    {
        #region МЕТОДЫ РАБОТЫ С ДОКУМЕНТАМИ

        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            return Manager.document_add(id, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     iid_entity, iid_entity_instance, iid_sub_entity_instance);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     user User)
        {
            return Manager.document_add(id, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     User);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     pos_temp Pos_temp)
        {
            return Manager.document_add(id, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Pos_temp);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     pos_temp_prop Pos_temp_prop)
        {
            return Manager.document_add(id, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Pos_temp_prop);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     position Position)
        {
            return Manager.document_add(id, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Position);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     position_prop Position_prop)
        {
            return Manager.document_add(id, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Position_prop);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     object_general Object_general)
        {
            return Manager.document_add(id, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Object_general);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     object_prop Object_prop)
        {
            return Manager.document_add(id, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Object_prop);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     group Group)
        {
            return Manager.document_add(id, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Group);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     vclass Class)
        {
            return Manager.document_add(id, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Class);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     class_prop Class_prop)
        {
            return Manager.document_add(id, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Class_prop);
        }
        //*********************************************************************************************
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанный документ и все его файлы
        /// </summary>
        public void document_del(Int64 iid_document)
        {
            Manager.document_del(iid_document);
        }

        /// <summary>
        /// Метод удаляет указанный документ и все его файлы
        /// </summary>
        public void document_del(document Document)
        {
            Manager.document_del(Document.Id);
        }
        //*************************************************************************************
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист документов по идентификатору концепции
        /// document_ext_by_id_conception
        /// document_by_id_conception
        /// </summary>
        public List<document> document_list_get(Boolean Extended = false)
        {
            if (Extended)
            {
                return Manager.document_ext_by_id_category(Id);
            }
            else
            {
                return Manager.document_by_id_category(Id);
            }
        }
        //*************************************************************************************

        /// <summary>
        /// Лист документов концепции по маске имени документов
        /// document_ext_by_name
        /// document_by_name
        /// </summary>
        public List<document> document_by_name(String iname, Boolean Extended = false)
        {
            if (Extended)
            {
                return Manager.document_ext_by_msk_name_from_category(iname, Id);
            }
            else
            {
                return Manager.document_by_msk_name_from_category(iname, Id);
            }
        }
        //*************************************************************************************
        #endregion

        #region СЛУЖЕБНЫЕ МЕТОДЫ БИБЛИОТЕКИ ДОКУМЕНТОВ
        /// <summary>
        /// Лист расширений файлов документов по идентификатору концепции
        /// </summary>
        public List<String> doc_file_extension_list_get()
        {
            return Manager.doc_file_extension_by_id_conception(Id_conception);
        }
        #endregion
        #endregion
    }
}
