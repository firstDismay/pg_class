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
        /// Метод добавляет новое значение пользовательского свойства объекта
        /// </summary>
        public object_prop_user_val user_data_add(object_prop_user_val ObjectPropUserVal)
        {
            object_prop_user_val Result = null;
            Result = Manager.object_prop_user_val_add(ObjectPropUserVal);
            return Result;
        }

        #endregion

        #region УДАЛИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод удаляет значение пользовательского свойства объекта
        /// </summary>
        public void user_data_del()
        {
            Manager.object_prop_user_val_del(this);
        }
        #endregion

        #region ВЫБРАТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Значение пользовательского свойства, шаг №2
        /// </summary>
        public  object_prop_user_val user_data_get()
        {
            object_prop_user_val Result = null;
            Result = Manager.object_prop_user_val_by_id_prop(this);
            return Result;
        }
        #endregion
        #endregion
        
    }
}
