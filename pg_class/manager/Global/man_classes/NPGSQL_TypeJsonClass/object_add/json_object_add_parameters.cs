using Newtonsoft.Json;
using pg_class.pg_classes;
using System;
using System.Collections.Generic;

namespace pg_class
{
    /// <summary>
    /// Класс параметров создания объекта со свойствами
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class json_object_parameters
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Публичный конструктор класса Значения свойства
        /// </summary>
        public json_object_parameters(object_general iObject)
        {
            IdPosition = iObject.Id_position;
            IdObject = iObject.Id;
            NameObject = iObject.Name;
            IdClass = iObject.Id_class;
            IdUnitConversionRule = iObject.Id_unit_conversion_rule;
            СQuantity = iObject.Quantity_curent;
            ObjectPropertyList = new List<json_object_prop_val>();

            foreach (object_prop op in iObject.Property_list_get(false))
            {
                ObjectPropertyList.Add(new json_object_prop_val(op));
            }
        }

        /// <summary>
        /// Публичный конструктор класса Значения свойства
        /// </summary>
        public json_object_parameters(vclass iClass)
        {
            //IdPosition = iIdPosition;
            //IdObject = iObject.Id;
            NameObject = iClass.Name;
            IdClass = iClass.Id;
            IdUnitConversionRule = iClass.Id_unit_conversion_rule;
            //СQuantity = iCQuantity;
            ObjectPropertyList = new List<json_object_prop_val>();

            foreach (class_prop cp in iClass.Property_list_get(false))
            {
                ObjectPropertyList.Add(new json_object_prop_val(cp));
            }
        }

        /// <summary>
        /// Публичный конструктор класса Значения свойства
        /// </summary>
        public json_object_parameters(vclass iClass, Int64 iIdPosition, Int32 iIdUnitConversionRule, Decimal iCQuantity)
        {
            IdPosition = iIdPosition;
            //IdObject = iObject.Id;
            NameObject = iClass.Name;
            IdClass = iClass.Id;
            IdUnitConversionRule = iIdUnitConversionRule;
            СQuantity = iCQuantity;
            ObjectPropertyList = new List<json_object_prop_val>();

            foreach (class_prop cp in iClass.Property_list_get(false))
            {
                ObjectPropertyList.Add(new json_object_prop_val(cp));
            }
        }
        #endregion

        /// <summary>
        /// Идентификатор позиции объекта 
        /// </summary>
        [JsonProperty]
        public Int64 IdPosition { get; set; }

        /// <summary>
        /// Идентификатор объекта используется для обновления данных об объекте
        /// </summary>
        [JsonProperty]
        public Int64 IdObject { get; set; }

        /// <summary>
        /// Идентификатор объекта используется для обновления данных об объекте
        /// </summary>
        [JsonProperty]
        public String NameObject { get; set; }

        /// <summary>
        /// Идентификатор класса объекта используется для создания новых объектов
        /// </summary>
        [JsonProperty]
        public Int64 IdClass { get; set; }

        /// <summary>
        /// Идентификатор правила пересчета объекта
        /// </summary>
        [JsonProperty]
        public Int32 IdUnitConversionRule { get; set; }

        /// <summary>
        /// Количество объекта в единицах пересчета текущего правила
        /// </summary>
        [JsonProperty]
        public Decimal СQuantity { get; set; }

        /// <summary>
        /// Лист свойств объекта
        /// </summary>
        [JsonProperty]
        public List<json_object_prop_val> ObjectPropertyList { get; set; }

        /// <summary>
        /// Переопределенный метод класса
        /// </summary>
        public override string ToString()
        {
            return NameObject;
        }
    }
}