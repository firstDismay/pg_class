using System;
using Newtonsoft.Json;
using System.Data;


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
            return JsonConvert.SerializeObject(oa, Formatting.Indented);
        }
    }

}
