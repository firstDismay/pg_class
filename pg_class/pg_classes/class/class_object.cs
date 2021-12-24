using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class vclass
    {
        #region ПРИВЕСТИ ОБЪЕКТЫ КЛАССА 
        /// <summary>
        /// Метод приводит все объекты класса к состоянию данного класса
        /// object_cast_for_class
        /// </summary>
        public List<errarg_cast> Object_cast_to_me()
        {
            return Manager.object_cast_for_class(this);
        }

        /// <summary>
        /// приводит все объекты к активным состояниям классов рекурсивно начиная с указанного
        /// object_cast_for_class_act
        /// </summary>
        public List<errarg_cast> Object_cast_to_active_state()
        {
            return Manager.object_cast_for_class_act(this);
        }
        #endregion

        #region ДОБАВИТЬ ОБЪЕКТЫ ВЕЩЕСТВЕННЫХ КЛАССОВ
        /// <summary>
        ///  Метод выполняет создание объектов всех вещественных классов указанного класса
        ///  object_add_for_class_act
        /// </summary>
        public List<errarg_object_add> Object_add_for_class_act(position Position_target)
        {
            return Manager.object_add_for_class_act(this, Position_target);
        }
        #endregion

        #region ВЫБРАТЬ ОБЪЕКТЫ КЛАССА
        /// <summary>
        /// Лист объектов класса с учетом штампа времени
        /// </summary>
        public List<object_general> Object_list_get(Boolean Extended = false)
        {
            List<object_general> list = new List<object_general>();
            switch (StorageType)
            {
                case eStorageType.Active:
                    if (Extended)
                    {
                        list = Manager.object_ext_by_id_class_act(this);
                    }
                    else
                    {
                        list = Manager.object_by_id_class_act(this);
                    }
                    break;
                case eStorageType.History:
                    if (Extended)
                    {
                        list = Manager.object_ext_by_id_class_snapshot(this);
                    }
                    else
                    {
                        list = Manager.object_by_id_class_snapshot(this);
                    }
                    break;
            }
            return list;
        }

        /// <summary>
        /// Лист объектов класса с учетом штампа времени и содержащей позиции
        /// </summary>
        public List<object_general> Object_list_get(position Position_parent, Boolean Extended = false)
        {
            List<object_general> list = new List<object_general>();
            if (Extended)
            {
                list = Manager.object_ext_by_id_class_snapshot_id_pos(this, Position_parent);
            }
            else
            {
                list = Manager.object_by_id_class_snapshot_id_pos(this, Position_parent);
            }
            return list;
        }

        /// <summary>
        /// Лист объектов класса с учетом штампа времени и содержащей позиции
        /// </summary>
        public List<object_general> Object_list_get(Int64 Id_position_parent, Boolean Extended = false)
        {
            List<object_general> list = new List<object_general>();
            if (Extended)
            {
                list = Manager.object_ext_by_id_class_snapshot_id_pos(this, Id_position_parent);
            }
            else
            {
                list = Manager.object_by_id_class_snapshot_id_pos(this, Id_position_parent);
            }
            return list;
        }


        /// <summary>
        /// Лист всех объектов класса без учета штампа времени
        /// </summary>
        public List<object_general> Object_list_full_get(Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_id_class_full(this);
            }
            else
            {
                Result = Manager.object_by_id_class_full(this);
            }
            return Result;
            
        }
        #endregion
    }
}
