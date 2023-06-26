namespace pg_class
{
    #region Перечисления для функций и методов сложного поиска

    /// <summary>
    /// Перечисление определяет доступные методы поиска значений при поиске
    /// </summary>
    public enum eSearchMethods
    {
        /// <summary>
        /// Больше
        /// </summary>
        more,
        /// <summary>
        /// Больше или равно
        /// </summary>
        more_or_equal,
        /// <summary>
        /// Меньше
        /// </summary>
        less,
        /// <summary>
        /// Меньше или равно
        /// </summary>
        less_or_equal,
        /// <summary>
        /// Больше и меньше
        /// </summary>
        more_and_less,
        /// <summary>
        /// Больше или равно и меньше
        /// </summary>
        more_or_equal_and_less,
        /// <summary>
        /// Больше или равно и меньше или равно
        /// </summary>
        more_or_equal_and_less_or_equal,
        /// <summary>
        /// Больше и меньше или равно
        /// </summary>
        more_and_less_or_equal,
        /// <summary>
        /// Равно
        /// </summary>
        equal,
        /// <summary>
        /// Не равно
        /// </summary>
        not_equal,
        /// <summary>
        /// соответствует шаблону
        /// </summary>
        like,
        /// <summary>
        /// соответствует шаблону без учета регистра
        /// </summary>
        like_lower,
        /// <summary>
        /// Входит в массив значений
        /// </summary>
        any_array,
        /// <summary>
        /// Не входит в массив значений
        /// </summary>
        not_any_array
    }
    #endregion
}
