using Newtonsoft.Json;
using System;


namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    [Serializable]
    public partial class vclass
    {
        System.Data.DataRow crow;

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
