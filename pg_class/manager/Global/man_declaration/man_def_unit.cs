namespace pg_class
{
    /// <summary>
    /// Перечисление измеряемых величин
    /// </summary>
    public enum eUnit
    {
        /// <summary>
        /// Единицы длины, метр
        /// </summary>
        unit_width = 1,
        /// <summary>
        /// Единицы площади, метр квадратный
        /// </summary>
        unit_area = 2,
        /// <summary>
        /// Единицы объема, метр кубический
        /// </summary>
        unit_volume = 3,
        /// <summary>
        /// Единицы массы, килограмм
        /// </summary>
        unit_weight = 4,
        /// <summary>
        /// Единицы колличества, штука
        /// </summary>
        unit_quantity = 5,
        /// <summary>
        /// Единичный учет, единица
        /// </summary>
        unit_single = 6,
        /// <summary>
        /// Учет объектных агрегатов, объектный агрегат
        /// </summary>
        unit_aggregate = 7,
        /// <summary>
        /// Неопределенная величина
        /// </summary>
        unit_undefined = 8
    }
}
