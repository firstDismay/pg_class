using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pg_class
{
    #region Перечисления типов данных
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
	#endregion
}
