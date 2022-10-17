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
    /// Класс документов 
    /// </summary>
    public partial class document
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ СО ССЫЛКАМИ ДОКУМЕНТА
        #region ДОБАВИТЬ
        /// <summary>
        /// Метод добавляет новый файл документа
        /// </summary>
        public doc_link doc_link_add(user User)
        {
            return Manager.doc_link_add(Id, User.EntityID, User.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новый файл документа
        /// </summary>
        public doc_link doc_link_add(pos_temp Pos_temp)
        {
            return Manager.doc_link_add(Id, Pos_temp.EntityID, Pos_temp.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новый файл документа
        /// </summary>
        public doc_link doc_link_add(pos_temp_prop Pos_temp_prop)
        {
            return Manager.doc_link_add(Id, Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новый файл документа
        /// </summary>
        public doc_link doc_link_add(position Position)
        {
            return Manager.doc_link_add(Id, Position.EntityID, Position.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новый файл документа
        /// </summary>
        public doc_link doc_link_add(position_prop Position_prop)
        {
            return Manager.doc_link_add(Id, Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        /// <summary>
        /// Метод добавляет новый файл документа
        /// </summary>
        public doc_link doc_link_add(object_general Object_general)
        {
            return Manager.doc_link_add(Id, Object_general.EntityID, Object_general.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новый файл документа
        /// </summary>
        public doc_link doc_link_add(object_prop Object_prop)
        {
            return Manager.doc_link_add(Id, Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        /// <summary>
        /// Метод добавляет новый файл документа
        /// </summary>
        public doc_link doc_link_add(group Group)
        {
            return Manager.doc_link_add(Id, Group.EntityID, Group.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новый файл документа
        /// </summary>
        public doc_link doc_link_add(vclass Class)
        {
            return Manager.doc_link_add(Id, Class.EntityID, Class.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новый файл документа
        /// </summary>
        public doc_link doc_link_add(class_prop Class_prop)
        {
            return Manager.doc_link_add(Id, Class_prop.EntityID, Class_prop.Id, -1);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указаную ссылку документа
        /// </summary>
        public void doc_link_del(Int64 iid_doc_link)
        {
            Manager.doc_link_del(iid_doc_link);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа
        /// </summary>
        public void doc_link_del(doc_link Doc_link)
        {
            Manager.doc_link_del(Doc_link.Id);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del(user User)
        {
            Manager.doc_link_del_by_entity(this.Id, User.EntityID, User.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del(pos_temp Pos_temp)
        {
            Manager.doc_link_del_by_entity(this.Id, Pos_temp.EntityID, Pos_temp.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del(pos_temp_prop Pos_temp_prop)
        {
            Manager.doc_link_del_by_entity(this.Id, Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del(position Position)
        {
            Manager.doc_link_del_by_entity(this.Id, Position.EntityID, Position.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del(position_prop Position_prop)
        {
            Manager.doc_link_del_by_entity(this.Id, Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del(object_general Object_general)
        {
            Manager.doc_link_del_by_entity(this.Id, Object_general.EntityID, Object_general.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del(object_prop Object_prop)
        {
            Manager.doc_link_del_by_entity(this.Id, Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del(group Group)
        {
            Manager.doc_link_del_by_entity(this.Id, Group.EntityID, Group.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del(vclass Class)
        {
            Manager.doc_link_del_by_entity(this.Id, Class.EntityID, Class.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del(class_prop Class_prop)
        {
            Manager.doc_link_del_by_entity(this.Id, Class_prop.EntityID, Class_prop.Id, -1);
        }
        #endregion

        #region ВЫБРАТЬ
        List<doc_link> doc_link_list;
        /// <summary>
        /// Лист ссылок документа по идентификатору документа
        /// </summary>
        public List<doc_link> doc_link_list_get(Boolean DirectRequest = true)
        {
            if (DirectRequest || doc_link_list == null)
            {
                doc_link_list = Manager.doc_link_by_id_document(Id);
            }
            return doc_link_list;
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity( user User)
        {
            return Manager.doc_link_by_entity(this.Id, User.EntityID, User.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(pos_temp Pos_temp)
        {
            return Manager.doc_link_by_entity(this.Id, Pos_temp.EntityID, Pos_temp.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(pos_temp_prop Pos_temp_prop)
        {
            return Manager.doc_link_by_entity(this.Id, Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity( position Position)
        {
            return Manager.doc_link_by_entity(this.Id, Position.EntityID, Position.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity( position_prop Position_prop)
        {
            return Manager.doc_link_by_entity(this.Id, Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity( object_general Object_general)
        {
            return Manager.doc_link_by_entity(this.Id, Object_general.EntityID, Object_general.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity( object_prop Object_prop)
        {
            return Manager.doc_link_by_entity(this.Id, Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(group Group)
        {
            return Manager.doc_link_by_entity(this.Id, Group.EntityID, Group.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(vclass Class)
        {
            return Manager.doc_link_by_entity(this.Id, Class.EntityID, Class.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(class_prop Class_prop)
        {
            return Manager.doc_link_by_entity(this.Id, Class_prop.EntityID, Class_prop.Id, -1);
        }
        #endregion
        #endregion
    }
}
