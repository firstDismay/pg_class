using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using pg_class.pg_classes;


namespace pg_class
{
    /// <summary>
    /// Класс значений свойств объектов
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class json_object_prop_val
    {
        /// <summary>
        /// Публичный конструктор класса Значения свойства
        /// </summary>
        public json_object_prop_val(object_prop ObjectProp)
        {
            IdClassProp = ObjectProp.Id_class_prop;
            NameClassProp = ObjectProp.Name;
            ValueObjectProp = ObjectProp.String_val;
        }

        /// <summary>
        /// Идентификатор свойства класса
        /// </summary>
        [JsonProperty]
        public Int64 IdClassProp { get; set; }
        
        /// <summary>
        ///Наименование свойства класса
        /// </summary>
        [JsonProperty]
        public String NameClassProp { get; set; }
        
        /// <summary>
        ///Значеие свойства объекта
        /// </summary>
        [JsonProperty]
        public String ValueObjectProp { get; set; }

        /// <summary>
        /// Переопределенный метод класса
        /// </summary>
        public override string ToString()
        {
            return String.Format("{0}[1]: {2}", NameClassProp, IdClassProp, ValueObjectProp);
        }
    }
}