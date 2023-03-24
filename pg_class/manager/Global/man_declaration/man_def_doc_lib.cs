namespace pg_class
{
    #region Перечисления библиотеки документов
    /// <summary>
    /// Перечисление определящее велечиину фрагментов файлов
    /// </summary>
    public enum eSizeTransferPage
    {
        /// <summary>
        /// Один мегабайт
        /// </summary>
        Size1Mb = 1048576,
        /// <summary>
        /// Два мегабайта
        /// </summary>
        Size2Mb = 2097152,
        /// <summary>
        /// Четыре мегабайта
        /// </summary>
        Size4Mb = 4194304,
        /// <summary>
        /// Четыре мегабайта
        /// </summary>
        Size8Mb = 8388608,
        /// <summary>
        /// Шестнадцать мегабайта
        /// </summary>
        Size16Mb = 16777216,
        /// <summary>
        /// Тридцать два мегабайта
        /// </summary>
        Size32Mb = 33554432,
        /// <summary>
        /// Шестьдесят четыре мегабайта
        /// </summary>
        Size64Mb = 67108864,
        /// <summary>
        /// Сто двадцать восемь мегабайт
        /// </summary>
        Size128Mb = 134217728,
        /// <summary>
        /// Двести мегабайт
        /// </summary>
        Size200Mb = 208666624
    }
    #endregion
}
