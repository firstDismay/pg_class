using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class vclass
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С НАСЛЕДУЮЩИМИ ПРЕДСТАВЛЕНИЯМИ КЛАССОВ

        /// <summary>
        /// Лист наследующих представлений классов содержащих объекты (наследуемых объектами по цепочке)
        /// </summary>
        public List<vclass> Сlass_snapshot_on_object_by_parent_pos_list_get(position Position_parent, Boolean Extended = false)
        {
            List<vclass> Result = null;
            if (Extended)
            {
                Result = Manager.class_snapshot_ext_on_object_by_id_parent_snapshot_parent_pos(this, Position_parent);
            }
            else
            {
                Result = Manager.class_snapshot_on_object_by_id_parent_snapshot_parent_pos(this, Position_parent);
            }
            return Result;
        }

        /// <summary>
        /// Лист наследующих представлений классов содержащих объекты (наследуемых объектами по цепочке)
        /// </summary>
        public List<vclass> Сlass_snapshot_on_object_by_parent_pos_list_get(Int64 Id_position_parent, Boolean Extended = false)
        {
            List<vclass> Result = null;
            if (Extended)
            {
                Result = Manager.class_snapshot_ext_on_object_by_id_parent_snapshot_parent_pos(Id, timestamp, Id_position_parent);
            }
            else
            {
                Result = Manager.class_snapshot_on_object_by_id_parent_snapshot_parent_pos(Id, timestamp, Id_position_parent);
            }

            return Result;
        }

        /// <summary>
        /// Лист наследующих представлений классов содержащих объекты (наследуемых объектами по цепочке)
        /// </summary>
        public List<vclass> Сlass_snapshot_on_object_by_parent_pos_list_get(Boolean Extended = false)
        {
            List<vclass> Result = null;
            if (Extended)
            {
                Result = Manager.class_snapshot_ext_on_object_by_id_parent_snapshot_parent_pos(Id, timestamp, id_position_parent_object);
            }
            else
            {
                Result = Manager.class_snapshot_on_object_by_id_parent_snapshot_parent_pos(Id, timestamp, id_position_parent_object);
            }

            return Result;
        }
        #endregion
    }
}
