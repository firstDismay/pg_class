namespace pg_class
{
    #region Перечисления данных значения свойств Шаг №2
    /// <summary>
    /// Перечисление действий при встраивании объектов значений объектных свойств
    /// </summary>
    public enum eObjectPropCreateEmdedMode
    {
        /// <summary>
        /// Действие не требуется
        /// </summary>
        NoAction = 0,
        /// <summary>
        /// Создать и встроить по Max
        /// </summary>
        EmbedNewMax = 1,
        /// <summary>
        /// Создать и встроить по Min
        /// </summary>
        EmbedNewMin = 2,
    }
    #endregion
}
