using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс обобщенного представления объектов
    /// </summary>
    public partial class object_general
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ СО СВОЙСТВАМИ ОБЪЕКТА НОСИТЕЛЯ

        List<object_prop> property_list;
        /// <summary>
        /// Лист свойств объекта
        /// </summary>
        public List<object_prop> Property_list_get(Boolean DirectRequest = true)
        {
            if (DirectRequest || property_list == null)
            {
                property_list = Manager.object_prop_by_id_object(this);
            }
            return property_list;
        }

        /// <summary>
        /// Лист свойств объекта с указанным тэгом
        /// </summary>
        public List<object_prop> Property_list_by_tag_get(String itag = "")
        {
            return Property_list_get(false).FindAll(x => x.Tag == itag);
        }

        /// <summary>
        /// Лист свойств объекта без указанного тэга
        /// </summary>
        public List<object_prop> Property_list_by_not_tag_get(String itag = "")
        {
            return Property_list_get(false).FindAll(x => x.Tag == itag);
        }

        /// <summary>
        /// Лист свойств объекта указанного типа
        /// </summary>
        public List<object_prop> Property_list_get(ePropType PropType)
        {
            return Property_list_get(false).FindAll(x => x.Prop_type == PropType);
        }

        /// <summary>
        /// Метод возвращает свойство объекта сопоставленное указанному глобальному свойству, с учетом способа получения объекта (прямой запрос или расширенный объект) 
        /// object_prop_by_id_object
        /// </summary>
        public object_prop Property_by_global_prop(global_prop Global_prop)
        {
            object_prop Result = null;

            List<object_prop> Property_list = Property_list_get(false);
            Result = Property_list.Find(x => x.Id_global_prop == Global_prop.Id);
            return Result;
        }

        /// <summary>
        /// Метод возвращает свойство объекта сопоставленное указанному глобальному свойству, с учетом способа получения объекта (прямой запрос или расширенный объект) 
        /// object_prop_by_id_object
        /// </summary>
        public object_prop Property_by_global_prop(Int64 Id_global_prop)
        {
            object_prop Result = null;

            List<object_prop> Property_list = Property_list_get(false);
            Result = Property_list.Find(x => x.Id_global_prop == Id_global_prop);
            return Result;
        }

        /// <summary>
        /// Метод возвращает свойство объекта сопоставленное указанному определяющему свойству, с учетом способа получения объекта (прямой запрос или расширенный объект) 
        /// object_prop_by_id_object
        /// </summary>
        public object_prop Property_by_definition_prop(class_prop PropertyDefinition)
        {
            object_prop Result = null;

            List<object_prop> Property_list = Property_list_get(false);
            Result = Property_list.Find(x => x.Id_prop_definition == PropertyDefinition.Id);
            return Result;
        }

        /// <summary>
        /// Метод возвращает свойство объекта сопоставленное указанному определяющему свойству, с учетом способа получения объекта (прямой запрос или расширенный объект) 
        /// object_prop_by_id_object
        /// </summary>
        public object_prop Property_by_definition_prop(object_prop PropertyDefinition)
        {
            object_prop Result = null;

            List<object_prop> Property_list = Property_list_get(false);
            Result = Property_list.Find(x => x.Id_prop_definition == PropertyDefinition.Id_class_prop);
            return Result;
        }

        /// <summary>
        /// Метод возвращает свойство объекта сопоставленное указанному определяющему свойству, с учетом способа получения объекта (прямой запрос или расширенный объект) 
        /// object_prop_by_id_object
        /// </summary>
        public object_prop Property_by_definition_prop(Int64 IdPropertyDefinition)
        {
            object_prop Result = null;

            List<object_prop> Property_list = Property_list_get(false);
            Result = Property_list.Find(x => x.Id_prop_definition == IdPropertyDefinition);
            return Result;
        }
        #endregion
    }
}
