using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace pg_class
{
    partial class manager
    {
        #region ФУНКЦИИ СОПОСТАВЛЕНИЯ ТИПОВ ДАННЫХ Postgre SQL и .NET
        /// <summary>
        /// Функция определяет тип данных net столбца таблицы
        /// </summary>
        private Type Name_To_Type(String NameType, String CategoryType = "S")
        {
            Type ResType = null;
            if (CategoryType == "A")

            {
                ResType = typeof(System.Array);
            }
            else
            {
                switch (NameType)
                {
                    case "int2":
                        ResType = typeof(Int16);
                        break;
                    case "int4":
                        ResType = typeof(Int32);
                        break;
                    case "int8":
                        ResType = typeof(Int64);
                        break;
                    case "varchar":
                        ResType = typeof(String);
                        break;
                    case "name":
                        ResType = typeof(String);
                        break;
                    case "uuid":
                        ResType = typeof(String);
                        break;
                    case "numeric":
                        ResType = typeof(Decimal);
                        break;
                    case "bool":
                        ResType = typeof(Boolean);
                        break;
                    case "text":
                        ResType = typeof(String);
                        break;
                    case "oid":
                        ResType = typeof(UInt32);
                        break;
                    case "bytea":
                        ResType = typeof(Byte[]);
                        break;
                    case "json":
                        ResType = typeof(String);
                        break;
                    case "money":
                        ResType = typeof(Decimal);
                        break;
                    case "time":
                        ResType = typeof(TimeSpan);
                        break;
                    case "float4":
                        ResType = typeof(Single);
                        break;
                    case "float8":
                        ResType = typeof(Double);
                        break;
                    case "date":
                        ResType = typeof(DateTime);
                        break;
                    case "timestamp":
                        ResType = typeof(DateTime);
                        break;
                    case "interval":
                        ResType = typeof(TimeSpan);
                        break;
                    case "argument":
                        ResType = typeof(pg_argument);
                        break;
                    case "tblcol2":
                        ResType = typeof(pg_tblcol2);
                        break;
                    case "errarg2":
                        ResType = typeof(pg_errarg2);
                        break;
                    case "cclass_prop":
                        ResType = typeof(pg_vclass_prop);
                        break;
                    case "cobject_prop":
                        ResType = typeof(pg_vobject_prop);
                        break;
                    case "cdoc_file":
                        ResType = typeof(pg_vdoc_file);
                        break;
                    case "cdoc_link":
                        ResType = typeof(pg_vdoc_link);
                        break;
                    case "cdoc_category":
                        ResType = typeof(pg_vdoc_category);
                        break;
                    case "day_type":
                        ResType = typeof(pg_day_type);
                        break;
                    case "range_work_type":
                        ResType = typeof(pg_range_work_type);
                        break;
                    case "range_work_state":
                        ResType = typeof(pg_range_work_state);
                        break;
                    case "tsrange":
                        ResType = typeof(NpgsqlRange<DateTime>);
                        break;
                    default:
                        ResType = typeof(String);
                        break;
                }
            }
            return ResType;
        }

        /// <summary>
        /// Функция определяет тип данных параметра функции
        /// </summary>
        private NpgsqlTypes.NpgsqlDbType Name_To_NpgsqlType(String NameType)
        {
            NpgsqlTypes.NpgsqlDbType Result = NpgsqlTypes.NpgsqlDbType.Varchar;
            NpgsqlTypes.NpgsqlDbType TValue;
            if (Dictionary_Name_To_NpgsqlType.TryGetValue(NameType, out TValue))
                Result = TValue;
            return Result;
        }

        private static readonly Dictionary<String, NpgsqlTypes.NpgsqlDbType> Dictionary_Name_To_NpgsqlType = new Dictionary<String, NpgsqlTypes.NpgsqlDbType>()
        {
            { "int2", NpgsqlDbType.Smallint },
            { "int4", NpgsqlDbType.Integer },
            { "int8", NpgsqlDbType.Bigint },
            { "varchar", NpgsqlDbType.Varchar },
            { "name", NpgsqlDbType.Name },
            { "numeric", NpgsqlDbType.Numeric },
            { "bool", NpgsqlDbType.Boolean },
            { "text", NpgsqlDbType.Text },
            { "oid", NpgsqlDbType.Oid },
            { "bytea", NpgsqlDbType.Bytea },
            { "json", NpgsqlDbType.Json },
            { "jsonb", NpgsqlDbType.Jsonb },
            { "array", NpgsqlDbType.Array },
            { "money", NpgsqlDbType.Money },
            { "time", NpgsqlDbType.Time },
            { "float4", NpgsqlDbType.Real },
            { "float8", NpgsqlDbType.Double },
            { "date", NpgsqlDbType.Date },
            { "timestamp", NpgsqlDbType.Timestamp },
            { "timestamptz", NpgsqlDbType.TimestampTz },
            { "interval", NpgsqlDbType.Interval },
            {"int4range" , NpgsqlDbType.Range | NpgsqlDbType.Integer},
            {"int8range" , NpgsqlDbType.Range | NpgsqlDbType.Bigint},
            {"numrange" , NpgsqlDbType.Range | NpgsqlDbType.Numeric},
            { "tsrange", NpgsqlDbType.Range | NpgsqlDbType.Timestamp},
            {"tstzrange" , NpgsqlDbType.Range | NpgsqlDbType.TimestampTz},
            {"daterange" , NpgsqlDbType.Range | NpgsqlDbType.Date},

            { "_int2", NpgsqlDbType.Array | NpgsqlDbType.Smallint },
            { "_int4", NpgsqlDbType.Array | NpgsqlDbType.Integer },
            { "_int8", NpgsqlDbType.Array | NpgsqlDbType.Bigint },
            { "_varchar", NpgsqlDbType.Array | NpgsqlDbType.Varchar },
            { "_name", NpgsqlDbType.Array | NpgsqlDbType.Name },
            { "_numeric", NpgsqlDbType.Array | NpgsqlDbType.Numeric },
            { "_bool", NpgsqlDbType.Array | NpgsqlDbType.Boolean },
            { "_text", NpgsqlDbType.Array | NpgsqlDbType.Text },
            { "_oid", NpgsqlDbType.Array | NpgsqlDbType.Oid },
            { "_json", NpgsqlDbType.Array |  NpgsqlDbType.Json },
            { "_jsonb", NpgsqlDbType.Array| NpgsqlDbType.Jsonb  },
            { "_money", NpgsqlDbType.Array | NpgsqlDbType.Money },
            { "_time", NpgsqlDbType.Array | NpgsqlDbType.Time },
            { "_float4", NpgsqlDbType.Array | NpgsqlDbType.Real },
            { "_float8", NpgsqlDbType.Array | NpgsqlDbType.Double },
            { "_date", NpgsqlDbType.Array | NpgsqlDbType.Date },
            { "_timestamp", NpgsqlDbType.Array | NpgsqlDbType.Timestamp },
            { "_timestamptz", NpgsqlDbType.Array | NpgsqlDbType.TimestampTz },
            { "_interval", NpgsqlDbType.Array | NpgsqlDbType.Interval }
        };

        //***********************************************
            /// <summary>
            /// Функция определяет тип данных свойства в среде Postgre SQL
            /// </summary>
        public NpgsqlTypes.NpgsqlDbType DataTypeNpgsql(eDataType Datatype)
        {
            NpgsqlTypes.NpgsqlDbType Result = NpgsqlTypes.NpgsqlDbType.Unknown;
            NpgsqlTypes.NpgsqlDbType TValue;
            if (Dictionary_DataTypeNpgsql.TryGetValue(Datatype, out TValue))
                Result = TValue;
            return Result;
        }
        private static readonly Dictionary<eDataType, NpgsqlTypes.NpgsqlDbType> Dictionary_DataTypeNpgsql = new Dictionary<eDataType, NpgsqlTypes.NpgsqlDbType>()
        {
            { eDataType.val_varchar, NpgsqlTypes.NpgsqlDbType.Varchar },
            { eDataType.val_int, NpgsqlTypes.NpgsqlDbType.Integer },
            { eDataType.val_numeric, NpgsqlTypes.NpgsqlDbType.Numeric },
            { eDataType.val_real, NpgsqlTypes.NpgsqlDbType.Real },
            { eDataType.val_double, NpgsqlTypes.NpgsqlDbType.Double },
            { eDataType.val_money, NpgsqlTypes.NpgsqlDbType.Money },
            { eDataType.val_text, NpgsqlTypes.NpgsqlDbType.Text },
            { eDataType.val_bytea, NpgsqlTypes.NpgsqlDbType.Bytea },
            { eDataType.val_boolean, NpgsqlTypes.NpgsqlDbType.Boolean },
            { eDataType.val_date, NpgsqlTypes.NpgsqlDbType.Date },
            { eDataType.val_time, NpgsqlTypes.NpgsqlDbType.Time },
            { eDataType.val_interval, NpgsqlTypes.NpgsqlDbType.Interval },
            { eDataType.val_timestamp, NpgsqlTypes.NpgsqlDbType.Timestamp },
            { eDataType.val_json, NpgsqlTypes.NpgsqlDbType.Json },
            { eDataType.val_bigint, NpgsqlTypes.NpgsqlDbType.Bigint }
        };

        ///////**************************
            /// <summary>
            /// Функция определяет тип данных свойства в среде .Net 
            /// </summary>
        public eDataTypeNet DataTypeNet(eDataType Datatype)
        {
            eDataTypeNet Result = eDataTypeNet.Object;
            eDataTypeNet TValue;
            if (Dictionary_DataTypeNet.TryGetValue(Datatype, out TValue))
                Result = TValue;
            return Result;
        }

        private static readonly Dictionary<eDataType, eDataTypeNet> Dictionary_DataTypeNet = new Dictionary<eDataType, eDataTypeNet>() 
        {
            { eDataType.val_varchar, eDataTypeNet.String },
            { eDataType.val_int, eDataTypeNet.Int32 },
            { eDataType.val_numeric, eDataTypeNet.Decimal },
            { eDataType.val_real, eDataTypeNet.Single },
            { eDataType.val_double, eDataTypeNet.Double },
            { eDataType.val_money, eDataTypeNet.Decimal },
            { eDataType.val_text, eDataTypeNet.String },
            { eDataType.val_bytea, eDataTypeNet.ByteArray },
            { eDataType.val_boolean, eDataTypeNet.Boolean },
            { eDataType.val_date, eDataTypeNet.DateTime },
            { eDataType.val_time, eDataTypeNet.TimeSpan },
            { eDataType.val_interval, eDataTypeNet.TimeSpan },
            { eDataType.val_timestamp, eDataTypeNet.DateTime },
            { eDataType.val_json, eDataTypeNet.String },
            { eDataType.val_bigint, eDataTypeNet.Int64 }
        };

        #endregion

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

        #region Обработка ошибок методов БД

        /// <summary>
        /// Функция определяющая базовый код ошибки сущности
        /// </summary>
        public static eEntity_ErrID Entity_To_ErrID(eEntity Entity)
        {
            eEntity_ErrID Result = eEntity_ErrID.entity;
            eEntity_ErrID TValue;
            if (Dictionary_Entity_To_ErrID.TryGetValue(Entity, out TValue))
                Result = TValue;
            return Result;
        }
        private static readonly Dictionary<eEntity, eEntity_ErrID> Dictionary_Entity_To_ErrID = new Dictionary<eEntity, eEntity_ErrID>()
        {
            { eEntity.entity, eEntity_ErrID.entity },
            { eEntity.pos_prototype, eEntity_ErrID.pos_prototype },
            { eEntity.conception, eEntity_ErrID.conception },
            { eEntity.pos_temp, eEntity_ErrID.pos_temp },
            { eEntity.position, eEntity_ErrID.position },
            { eEntity.vector, eEntity_ErrID.vector },
            { eEntity.link_obj_pos, eEntity_ErrID.link_obj_pos },
            { eEntity.role_base, eEntity_ErrID.role_base },
            { eEntity.user, eEntity_ErrID.user },
            { eEntity.position_prop, eEntity_ErrID.position_prop },
            { eEntity.pos_temp_prop, eEntity_ErrID.pos_temp_prop },
            { eEntity.pos_temp_enum_prop, eEntity_ErrID.pos_temp_enum_prop },
            { eEntity.ticket, eEntity_ErrID.ticket },
            { eEntity.message, eEntity_ErrID.message },
            { eEntity.ticket_prop, eEntity_ErrID.ticket_prop },
            { eEntity.mes_prop, eEntity_ErrID.mes_prop },
            { eEntity.property, eEntity_ErrID.property },
            { eEntity.group, eEntity_ErrID.group },
            { eEntity.vclass, eEntity_ErrID.vclass },
            { eEntity.class_prop, eEntity_ErrID.class_prop},
            { eEntity.vobject, eEntity_ErrID.vobject },
            { eEntity.rulel1_group_on_pos_temp, eEntity_ErrID.rulel1_group_on_pos_temp },
            { eEntity.rulel2_class_on_position, eEntity_ErrID.rulel2_class_on_position },
            { eEntity.pos_temp_nested_rule, eEntity_ErrID.pos_temp_nested_rule },
            { eEntity.unit, eEntity_ErrID.unit },
            { eEntity.unit_conversion_rule, eEntity_ErrID.unit_conversion_rule },
            { eEntity.class_unit_conversion_rule, eEntity_ErrID.class_unit_conversion_rule },
            { eEntity.class_prop_object_val, eEntity_ErrID.class_prop_object_val },
            { eEntity.object_prop_object_val, eEntity_ErrID.object_prop_object_val },
            { eEntity.rulel1_group_on_pos_temp_access, eEntity_ErrID.rulel1_group_on_pos_temp_access },
            { eEntity.rulel2_class_snapshot_on_position, eEntity_ErrID.rulel2_class_snapshot_on_position },
            { eEntity.prop_data_type, eEntity_ErrID.prop_data_type },
            { eEntity.con_prop_data_type, eEntity_ErrID.con_prop_data_type },
            { eEntity.prop_type, eEntity_ErrID.prop_type },
            { eEntity.prop_data_bin_ext, eEntity_ErrID.prop_data_bin_ext },
            { eEntity.object_prop, eEntity_ErrID.object_prop },
            { eEntity.class_prop_user_val, eEntity_ErrID.class_prop_user_val },
            { eEntity.class_prop_enum_val, eEntity_ErrID.class_prop_enum_val },
            { eEntity.object_prop_user_val, eEntity_ErrID.object_prop_user_val },
            { eEntity.object_prop_enum_val, eEntity_ErrID.object_prop_enum_val },
            { eEntity.prop_val_spec, eEntity_ErrID.prop_val_spec },
            { eEntity.prop_enum, eEntity_ErrID.prop_enum },
            { eEntity.prop_enum_val, eEntity_ErrID.prop_enum_val },
            { eEntity.class_prop_link_val, eEntity_ErrID.class_prop_link_val },
            { eEntity.object_prop_link_val, eEntity_ErrID.object_prop_link_val },
            { eEntity.global_prop, eEntity_ErrID.global_prop },
            { eEntity.global_prop_link_class_prop, eEntity_ErrID.global_prop_link_class_prop },
            { eEntity.global_prop_link_pos_temp_prop, eEntity_ErrID.global_prop_link_pos_temp_prop },
            { eEntity.pos_temp_prop_user_val, eEntity_ErrID.pos_temp_prop_user_val },
            { eEntity.pos_temp_prop_enum_val, eEntity_ErrID.pos_temp_prop_enum_val },
            { eEntity.pos_temp_prop_object_val, eEntity_ErrID.pos_temp_prop_object_val },
            { eEntity.pos_temp_prop_link_val, eEntity_ErrID.pos_temp_prop_link_val },
            { eEntity.position_prop_user_val, eEntity_ErrID.position_prop_user_val },
            { eEntity.position_prop_enum_val, eEntity_ErrID.position_prop_enum_val },
            { eEntity.position_prop_object_val, eEntity_ErrID.position_prop_object_val },
            { eEntity.position_prop_link_val, eEntity_ErrID.position_prop_link_val },
            { eEntity.global_prop_area_val, eEntity_ErrID.global_prop_area_val },
            { eEntity.document, eEntity_ErrID.document },
            { eEntity.doc_file, eEntity_ErrID.doc_file },
            { eEntity.doc_link, eEntity_ErrID.doc_link },
            { eEntity.doc_category, eEntity_ErrID.doc_category },
            { eEntity.manager, eEntity_ErrID.manager },
            { eEntity.pool, eEntity_ErrID.pool },
            { eEntity.connect, eEntity_ErrID.connect },
            { eEntity.procedure_export, eEntity_ErrID.procedure_export },
            { eEntity.plan_calendar, eEntity_ErrID.plan_calendar },
            { eEntity.plan, eEntity_ErrID.plan },
            { eEntity.plan_link, eEntity_ErrID.plan_link },
            { eEntity.plan_range, eEntity_ErrID.plan_range },
            { eEntity.plan_range_link, eEntity_ErrID.plan_range_link },
            { eEntity.plan_given_range_plan, eEntity_ErrID.plan_given_range_plan },
            { eEntity.plan_given_range_plan_link, eEntity_ErrID.plan_given_range_plan_link },
            { eEntity.plan_given_range_fact, eEntity_ErrID.plan_given_range_fact },
            { eEntity.plan_given_range_fact_link, eEntity_ErrID.plan_given_range_fact_link },
            { eEntity.plan_transfer_day, eEntity_ErrID.plan_transfer_day },
            { eEntity.plan_holiday, eEntity_ErrID.plan_holiday },
            { eEntity.role_user, eEntity_ErrID.role_user },
            { eEntity.rulel1_class_on_pos_temp, eEntity_ErrID.rulel1_class_on_pos_temp },
            { eEntity.rulel1_class_on_pos_temp_access, eEntity_ErrID.rulel1_class_on_pos_temp_access },
            { eEntity.plan_rule_crossing, eEntity_ErrID.plan_rule_crossing },
            { eEntity.plan_rule_crossing_link, eEntity_ErrID.plan_rule_crossing_link },
            { eEntity.plan_rule_nesting, eEntity_ErrID.plan_rule_nesting },
            { eEntity.plan_rule_nesting_link, eEntity_ErrID.plan_rule_nesting_link },

        };


        /// <summary>
        /// Описания ошибок
        /// </summary>
        public static String SubClass_ErrDesc(eSubClass_ErrID SubClass_ErrID)
        {
            String Result = "Без описания";

            switch (SubClass_ErrID)
            {
                case eSubClass_ErrID.SCE0_Unknown_Error:
                    Result = "Неизвестная ошибка";
                    break;
                case eSubClass_ErrID.SCE1_NonExistent_Entity:
                    Result = "Несуществующая сущность";
                    break;
                case eSubClass_ErrID.SCE2_Violation_Unique:
                    Result = "Нарушение уникальности";
                    break;
                case eSubClass_ErrID.SCE3_Violation_Rules:
                    Result = "Нарушение правил или ограничений";
                    break;
                case eSubClass_ErrID.SCE4_Violation_Rules_Nesting:
                    Result = "Нарушение правил вложенности";
                    break;
                case eSubClass_ErrID.SCE5_Violation_Limitations_Nesting:
                    Result = "Нарушение ограничений вложенности";
                    break;
                case eSubClass_ErrID.SCE6_Over_Limitations_Nesting:
                    Result = "Превышение ограничения вложенности";
                    break;
                case eSubClass_ErrID.SCE7_NonExistent_Inherited_Entity:
                    Result = "Несуществующая наследуемая сущность";
                    break;
                case eSubClass_ErrID.SCE8_NonExistent_Parental_Entity:
                    Result = "Несуществующая родительская сущность";
                    break;
                case eSubClass_ErrID.SCE9_Out_Of_Range:
                    Result = "Выход за пределы допустимых значений";
                    break;
                case eSubClass_ErrID.SCE10_NonExistent_Source_Entity:
                    Result = "Несуществующая исходная сущность";
                    break;
            }
            return Result;
        }
        #endregion

        #region Функции экспорта/импорта данных
        /// <summary>
        /// Описание режима базового экспорта данных
        /// </summary>
        public static String ExportMode(eExportMode ExportMode)
        {
            String mode = "Таблица";
            switch (ExportMode)
            {
                case eExportMode.ImportReport:
                    mode = "Экспорт в формате доступном для импорта";
                    break;
                case eExportMode.SimplyReport:
                    mode = "Экспорт в формате простого списка";
                    break;
                case eExportMode.AdvancedReport:
                    mode = "Экспорт в формаие расширенного списка со свойствами";
                    break;
                case eExportMode.TableReport:
                    mode = "Экспорт в формате таблицы";
                    break;
                case eExportMode.ViewReport:
                    mode = "Экспорт в формате представления";
                    break;
            }
            return mode;
        }
        #endregion

        #region Функции сопоставления методов поиска и его пользовательского представления

        /// <summary>
        /// Пользовательское представление символьного обозначения метода поиска
        /// </summary>    
        public static String SearchMethodsToString(eSearchMethods SearchMethods)
        {
            String Result = "?";
            String TValue;
            if (Dictionary_SearchMethods.TryGetValue(SearchMethods, out TValue))
                Result = TValue;
            return Result;
        }

        private static readonly Dictionary<eSearchMethods, string> Dictionary_SearchMethods = new Dictionary<eSearchMethods, String>()
        {
            { eSearchMethods.equal, Convert.ToString((char)61)},
            { eSearchMethods.not_equal, Convert.ToString((char)8800)},

            { eSearchMethods.less, Convert.ToString((char)60)},
            { eSearchMethods.less_or_equal, Convert.ToString((char)8804)},
            { eSearchMethods.more, Convert.ToString((char)62)},
            { eSearchMethods.more_or_equal, Convert.ToString((char)8805)},

            { eSearchMethods.more_and_less, Convert.ToString((char)60)+ ".." + Convert.ToString((char)60)},
            { eSearchMethods.more_and_less_or_equal, Convert.ToString((char)60) + ".." + Convert.ToString((char)8804)},
            { eSearchMethods.more_or_equal_and_less, Convert.ToString((char)8804) + ".." + Convert.ToString((char)60)},
            { eSearchMethods.more_or_equal_and_less_or_equal, Convert.ToString((char)8804) + ".." + Convert.ToString((char)8804)},

            { eSearchMethods.like, Convert.ToString((char)8838)},
            { eSearchMethods.like_lower, Convert.ToString((char)8838) + (char)8595},

            { eSearchMethods.any_array, Convert.ToString((char)8834)},
            { eSearchMethods.not_any_array, Convert.ToString((char)8836)},
        };

        /// <summary>
        /// Пользовательское описание символьного обозначения метода поиска
        /// </summary>    
        public static String SearchMethodsToDescription(eSearchMethods SearchMethods)
        {
            String Result = "?";
            String TValue;
            if (Dictionary_SearchMethodsDescription.TryGetValue(SearchMethods, out TValue))
                Result = TValue;
            return Result;
        }

        /// <summary>
        /// Пользовательское описание символьного обозначения метода поиска
        /// </summary>    
        private static readonly Dictionary<eSearchMethods, string> Dictionary_SearchMethodsDescription = new Dictionary<eSearchMethods, String>()
        {
            { eSearchMethods.equal, "Равно" },
            { eSearchMethods.not_equal, "Не равно"},

            { eSearchMethods.less, "Меньше"},
            { eSearchMethods.less_or_equal, "Меньше или равно"},
            { eSearchMethods.more, "Больше"},
            { eSearchMethods.more_or_equal, "Больше или равно"},

            { eSearchMethods.more_and_less, "Больше, меньше"},
            { eSearchMethods.more_and_less_or_equal, "Больше, меньше или равно"},
            { eSearchMethods.more_or_equal_and_less, "Больше или равно, меньше"},
            { eSearchMethods.more_or_equal_and_less_or_equal, "Больше или равно, меньше или равно"},

            { eSearchMethods.like, "Соответствует маске"},
            { eSearchMethods.like_lower, "Не соответствует маске"},

            { eSearchMethods.any_array, "Соответствует значениям"},
            { eSearchMethods.not_any_array, "Не соответствует значениям"},
        };

        #endregion
    }
}
