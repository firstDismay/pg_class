using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace pg_class
{
    /// <summary>
    /// Класс методов для работы с JSON
    /// </summary>
    public static class man_json
    {
        /// <summary>
        /// Метод определяет является ли строка допустимой для сериализации в JSON
        /// </summary>
        public static bool IsJson(String source)
        {
            if (source == null)
                return false;

            try
            {
                JObject.Parse(source);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }
    }
}