using System;

namespace pg_class.pg_classes
{
    public partial class position
    {
        /// <summary>
        /// Метод объединяет массив объектов с совпадающими снимками классов
        /// </summary>
        public object_general Object_merging(object_general[] Object_merging_array)
        {
            Int64[] id_array;
            if (Object_merging_array.Length > 0)
            {
                id_array = new Int64[Object_merging_array.Length];

                for (int i = 0; i < Object_merging_array.Length; i++)
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
        public object_general Object_merging(Int64[] Object_merging_array)
        {
            Int64[] id_array;
            if (Object_merging_array.Length > 0)
            {
                id_array = new Int64[Object_merging_array.Length];

                for (int i = 0; i < Object_merging_array.Length; i++)
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