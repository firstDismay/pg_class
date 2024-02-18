using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class conception
    {

        #region МЕТОДЫ РАБОТЫ С ПЕРЕЧИСЛЕНИЯМИ

        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новое перечисление для свойств
        /// prop_enum_add
        /// </summary>
        public prop_enum Prop_enum_add(String iname, String idesc, prop_enum_use_area iprop_enum_use_area, eDataType DataType)
        {
            return Manager.prop_enum_add(id, iname, idesc, iprop_enum_use_area, (Int32)DataType);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Prop_enum_add(out eAccess Access)
        {
            return Manager.prop_enum_add(out Access);
        }
        

        /// <summary>
        /// Метод добавляет новое перечисление для свойств
        /// prop_enum_add
        /// </summary>
        public prop_enum prop_enum_add(String iname, String idesc, Int32 iid_prop_enum_use_area, Int32 iid_data_type)
        {
            return Manager.prop_enum_add(id, iname, idesc, iid_prop_enum_use_area, iid_data_type);
        }
        
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Удалить новое перечисление для свойств
        /// prop_enum_del
        /// </summary>
        public void Prop_enum_del(prop_enum Prop_enum)
        {
            Manager.prop_enum_del(Prop_enum.Id_prop_enum, id);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Prop_enum_del(out eAccess Access)
        {
            return Manager.prop_enum_del(out Access);
        }
        
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Метод возвращает лист перечислений концепции
        /// prop_enum_by_id_conception
        /// </summary>
        public List<prop_enum> Prop_enum_list_get()
        {
            return Manager.prop_enum_by_id_conception(this);
        }

        

        /// <summary>
        /// Метод возвращает лист перечислений концепции
        /// prop_enum_by_id_conception_data_type
        /// </summary>
        public List<prop_enum> Prop_enum_list_get(con_prop_data_type ConPropDataType)
        {
            return Manager.prop_enum_by_id_conception_data_type(this, ConPropDataType);
        }
        

        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом области применения
        ///  prop_enum_by_id_conception_use_area
        /// </summary>
        public List<prop_enum> Prop_enum_list_use_area_get(prop_enum_use_area Prop_enum_use_area)
        {
            return Manager.prop_enum_by_id_conception_use_area(this, Prop_enum_use_area);
        }
        

        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом области применения
        ///  prop_enum_by_id_conception_use_area
        /// </summary>
        public List<prop_enum> Prop_enum_list_use_area_get(eProp_enum_use_area Prop_enum_use_area)
        {
            return Manager.prop_enum_by_id_conception_use_area(id, (Int32)Prop_enum_use_area);
        }
        

        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом области применения и типа данных перечисления
        ///  prop_enum_by_id_conception_use_area_data_type
        /// </summary>
        public List<prop_enum> Prop_enum_list_use_area_data_type_get(prop_enum_use_area Prop_enum_use_area, con_prop_data_type Data_type)
        {
            return Manager.prop_enum_by_id_conception_use_area_data_type(id, Prop_enum_use_area.Id, Data_type.Id);
        }
        

        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом области применения и типа данных перечисления
        ///  prop_enum_by_id_conception_use_area_data_type
        /// </summary>
        public List<prop_enum> Prop_enum_list_get(eProp_enum_use_area Prop_enum_use_area, eDataType DataType)
        {
            return Manager.prop_enum_by_id_conception_use_area_data_type(id, (Int32)Prop_enum_use_area, (Int32)DataType);
        }
        


        /// <summary>
        ///  Выбрать все перечисления для свойств объектов по идентификатору концепции с учетом типа данных перечисления
        ///  prop_enum_for_object_by_id_conception_data_type
        /// </summary>
        public List<prop_enum> Prop_enum_for_object_list_get(con_prop_data_type Data_type)
        {
            return Manager.prop_enum_for_object_by_id_conception_data_type(id, Data_type.Id);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Prop_enum_for_object_list_get(out eAccess Access)
        {
            return Manager.prop_enum_for_object_by_id_conception_data_type(out Access);
        }
        

        /// <summary>
        ///  Выбрать все перечисления для свойств объектов по идентификатору концепции с учетом типа данных перечисления
        ///  prop_enum_for_object_by_id_conception_data_type
        /// </summary>
        public List<prop_enum> Prop_enum_for_object_list_get(eProp_enum_use_area Prop_enum_use_area, eDataType DataType)
        {
            return Manager.prop_enum_for_object_by_id_conception_data_type(id, (Int32)DataType);
        }
        

        /// <summary>
        ///  Выбрать все перечисления для свойств позиций по идентификатору концепции с учетом типа данных перечисления
        ///  prop_enum_for_position_by_id_conception_data_type
        /// </summary>
        public List<prop_enum> Prop_enum_for_position_list_get(con_prop_data_type Data_type)
        {
            return Manager.prop_enum_for_position_by_id_conception_data_type(id, Data_type.Id);
        }


        /// <summary>
        ///  Выбрать все перечисления для свойств позиций по идентификатору концепции с учетом типа данных перечисления
        ///  prop_enum_for_position_by_id_conception_data_type
        /// </summary>
        public List<prop_enum> Prop_enum_for_position_list_get(eProp_enum_use_area Prop_enum_use_area, eDataType DataType)
        {
            return Manager.prop_enum_for_position_by_id_conception_data_type(id, (Int32)DataType);
        }
        #endregion

        #region МЕТОДЫ КЛАССА ДЛЯ ДОСТУПА К ДАННЫМ ОБЛАСТЕЙ ПРИМЕНЕНИЯ ПЕРЕЧИСЛЕНИЯ
        /// <summary>
        /// Метод возвращает лист классов областей применения перечисления
        /// prop_enum_use_area_by_all
        /// </summary>
        public List<prop_enum_use_area> Prop_enum_use_area_list_get()
        {
            return Manager.prop_enum_use_area_by_all();
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Prop_enum_use_area_list_get(out eAccess Access)
        {
            return Manager.prop_enum_use_area_by_all(out Access);
        }
        
        #endregion
        #endregion
    }
}
