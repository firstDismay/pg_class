using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_exceptions;

namespace pg_class.pg_classes
{
    public partial class class_prop
    {
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ СВОЙСТВ-ССЫЛОК
        #region ДОБАВИТЬ ЗНАЧЕНИЕ

        /// <summary>
        /// Метод добавляет новое значение свойства-ссылки
        /// </summary>
        public class_prop_link_val link_data_add(class_prop_link_val ClassPropLinkVal)
        {
            class_prop_link_val Result = null;
            if (this.StorageType == eStorageType.Active)
            {
                Result = Manager.class_prop_link_val_add(ClassPropLinkVal.Id_class_prop, ClassPropLinkVal.Link_id_entity, ClassPropLinkVal.Link_id_entity_instance, ClassPropLinkVal.Link_id_sub_entity_instance);
            }
            else
            {
                throw new PgDataException(eEntity.class_prop_user_val, eAction.Insert, eSubClass_ErrID.SCE3_Violation_Rules,
                    "Метод обновления данных класса не применим к историческому представлению класса!");
            }
            return Result;
        }
        
        #endregion

        #region УДАЛИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод удаляет значение свойства-ссылки
        /// </summary>
        public void link_data_del()
        {
            if (this.StorageType == eStorageType.Active)
            {
                Manager.class_prop_link_val_del(this);
            }
            else
            {
                throw new PgDataException(eEntity.class_prop_user_val, eAction.Delete, eSubClass_ErrID.SCE3_Violation_Rules,
                    "Метод обновления данных класса не применим к историческому представлению класса!");
            }
        }
        #endregion

        #region ВЫБРАТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Данные значения свойства типа перечисление, шаг №2
        /// </summary>
        public class_prop_link_val link_data_get()
        {
            class_prop_link_val Result = null;
            switch (StorageType)
            {
                case eStorageType.Active:
                    Result = Manager.class_prop_link_val_by_id_prop(this);
                    break;
                case eStorageType.History:
                    Result = Manager.class_prop_link_val_snapshot_by_id_prop(this);
                    break;
            }
            return Result;
        }
        #endregion
        #endregion
        
    }
}
