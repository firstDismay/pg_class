using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace pg_class
{
    partial class manager
    {
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
