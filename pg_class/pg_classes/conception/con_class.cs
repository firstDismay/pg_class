using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class conception
    {
        #region МЕТОДЫ РАБОТЫ С КЛАССАМИ И СНИМКАМИ КЛАССОВ КОНЦЕПЦИИ

        #region КОПИРОВНИАЕ И ПЕРЕНОС АКТИВНЫХ ПРЕДСТАВЛЕНИЙ КЛАССОВ

        /// <summary>
        /// Метод переносит активное представление класса в указанный абстрактный класс
        /// class_move_to_class
        /// </summary>
        public vclass class_move_to_class(vclass Class_pattern, vclass Class_target)
        {
            return Manager.class_move_to_class(Class_pattern.Id, Class_target.Id);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_move_to_class(out eAccess Access)
        {
            return Manager.class_move_to_class(out Access);
        }
        //*************************************************************************************

        /// <summary>
        /// Метод копирует активное представление класса в указанный абстрактный класс
        /// class_copy_to_class
        /// </summary>
        public vclass class_copy_to_class(vclass Class_pattern, vclass Class_target, Boolean on_nested)
        {
            return Manager.class_copy_to_class(Class_pattern.Id, Class_target.Id, on_nested);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_copy_to_class(out eAccess Access)
        {
            return Manager.class_copy_to_class(out Access);
        }
        //*************************************************************************************


        /// <summary>
        /// Метод переносит представление базового абстрактного класса в новую группу
        /// class_move_to_group
        /// </summary>
        public vclass class_move_to_group(vclass Class_pattern, group Group_target)
        {
            return Manager.class_move_to_group(Class_pattern, Group_target);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_move_to_group(out eAccess Access)
        {
            return Manager.class_move_to_group(out Access);
        }
        //*************************************************************************************


        /// <summary>
        /// Метод копирует активное представление базового класса в указанную группу
        /// class_copy_to_group
        /// </summary>
        public vclass class_copy_to_group(vclass Class_pattern, group Group_target, Boolean on_nested)
        {
            return Manager.class_copy_to_group(Class_pattern.Id, Group_target.Id, on_nested);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_copy_to_group(out eAccess Access)
        {
            return Manager.class_copy_to_group(out Access);
        }
        //*************************************************************************************

        #endregion

        #region ПОТЕРЯННЫЕ СУЩНОСТИ КОНЦЕПЦИИ
        /// <summary>
        /// Лист потерянных активных классов концепции
        /// class_act_lost_info
        /// </summary>
        public List<vclass> class_act_lost_info()
        {
            return Manager.class_act_lost_info(this);
        }
        //*************************************************************************************

        #endregion

        #region ОЧИСТИТЬ
        /// <summary>
        /// Метод удаляет снимки концепции не содержащие каскадно наследующие объекты и классы значения свойств
        /// class_snapshot_clear
        /// </summary>
        public Int64 Clear()
        {
            return Manager.class_snapshot_clear(this);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Clear(out eAccess Access)
        {
            return Manager.class_snapshot_clear(out Access);
        }
        //*************************************************************************************

        /// <summary>
        /// Лист неиспользуемых снимков классов концепции по идентификатору концепции
        /// class_snapshot_clear_info
        /// </summary>
        public List<vclass> class_snapshot_clear_info()
        {
            return Manager.class_snapshot_clear_info(this);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_clear_info(out eAccess Access)
        {
            return Manager.class_snapshot_clear_info(out Access);
        }
        //*************************************************************************************
        #endregion

        #region НАЙТИ КЛАСС
        /// <summary>
        /// Лист представлений активных классов концепции по маске имени
        /// class_act_by_id_conception_msk_name
        /// </summary>
        public List<vclass> Class_act_by_msk_name(String name_mask, Boolean Extended = false)
        {
            List<vclass> Result = null;
            if (Extended)
            {
                Result = Manager.class_act_ext_by_id_conception_msk_name(this.Id, name_mask);
            }
            else
            {
                Result = Manager.class_act_by_id_conception_msk_name(this.Id, name_mask);
            }
            return Result;
        }

        /// <summary>
        /// Лист представлений активных классов указанного расположения по маске имени
        /// class_act_by_id_parent_msk_name
        /// </summary>
        public List<vclass> Class_act_by_id_parent_msk_name(vclass Vclass_parent, String name_mask, Boolean Extended = false)
        {
            List<vclass> Result = null;
            if (Extended)
            {
                Result = Manager.class_act_ext_by_id_parent_msk_name(Vclass_parent, name_mask);
            }
            else
            {
                Result = Manager.class_act_by_id_parent_msk_name(Vclass_parent, name_mask);
            }
            return Result;
        }
        #endregion
        #endregion
    }
}
