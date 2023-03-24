namespace pg_class
{


    /// <summary>
    /// Перечисление типа дня в календаре графиков
    /// </summary>
    public enum pg_day_type
    {
        /// <summary>
        /// Рабочий
        /// </summary>
        work,
        /// <summary>
        /// Выходной
        /// </summary>
        off,
        /// <summary>
        /// Предпраздничный
        /// </summary>
        pre_holiday,
        /// <summary>
        /// Праздничный
        /// </summary>
        holiday
    };

    /// <summary>
    /// Статус диапазона рабочего времени
    /// </summary>
    public enum pg_range_work_state
    {
        /// <summary>
        /// Свободный
        /// </summary>
        free,
        /// <summary>
        /// Запланированный
        /// </summary>
        planed,
        /// <summary>
        /// Зарезервированный
        /// </summary>
        reserved,
        /// <summary>
        /// Истекший
        /// </summary>
        expired,
        /// <summary>
        /// Выполненний
        /// </summary>
        completed,
        /// <summary>
        /// Выполняющийся
        /// </summary>
        processed
    };

    /// <summary>
    /// Тип диапазона рабочего времени
    /// </summary>
    public enum pg_range_work_type
    {
        /// <summary>
        /// Рабочий
        /// </summary>
        working,
        /// <summary>
        /// Не рабочий
        /// </summary>
        off,
        /// <summary>
        /// Сверх нормативный
        /// </summary>
        overtime,
        /// <summary>
        /// Обеденный
        /// </summary>
        lunch_break,
        /// <summary>
        /// Ночной
        /// </summary>
        night
    };

    /// <summary>
    /// Перечисление действий для политик RLS
    /// </summary>
    public enum pg_action_sql
    {
        /// <summary>
        /// Выбор
        /// </summary>
        select,
        /// <summary>
        /// Вставка
        /// </summary>
        insert,
        /// <summary>
        /// Обновление
        /// </summary>
        update,
        /// <summary>
        /// Удаление
        /// </summary>
        delete,
        /// <summary>
        /// Все действия
        /// </summary>
        all
    }
}
