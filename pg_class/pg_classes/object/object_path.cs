using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class object_general
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПУТЯМИ ПРЕДСТАВЛЕНИЙ КЛАССОВ

        /// <summary>
        /// Свойство возвращает лист фрагментов пути представлений объектов отсортированных от корневого несущего объкта
        /// </summary>
        public List<pos_path> Path_position_get()
        {
            return Manager.position_path_by_id_position(this.Id_position);
        }

        /// <summary>
        /// Свойство возвращает лист фрагментов пути представлений объектов отсортированных от корневого несущего объкта
        /// </summary>
        public List<object_path> Path_object_get()
        {
            return Manager.object_path_by_id_object(this);
        }

        /// <summary>
        /// Строкое представление полного пути объекта в структуре концепции (в том числе позиция в агрегате)
        /// </summary>
        public String Path_object_full_get()
        {
            return Manager.object_spathfull(this.Id);
        }

        /// <summary>
        /// Строкое представление пути объекта в дереве позиций
        /// </summary>
        public String Path
        {
            get
            {
                return path;
            }
        }
        #endregion
    }
}
