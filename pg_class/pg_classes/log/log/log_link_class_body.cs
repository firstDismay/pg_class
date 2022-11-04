using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс записей журнала 
    /// </summary>
    public partial class log
    {
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
                        catch (JsonReaderException ex){}
                    }
                }
            }
        }
    }
}