using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace pg_class.pg_classes
{
    public partial  class object_general
    {
        #region МЕТОДЫ ОБЪЕКТА ДЛЯ ПРЕДСТАВЛЕНИЯ ОБЪЕКТА В JSON

        /// <summary>
        /// Метод преобразует полное представление объекта в промежуточный объект json_object_parameters
        /// </summary>
        public json_object_parameters ToJsonObjectParameters()
        {
            return new json_object_parameters(this);
        }

        /// <summary>
        /// Метод преобразует полное представление объекта в JSON
        /// </summary>
        public String ToJson()
        {
            return JsonConvert.SerializeObject(ToJsonObjectParameters(), Formatting.Indented);
        }
        #endregion
    }
}