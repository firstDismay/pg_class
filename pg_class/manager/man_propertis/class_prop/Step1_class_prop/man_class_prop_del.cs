using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод удаляет свойство класса и все наследующие свойства
        /// </summary>
        public void class_prop_del(Int64 iid)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_del");
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

            //Запрос удаляемой сущности
            class_prop class_prop = class_prop_by_id(iid);

            cmdk.Parameters["iid"].Value = iid;
            cmdk.ExecuteNonQuery();

            //Генерируем событие удаления свойства класса
            if (class_prop != null)
            {
                ClassPropChangeEventArgs e = new ClassPropChangeEventArgs(class_prop, eAction.Delete);
                ClassPropOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет свойство класса и все наследующие свойства
        /// </summary>
        public void class_prop_del(class_prop Class_Prop)
        {
            if (Class_Prop != null)
            {
                if (Class_Prop.StorageType == eStorageType.Active)
                {
                    class_prop_del(Class_Prop.Id);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        "Метод удаления свойства класса не применим к историческому представлению класса!");
                }
            }

        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_del");
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