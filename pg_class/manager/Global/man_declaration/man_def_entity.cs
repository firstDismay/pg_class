using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pg_class
{
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
        plan_rule_nesting_link = 120,
		/// <summary>
		/// Запись журнала событий
		/// </summary>
		log = 121,
		/// <summary>
		/// Категория записи журнала событий
		/// </summary>
		log_category = 122,
		/// <summary>
		/// Ссылка записи журнала событий
		/// </summary>
		log_link = 123
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
}
