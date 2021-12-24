using System;
using System.Text.Json;
using System.Data;
using System.Text.Json.Serialization;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    [Serializable]
    public partial class class_prop
    {
        System.Data.DataRow crow;

        /// <summary>
        /// Строка представления БД
        /// </summary>
        public System.Data.DataRow Crow
        {
            get
            {
                return crow;
            }
        }

        /// <summary>
        /// Идентификатор сущности в БД
        /// </summary>
        public String ToJsonString()
        {
            Object[] oa = crow.ItemArray;
            return JsonSerializer.Serialize(oa);
        }
    }

}
