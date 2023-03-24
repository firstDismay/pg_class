namespace pg_class
{
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
        plan_rule_nesting_link = 22000000,
        /// <summary>
        /// Запись журнала событий
        /// </summary>
        log = 22100000,
        /// <summary>
        /// Категория записи журнала событий
        /// </summary>
        log_category = 22200000,
        /// <summary>
        /// Ссылка записи журнала событий
        /// </summary>
        log_link = 22300000
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
}
