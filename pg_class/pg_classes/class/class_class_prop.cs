using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class vclass
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ СО СПИСКОМ СВОЙСТВ
        List<class_prop> property_list;
        
        /// <summary>
        /// Лист свойств класса с пустым тэгом ''
        /// </summary>
        public List<class_prop> Property_list_get(Boolean DirectRequest = true)
        {
            switch (StorageType)
            {
                case eStorageType.Active:
                    if (DirectRequest || property_list == null)
                    {
                        property_list = Manager.class_prop_by_id_class(this);
                    }
                    break;
                case eStorageType.History:
                    if (DirectRequest || property_list == null)
                    {
                        property_list = Manager.class_prop_snapshot_by_id_class_snapshot(this);
                    }
                    break;
            }
            return property_list;
        }

        /// <summary>
        /// Лист свойств класса указанного типа
        /// </summary>
        public List<class_prop> Property_list_get(ePropType PropType)
        {
            return Property_list_get(false).FindAll(x => x.Prop_type == PropType);
        }

        /// <summary>
        /// Лист свойств класса с указанным тэгом
        /// </summary>
        public List<class_prop> Property_list_by_tag_get( String itag = "")
        {
            return Property_list_get(false).FindAll(x => x.Tag == itag);
        }

        /// <summary>
        /// Лист свойств класса с без указанного тэга
        /// </summary>
        public List<class_prop> Property_list_by_not_tag_get(String itag = "")
        {
            return Property_list_get(false).FindAll(x => x.Tag != itag);
        }

        /// <summary>
        /// Метод возвращает свойство класса сопоставленное указанному глобальному свойству, с учетом способа получения класса (прямой запрос или расширенный класс) 
        /// class_prop_by_id_class
        /// class_prop_snapshot_by_id_class_snapshot
        /// </summary>
        public class_prop Property_by_global_prop(global_prop Global_prop)
        {
            class_prop Result = null;

            List<class_prop> Property_list = Property_list_get(false);
            Result = Property_list.Find(x => x.Id_global_prop == Global_prop.Id);
            return Result;
        }

        /// <summary>
        /// Метод возвращает свойство класса сопоставленное указанному глобальному свойству, с учетом способа получения класса (прямой запрос или расширенный класс) 
        /// class_prop_by_id_class
        /// class_prop_snapshot_by_id_class_snapshot
        /// </summary>
        public class_prop Property_by_global_prop(Int64 Id_global_prop)
        {
            class_prop Result = null;

            List<class_prop> Property_list = Property_list_get(false);
            Result = Property_list.Find(x => x.Id_global_prop == Id_global_prop);
            return Result;
        }

        /// <summary>
        /// Метод возвращает свойство класса сопоставленное указанному определяющему свойству, с учетом способа получения объекта (прямой запрос или расширенный объект) 
        /// class_prop_by_id_class
        /// class_prop_snapshot_by_id_class_snapshot
        /// </summary>
        public class_prop Property_by_definition_prop(class_prop PropertyDefinition)
        {
            class_prop Result = null;

            List<class_prop> Property_list = Property_list_get(false);
            Result = Property_list.Find(x => x.Id_prop_definition == PropertyDefinition.Id);
            return Result;
        }

        /// <summary>
        /// Метод возвращает свойство класса сопоставленное указанному определяющему свойству, с учетом способа получения объекта (прямой запрос или расширенный объект) 
        /// class_prop_by_id_class
        /// class_prop_snapshot_by_id_class_snapshot
        /// </summary>
        public class_prop Property_by_definition_prop(Int64 IdPropertyDefinition)
        {
            class_prop Result = null;

            List<class_prop> Property_list = Property_list_get(false);
            Result = Property_list.Find(x => x.Id_prop_definition == IdPropertyDefinition);
            return Result;
        }

        /// <summary>
        /// Метод определяет готовность класса к созданию объектов
        /// </summary>
        public eClass_real_ready Is_Ready()
        {
            eClass_real_ready Result = eClass_real_ready.NotAllowed;

            if (!on_abstraction)
            {
                switch (StorageType)
                {
                    case eStorageType.Active:
                        if (ready)
                        {
                            Result = eClass_real_ready.Ready;
                        }
                        else
                        {
                            Result = eClass_real_ready.NoReady;
                        }
                        break;
                    case eStorageType.History:
                        Result = eClass_real_ready.Ready;
                        break;
                }
            }
            else
            {
                Result = eClass_real_ready.NotAllowed;
            }
            return Result;
        }

        /// <summary>
        /// Метод проверяет состояние текущего формата класса
        /// </summary>
        public Boolean Name_format_check()
        {
            return Manager.class_name_format_check(this);
        }

        /// <summary>
        /// Метод проверяет готовность свойств клсса к созданию объектов
        /// </summary>
        public Boolean Property_is_Ready()
        {
            return Manager.class_act_prop_check(this);
        }
        #endregion

        #region МЕТОДЫ РАБОТЫ  СО СПИСКОМ СВОЙСТВ КЛАССА
        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новое свойство класса
        /// </summary>
        public class_prop class_prop_add( prop_type Prop_type, Boolean On_Override, prop_data_type Data_type, String iname, String idesc, String itag, Int32 isort)
        {
            return Manager.class_prop_add(this.Id, Prop_type.Id, On_Override, Data_type.Id, iname, idesc, itag, isort);
        }
        #endregion

        #region ИЗМЕНИТЬ
        /// <summary>
        /// Метод изменяет текущую сортировку свойств активного класса на сортировку по имени
        /// class_prop_sort_by_name
        /// </summary>
        public void Sort_prop_by_name()
        {
            Manager.class_prop_sort_by_name(this);
        }
        #endregion

        #region УДАЛИТЬ

        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Cвойства класса по глобальному свойству
        /// </summary>
        public class_prop Property_by_global_prop(global_prop Global_prop, Boolean DirectRequest = true)
        {
            class_prop class_prop = null;
            if (DirectRequest)
            {
                switch (StorageType)
                {
                    case eStorageType.Active:
                        class_prop = Manager.class_prop_by_id_global_prop(this, Global_prop);
                        break;
                    case eStorageType.History:
                        class_prop = Manager.class_prop_snapshot_by_id_global_prop(this, Global_prop);
                        break;
                }
            }
            else
            {
                List<class_prop> Property_list = Property_list_get(false);
                class_prop = Property_list.Find(x => x.Id_global_prop == Global_prop.Id);
            }
            return class_prop;
        }
        #endregion
        #endregion

        #region МЕТОДЫ ДЛЯ ПОЛУЧЕНИЯ СПИСКОВ СВОЙСТВ С УЧЕТОМ МЕТОДОВ СЛОЖНОГО ПОИСКА

        /// <summary>
        /// Лист свойств класса по идентификатору класса-носителя с учетом метода сложного поиска
        /// </summary>
        public List<class_prop> Property_list_by_search_method(eSearchMethods isearch_method)
        {
            List<class_prop> property_list = new List<class_prop>();

            switch (StorageType)
            {
                case eStorageType.Active:
                        property_list = Manager.class_prop_by_id_class_search_method(this, isearch_method);
                    break;
                case eStorageType.History:
                        property_list = Manager.class_prop_snapshot_by_id_class_snapshot_search_method(this, isearch_method);
                    break;
            }
            return property_list;
        }
        #endregion

        #region СВОЙСТВА ДЛЯ РАБОТЫ ТИПАМИ СВОЙСТВ
        /// <summary>
        /// Лист доступных типов свойств класса
        /// </summary>
        public List<prop_type> Prop_type_list
        {
            get
            {
                return Manager.prop_type_by_all();
            }
        }
        #endregion

        #region СВОЙСТВА МЕТОДЫ ДЛЯ РАБОТЫ ТИПАМИ ДАННЫХ СВОЙСТВ
        /// <summary>
        /// Лист всех типов данных свойств класса
        /// </summary>
        public List<prop_data_type> Prop_data_type_by_all
        {
            get
            {
                return Manager.prop_data_type_by_all();
            }
        }

        /// <summary>
        /// Лист типов данных свойств класса по типу свойства
        /// </summary>
        public List<con_prop_data_type> Prop_data_type_by_prop_type(prop_type Prop_type)
        {
            return Manager.Con_prop_data_type_by_id_prop_type(Id_conception, Prop_type);
        }
        #endregion
    }
}
