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
            { eEntity.conception, "Концепция"},
            { eEntity.user, "Пользователь" },
            { eEntity.role_base, "Базовая роль" },
            { eEntity.unit, "Единица измерения" },
            { eEntity.unit_conversion_rule, "Правило пересчета" },
            { eEntity.class_unit_conversion_rule, "Правило назначения правил пересчета объектов вещественного класса" },
            { eEntity.pos_temp_nested_rule, "Правило вложенности шаблонов позиций" },
            { eEntity.rulel1_class_on_pos_temp, "Правило вложенности уровня 1 класс на шаблон позиции" },
            { eEntity.rulel1_group_on_pos_temp, "Правило вложенности уровня 1 группа на шаблон позиции" },
            { eEntity.rulel2_class_on_position, "Правило вложенности уровня 2 класс на позицию" },
            { eEntity.rulel1_group_on_pos_temp_access, "Разрешение правила вложенности уровня 1 группа на шаблон позиции" },
            { eEntity.rulel1_class_on_pos_temp_access, "Разрешение правила вложенности уровня 1 класс на шаблон позиции" },
            { eEntity.rulel2_class_snapshot_on_position, "Разрешение правила вложенности уровня 2 снимок класса на позицию" },
            { eEntity.prop_data_type, "Тип данных" },
            { eEntity.con_prop_data_type, "Тип данных концепции" },
            { eEntity.prop_enum, "Перечисление" },
            { eEntity.prop_enum_val, "Элемент перечисления" },
            { eEntity.group, "Группа библиотеки" },
            { eEntity.vclass, "Класс" },
            { eEntity.class_prop, "Свойство класса" },
            { eEntity.class_prop_user_val, "Данные значения пользовательского свойства класса" },
            { eEntity.class_prop_enum_val, "Данные значения свойства-перечисления класса" },
            { eEntity.class_prop_object_val, "Данные значение объектного свойства класса" },
            { eEntity.class_prop_link_val, "Данные значения свойства-ссылки класса" },
            { eEntity.pos_prototype, "Прототип" },
            { eEntity.pos_temp, "Шаблон" },
            { eEntity.pos_temp_prop, "Свойство шаблона" },
            { eEntity.pos_temp_prop_user_val, "Данные значения пользовательского свойства шаблона" },
            { eEntity.pos_temp_prop_enum_val, "Данные значения свойства-перечисления шаблона" },
            { eEntity.pos_temp_prop_object_val, "Данные значение объектного свойства шаблона" },
            { eEntity.pos_temp_prop_link_val, "Данные значения свойства-ссылки шаблона" },
            { eEntity.position, "Позиция" },
            { eEntity.position_prop, "Свойство позиции" },
            { eEntity.position_prop_user_val, "Данные значения пользовательского свойства позиции" },
            { eEntity.position_prop_enum_val, "Данные значения свойства-перечисления позиции" },
            { eEntity.position_prop_object_val, "Данные значение объектного свойства позиции" },
            { eEntity.position_prop_link_val, "Данные значения свойства-ссылки позиции" },
            { eEntity.vobject, "Объект" },
            { eEntity.object_prop, "Свойство объекта" },
            { eEntity.object_prop_user_val, "Данные значения свойства-пользовательского объекта" },
            { eEntity.object_prop_enum_val, "Данные значения свойства-перечисления объекта" },
            { eEntity.object_prop_object_val, "Данные значение объектного свойства объекта" },
            { eEntity.object_prop_link_val, "Данные значения свойства-ссылки объекта" },
            { eEntity.global_prop, "Глобальное свойство концепции" },
            { eEntity.global_prop_link_class_prop, "Ссылка глобального свойства  на определяющее свойство класса" },
            { eEntity.global_prop_link_pos_temp_prop, "Ссылка глобального свойства  на свойство шаблона позиции" },

            { eEntity.document, "Документ" },
            { eEntity.doc_file, "Файл документа" },
            { eEntity.doc_link, "Ссылка документа" },
            { eEntity.doc_category, "Категория документа" },
            { eEntity.entity, "Сущность базы данных" },
            { eEntity.manager, "Менеджер данных" },
            { eEntity.pool, "Пул соединений менеджера данных" },
            { eEntity.connect, "Соединение пула соединений" },
            { eEntity.procedure_export, "Процедура экспорта" },
            { eEntity.calendar, "Производственный календарь" },
            { eEntity.work_plan, "Плановый диапазон расписания на вид работы" },
            { eEntity.work_time_link, "Ссылка на общий диапазон рабочего времени расписания" },
            { eEntity.work_time, "Общий диапазон рабочего времени расписания впределах суток или смены" },
            { eEntity.work_fact, "Фактический диапазон расписания на вид работы" },
            { eEntity.transfer_day, "Перенесенный по указу правителсьтва РФ день" },
            { eEntity.work_plan_link, "Ссылка на плановый диапазон расписания на вид работы" },
            { eEntity.work_fact_link, "Ссылка фактический диапазон расписания на вид работы" },
            { eEntity.holiday, "Праздничный день или каникулы" },
            { eEntity.plan, "План" },
            { eEntity.plan_link, "Ссылка плана" },
            { eEntity.role_user, "Роль пользователя" }
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
            eEntity_ErrID Result = eEntity_ErrID.manager;

            switch (Entity)
            {
                case eEntity.entity:
                    Result = eEntity_ErrID.entity;
                    break;
                case eEntity.pos_prototype:
                    Result = eEntity_ErrID.pos_prototype;
                    break;
                case eEntity.conception:
                    Result = eEntity_ErrID.conception;
                    break;
                case eEntity.pos_temp:
                    Result = eEntity_ErrID.pos_temp;
                    break;
                case eEntity.position:
                    Result = eEntity_ErrID.position;
                    break;
                case eEntity.vector:
                    Result = eEntity_ErrID.vector;
                    break;
                case eEntity.link_obj_pos:
                    Result = eEntity_ErrID.link_obj_pos;
                    break;
                case eEntity.role_user:
                    Result = eEntity_ErrID.role_user;
                    break;
                case eEntity.role_base:
                    Result = eEntity_ErrID.role_base;
                    break;
                case eEntity.user:
                    Result = eEntity_ErrID.user;
                    break;
                case eEntity.position_prop:
                    Result = eEntity_ErrID.pos_prop;
                    break;
                case eEntity.pos_temp_prop:
                    Result = eEntity_ErrID.pos_temp_prop;
                    break;
                case eEntity.pos_temp_enum_prop:
                    Result = eEntity_ErrID.pos_temp_enum_prop;
                    break;
                case eEntity.ticket:
                    Result = eEntity_ErrID.ticket;
                    break;
                case eEntity.message:
                    Result = eEntity_ErrID.message;
                    break;
                case eEntity.ticket_prop:
                    Result = eEntity_ErrID.ticket_prop;
                    break;
                case eEntity.mes_prop:
                    Result = eEntity_ErrID.mes_prop;
                    break;
                case eEntity.property:
                    Result = eEntity_ErrID.property;
                    break;
                case eEntity.group:
                    Result = eEntity_ErrID.group;
                    break;
                case eEntity.vclass:
                    Result = eEntity_ErrID.vclass;
                    break;
                case eEntity.class_prop:
                    Result = eEntity_ErrID.class_prop;
                    break;
                case eEntity.vobject:
                    Result = eEntity_ErrID.vobject;
                    break;
                case eEntity.pos_temp_nested_rule:
                    Result = eEntity_ErrID.pos_temp_nested_rule;
                    break;
                case eEntity.unit:
                    Result = eEntity_ErrID.unit;
                    break;
                case eEntity.unit_conversion_rule:
                    Result = eEntity_ErrID.unit_conversion_rule;
                    break;
                case eEntity.class_unit_conversion_rule:
                    Result = eEntity_ErrID.class_unit_conversion_rule;
                    break;
                case eEntity.class_prop_object_val:
                    Result = eEntity_ErrID.class_prop_object_val;
                    break;
                case eEntity.object_prop_object_val:
                    Result = eEntity_ErrID.object_prop_object_val;
                    break;
                case eEntity.rulel1_class_on_pos_temp:
                    Result = eEntity_ErrID.rulel1_class_on_pos_temp;
                    break;
                case eEntity.rulel1_class_on_pos_temp_access:
                    Result = eEntity_ErrID.rulel1_class_on_pos_temp_access;
                    break;
                case eEntity.rulel1_group_on_pos_temp:
                    Result = eEntity_ErrID.rulel1_group_on_pos_temp;
                    break;
                case eEntity.rulel1_group_on_pos_temp_access:
                    Result = eEntity_ErrID.rulel1_group_on_pos_temp_access;
                    break;
                case eEntity.rulel2_class_on_position:
                    Result = eEntity_ErrID.rulel2_class_on_position;
                    break;
                case eEntity.rulel2_class_snapshot_on_position:
                    Result = eEntity_ErrID.rulel2_class_snapshot_on_position;
                    break;
                case eEntity.prop_data_type:
                    Result = eEntity_ErrID.prop_data_type;
                    break;
                case eEntity.con_prop_data_type:
                    Result = eEntity_ErrID.con_prop_data_type;
                    break;
                case eEntity.prop_type:
                    Result = eEntity_ErrID.prop_type;
                    break;
                case eEntity.prop_data_bin_ext:
                    Result = eEntity_ErrID.prop_data_bin_ext;
                    break;
                case eEntity.object_prop:
                    Result = eEntity_ErrID.object_prop;
                    break;

                case eEntity.class_prop_user_val:
                    Result = eEntity_ErrID.class_prop_user_val;
                    break;
                case eEntity.class_prop_enum_val:
                    Result = eEntity_ErrID.class_prop_enum_val;
                    break;
                case eEntity.object_prop_user_val:
                    Result = eEntity_ErrID.object_prop_user_val;
                    break;
                case eEntity.object_prop_enum_val:
                    Result = eEntity_ErrID.object_prop_enum_val;
                    break;

                case eEntity.manager:
                    Result = eEntity_ErrID.manager;
                    break;
                case eEntity.pool:
                    Result = eEntity_ErrID.pool;
                    break;
                case eEntity.connect:
                    Result = eEntity_ErrID.connect;
                    break;
                case eEntity.procedure_export:
                    Result = eEntity_ErrID.procedure_export;
                    break;
            }
            return Result;
        }

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
        public static String ExportMode(eBaseExportFormat ExportFormat)
        {
            String mode = "Таблица";
            switch (ExportFormat)
            {
                case eBaseExportFormat.TableEntity:
                    mode = "Таблица БД";
                    break;
                case eBaseExportFormat.ViewEntity:
                    mode = "Представление БД";
                    break;
                case eBaseExportFormat.ReportEntity:
                    mode = "Представление обобщенное";
                    break;
                case eBaseExportFormat.ReportEntityWithProp:
                    mode = "Представление со свойствами";
                    break;
            }
            return mode;
        }
        #endregion

        #region Функции сопоставления методов поиска и его пользовательского представления

        /// <summary>
        /// Пользовательское представление метода поиска
        /// </summary>    
        public static String SearchMethodsToString(eSearchMethods SearchMethods)
        {
            String Result = "неопределенный метод поиска";
            String TValue;
            if (Dictionary_SearchMethods.TryGetValue(SearchMethods, out TValue))
                Result = TValue;
            return Result;
        }

        private static readonly Dictionary<eSearchMethods, string> Dictionary_SearchMethods = new Dictionary<eSearchMethods, String>()
        {
            { eSearchMethods.more, "< x"},
            { eSearchMethods.more_or_equal, "<= x" },
            { eSearchMethods.less, "> x" },
            { eSearchMethods.less_or_equal, ">= x" },
            { eSearchMethods.more_and_less, "< x <"},
            { eSearchMethods.more_or_equal_and_less, "<= x <"},
            { eSearchMethods.more_or_equal_and_less_or_equal, "<= x <="},
            { eSearchMethods.more_and_less_or_equal, "< x <="},
            { eSearchMethods.equal, "= x"},
            { eSearchMethods.not_equal, "<> x"},
            { eSearchMethods.like, "like x"},
            { eSearchMethods.like_lower, "like lower x"},
        };
        #endregion
    }
}
