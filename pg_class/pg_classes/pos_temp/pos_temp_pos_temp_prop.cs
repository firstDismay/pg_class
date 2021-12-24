using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class pos_temp
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ СО СВОЙСТВАМИ

        /// <summary>
        /// Лист свойств шаблона
        /// </summary>
        public List<pos_temp_prop> Property_list_get()
        {
            return Manager.pos_temp_prop_by_id_pos_temp(this);
        }

        /// <summary>
        /// Метод определяет готовность класса к созданию объектов
        /// </summary>
        public Boolean Is_Ready()
        {
            return Manager.pos_temp_ready_check(this); ;
        }

        /// <summary>
        /// Метод проверяет готовность свойств клсса к созданию объектов
        /// </summary>
        public Boolean Property_is_Ready()
        {
            return Manager.pos_temp_prop_check(this);
        }

        #endregion

        #region МЕТОДЫ РАБОТЫ  СО СПИСКОМ СВОЙСТВ КЛАССА
        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новое свойство шаблона
        /// pos_temp_prop_add
        /// </summary>
        public pos_temp_prop pos_temp_prop_add( prop_type Prop_type, Boolean On_Override, prop_data_type Data_type, String iname, String idesc, Int32 isort)
        {
            return Manager.pos_temp_prop_add(this.Id, Prop_type.Id, On_Override, Data_type.Id, iname, idesc, isort);
        }
        #endregion

        #region ИЗМЕНИТЬ
        /// <summary>
        /// Метод изменяет текущую сортировку свойств шаблона на сортировку по имени
        /// pos_temp_prop_sort_by_name
        /// </summary>
        public void Sort_prop_by_name()
        {
            Manager.pos_temp_prop_sort_by_name(this);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет свойство шаблона
        /// pos_temp_prop_del
        /// </summary>
        public void class_prop_del_cascade(class_prop ClassProp)
        {
            Manager.pos_temp_prop_del(ClassProp.Id);
        }
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Метод возвращает свойство шаблона сопоставленное указанному глобальному свойству 
        /// </summary>
        public pos_temp_prop Property_by_global_prop(global_prop Global_prop)
        {
            return Manager.pos_temp_prop_by_id_global_prop(this, Global_prop); ;
        }
        #endregion
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
