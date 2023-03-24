﻿using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class vclass
    {
        /// <summary>
        /// Проверка валидности баркода EAN 13
        /// </summary>
        public bool Barcode_EAN13_checksum_check(Int64 Код)
        {
            return Manager.Barcode_EAN13_checksum_check(Код);
        }

        /// <summary>
        /// Расчет проверочного числа баркода EAN13
        /// </summary>
        public Int32 Barcode_EAN13_checksum_calculate(Int64 Код)
        {
            return Manager.Barcode_EAN13_checksum_calculate(Код);
        }
    }
}
