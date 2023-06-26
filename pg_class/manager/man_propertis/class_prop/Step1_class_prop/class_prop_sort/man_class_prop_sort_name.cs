using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет текущую сортировку свойств активного класса на сортировку по имени
        /// </summary>
        public vclass class_prop_sort_by_name(Int64 iid_class)
        {
            vclass class_sort = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_sort_by_name");
            if (cmdk != null)
            {
                if (!cmdk.Access)
                {
                    throw new AccessDataBaseException(404, String.Format(@"Отказано в доступе к методу: {0}!", cmdk.CommandText));
                }
            }
            else
            {
                throw new AccessDataBaseException(405, String.Format(@"Не найден метод: {0}!", cmdk.CommandText));
            }

            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.ExecuteNonQuery();

            class_sort = class_act_by_id(iid_class);

            //Генерируем событие применения метода сортировки
            if (class_sort != null)
            {
                ClassChangeEventArgs e = new ClassChangeEventArgs(class_sort, eAction.Update);
                ClassPropSortOnChange(e);
            }
            //Возвращаем сущность
            return class_sort;
        }

        /// <summary>
        /// Метод изменяет текущую сортировку свойств активного класса на сортировку по имени
        /// </summary>
        public vclass class_prop_sort_by_name(vclass Class)
        {
            vclass Result = null;
            if (Class != null)
            {
                if (Class.StorageType == eStorageType.Active)
                {
                    Result = class_prop_sort_by_name(Class.Id);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        "Метод обновления данных свойства класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_sort_by_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_sort_by_name");
            if (cmdk != null)
            {
                Result = cmdk.Access;
                if (Result)
                {
                    Access = eAccess.Success;
                }
                else
                {
                    Access = eAccess.NotAvailable;
                }
            }
            return Result;
        }
    }
}