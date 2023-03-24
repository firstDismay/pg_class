using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс записей журнала 
    /// </summary>
    public partial class log
    {
        #region СВОЙСТВА КЛАССА
        private String class_body;
        private String body;

        /// <summary>
		/// Класс сообщения
		/// </summary>
		public String Class_body
        {
            get
            {
                return class_body;
            }
            set
            {
                if (class_body != value)
                {
                    class_body = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Тело сообщения в формате JSON
        /// </summary>
        public String Body
        {
            get
            {
                return body;
            }
            set
            {
                if (body != value)
                {
                    if (value != null || value != "")
                    {
                        JObject body_check = JObject.Parse(body);
                    }
                    body = value;
                    include_class_body_to_json_boby();
                    on_change = true;
                }
            }
        }
        #endregion

        /// <summary>
        /// Свойство определяет поведение атрибута class_body, если свойство true атрибут добавляется в исходный JSON в случае если он корректен
        /// </summary>
        public Boolean include_class_body_to_JSON { get; set; }

        /// <summary>
        /// Реализует поведение атрибута include_class_body_to_JSON
        /// </summary>
        private void include_class_body_to_json_boby()
        {
            if (include_class_body_to_JSON)
            {
                if (class_body != null && body != null)
                {
                    if (class_body != "" && body != "")
                    {
                        try
                        {
                            JObject body_check = JObject.Parse(body);
                            if (!body_check.ContainsKey("class_body"))
                            {
                                body_check.Add("class_body", class_body);
                                body = body_check.ToString();
                            }
                        }
                        catch (JsonReaderException ex) { }
                    }
                }
            }
        }
    }
}