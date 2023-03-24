using NpgsqlTypes;
using System;
using System.Collections.Generic;

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
                    case "vclass_prop":
                        ResType = typeof(pg_vclass_prop);
                        break;
                    case "vobject_prop":
                        ResType = typeof(pg_vobject_prop);
                        break;
                    case "vdoc_file":
                        ResType = typeof(pg_vdoc_file);
                        break;
                    case "vdoc_link":
                        ResType = typeof(pg_vdoc_link);
                        break;
                    case "vdoc_category":
                        ResType = typeof(pg_vdoc_category);
                        break;
                    case "vlog_link":
                        ResType = typeof(pg_vlog_link);
                        break;
                    case "vlog_category":
                        ResType = typeof(pg_vlog_category);
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
    }
}
