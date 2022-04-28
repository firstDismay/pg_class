using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_exceptions;

namespace pg_class.pg_classes
{
    public partial class vclass
    {
        #region МЕТОДЫ РАБОТЫ  С НАСЛЕДУЮЩИМИ ПРЕДСТАВЛЕНИЯМИ КЛАССОВ
        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новое представление класса
        /// </summary>
        public vclass class_add(String iname, String idesc, Boolean ion,
            Boolean ion_extensible, Boolean ion_abstraction, Int32 iid_unit, Int32 iid_unit_conversion_rule, Int64 ibarcode_manufacturer)
        {
            return Manager.class_add(this.Id_group, this.Id, iname, idesc, ion,
            ion_extensible, ion_abstraction, iid_unit, iid_unit_conversion_rule, ibarcode_manufacturer);
        }

        /// <summary>
        /// Метод добавляет новое представление класса, с сохранением текущей измеряемой величины
        /// </summary>
        public vclass class_add(String iname, String idesc, Boolean ion,
            Boolean ion_extensible, Boolean ion_abstraction, Int32 iid_unit_conversion_rule, Int64 ibarcode_manufacturer)
        {
            return Manager.class_add(this.Id_group, this.Id, iname, idesc, ion,
            ion_extensible, ion_abstraction, id_unit, iid_unit_conversion_rule, ibarcode_manufacturer);
        }
        #endregion

        #region УДАЛИТЬ

        #endregion

        #region ВЫБРАТЬ

        /// <summary>
        /// Лист наследующих представлений классов
        /// </summary>
        public List<vclass> Class_child_list_get(Boolean Extended = false)
        {
            List<vclass> Result = null;
            switch (StorageType)
            {
                case eStorageType.Active:
                    if (Extended)
                    {
                        Result = Manager.class_act_ext_by_id_parent(this);
                    }
                    else
                    {
                        Result = Manager.class_act_by_id_parent(this);
                    }
                    break;
                case eStorageType.History:

                    if (Extended)
                    {
                        Result = Manager.class_snapshot_ext_by_id_parent_snapshot(this);
                    }
                    else
                    {
                        Result = Manager.class_snapshot_by_id_parent_snapshot(this);
                    }
                    break;
            }
            return Result;
        }


        /// <summary>
        /// Лист вещественных классов входящих в ветвь потомков текущего класса
        /// </summary>
        public List<vclass> Class_act_real_list_get()
        {
            List<vclass> Result = null;
            switch (StorageType)
            {
                case eStorageType.Active:
                    Result = Manager.class_act_real_by_id_parent(this);
                    break;
                case eStorageType.History:
                    throw new PgDataException(505, "Тип представления класса не соотвествует сигнатуре функции, требуется активное представление класса");
            }
            return Result;
        }

        /// <summary>
        /// Родительский класс 
        /// </summary>
        public vclass Class_parent
        {
            get
            {
                vclass Result = null;
                switch (StorageType)
                {
                    case eStorageType.Active:
                        Result = Manager.class_act_by_id(this.Id_parent);
                        break;
                    case eStorageType.History:
                        Result = Manager.class_snapshot_by_id(this.Id_parent, this.Timestamp_parent);
                        break;
                }
                return Result;
            }
        }

        /// <summary>
        /// Активное представление класса
        /// </summary>
        public vclass Class_act_get()
        {
            vclass Result = null;
            switch (StorageType)
            {
                case eStorageType.Active:
                    Result = this;
                    break;
                case eStorageType.History:
                    Result = Manager.class_act_by_id(this.Id);
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Базовый абстрактный класс
        /// </summary>
        public vclass Class_base
        {
            get
            {
                vclass Result = null;
                switch (StorageType)
                {
                    case eStorageType.Active:
                        Result = Manager.class_act_by_id(this.Id_root);
                        break;
                    case eStorageType.History:
                        Result = Manager.class_snapshot_by_id(this.Id_root, this.Timestamp_root);
                        break;
                }
                return Result;
            }
        }
        #endregion

        #region МЕТОДЫ РАБОТЫ С КЛАССАМИ И СНИМКАМИ КЛАССОВ КЛАССА
        /// <summary>
        /// Лист всех вещественных классов концепции
        /// class_full_real_by_id_conception
        /// </summary>
        public List<vclass> class_full_real_list_get()
        {
            return Manager.class_full_real_by_id_parent(this);
        }
        #endregion

        #region Поисковые методы класса
        /// <summary>
        /// Лист дочерних классов по строгому соотвествию имени 
        /// class_act_by_id_parent_strict_name
        /// </summary>
        public List<vclass> Class_act_by_strict_name(String iname, Boolean Extended = false)
        {
            List<vclass> Result = null;
            if (Extended)
            {
                Result = Manager.class_act_ext_by_id_parent_strict_name(this, iname);
            }
            else
            {
                Result = Manager.class_act_by_id_parent_strict_name(this, iname);
            }
            return Result;
        }

        /// <summary>
        /// Лист представлений активных классов указанного расположения по маске имени
        /// class_act_by_id_parent_msk_name
        /// </summary>
        public List<vclass> Class_act_by_msk_name( String name_mask, Boolean Extended = false)
        {
            List<vclass> Result = null;
            if (Extended)
            {
                Result = Manager.class_act_ext_by_id_parent_msk_name(this, name_mask);
            }
            else
            {
                Result = Manager.class_act_by_id_parent_msk_name(this, name_mask);
            }
            return Result;
        }
        #endregion
        #endregion
    }
}
