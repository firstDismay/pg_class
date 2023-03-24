using System;

namespace pg_class.pg_classes
{
    public partial class global_prop
    {
        #region АГРЕГАТНЫЕ ФУНКЦИИ ДЛЯ РАБОТЫ С ГЛОБАЛЬНЫМИ СВОЙСТВАМИ
        /// <summary>
        /// Агрегатная функция определяет сумму значений глобальных числовых свойств агрегатных объектов с учетом количества
        /// object_prop_user_small_agg_func_sum
        /// </summary>
        public Decimal user_small_agg_func_sum(object_general Object, Boolean on_quantity = true)
        {
            return Manager.object_prop_user_small_agg_func_sum(this, Object, on_quantity);
        }
        #endregion
    }
}
