using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class conception
    {
        #region МЕТОДЫ РАБОТЫ С ПРОТОТИПАМИ ПОЗИЦИЙ
        /// <summary>
        /// Метод обновляет лист доступных к вложению в концепцию прототипов позиций 
        /// pos_prototype_nested_by_id_prototype
        /// </summary>
        public List<pos_prototype> Pos_prototype_nested_list_get()
        {
            return Manager.pos_prototype_nested_by_id_prototype(0);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Pos_prototype_nested_list_get(out eAccess Access)
        {
            return Manager.pos_prototype_nested_by_id_prototype(out Access);
        }
        


        /// <summary>
        /// Метод обновляет лист всех прототипов позиций 
        /// pos_prototype_by_all
        /// </summary>
        public List<pos_prototype> Pos_prototype_all_list_get()
        {
            return Manager.pos_prototype_by_all();
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Pos_prototype_all_list_get(out eAccess Access)
        {
            return Manager.pos_prototype_by_all(out Access);
        }
        

        #endregion
    }
}
