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
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ КЛАССА
        #region ДОБАВИТЬ ЗНАЧЕНИЕ

        /// <summary>
        /// Метод добавляет новое значение пользовательского свойство класса
        /// </summary>
        public class_prop_user_val user_data_add(class_prop_user_val ClassPropUserVal)
        {
            class_prop_user_val Result = null;
            if (this.StorageType == eStorageType.Active)
            {
                Result = Manager.class_prop_user_val_add(ClassPropUserVal);
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
        /// Метод удаляет значение объектного свойства класса
        /// </summary>
        public void user_data_del()
        {
            if (this.StorageType == eStorageType.Active)
            {
                Manager.class_prop_user_val_del(this);
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
        /// Значение пользовательского свойства, шаг №2
        /// </summary>
        public class_prop_user_val user_data_get()
        {
            class_prop_user_val Result = null;
            switch (StorageType)
            {
                case eStorageType.Active:
                    Result = Manager.class_prop_user_val_by_id_prop(this);
                    break;
                case eStorageType.History:
                    Result = Manager.class_prop_user_val_snapshot_by_id_prop(this);
                    break;
            }
            return Result;
        }
        #endregion
        #endregion
        
    }
}
