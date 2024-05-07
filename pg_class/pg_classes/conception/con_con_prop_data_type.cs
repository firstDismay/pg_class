using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class conception
    {
        #region МЕТОДЫ РАБОТЫ С ПРАВИЛАМИ ПЕРЕСЧЕТА КОНЦЕПЦИИ
        #region ДОБАВИТЬ
        /// <summary>
        /// Метод добавляет тип данных в список типов данных концепции
        /// Con_prop_data_type_set
        /// </summary>
        public void con_prop_data_type_set(con_prop_data_type Con_prop_data_type)
        {
            Manager.con_prop_data_type_set(Con_prop_data_type);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean con_prop_data_type_set(out eAccess Access)
        {
            return Manager.con_prop_data_type_set(out Access);
        }
        

        /// <summary>
        /// Метод добавляет тип данных в список типов данных концепции
        /// Con_prop_data_type_set
        /// </summary>
        public void con_prop_data_type_set(prop_data_type Con_prop_data_type, String Alias = "", Int32 Sort = 0)
        {
            Manager.con_prop_data_type_set(this, Con_prop_data_type, Alias, Sort);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет тип данных из списка типов данных концепции
        /// Con_prop_data_type_del
        /// </summary>
        public void Con_prop_data_type_del(con_prop_data_type Con_prop_data_type)
        {
            Manager.Con_prop_data_type_del(Con_prop_data_type);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Con_prop_data_type_del(out eAccess Access)
        {
            return Manager.Con_prop_data_type_del(out Access);
        }
        
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Метод возвращает полный список типов данных доступных для концепции
        /// Con_prop_data_type_full_by_id_con
        /// </summary>
        public List<con_prop_data_type> Con_prop_data_type_full_list()
        {
            return Manager.сon_prop_data_type_full_by_id_con(this);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Con_prop_data_type_full_list(out eAccess Access)
        {
            return Manager.сon_prop_data_type_full_by_id_con(out Access);
        }
        

        /// <summary>
        /// Метод возвращает назначение типа данных концепции по идентификатору
        /// сon_prop_data_type_by_id
        /// </summary>
        public con_prop_data_type сon_prop_data_type_by_id(Int32 Id_con_prop_data_type)
        {
            return Manager.сon_prop_data_type_by_id(Id, Id_con_prop_data_type);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean сon_prop_data_type_by_id(out eAccess Access)
        {
            return Manager.сon_prop_data_type_by_id(out Access);
        }
        

        /// <summary>
        /// Лист типов данных свойств класса по типу свойства
        /// сon_prop_data_type_by_id_prop_type
        /// </summary>
        public List<con_prop_data_type> Prop_data_type(prop_type Prop_type)
        {
            return Manager.сon_prop_data_type_by_id_prop_type(id, Prop_type);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Prop_data_type(out eAccess Access)
        {
            return Manager.сon_prop_data_type_by_id_prop_type(out Access);
        }
        

        /// <summary>
        /// Лист типов данных свойств класса по типу свойства
        /// сon_prop_data_type_by_id_prop_type
        /// </summary>
        public List<con_prop_data_type> Prop_data_type(Int32 id_prop_type)
        {
            return Manager.сon_prop_data_type_by_id_prop_type(id, id_prop_type);
        }
        


        /// <summary>
        /// Лист типов данных свойств класса по типу свойства
        /// сon_prop_data_type_by_id_prop_type
        /// </summary>
        public List<con_prop_data_type> Prop_data_type(ePropType PropType)
        {
            return Manager.сon_prop_data_type_by_id_prop_type(id, (Int32)PropType);
        }
        //*****************************************************************************
        #endregion
        #endregion
    }
}
