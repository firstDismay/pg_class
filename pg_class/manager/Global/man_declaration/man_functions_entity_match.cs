using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace pg_class
{
    partial class manager
    {
        #region ФУНКЦИИ СОПОСТАВЛЕНИЯ СУЩНОСТЕЙ Postgre SQL и .NET

        /// <summary>
        /// Нименовании сущности по данным перечисления типа сущности
        /// </summary>    
        public static String EntityName(eEntity EntityType)
        {
            String Result = "неизвестная сущность";
            String TValue;
            if (Dictionary_EntityName.TryGetValue(EntityType, out TValue))
                Result = TValue;
            return Result;
        }
        private static readonly Dictionary<eEntity, string> Dictionary_EntityName = new Dictionary<eEntity, String>()
        {
            { eEntity.entity, "Сущность"},
            { eEntity.pos_prototype, "Прототип позиции"},
            { eEntity.conception, "Концепция"},
            { eEntity.pos_temp, "Шаблон"},
            { eEntity.position, "Позиция"},
            { eEntity.vector, "Вектор"},
            { eEntity.link_obj_pos, "Ссылка на объект"},
            { eEntity.role_base, "Базовая роль"},
            { eEntity.user, "Пользователь"},
            { eEntity.position_prop, "Свойство позиции"},
            { eEntity.pos_temp_prop, "Свойство шаблона"},
            { eEntity.pos_temp_enum_prop, "Перечисление значений свойства"},
            { eEntity.ticket, "Тема форума поддержки"},
            { eEntity.message, "Сообщение форума поддержки"},
            { eEntity.ticket_prop, "Свойство темы форума поддержки"},
            { eEntity.mes_prop, "Свойство сообщения форума поддержки"},
            { eEntity.property, "Свойство"},
            { eEntity.group, "Группа"},
            { eEntity.vclass, "Класс"},
            { eEntity.class_prop, "Свойство класса"},
            { eEntity.vobject, "Объект"},
            { eEntity.rulel1_group_on_pos_temp, "Правило вложенности уровня 1 группа на шаблон позиции"},
            { eEntity.rulel2_class_on_position, "Правило вложенности уровня 2 класс на позицию"},
            { eEntity.pos_temp_nested_rule, "Правило вложенности шаблонов позиций"},
            { eEntity.unit, "Единицы измерения величин и правила пересчета"},
            { eEntity.unit_conversion_rule, "Правило пересчета колличества объектов"},
            { eEntity.class_unit_conversion_rule, "Правило назначения правил пересчета объектов вещественного класса"},
            { eEntity.class_prop_object_val, "Данные значение объектного свойства класса"},
            { eEntity.object_prop_object_val, "Значение объектного свойства объекта"},
            { eEntity.rulel1_group_on_pos_temp_access, "Разрешение правила вложенности уровня 1 группа на шаблон позиции"},
            { eEntity.rulel2_class_snapshot_on_position, "Разрешение правила вложенности уровня 2 снимок класса на позицию"},
            { eEntity.prop_data_type, "Тип данных"},
            { eEntity.con_prop_data_type, "Тип данных концепции"},
            { eEntity.prop_type, "Тип свойства"},
            { eEntity.prop_data_bin_ext, "Расширение двоичного типа данных свойства"},
            { eEntity.object_prop, "Свойство объекта"},
            { eEntity.class_prop_user_val, "Данные значения пользовательского свойства класса"},
            { eEntity.class_prop_enum_val, "Данные значения свойства-перечисления класса"},
            { eEntity.object_prop_user_val, "Данные значения свойства-пользовательского объекта"},
            { eEntity.object_prop_enum_val, "Данные значения свойства-перечисления объекта"},
            { eEntity.prop_val_spec, "Спецификатор значения свойства"},
            { eEntity.prop_enum, "Перечисление"},
            { eEntity.prop_enum_val, "Элемент перечисления"},
            { eEntity.class_prop_link_val, "Данные значения свойства-ссылки класса"},
            { eEntity.object_prop_link_val, "Данные значения свойства-ссылки объекта"},
            { eEntity.global_prop, "Глобальное свойство концепции"},
            { eEntity.global_prop_link_class_prop, "Ссылка глобального свойства  на определяющее свойство класса"},
            { eEntity.global_prop_link_pos_temp_prop, "Ссылка глобального свойства  на свойство шаблона позиции"},
            { eEntity.pos_temp_prop_user_val, "Данные значения пользовательского свойства шаблона"},
            { eEntity.pos_temp_prop_enum_val, "Данные значения свойства-перечисления шаблона"},
            { eEntity.pos_temp_prop_object_val, "Данные значение объектного свойства шаблона"},
            { eEntity.pos_temp_prop_link_val, "Данные значения свойства-ссылки шаблона"},
            { eEntity.position_prop_user_val, "Данные значения пользовательского свойства позиции"},
            { eEntity.position_prop_enum_val, "Данные значения свойства-перечисления позиции"},
            { eEntity.position_prop_object_val, "Данные значение объектного свойства позиции"},
            { eEntity.position_prop_link_val, "Данные значения свойства-ссылки позиции"},
            { eEntity.global_prop_area_val, "Данные области значения глобального свойства"},
            { eEntity.document, "Документ библиотеки документов"},
            { eEntity.doc_file, "Файл документа"},
            { eEntity.doc_link, "Ссылка документа"},
            { eEntity.doc_category, "Категория документа"},
            { eEntity.manager, "Базовый класс доступа к данным"},
            { eEntity.pool, "Пул соединений менеджера данных"},
            { eEntity.connect, "Соединение пула соединений"},
            { eEntity.procedure_export, "Процедура экспорта"},
            { eEntity.plan_calendar, "Производственный календарь"},
            { eEntity.plan, "План"},
            { eEntity.plan_link, "Ссылка плана"},
            { eEntity.plan_range, "Диапазон плана запланированный"},
            { eEntity.plan_range_link, "Ссылка диапазона плана"},
            { eEntity.plan_given_range_plan, "Выданный диапазон плана"},
            { eEntity.plan_given_range_plan_link, "Ссылка на плановый диапазон расписания на вид работы"},
            { eEntity.plan_given_range_fact, "Фактический диапазон расписания на вид работы"},
            { eEntity.plan_given_range_fact_link, "Ссылка фактический диапазон расписания на вид работы"},
            { eEntity.plan_transfer_day, "Перенесенный по указу правителсьтва РФ день"},
            { eEntity.plan_holiday, "Праздничный день или каникулы"},
            { eEntity.role_user, "Роль пользователя"},
            { eEntity.rulel1_class_on_pos_temp, "Правило вложенности уровня 1 класс на шаблон позиции"},
            { eEntity.rulel1_class_on_pos_temp_access, "Разрешение правила вложенности уровня 1 группа на шаблон позиции"},
            { eEntity.plan_rule_crossing, "Правило пересечения диапазонов подчиненных планов"},
            { eEntity.plan_rule_crossing_link, "Ссылка правила пересечения диапазонов подчиненных планов"},
            { eEntity.plan_rule_nesting, "Правило вложенности диапазонов подчиненных планов"},
            { eEntity.plan_rule_nesting_link, "Ссылка правила вложенности диапазонов подчиненных планов"},
			{ eEntity.log, "Запись журнала событий"},
			{ eEntity.log_category, "Категория записи журнала событий"},
			{ eEntity.log_link, "Ссылка записи журнала событий"},

		};

        /// <summary>
        /// Текстовое описание операции по данным перечисления типов операций
        /// </summary>
        public static String ActionDesc(eAction Action)
        {
            String Result = "Неизвестное действие";
            String TValue;
            if (Dictionary_ActionDesc.TryGetValue(Action, out TValue))
                Result = TValue;
            return Result;
        }
        private static readonly Dictionary<eAction, string> Dictionary_ActionDesc = new Dictionary<eAction, String>()
        {
            { eAction.Copy, "Копирование"},
            { eAction.Delete, "Удаление" },
            { eAction.Insert, "Добавление" },
            { eAction.Insert_mass, "Добавление массовое" },
            { eAction.Lock, "Блокировка" },
            { eAction.Move, "Перемещение" },
            { eAction.Select, "Выборка" },
            { eAction.UnLock, "Разблокировка" },
            { eAction.Update, "Обновление" },
            { eAction.Execute, "Выполнение функции" },
            { eAction.Connect, "Подключен к базе" },
            { eAction.ReConnect, "Переподключение к базе" },
            { eAction.DisConnect, "Отключен от базы" },
            { eAction.Init, "Инициализация" },
            { eAction.Clone, "Клонирование" },
            { eAction.RollBack, "Отмена" },
            { eAction.Clear, "Очистка" },
            { eAction.Cast, "Приведение" },
            { eAction.Merging, "Слияние" },
            { eAction.Include, "Включение" },
            { eAction.Exclude, "Исключение" },
            { eAction.Restore, "Восстановление" }
        };

        #endregion
    }
}
