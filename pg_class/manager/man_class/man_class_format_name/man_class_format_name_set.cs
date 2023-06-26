using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод определяет формат имен объектов классов
        /// </summary>
        protected vclass class_act_name_format_set(Int64 iid_class, String iname_format)
        {
            vclass vclass = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_act_name_format_set");
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
            cmdk.Parameters["iname_format"].Value = iname_format;
            cmdk.ExecuteNonQuery();

            vclass = class_act_by_id(iid_class);

            //Генерируем событие изменения представления класса
            ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Update);
            ClassOnChange(e);
            //Возвращаем сущность
            return vclass;
        }

        /// <summary>
        /// Метод определяет формат имен объектов классов
        /// </summary>
        public vclass class_act_name_format_set(vclass Vclass, String iname_format)
        {
            vclass Result = null;

            if (Vclass != null)
            {
                Result = class_act_name_format_set(Vclass.Id, iname_format);
            }
            return Result;
        }

        /// <summary>
        /// Метод определяет формат имен объектов классов
        /// </summary>
        public vclass class_act_name_format_set(class_name_format_builder Class_name_format_builder)
        {
            vclass Result = null;

            if (Class_name_format_builder.Сlass != null)
            {
                Result = class_act_name_format_set(Class_name_format_builder.Сlass.Id, Class_name_format_builder.Format_get());
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_name_format_set(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_act_name_format_set");
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

        /// <summary>
        /// Метод устанавливает значение флага отображения количества в имени объектов
        /// </summary>
        protected vclass class_quantity_show_set(Int64 iid_class, Boolean iquantity_show)
        {
            vclass vclass = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_quantity_show_set");
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
            cmdk.Parameters["iquantity_show"].Value = iquantity_show;
            cmdk.ExecuteNonQuery();
            
            //Генерируем событие изменения представления класса
            ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Update);
            ClassOnChange(e);
            //Возвращаем сущность
            return vclass;
        }

        /// <summary>
        /// Метод устанавливает значение флага отображения количества в имени объектов
        /// </summary>
        public vclass class_quantity_show_set(vclass Vclass, Boolean iquantity_show)
        {
            vclass Result = null;

            if (Vclass != null)
            {
                Result = class_quantity_show_set(Vclass.Id, iquantity_show);
            }
            return Result;
        }

        /// <summary>
        /// Метод устанавливает значение флага отображения количества в имени объектов
        /// </summary>
        public vclass class_quantity_show_set(class_name_format_builder Class_name_format_builder)
        {
            vclass Result = null;

            if (Class_name_format_builder.Сlass != null)
            {
                Result = class_quantity_show_set(Class_name_format_builder.Сlass.Id, Class_name_format_builder.Quantity_show);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_quantity_show_set(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_quantity_show_set");
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