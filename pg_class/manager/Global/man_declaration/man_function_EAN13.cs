using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

namespace pg_class
{
    public partial class manager
    {
        #region МЕТОДЫ МЕНЕДЖЕРА ДАННЫХ ДЛЯ РАБОТЫ СО ШТРИХКОДАМИ EAN13

        private List<Int32> Number_list(Int64 Код, Int32 Мин_количество_цифр = 1)
        {
            List<Int32> Result = new List<Int32>();

            //Узнаем количество разрядов в числе
            Int32 Количество_цифр = 1;
            while (Код / Convert.ToInt64(Math.Pow(10, Количество_цифр)) > 1)
            {
                Количество_цифр++;
            }

            //Разбиваем число на цифры
            for (Int32 i = Количество_цифр; i > 0; i--)
            {
                Int64 Part_1 = Convert.ToInt64(Код % (Math.Pow(10, i)));
                Int64 Part_2 = Convert.ToInt64(Math.Pow(10, i - 1));

                Int32 Num = Convert.ToInt32(Part_1 / Part_2);
                Result.Add(Num);
            }

            //Добавляем 0 в начало до маски
            if (Количество_цифр < Мин_количество_цифр)
            {
                for (Int32 i = 0; i < Мин_количество_цифр - Количество_цифр; i++)
                {
                    Result.Insert(0, 0);
                }
            }

            return Result;
        }

        /// <summary>
        /// Проверка валидности баркода EAN13
        /// </summary>
        public bool Barcode_EAN13_checksum_check(Int64 Код)
        {
            bool Result = false;

            if (Код >= 0 && Код <= 9999999999999)
            {
                Int32 Сумма_четных = 0;
                Int32 Сумма_нечетных = 0;

                List<Int32> _Код = Number_list(Код, 13);
                Int32 Контроль = _Код[12];

                for (Int32 i = 0; i < _Код.Count - 1; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        Int32 Num = _Код[i];
                        Сумма_четных = Сумма_четных + Num;
                    }
                    else
                    {
                        Int32 Num = _Код[i];
                        Сумма_нечетных = Сумма_нечетных + Num;
                    }
                }

                Int32 Сумма = Сумма_нечетных + 3 * Сумма_четных;

                List<Int32> Код_расчетный = Number_list(Сумма);
                Int32 Последняя_цифра = Код_расчетный[Код_расчетный.Count - 1];
                Int32 Контроль_рассчет = 10 - Последняя_цифра;

                if (Последняя_цифра == 0)
                {
                    Контроль_рассчет = 0;
                }

                if (Контроль_рассчет == Контроль)
                {
                    Result = true;
                }
            }

            return Result;
        }

        /// <summary>
        /// Расчет проверочного числа баркода EAN13
        /// </summary>
        public Int32 Barcode_EAN13_checksum_calculate(Int64 Код)
        {
            Int32 Result = -1;

            if (Код >= 0 && Код <= 999999999999)
            {
                Int32 Сумма_четных = 0;
                Int32 Сумма_нечетных = 0;

                List<Int32> _Код = Number_list(Код, 12);

                for (Int32 i = 0; i < _Код.Count; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        Int32 Num = _Код[i];
                        Сумма_четных = Сумма_четных + Num;
                    }
                    else
                    {
                        Int32 Num = _Код[i];
                        Сумма_нечетных = Сумма_нечетных + Num;
                    }
                }

                Int32 Сумма = Сумма_нечетных + 3 * Сумма_четных;

                Int32 Последняя_цифра = Number_list(Сумма)[Number_list(Сумма).Count - 1];
                Int32 Контроль_рассчет = 10 - Последняя_цифра;

                if (Последняя_цифра == 0)
                {
                    Контроль_рассчет = 0;
                }

                Result = Контроль_рассчет;
            }

            return Result;
        }

        /// <summary>
        /// Генератор локального штрихкода для идентификации классов
        /// </summary>
        public Int64 Generate_EAN13_vclass(Int64 id_class)
        {
            Int64 Result = -1;
            Int64 System = 201;

            if (id_class >= 0 && id_class <= 999999999)
            {
                Int32 Контроль = Barcode_EAN13_checksum_calculate(System * 1000000000 + id_class);
                Result = (System * 1000000000 + id_class) * 10 + Контроль;
            }

            return Result;
        }

        /// <summary>
        /// Генератор локального штрихкода для идентификации объектов
        /// </summary>
        public Int64 Generate_EAN13_vobject(Int64 id_object)
        {
            Int64 Result = -1;
            Int64 System = 202;

            if (id_object >= 0 && id_object <= 999999999)
            {
                Int32 Контроль = Barcode_EAN13_checksum_calculate(System * 1000000000 + id_object);
                Result = (System * 1000000000 + id_object) * 10 + Контроль;
            }

            return Result;
        }
        #endregion
    }
}