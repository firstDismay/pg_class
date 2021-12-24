using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class object_general
    {
        /// <summary>
        /// Метод объединяет массив объектов с совпадающими снимками классов
        /// </summary>
        public object_general merging(object_general[] Object_merging_array)
        {
            Int64[] id_array;
            if (Object_merging_array.Length > 0)
            {
                id_array = new Int64[Object_merging_array.Length + 1];

                id_array[0] = id;
                for (int i = 1; i < Object_merging_array.Length; i++)
                {
                    id_array[i] = Object_merging_array[i].Id;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Массив объектов пуст!");
            }
            return Manager.object_merging(id_array);
        }

        /// <summary>
        /// Метод объединяет массив объектов с совпадающими снимками классов
        /// </summary>
        public object_general merging(Int64[] Object_merging_array)
        {
            Int64[] id_array;
            if (Object_merging_array.Length > 0)
            {
                id_array = new Int64[Object_merging_array.Length + 1];

                id_array[0] = id;
                for (int i = 1; i < Object_merging_array.Length; i++)
                {
                    id_array[i] = Object_merging_array[i];
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Массив объектов пуст!");
            }
            return Manager.object_merging(id_array);
        }
    }
}
