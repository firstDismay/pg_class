namespace pg_class
{
    #region Перечисления источников значений свойств объектов и позиций Шаг №3
    /// <summary>
    /// Перечисление источников значения свойства объекта STEP3
    /// </summary>
    public enum eSourceValue_ObjectProp
    {
        /// <summary>
        /// Значение не установлено
        /// </summary>
        set_null,
        /// <summary>
        /// Значение установлено по данным значения свойства класса
        /// </summary>
        set_class,
        /// <summary>
        /// Значение установлено по данным значения свойства объекта
        /// </summary>
        set_object
    }

    /// <summary>
    /// Перечисление источников значения свойства позиции STEP3
    /// </summary>
    public enum eSourceValue_PositionProp
    {
        /// <summary>
        /// Значение не установлено
        /// </summary>
        set_null,
        /// <summary>
        /// Значение установлено по данным значения свойства шаблона
        /// </summary>
        set_pos_temp,
        /// <summary>
        /// Значение установлено по данным значения свойства позиции
        /// </summary>
        set_position
    }
    #endregion
}
