using Newtonsoft.Json;
using pg_class.pg_exceptions;
using System;

namespace pg_class.pg_classes
{
    public partial class vclass
    {
        #region МЕТОДЫ КЛАССА ДЛЯ ПРЕДСТАВЛЕНИЯ ОБЪЕКТА В JSON

        /// <summary>
        /// Метод преобразует полное представление объекта в промежуточный объект json_object_parameters
        /// </summary>
        public json_object_parameters ToJsonObjectParameters()
        {
            if (On_abstraction)
            {
                throw new ArgumentOutOfRangeException(
                    "Абстрактный класс не допускает извлечение классов представления объектов в JSON!");
            }
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
