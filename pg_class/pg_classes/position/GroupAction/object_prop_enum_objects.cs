﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_exceptions;

namespace pg_class.pg_classes
{
    public partial class position
    {
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ СВОЙСТВ ПЕРЕЧИСЛЕНИЙ ОБЪЕКТОВ УКАЗАННЫХ СНИМКА И ПОЗИЦИИ
        #region ДОБАВИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод добавляет новое значение свойств перечисления объектам позиции указанного снимка класса
        /// </summary>
        public void object_prop_enum_val_objects_add(class_prop_enum_val Class_prop_enum_val, Boolean on_internal = false)
        {
            Manager.object_prop_enum_val_objects_add(this, Class_prop_enum_val, on_internal);
        }
        #endregion

        #region ИЗМЕНИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод изменяет новое значение свойств перечисления объектам позиции указанного снимка класса
        /// </summary>
        public void object_prop_enum_val_objects_upd(class_prop_enum_val Class_prop_enum_val, Boolean on_internal = false)
        {
            Manager.object_prop_enum_val_objects_upd(this, Class_prop_enum_val, on_internal);
        }
        #endregion

        #region УДАЛИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод удаляет новое значение свойств перечисления объектам позиции указанного снимка класса
        /// </summary>
        public void object_prop_enum_val_objects_del(class_prop_enum_val Class_prop_enum_val, Boolean on_internal = false)
        {
            Manager.object_prop_enum_val_objects_del(this, Class_prop_enum_val, on_internal);
        }

        /// <summary>
        /// Метод удаляет новое значение свойств перечисления объектам позиции указанного снимка класса
        /// </summary>
        public void object_prop_enum_val_objects_del(class_prop Class_prop, Boolean on_internal = false)
        {
            Manager.object_prop_enum_val_objects_del(this, Class_prop, on_internal);
        }
        #endregion
        #endregion  
    }
}
