namespace pg_class
{
    #region Перечисления общих параметров менеджера данных и методов доступа к данным
    /// <summary>
    /// Перечисление допустимых типов подключений
    /// </summary>
    public enum eConnectType
    {
        /// <summary>
        /// Стандартный TCP
        /// </summary>
        TCP,
        /// <summary>
        /// SSH поверх TCP
        /// </summary>
        TCPoverSSH
    }

    /// <summary>
    /// Условный тип метода передачи прав на элемент программного API БД
    /// </summary>
    public enum eAccess
    {
        /// <summary>
        /// Доступ предоставлен
        /// </summary>
        Success,
        /// <summary>
        /// Доступ закрыт
        /// </summary>
        NotAvailable,
        /// <summary>
        /// Метод не найден
        /// </summary>
        NotFound,
        /// <summary>
        /// Метод не применим
        /// </summary>
        NotApplicable
    }

    /// <summary>
    /// Перечисление определяющее тип действия выполняемого методом доступа к БД
    /// </summary>
    public enum eAction
    {
        /// <summary>
        /// Любое действие, значение по умолчанию
        /// </summary>
        AnyAction = 0,
        /// <summary>
        /// Операция выборки
        /// </summary>
        Select = 7000,
        /// <summary>
        /// Операция вставки
        /// </summary>
        Insert = 1000,
        /// <summary>
        /// Операция обновления
        /// </summary>
        Update = 2000,
        /// <summary>
        /// Операция удалеия
        /// </summary>
        Delete = 3000,
        /// <summary>
        /// Операция переноса, перемещения
        /// </summary>
        Move = 4000,
        /// <summary>
        /// Операция блокировки сущности
        /// </summary>
        Lock = 9000,
        /// <summary>
        /// Операция разблокировки сущности
        /// </summary>
        UnLock = 10000,
        /// <summary>
        /// Операция копирования, в том числе вложенных сущностей
        /// </summary>
        Copy = 5000,
        /// <summary>
        /// Операция подключения к БД
        /// </summary>
        Connect = 11000,
        /// <summary>
        /// Операция переподключения к БД
        /// </summary>
        ReConnect = 12000,
        /// <summary>
        /// Операция отключения от БД
        /// </summary>
        DisConnect = 13000,
        /// <summary>
        /// Выполнение функции
        /// </summary>
        Execute = 14000,
        /// <summary>
        /// Инициализация сущности БД
        /// </summary>
        Init = 15000,
        /// <summary>
        /// Операция клонирования сущности
        /// </summary>
        Clone = 6000,
        /// <summary>
        /// Откат сущности к ранее сохраненному состоянию
        /// </summary>
        RollBack = 8000,
        /// <summary>
        /// Очистка сущности от неиспользуемых или поврежденных данных
        /// </summary>
        Clear = 16000,
        /// <summary>
        /// Приведение сущности к указанному виду
        /// </summary>
        Cast = 17000,
        /// <summary>
        /// Операция массовой вставки
        /// </summary>
        Insert_mass = 18000,
        /// <summary>
        /// Операция слияния
        /// </summary>    
        Merging = 19000,
        /// <summary>
        /// Операция включения
        /// </summary>
        Include = 20000,
        /// <summary>
        /// Операция исключения
        /// </summary>
        Exclude = 21000,
        /// <summary>
        /// Операция исключения
        /// </summary>
        Restore = 22000
    }

    /// <summary>
    /// Типы сообщений журнала конфигуратора
    /// </summary>
    public enum eJournalMessageType
    {
        /// <summary>
        /// Онформационное сообщение
        /// </summary>
        information,
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        error,
        /// <summary>
        /// Сообщение об успешном завершении
        /// </summary>
        success,
        /// <summary>
        /// Низкоуровневые сообщения
        /// </summary>
        debug
    }

    /// <summary>
    /// Условный тип метода передачи прав на элемент программного API БД
    /// </summary>
    public enum eStatus
    {
        /// <summary>
        /// Все
        /// </summary>
        all,
        /// <summary>
        /// Включенные
        /// </summary>
        on,
        /// <summary>
        /// Выключенные
        /// </summary>
        off
    }

    /// <summary>
    /// Действие изменившее список вложенности шаблона позиции
    /// </summary>
    public enum eActionPosTempNestedList
    {
        /// <summary>
        /// Список ограничения вложенности включен (создан полный список на основе правил вложенности прототипов)
        /// </summary>
        on,
        /// <summary>
        /// Список ограничения вложенности выключен, список ограничений удален
        /// </summary>
        off,
        /// <summary>
        /// Добавлено новое правило в список ограничений вложенности
        /// </summary>
        addrule,
        /// <summary>
        /// Удалено правило из списока ограничений вложенности
        /// </summary>
        delrule,
        /// <summary>
        /// Список ограничений вложенности очищен
        /// </summary>
        delallrule,
        /// <summary>
        /// Действие не выполнено
        /// </summary>
        none
    }

    /// <summary>
    /// Действие изменившее список Правил (для всех видов)
    /// </summary>
    public enum eActionRuleList
    {
        /// <summary>
        /// Список ограничения вложенности включен (создан полный список на основе правил вложенности прототипов)
        /// </summary>
        on,
        /// <summary>
        /// Список ограничения вложенности выключен, список ограничений удален
        /// </summary>
        off,
        /// <summary>
        /// Добавлено новое правило в список ограничений вложенности
        /// </summary>
        addrule,
        /// <summary>
        /// Удалено правило из списока ограничений вложенности
        /// </summary>
        delrule,
        /// <summary>
        /// Список ограничений вложенности очищен
        /// </summary>
        delallrule,
        /// <summary>
        /// Действие не выполнено
        /// </summary>
        none,
        /// <summary>
        /// Параметры правила обновлены
        /// </summary>
        updaterule
    }

    /// <summary>
    /// Тип хранилища данных сущностей имеющих историческую ретроспективу
    /// </summary>
    public enum eStorageType
    {
        /// <summary>
        /// Активные данные класса
        /// </summary>
        Active,
        /// <summary>
        /// Исторические данные класса
        /// </summary>
        History,
        /// <summary>
        /// Сохранение данных не выполнялось, данные в оперативной памяти
        /// </summary>
        NotSaved
    }

    /// <summary>
    /// Иерархический уровень класса в цепи наследования
    /// </summary>
    public enum eClassLevel
    {
        /// <summary>
        /// Базовый абстрактный класс
        /// </summary>
        Base,
        /// <summary>
        /// Абстрактный наследующий класс
        /// </summary>
        Abstraction,
        /// <summary>
        /// Реальный класс пораждающий объекты
        /// </summary>
        Real
    }

    /// <summary>
    /// Состояния менеджера данных
    /// </summary>
    public enum eManagerState
    {
        /// <summary>
        /// Менеджер Не готов к работе
        /// </summary>
        NoReady,
        /// <summary>
        /// Менеджер подключен к базе и инициализирован
        /// </summary>
        Connected,
        /// <summary>
        /// Менеджер инициализирован и отключен от базы все соединения разорваны по таймауту учетные данные сессии определены
        /// </summary>
        Disconnected,
        /// <summary>
        /// Менеджер инициализирован, Пользователь вышел из всех сессий, все соединения разорваны учетные данные сброшены
        /// </summary>
        LogOff
    }

    #endregion
}
