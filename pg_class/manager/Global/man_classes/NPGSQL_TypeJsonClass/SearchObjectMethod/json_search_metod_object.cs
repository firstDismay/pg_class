using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace pg_class
{
    /// <summary>
    /// Класс метода поиска
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SearchMetodObject
    {
        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        public SearchMetodObject(eSearchMethods iSearchMethod)
        {
            SearchMethod = iSearchMethod;
        }

        /// <summary>
        ///Метод поиска
        /// </summary>
        [JsonProperty]
        public eSearchMethods SearchMethod { get; set; }

        /// <summary>
        /// Описание метода поиска
        /// </summary>
        public  String Description()
        {
            return manager.SearchMethodsToDescription(SearchMethod);
        }

        /// <summary>
        /// Переопределение метода ToString
        /// </summary>
        public override String ToString()
        {
            return manager.SearchMethodsToString(SearchMethod);
        }
    }
}