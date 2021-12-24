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
    public partial class vclass
    {
        System.Data.DataRow crow;
        
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
