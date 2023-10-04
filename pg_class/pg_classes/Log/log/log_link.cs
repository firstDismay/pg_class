using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс записей журнала 
    /// </summary>
    public partial class log
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ СО ССЫЛКАМИ
        #region ДОБАВИТЬ
        /// <summary>
        /// Метод добавляет новую ссылку 
        /// </summary>
        public log_link log_link_add(user User)
        {
            return Manager.log_link_add(Id, User.EntityID, User.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новую ссылку
        /// </summary>
        public log_link log_link_add(pos_temp Pos_temp)
        {
            return Manager.log_link_add(Id, Pos_temp.EntityID, Pos_temp.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новую ссылку
        /// </summary>
        public log_link log_link_add(pos_temp_prop Pos_temp_prop)
        {
            return Manager.log_link_add(Id, Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новую ссылку
        /// </summary>
        public log_link log_link_add(position Position)
        {
            return Manager.log_link_add(Id, Position.EntityID, Position.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новую ссылку
        /// </summary>
        public log_link log_link_add(position_prop Position_prop)
        {
            return Manager.log_link_add(Id, Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        /// <summary>
        /// Метод добавляет новую ссылку
        /// </summary>
        public log_link log_link_add(object_general Object_general)
        {
            return Manager.log_link_add(Id, Object_general.EntityID, Object_general.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новую ссылку
        /// </summary>
        public log_link log_link_add(object_prop Object_prop)
        {
            return Manager.log_link_add(Id, Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        /// <summary>
        /// Метод добавляет новую ссылку
        /// </summary>
        public log_link log_link_add(group Group)
        {
            return Manager.log_link_add(Id, Group.EntityID, Group.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новую ссылку
        /// </summary>
        public log_link log_link_add(vclass Class)
        {
            return Manager.log_link_add(Id, Class.EntityID, Class.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новую ссылку
        /// </summary>
        public log_link log_link_add(class_prop Class_prop)
        {
            return Manager.log_link_add(Id, Class_prop.EntityID, Class_prop.Id, -1);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанную ссылку
        /// </summary>
        public void log_link_del(Int64 iid_log_link)
        {
            Manager.log_link_del(iid_log_link);
        }

        /// <summary>
        /// Метод удаляет указанную ссылку
        /// </summary>
        public void log_link_del(log_link log_link)
        {
            Manager.log_link_del(log_link.Id);
        }

        /// <summary>
        /// Метод удаляет указанную ссылку
        /// </summary>
        public void log_link_del(user User)
        {
            Manager.log_link_del_by_entity(this.Id, User.EntityID, User.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указанную ссылку
        /// </summary>
        public void log_link_del(pos_temp Pos_temp)
        {
            Manager.log_link_del_by_entity(this.Id, Pos_temp.EntityID, Pos_temp.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указанную ссылку
        /// </summary>
        public void log_link_del(pos_temp_prop Pos_temp_prop)
        {
            Manager.log_link_del_by_entity(this.Id, Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указанную ссылку
        /// </summary>
        public void log_link_del(position Position)
        {
            Manager.log_link_del_by_entity(this.Id, Position.EntityID, Position.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указанную ссылку
        /// </summary>
        public void log_link_del(position_prop Position_prop)
        {
            Manager.log_link_del_by_entity(this.Id, Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        /// <summary>
        /// Метод удаляет указанную ссылку
        /// </summary>
        public void log_link_del(object_general Object_general)
        {
            Manager.log_link_del_by_entity(this.Id, Object_general.EntityID, Object_general.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указанную ссылку
        /// </summary>
        public void log_link_del(object_prop Object_prop)
        {
            Manager.log_link_del_by_entity(this.Id, Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        /// <summary>
        /// Метод удаляет указанную ссылку
        /// </summary>
        public void log_link_del(group Group)
        {
            Manager.log_link_del_by_entity(this.Id, Group.EntityID, Group.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указанную ссылку
        /// </summary>
        public void log_link_del(vclass Class)
        {
            Manager.log_link_del_by_entity(this.Id, Class.EntityID, Class.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указанную ссылку
        /// </summary>
        public void log_link_del(class_prop Class_prop)
        {
            Manager.log_link_del_by_entity(this.Id, Class_prop.EntityID, Class_prop.Id, -1);
        }
        #endregion

        #region ВЫБРАТЬ
        private List<log_link> log_link_list;
        /// <summary>
        /// Лист ссылок записи журнала
        /// </summary>
        public List<log_link> log_link_get(Boolean DirectRequest = true)
        {
            if (DirectRequest || log_link_list == null)
            {
                log_link_list = Manager.log_link_by_id_log(Id);
            }
            return log_link_list;
        }
        #endregion
        #endregion
    }
}