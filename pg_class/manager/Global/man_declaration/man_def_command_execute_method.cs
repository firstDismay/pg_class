namespace pg_class
{
    /// <summary>
    /// Метод команды используемый для вызова внутренней функции
    /// </summary>
    public enum eCommandMetod
    {
        /// <summary>
        /// Вызов функции не возвращающей значение (все методы менящие данные)
        /// </summary>
        ExecuteNonQuery,

        /// <summary>
        /// Вызов фуркция возвраающих кортежи (все методы возвращающие данные кроме is_actual)
        /// </summary>
        Fill,

        /// <summary>
        /// Вызов функции возвращающей скалярное значение (методы is_actual и им подобные возвращающие единичное значение)
        /// </summary>
        ExecuteScalar
    }
}
