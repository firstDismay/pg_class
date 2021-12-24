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
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ СВОЙСТВ-ПЕРЕЧИСЛЕНИЙ
        #region ДОБАВИТЬ ЗНАЧЕНИЕ

        /// <summary>
        /// Метод добавляет новое значение свойства типа перечисление
        /// </summary>
        public class_prop_enum_val enum_data_add(class_prop_enum_val ClassPropEnumVal)
        {
            class_prop_enum_val Result = null;
            
            if (this.StorageType == eStorageType.Active)
            {
                Result = Manager.class_prop_enum_val_add(ClassPropEnumVal.Id_class_prop, ClassPropEnumVal.Id_prop_enum, ClassPropEnumVal.Id_prop_enum_val);
            }
            else
            {
                throw new PgDataException(eEntity.class_prop_user_val, eAction.Insert, eSubClass_ErrID.SCE3_Violation_Rules,
                    "Метод обновления данных класса не применим к историческому представлению класса!");
            }
            return Result;
        }

        /// <summary>
        /// Метод добавляет новое значение свойства типа перечисление
        /// </summary>
        public class_prop_enum_val enum_data_add(prop_enum_val PropEnumVal)
        {
            class_prop_enum_val Result = null;
            if (this.StorageType == eStorageType.Active)
            {
                Result = Manager.class_prop_enum_val_add(this.Id, PropEnumVal.Id_prop_enum, PropEnumVal.Id_prop_enum_val);
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
        /// Метод удаляет значение свойства класса типа перечисление
        /// </summary>
        public void enum_data_del()
        {
            if (this.StorageType == eStorageType.Active)
            {
                Manager.class_prop_enum_val_del(this);
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
        public class_prop_enum_val enum_data_get()
        {
            class_prop_enum_val Result = null;
            switch (StorageType)
            {
                case eStorageType.Active:
                    Result = Manager.class_prop_enum_val_by_id_prop(this);
                    break;
                case eStorageType.History:
                    Result = Manager.class_prop_enum_val_snapshot_by_id_prop(this);
                    break;
            }
            return Result;
        }
        #endregion
        #endregion
        
    }
}
