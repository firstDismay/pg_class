using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class conception
    {
        #region МЕТОДЫ РАБОТЫ С ГЛОБАЛЬНЫМИ СВОЙСТВАМИ КОНЦЕПЦИИ
        #region ДОБАВИТЬ
        /// <summary>
        /// Метод добавляет новое глобальное свойство
        /// global_prop_add
        /// </summary>
        public global_prop Global_prop_add(prop_type Prop_type, con_prop_data_type Data_type, String iname, String idesc, Boolean ivisible)
        {
            return Manager.global_prop_add(this, Prop_type, Data_type, iname, idesc, ivisible);
        }
        //*************************************************************************************
        
        /// <summary>
        /// Метод добавляет новое глобальное свойство по образцу существующего свойства
        /// global_prop_add_as_class_prop
        /// </summary>
        public global_prop Global_prop_add(class_prop ClasProp)
        {
            return Manager.global_prop_add_as_class_prop(this, ClasProp);
        }
        //*************************************************************************************

        /// <summary>
        /// Метод добавляет новое глобальное свойство по образцу существующего свойства
        /// global_prop_add_as_pos_temp_prop
        /// </summary>
        public global_prop Global_prop_add(pos_temp_prop PosTempProp)
        {
            return Manager.global_prop_add_as_pos_temp_prop(this, PosTempProp);
        }
        //*************************************************************************************
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет глобальное свойство
        /// global_prop_del
        /// </summary>
        public void global_prop_del(global_prop Global_Prop)
        {
            if (Global_Prop != null)
            {
                Manager.global_prop_del(Global_Prop.Id);
            }

        }
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Метод возвращает лист глобальных свойств концепции
        /// group_by_id_parent
        /// </summary>
        public List<global_prop> Global_prop_list_get()
        {
            return Manager.global_prop_by_id_conception(this);
        }

        /// <summary>
        /// Метод возвращает лист глобальных свойств концепции с учетом видимости
        /// global_prop_visible_by_id_conception
        /// </summary>
        public List<global_prop> Global_prop_visible_list_get()
        {
            return Manager.global_prop_visible_by_id_conception(this);
        }

        /// <summary>
        /// Метод возвращает лист глобальных свойств концепции с учетом видимости и допустимых для поиска по значению
        /// global_prop_for_search_by_id_conception
        /// </summary>
        public List<global_prop> Global_prop_for_search_list_get()
        {
            return Manager.global_prop_for_search_by_id_conception(this);
        }

        /// <summary>
        /// Лист глобальных свойств концепции по строкгому соотвествию имени
        /// group_by_id_parent
        /// </summary>
        public global_prop Global_prop_by_name(String iname)
        {
            return Manager.global_prop_by_name(this, iname);
        }

        //*************************************************************************************
        #endregion

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
    }
}
