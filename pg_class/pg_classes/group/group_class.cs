using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class group
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ С ПРЕДСТАВЛЕНИЯМИ ВЕЩЕСТВЕННЫХ КЛАССОВ

        /// <summary>
        /// Лист вещественных классов группы
        /// </summary>
        public List<vclass> Class_real_list_get(Boolean Extended = false)
        {
            List<vclass> Result = null;

            if (Extended)
            {
                Result = Manager.class_act_real_ext_by_id_group(this);
            }
            else
            {
                Result = Manager.class_act_real_by_id_group(this);
            }
            return Result;
        }

        /// <summary>
        /// Лист разрешенных представлений вещественных классов по идентификатору позиции создаваемого объекта
        /// </summary>
        public List<vclass> Class_real_allowed_by_id_group(position Position, Boolean Extended = false)
        {
            List<vclass> Result = null;

            if (Extended)
            {
                Result = Manager.class_act_real_ext_allowed_by_id_group(this, Position);
            }
            else
            {
                Result = Manager.class_act_real_allowed_by_id_group(this, Position);
            }
            return Result;
        }

        #endregion

        #region МЕТОДЫ РАБОТЫ С ПРЕДСТАВЛЕНИЯМИ БАЗОВЫХ АБСТРАКТНЫХ КЛАССОЫ
        
        #region ДОБАВИТЬ



        /// <summary>
        /// Метод добавляет новое представление базового, абстрактного, расширяемого класса
        /// </summary>
        public vclass vclass_base_add(String iname, String idesc, Boolean ion,
             Int32 iid_unit, Int64 ibarcode_manufacturer)
        {
            return Manager.class_add(this.id, 0, iname, idesc, ion,
            true, true, iid_unit, -1, ibarcode_manufacturer);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанную группу
        /// </summary>
        public void vclass_base_del(vclass Vclass)
        {
            Manager.class_del(Vclass);
        }
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист разрешенных представлений базовых абстрактных классов по идентификатору позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_base_allowed_by_id_group(position Position, Boolean Extended = false)
        {
            List<vclass> Result = null;
            if (Extended)
            {
                Result = Manager.class_act_base_ext_allowed_by_id_group(this, Position);
            }
            else
            {
                Result = Manager.class_act_base_allowed_by_id_group(this, Position);
            }
            return Result;
            
        }

        /// <summary>
        /// Лист базовых абстрактных классов группы
        /// </summary>
        /// <param name="Extended">Возврат расширенного предстваления классов с заполненным листом свойств STEP1</param>
        public List<vclass> Class_base_list_get(Boolean Extended = false)
        {
            List<vclass> Result = null;
            if (Extended)
            {
                Result = Manager.class_act_ext_by_id_group(this);
            }
            else
            {
                Result =  Manager.class_act_by_id_group(this);
            }
            return Result;
        }
        #endregion
        #endregion

        #region Поисковые методы класса
        /// <summary>
        /// Лист представлений активных классов указанного расположения по маске имени
        /// class_act_by_id_group_msk_name
        /// </summary>
        public List<vclass> Class_act_by_msk_name(String name_mask, Boolean Extended = false)
        {
            List<vclass> Result = null;
            if (Extended)
            {
                Result = Manager.class_act_ext_by_id_group_msk_name(this, name_mask);
            }
            else
            {
                Result = Manager.class_act_by_id_group_msk_name(this, name_mask);
            }
            return Result;
        }
        #endregion

        #region МЕТОДЫ РАБОТЫ С КЛАССАМИ И СНИМКАМИ КЛАССОВ ГРУППЫ
        /// <summary>
        /// Лист всех вещественных классов группы
        /// class_act_real_by_id_group
        /// </summary>
        public List<vclass> Class_act_real_list_get()
        {
            return Manager.class_act_real_by_id_group(this);
        }

        /// <summary>
        /// Лист всех вещественных классов группы рекурсивный
        /// class_full_real_by_id_group
        /// </summary>
        public List<vclass> Class_full_real_list_get()
        {
            return Manager.class_full_real_by_id_group(this);
        }
        #endregion
    }
}
