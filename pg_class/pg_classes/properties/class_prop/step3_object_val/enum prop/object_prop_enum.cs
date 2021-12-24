using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_exceptions;

namespace pg_class.pg_classes
{
    public partial class object_prop
    {
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ КЛАССА
        #region ДОБАВИТЬ ЗНАЧЕНИЕ

        /// <summary>
        /// Метод добавляет новое значение свойства-перечисления объекта
        /// </summary>
        public object_prop_enum_val enum_data_add(object_prop_enum_val ObjectPropEnumVal)
        {
            object_prop_enum_val Result = null;
            Result = Manager.object_prop_enum_val_add(ObjectPropEnumVal);
            return Result;
        }
        #endregion

        #region УДАЛИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод удаляет значение свойства-перечисления объекта
        /// </summary>
        public void enum_data_del()
        {
            Manager.object_prop_enum_val_del(this);
        }
        #endregion

        #region ВЫБРАТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод выбирает данные значение свойства-перечисления шаг №3
        /// </summary>
        public object_prop_enum_val enum_data_get()
        {
            object_prop_enum_val Result = null;
            Result = Manager.object_prop_enum_val_by_id_prop(this);
            return Result;
        }
        #endregion
        #endregion
        
    }
}
