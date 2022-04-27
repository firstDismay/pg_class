using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        Clone  = 6000,
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

    #region Перечисления типов данных и правил пересчета
    /// <summary>
    /// Перечисление допустимых типов данных свойств PostgreSQL
    /// </summary>
    public enum eDataType
    {
        /// <summary>
        /// Тип VarChar
        /// </summary>
        val_varchar = 1, //val_varchar
        /// <summary>
        /// Тип Integer
        /// </summary>
        val_int = 2, //val_int
        /// <summary>
        /// Тип Numeric
        /// </summary>
        val_numeric = 3, //val_numeric
        /// <summary>
        /// Тип Real
        /// </summary>
        val_real = 4, //val_real
        /// <summary>
        /// Тип Double
        /// </summary>
        val_double = 5, //val_double
        /// <summary>
        /// Тип Money
        /// </summary>
        val_money = 6, //val_money
        /// <summary>
        /// Тип Text
        /// </summary>
        val_text = 7, //val_text
        /// <summary>
        /// Тип Bytea
        /// </summary>
        val_bytea = 8, //val_bytea
        /// <summary>
        /// Тип Boolean
        /// </summary>
        val_boolean = 9, //val_boolean
        /// <summary>
        /// Тип Date
        /// </summary>
        val_date = 10, //val_date
        /// <summary>
        /// Тип Time
        /// </summary>
        val_time = 11, //val_time
        /// <summary>
        /// Тип Interval
        /// </summary>
        val_interval = 12, //val_interval
        /// <summary>
        /// Тип Time stamp
        /// </summary>
        val_timestamp = 13, //val_timestamp
        /// <summary>
        /// Тип Json
        /// </summary>
        val_json = 14, //val_json
        /// <summary>
        /// Тип BigInt
        /// </summary>
        val_bigint = 15 //val_bigint
    }

    /// <summary>
    /// Перечисление типов данных .Net
    /// </summary>
    public enum eDataTypeNet
    {
        /// <summary>
        /// Тип данных Boolean
        /// </summary>
        Boolean,
        /// <summary>
        /// Тип данных Byte
        /// </summary>
        Byte,
        /// <summary>
        /// Тип данных ByteArray
        /// </summary>
        ByteArray,
        /// <summary>
        /// Тип данных Char
        /// </summary>
        Char,
        /// <summary>
        /// Тип данных DateTime
        /// </summary>
        DateTime,
        /// <summary>
        /// Тип данных TimeSpan
        /// </summary>
        TimeSpan,
        /// <summary>
        /// Тип данных DBNull
        /// </summary>
        DBNull,
        /// <summary>
        /// Тип данных Decimal
        /// </summary>
        Decimal,
        /// <summary>
        /// Тип данных Double
        /// </summary>
        Double,
        /// <summary>
        /// Тип данных Empty
        /// </summary>
        Empty,
        /// <summary>
        /// Тип данных Int16
        /// </summary>
        Int16,
        /// <summary>
        /// Тип данных Int32
        /// </summary>
        Int32,
        /// <summary>
        /// Тип данных Int64
        /// </summary>
        Int64,
        /// <summary>
        /// Тип данных Object
        /// </summary>
        Object,
        /// <summary>
        /// Тип данных SByte
        /// </summary>
        SByte,
        /// <summary>
        /// Тип данных Single
        /// </summary>
        Single,
        /// <summary>
        /// Тип данных String
        /// </summary>
        String,
        /// <summary>
        /// Тип данных UInt16
        /// </summary>
        UInt16,
        /// <summary>
        /// Тип данных UInt32
        /// </summary>
        UInt32,
        /// <summary>
        /// Тип данных UInt64
        /// </summary>
        UInt64,
        /// <summary>
        /// Диапазан времени
        /// </summary>
        TSRange
    }

    /// <summary>
    /// Тип числового значения колличества объекта класса
    /// </summary>
    public enum eQuantityTypeVal
    {
        /// <summary>
        /// Базовые единицы
        /// bquantity
        /// </summary>
        BaseUnits,
        /// <summary>
        /// Пересчитанные в единицы правила пересчета
        /// bquantity
        /// </summary>
        RecalculatedUnits
    }

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
    #endregion

    #region Перечисления типов свойств Шаг №1

    /// <summary>
    /// Перечисление допустимых типов свойств
    /// </summary>
    public enum ePropType
    {
        /// <summary>
        /// Свободно определяемое свойство
        /// </summary>
        PropUser = 1,
        /// <summary>
        /// Перечислимое свойство
        /// </summary>
        PropEnum = 2,
        /// <summary>
        /// Объектное свойство
        /// </summary>
        PropObject = 3,
        /// <summary>
        /// Свойство-ссылка
        /// </summary>
        PropLink = 4
    }

    /// <summary>
    /// Перечисление размеров типов данных свойств
    /// </summary>
    public enum eDataSize
    {
        /// <summary>
        /// Свойство малых типов данных
        /// </summary>
        BigData = 1,
        /// <summary>
        /// Свойство больших типов данных
        /// </summary>
        SmallData = 2
    }

    /// <summary>
    /// Перечисление определяющее тип собятия класса
    /// </summary>
    public enum eEvents
    {
        /// <summary>
        /// Свойства класса изменено
        /// </summary>
        Change,
        /// <summary>
        /// Изменения класса сохранены в БД методом update
        /// </summary>
        UpdateBase

    }


    /// <summary>
    /// Состояние свойства в отношении готовности к линковке с глобальным свойством
    /// </summary>
    public enum ePropStateForGlobalPropLink
    {
        /// <summary>
        /// Свойство готово к линковке
        /// </summary>
        ready=0,
        /// <summary>
        /// Свойство не готово к линковке содержит различные имена в снимках метаданных
        /// </summary>
        different_names = 1,
        /// <summary>
        /// Свойство не готово к линковке содержит различные типы свойства в снимках метаданных
        /// </summary>
        different_prop_types = 2,
        /// <summary>
        /// Свойство не готово к линковке содержит различные типы данных свойства в снимках метаданных
        /// </summary>
        different_data_types = 3
    }

    #endregion

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

    #region Перечисления сущностей БД
    /// <summary>
    /// Текущее состояние данных сущности полученное с помощью группы методов is actual
    /// </summary>
    public enum eEntityState
    {
        /// <summary>
        /// Текущее представление Сущности не найдено в базе
        /// </summary>
        NotFound = 1,
        /// <summary>
        /// Текущее представление Сущности не соотвествует данным в базе, требуется обновление данных
        /// </summary>
        NotActual = 2,
        /// <summary>
        /// Текущее представление Сущности соотвествует данным в базе, обновление данных не требуется
        /// </summary>
        Actual = 3,
        /// <summary>
        /// Текущее представление Сущности соотвествует данным в базе, количественный состав потомков изменен, требуется обновление данных сущности
        /// </summary>
        Actual_Child_Change = 4,
        /// <summary>
        /// Текущее представление Сущности является историческим снимком
        /// </summary>
        History = 5,
    }

    /// <summary>
    /// Перечисление сущностей БД
    /// </summary>
    public enum eEntity
    {
        /// <summary>
        /// Сущность
        /// </summary>
        entity = 0,
        /// <summary>
        /// Прототип позиции
        /// </summary>
        pos_prototype = 1,
        /// <summary>
        /// Концепция
        /// </summary>
        conception = 2,
        /// <summary>
        /// Шаблон
        /// </summary>
        pos_temp = 3,
        /// <summary>
        /// Позиция
        /// </summary>
        position = 4,
        /// <summary>
        /// Вектор
        /// </summary>
        vector = 5,
        /// <summary>
        /// Ссылка на объект
        /// </summary>
        link_obj_pos = 6,
        /// <summary>
        /// Базовая роль
        /// </summary>
        role_base = 7,
        /// <summary>
        /// Пользователь
        /// </summary>
        user = 8,
        /// <summary>
        /// Свойство позиции
        /// </summary>
        position_prop = 9,
        /// <summary>
        /// Свойство шаблона
        /// </summary>
        pos_temp_prop = 10,
        /// <summary>
        /// Перечисление значений свойства
        /// </summary>
        pos_temp_enum_prop = 11,
        /// <summary>
        /// Тема форума поддержки
        /// </summary>
        ticket = 12,
        /// <summary>
        /// Сообщение форума поддержки
        /// </summary>
        message = 13,
        /// <summary>
        /// Свойство темы форума поддержки
        /// </summary>
        ticket_prop = 14,
        /// <summary>
        /// Свойство сообщения форума поддержки
        /// </summary>
        mes_prop = 15,
        /// <summary>
        /// Свойство
        /// </summary>
        property = 16,
        /// <summary>
        /// Группа
        /// </summary>
        group = 17,
        /// <summary>
        /// Класс
        /// </summary>
        vclass = 18,
        /// <summary>
        /// Свойство класса
        /// </summary>
        class_prop = 19,
        /// <summary>
        /// Объект
        /// </summary>
        vobject = 20,
        /// <summary>
        /// Правило вложенности уровня 1 группа на шаблон позиции
        /// </summary>
        rulel1_group_on_pos_temp = 21,
        /// <summary>
        /// Правило вложенности уровня 2 класс на позицию
        /// </summary>
        rulel2_class_on_position = 22,
        /// <summary>
        /// Правило вложенности шаблонов позиций
        /// </summary>
        pos_temp_nested_rule = 23,
        /// <summary>
        /// Единицы измерения величин и правила пересчета
        /// </summary>
        unit = 33,
        /// <summary>
        /// Правило пересчета колличества объектов
        /// </summary>
        unit_conversion_rule = 34,
        /// <summary>
        /// Правило назначения правил пересчета объектов вещественного класса
        /// </summary>
        class_unit_conversion_rule = 35,
        /// <summary>
        /// Данные значение объектного свойства класса
        /// </summary>
        class_prop_object_val = 36,
        /// <summary>
        /// Значение объектного свойства объекта
        /// </summary>
        object_prop_object_val = 37,
        /// <summary>
        /// Разрешение правила вложенности уровня 1 группа на шаблон позиции
        /// </summary>
        rulel1_group_on_pos_temp_access = 38,
        /// <summary>
        /// Разрешение правила вложенности уровня 2 снимок класса на позицию
        /// </summary>
        rulel2_class_snapshot_on_position = 39,
        /// <summary>
        /// Тип данных
        /// </summary>
        prop_data_type = 40,
        /// <summary>
        /// Тип данных концепции
        /// </summary>
        con_prop_data_type = 41,
        /// <summary>
        /// Тип свойства
        /// </summary>
        prop_type = 42,
        /// <summary>
        /// Расширение двоичного типа данных свойства
        /// </summary>
        prop_data_bin_ext = 43,
        /// <summary>
        /// Свойство объекта
        /// </summary>
        object_prop = 44,
        /// <summary>
        /// Данные значения пользовательского свойства класса
        /// </summary>
        class_prop_user_val = 45,
        /// <summary>
        /// Данные значения свойства-перечисления класса
        /// </summary>
        class_prop_enum_val = 46,
        /// <summary>
        /// Данные значения свойства-пользовательского объекта
        /// </summary>
        object_prop_user_val = 47,
        /// <summary>
        /// Данные значения свойства-перечисления объекта
        /// </summary>
        object_prop_enum_val = 48,
        /// <summary>
        /// Спецификатор значения свойства
        /// </summary>
        prop_val_spec = 49,
        /// <summary>
        /// Перечисление
        /// </summary>
        prop_enum = 50,
        /// <summary>
        /// Элемент перечисления
        /// </summary>
        prop_enum_val = 51,
        /// <summary>
        /// Данные значения свойства-ссылки класса
        /// </summary>
        class_prop_link_val = 52,
        /// <summary>
        /// Данные значения свойства-ссылки объекта
        /// </summary>
        object_prop_link_val = 53,
        /// <summary>
        /// Глобальное свойство концепции
        /// </summary>
        global_prop = 54,
        /// <summary>
        /// Ссылка глобального свойства  на определяющее свойство класса
        /// </summary>
        global_prop_link_class_prop = 55,
        /// <summary>
        /// Ссылка глобального свойства  на свойство шаблона позиции
        /// </summary>
        global_prop_link_pos_temp_prop = 56,
        /// <summary>
        /// Данные значения пользовательского свойства шаблона
        /// </summary>
        pos_temp_prop_user_val = 57,
        /// <summary>
        /// Данные значения свойства-перечисления шаблона
        /// </summary>
        pos_temp_prop_enum_val = 58,
        /// <summary>
        /// Данные значение объектного свойства шаблона
        /// </summary>
        pos_temp_prop_object_val = 59,
        /// <summary>
        /// Данные значения свойства-ссылки шаблона
        /// </summary>
        pos_temp_prop_link_val = 60,
        /// <summary>
        /// Данные значения пользовательского свойства позиции
        /// </summary>
        position_prop_user_val = 61,
        /// <summary>
        /// Данные значения свойства-перечисления позиции
        /// </summary>
        position_prop_enum_val = 62,
        /// <summary>
        /// Данные значение объектного свойства позиции
        /// </summary>
        position_prop_object_val = 63,
        /// <summary>
        /// Данные значения свойства-ссылки позиции
        /// </summary>
        position_prop_link_val = 64,
        /// <summary>
        /// Данные области значения глобального свойства
        /// </summary>
        global_prop_area_val = 65,
        /// <summary>
        /// Документ библиотеки документов
        /// </summary>
        document = 66,
        /// <summary>
        /// Файл документа
        /// </summary>
        doc_file = 67,
        /// <summary>
        /// Ссылка документа
        /// </summary>
        doc_link = 68,
        /// <summary>
        /// Категория документа
        /// </summary>
        doc_category = 69,
        /// <summary>
        /// Базовый класс доступа к данным
        /// </summary>
        manager = 99,
        /// <summary>
        /// Пул соединений менеджера данных
        /// </summary>
        pool = 100,
        /// <summary>
        /// Соединение пула соединений
        /// </summary>
        connect = 101,
        /// <summary>
        /// Процедура экспорта
        /// </summary>
        procedure_export = 102,
        /// <summary>
        /// Производственный календарь
        /// </summary>
        plan_calendar = 103,
        /// <summary>
        /// План
        /// </summary>
        plan = 104,
        /// <summary>
        /// Ссылка плана
        /// </summary>
        plan_link = 105,
        /// <summary>
        /// Диапазон плана запланированный
        /// </summary>
        plan_range = 106,
        /// <summary>
        /// Ссылка диапазона плана
        /// </summary>
        plan_range_link = 107,
        /// <summary>
        /// Выданный диапазон плана
        /// </summary>
        plan_given_range_plan = 108,
        /// <summary>
        /// Ссылка на плановый диапазон расписания на вид работы
        /// </summary>
        plan_given_range_plan_link = 109,
        /// <summary>
        /// Фактический диапазон расписания на вид работы
        /// </summary>
        plan_given_range_fact = 110,
        /// <summary>
        /// Ссылка фактический диапазон расписания на вид работы
        /// </summary>
        plan_given_range_fact_link = 111,
        /// <summary>
        /// Перенесенный по указу правителсьтва РФ день
        /// </summary>
        plan_transfer_day = 112,
        /// <summary>
        /// Праздничный день или каникулы
        /// </summary>
        plan_holiday = 113,
        /// <summary>
        /// Роль пользователя
        /// </summary>
        role_user = 114,
        /// <summary>
        /// Правило вложенности уровня 1 класс на шаблон позиции
        /// </summary>
        rulel1_class_on_pos_temp = 115,
        /// <summary>
        /// Разрешение правила вложенности уровня 1 группа на шаблон позиции
        /// </summary>
        rulel1_class_on_pos_temp_access = 116,
        /// <summary>
        /// Правило пересечения диапазонов подчиненных планов
        /// </summary>
        plan_rule_crossing = 117,
        /// <summary>
        /// Ссылка правила пересечения диапазонов подчиненных планов
        /// </summary>
        plan_rule_crossing_link = 118,
        /// <summary>
        /// Правило вложенности диапазонов подчиненных планов
        /// </summary>
        plan_rule_nesting = 119,
        /// <summary>
        /// Ссылка правила вложенности диапазонов подчиненных планов
        /// </summary>
        plan_rule_nesting_link = 120
    }

    /// <summary>
    /// Источник сущности свойство применимо к сущностям с открытыми конструкторами
    /// </summary>
    public enum eEntitySource
    {
        /// <summary>
        /// Создано сервером
        /// </summary>
        Server = 1,
        /// <summary>
        /// Создано клиентом
        /// </summary>
        Client = 2
    }

    /// <summary>
    /// Модификаторы строковых представлений сущностей для переопределения мотодов ToString
    /// </summary>
    public enum eEntityToString
    {
        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        DefaultName = 1,
        /// <summary>
        /// Полное имя
        /// </summary>
        FullName = 2,
        /// <summary>
        /// Краткое имя
        /// </summary>
        ShortName = 3
    }

    /// <summary>
    /// Перечисление областей применения перечислений для свойств
    /// </summary>
    public enum eProp_enum_use_area
    {
        /// <summary>
        /// Область применения не назначена
        /// </summary>
        none = 1,
        /// <summary>
        /// Применяется в позициях
        /// </summary>
        positions = 2,
        /// <summary>
        /// Применяется в объектах
        /// </summary>
        objects = 3,
        /// <summary>
        /// Применяется в объектах и позициях
        /// </summary>
        objects_and_positions = 4
    }

    /// <summary>
    /// Перечисление меняет режим обновления класса
    /// </summary>
    public enum eClass_real_ready
    {
        /// <summary>
        /// Вещественный класс готов к созданию объектов
        /// </summary>
        Ready,
        /// <summary>
        /// Вещественный класс не готов к созданию объектов
        /// </summary>
        NoReady,
        /// <summary>
        /// Вещественный класс не проверялся на готовность к созданию объектов
        /// </summary>
        NoChek,
        /// <summary>
        /// Абстрактный класс
        /// </summary>
        NotAllowed
    }
    #endregion

    #region Перечисления классов и кодов ошибок менеджера данных БД

    /// <summary>
    /// Перечисление базовых кодов ошибок для сущностей БД
    /// </summary>
    public enum eEntity_ErrID
    {

        /// <summary>
        ///Сущность
        /// </summary>
        entity = 10000000,

        /// <summary>
        ///Прототип позиции
        /// </summary>
        pos_prototype = 10100000,

        /// <summary>
        ///Концепция
        /// </summary>
        conception = 10200000,

        /// <summary>
        ///Шаблон
        /// </summary>
        pos_temp = 10300000,

        /// <summary>
        ///Позиция
        /// </summary>
        position = 10400000,

        /// <summary>
        ///Вектор
        /// </summary>
        vector = 10500000,

        /// <summary>
        ///Ссылка на объект
        /// </summary>
        link_obj_pos = 10600000,

        /// <summary>
        ///Базовая роль
        /// </summary>
        role_base = 10700000,

        /// <summary>
        ///Пользователь
        /// </summary>
        user = 10800000,

        /// <summary>
        ///Свойство позиции
        /// </summary>
        position_prop = 10900000,

        /// <summary>
        ///Свойство шаблона
        /// </summary>
        pos_temp_prop = 11000000,

        /// <summary>
        ///Перечисление значений свойства
        /// </summary>
        pos_temp_enum_prop = 11100000,

        /// <summary>
        ///Тема форума поддержки
        /// </summary>
        ticket = 11200000,

        /// <summary>
        ///Сообщение форума поддержки
        /// </summary>
        message = 11300000,

        /// <summary>
        ///Свойство темы форума поддержки
        /// </summary>
        ticket_prop = 11400000,

        /// <summary>
        ///Свойство сообщения форума поддержки
        /// </summary>
        mes_prop = 11500000,

        /// <summary>
        ///Свойство
        /// </summary>
        property = 11600000,

        /// <summary>
        ///Группа
        /// </summary>
        group = 11700000,

        /// <summary>
        ///Класс
        /// </summary>
        vclass = 11800000,

        /// <summary>
        ///Свойство класса
        /// </summary>
        class_prop = 11900000,

        /// <summary>
        ///Объект
        /// </summary>
        vobject = 12000000,

        /// <summary>
        ///Правило вложенности уровня 1 группа на шаблон позиции
        /// </summary>
        rulel1_group_on_pos_temp = 12100000,

        /// <summary>
        ///Правило вложенности уровня 2 класс на позицию
        /// </summary>
        rulel2_class_on_position = 12200000,

        /// <summary>
        ///Правило вложенности шаблонов позиций
        /// </summary>
        pos_temp_nested_rule = 12300000,

        /// <summary>
        ///Единицы измерения величин и правила пересчета
        /// </summary>
        unit = 13300000,

        /// <summary>
        ///Правило пересчета колличества объектов
        /// </summary>
        unit_conversion_rule = 13400000,

        /// <summary>
        ///Правило назначения правил пересчета объектов вещественного класса
        /// </summary>
        class_unit_conversion_rule = 13500000,

        /// <summary>
        ///Данные значение объектного свойства класса
        /// </summary>
        class_prop_object_val = 13600000,

        /// <summary>
        ///Значение объектного свойства объекта
        /// </summary>
        object_prop_object_val = 13700000,

        /// <summary>
        ///Разрешение правила вложенности уровня 1 группа на шаблон позиции
        /// </summary>
        rulel1_group_on_pos_temp_access = 13800000,

        /// <summary>
        ///Разрешение правила вложенности уровня 2 снимок класса на позицию
        /// </summary>
        rulel2_class_snapshot_on_position = 13900000,

        /// <summary>
        ///Тип данных
        /// </summary>
        prop_data_type = 14000000,

        /// <summary>
        ///Тип данных концепции
        /// </summary>
        con_prop_data_type = 14100000,

        /// <summary>
        ///Тип свойства
        /// </summary>
        prop_type = 14200000,

        /// <summary>
        ///Расширение двоичного типа данных свойства
        /// </summary>
        prop_data_bin_ext = 14300000,

        /// <summary>
        ///Свойство объекта
        /// </summary>
        object_prop = 14400000,

        /// <summary>
        ///Данные значения пользовательского свойства класса
        /// </summary>
        class_prop_user_val = 14500000,

        /// <summary>
        ///Данные значения свойства-перечисления класса
        /// </summary>
        class_prop_enum_val = 14600000,

        /// <summary>
        ///Данные значения свойства-пользовательского объекта
        /// </summary>
        object_prop_user_val = 14700000,

        /// <summary>
        ///Данные значения свойства-перечисления объекта
        /// </summary>
        object_prop_enum_val = 14800000,

        /// <summary>
        ///Спецификатор значения свойства
        /// </summary>
        prop_val_spec = 14900000,

        /// <summary>
        ///Перечисление
        /// </summary>
        prop_enum = 15000000,

        /// <summary>
        ///Элемент перечисления
        /// </summary>
        prop_enum_val = 15100000,

        /// <summary>
        ///Данные значения свойства-ссылки класса
        /// </summary>
        class_prop_link_val = 15200000,

        /// <summary>
        ///Данные значения свойства-ссылки объекта
        /// </summary>
        object_prop_link_val = 15300000,

        /// <summary>
        ///Глобальное свойство концепции
        /// </summary>
        global_prop = 15400000,

        /// <summary>
        ///Ссылка глобального свойства  на определяющее свойство класса
        /// </summary>
        global_prop_link_class_prop = 15500000,

        /// <summary>
        ///Ссылка глобального свойства  на свойство шаблона позиции
        /// </summary>
        global_prop_link_pos_temp_prop = 15600000,

        /// <summary>
        ///Данные значения пользовательского свойства шаблона
        /// </summary>
        pos_temp_prop_user_val = 15700000,

        /// <summary>
        ///Данные значения свойства-перечисления шаблона
        /// </summary>
        pos_temp_prop_enum_val = 15800000,

        /// <summary>
        ///Данные значение объектного свойства шаблона
        /// </summary>
        pos_temp_prop_object_val = 15900000,

        /// <summary>
        ///Данные значения свойства-ссылки шаблона
        /// </summary>
        pos_temp_prop_link_val = 16000000,

        /// <summary>
        ///Данные значения пользовательского свойства позиции
        /// </summary>
        position_prop_user_val = 16100000,

        /// <summary>
        ///Данные значения свойства-перечисления позиции
        /// </summary>
        position_prop_enum_val = 16200000,

        /// <summary>
        ///Данные значение объектного свойства позиции
        /// </summary>
        position_prop_object_val = 16300000,

        /// <summary>
        ///Данные значения свойства-ссылки позиции
        /// </summary>
        position_prop_link_val = 16400000,

        /// <summary>
        ///Данные области значения глобального свойства
        /// </summary>
        global_prop_area_val = 16500000,

        /// <summary>
        ///Документ библиотеки документов
        /// </summary>
        document = 16600000,

        /// <summary>
        ///Файл документа
        /// </summary>
        doc_file = 16700000,

        /// <summary>
        ///Ссылка документа
        /// </summary>
        doc_link = 16800000,

        /// <summary>
        ///Категория документа
        /// </summary>
        doc_category = 16900000,

        /// <summary>
        ///Базовый класс доступа к данным
        /// </summary>
        manager = 19900000,

        /// <summary>
        ///Пул соединений менеджера данных
        /// </summary>
        pool = 20000000,

        /// <summary>
        ///Соединение пула соединений
        /// </summary>
        connect = 20100000,

        /// <summary>
        ///Процедура экспорта
        /// </summary>
        procedure_export = 20200000,

        /// <summary>
        ///Производственный календарь
        /// </summary>
        plan_calendar = 20300000,

        /// <summary>
        ///План
        /// </summary>
        plan = 20400000,

        /// <summary>
        ///Ссылка плана
        /// </summary>
        plan_link = 20500000,

        /// <summary>
        ///Диапазон плана запланированный
        /// </summary>
        plan_range = 20600000,

        /// <summary>
        ///Ссылка диапазона плана
        /// </summary>
        plan_range_link = 20700000,

        /// <summary>
        ///Выданный диапазон плана
        /// </summary>
        plan_given_range_plan = 20800000,

        /// <summary>
        ///Ссылка на плановый диапазон расписания на вид работы
        /// </summary>
        plan_given_range_plan_link = 20900000,

        /// <summary>
        ///Фактический диапазон расписания на вид работы
        /// </summary>
        plan_given_range_fact = 21000000,

        /// <summary>
        ///Ссылка фактический диапазон расписания на вид работы
        /// </summary>
        plan_given_range_fact_link = 21100000,

        /// <summary>
        ///Перенесенный по указу правителсьтва РФ день
        /// </summary>
        plan_transfer_day = 21200000,

        /// <summary>
        ///Праздничный день или каникулы
        /// </summary>
        plan_holiday = 21300000,

        /// <summary>
        ///Роль пользователя
        /// </summary>
        role_user = 21400000,

        /// <summary>
        ///Правило вложенности уровня 1 класс на шаблон позиции
        /// </summary>
        rulel1_class_on_pos_temp = 21500000,

        /// <summary>
        ///Разрешение правила вложенности уровня 1 группа на шаблон позиции
        /// </summary>
        rulel1_class_on_pos_temp_access = 21600000,

        /// <summary>
        ///Правило пересечения диапазонов подчиненных планов
        /// </summary>
        plan_rule_crossing = 21700000,

        /// <summary>
        ///Ссылка правила пересечения диапазонов подчиненных планов
        /// </summary>
        plan_rule_crossing_link = 21800000,

        /// <summary>
        ///Правило вложенности диапазонов подчиненных планов
        /// </summary>
        plan_rule_nesting = 21900000,

        /// <summary>
        ///Ссылка правила вложенности диапазонов подчиненных планов
        /// </summary>
        plan_rule_nesting_link = 22000000
    }

    /// <summary>
    /// Перечисление базовых кодов ошибок для методов БД
    /// </summary>
    public enum eSubClass_ErrID
    {
        /// <summary>
        /// Неизвестная ошибка - 0
        /// </summary>
        SCE0_Unknown_Error = 0,
        /// <summary>
        /// Несуществующий объект - 1
        /// </summary>
        SCE1_NonExistent_Entity = 1,
        /// <summary>
        /// Нарушение уникальности -2
        /// </summary>
        SCE2_Violation_Unique = 2,
        /// <summary>
        /// Нарушение правил или ограничений - 3
        /// </summary>
        SCE3_Violation_Rules = 3,
        /// <summary>
        /// Нарушение правил вложенности - 4
        /// </summary>
        SCE4_Violation_Rules_Nesting = 4,
        /// <summary>
        /// Нарушение ограничений вложенности - 5
        /// </summary>
        SCE5_Violation_Limitations_Nesting = 5,
        /// <summary>
        /// Превышение ограничения вложенности - 6
        /// </summary>
        SCE6_Over_Limitations_Nesting = 6,
        /// <summary>
        /// Несуществующий наследуемый объект - 7
        /// </summary>
        SCE7_NonExistent_Inherited_Entity = 7,
        /// <summary>
        /// Несуществующий родительский объект - 8
        /// </summary>
        SCE8_NonExistent_Parental_Entity = 8,
        /// <summary>
        /// Выход за пределы допустимых значений
        /// </summary>
        SCE9_Out_Of_Range = 9,
        /// <summary>
        /// Несуществующий исходный объект
        /// </summary>
        SCE10_NonExistent_Source_Entity = 10,
    }

    /// <summary>
    /// Перечисление источников ошибок с учетом версий функций определяемых типом аргумента результата
    /// </summary>
    public enum eSourceError
    {
        /// <summary>
        /// Функция класса с аргументом версии 1
        /// </summary>
        ClassFuncVer1,
        /// <summary>
        /// Функция класса с аргументом версии 2
        /// </summary>
        ClassFuncVer2,
        /// <summary>
        /// Функция сервера с аргументом версии 1
        /// </summary>
        ServerFuncVer1,
        /// <summary>
        /// Функция сервера с аргументом версии 2
        /// </summary>
        ServerFuncVer2
    }
    #endregion

    #region Перечисления для функций экспорта импорта данных
    /// <summary>
    /// Перечисление базовых форматов экспорта данных сущностей
    /// </summary>
    public enum eExportMode
    {
        /// <summary>
        /// Экспорт в формате доступном для импорта
        /// </summary>
        ImportReport = 0,
        /// <summary>
        /// Экспорт в формате простого списка
        /// </summary>
        SimplyReport = 1,
        /// <summary>
        /// Экспорт в формаие расширенного списка со свойствами
        /// </summary>
        AdvancedReport = 2,
        /// <summary>
        /// Экспорт в формате табличного представления
        /// </summary>
        TableReport = 3,
        /// <summary>
        /// Экспорт в формате представления
        /// </summary>
        ViewReport = 4
    }

    /// <summary>
    /// Перечисление команд экспорта данных
    /// </summary>
    internal enum eCommandExport
    {
        /// <summary>
        /// Обобщенная строковая команда экспорта
        /// </summary>
        ExportStringCommand,
        /// <summary>
        /// Команда экспорта активных классов со свойствами по абстрактному классу носителю
        /// </summary>
        ExportClassActWithProp_by_id_parent,
        /// <summary>
        /// Команда экспорта активных классов со свойствами по группе носителю
        /// </summary>
        ExportClassActWithProp_by_id_group,
        /// <summary>
        /// Рекурсивная команда экспорта активных вещественных классов со свойствами по абстрактному классу носителю
        /// </summary>
        ExportClassActRealWithProp_by_id_parent,
        /// <summary>
        /// Рекурсивная команда экспорта активных вещественных классов со свойствами по группе носителю
        /// </summary>
        ExportClassActRealWithProp_by_id_group,
        /// <summary>
        /// Команда экспорта обобщенного представления вложенных объектов по позиции носителю
        /// </summary>
        ExportObjectGeneral_by_id_pos,
        /// <summary>
        /// Команда экспорта расширенного представления вложенных объектов по позиции носителю
        /// </summary>
        ExportObjectWithProp_by_id_pos,

        /// <summary>
        /// Команда экспорта расширенного представления вложенных объектов концепции по маске значения глобального свойства
        /// </summary>
        ExportObjectWithProp_by_global_prop_from_con,
        /// <summary>
        /// Команда экспорта расширенного представления вложенных объектов позиции по маске значения глобального свойства
        /// </summary>
        ExportObjectWithProp_by_global_prop_from_pos
    }
    #endregion

    #region Режимы работы менеджера
    /// <summary>
    /// Перечисление Режимов работы менеджера
    /// </summary>
    public enum eManagerMode
    {
        /// <summary>
        /// Основной режим работы менеджера
        /// </summary>
        NormalMode = 1,
        /// <summary>
        /// Отладочный режим работы менеджера
        /// </summary>
        DebugMode = 2
    }
    #endregion

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
        /// Соотвествует шаблону
        /// </summary>
        like,
        /// <summary>
        /// Соотвествует шаблону без учета регистра
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
