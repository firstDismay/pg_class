using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет новое глобальное свойство
        /// </summary>
        public global_prop global_prop_add(Int64 iid_conception, Int32 iid_prop_type, Int32 iid_data_type, String iname, String idesc, Boolean ivisible)
        {
            global_prop global_prop = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_add");
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

            cmdk.Parameters["iid_conception"].Value = iid_conception;
            cmdk.Parameters["iid_prop_type"].Value = iid_prop_type;
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["ivisible"].Value = ivisible;
            cmdk.ExecuteNonQuery();

            id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
            if (id > 0)
            {
                global_prop = global_prop_by_id(id);
            }

            //Генерируем событие изменения свойства класса
            GlobalPropChangeEventArgs e = new GlobalPropChangeEventArgs(global_prop, eAction.Insert);
            GlobalPropOnChange(e);
            //Возвращаем сущность
            return global_prop;
        }

        /// <summary>
        /// Метод добавляет новое глобальное свойство
        /// </summary>
        public global_prop global_prop_add(conception Conception, prop_type Prop_type, con_prop_data_type Data_type, String iname, String idesc, Boolean ivisible)
        {
            global_prop Result = null;
            if (Conception != null)
            {
                Result = global_prop_add(Conception.Id, Prop_type.Id, Data_type.Id, iname, idesc, ivisible);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_add");
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
        /// Метод добавляет новое глобальное свойство по свойству класса
        /// </summary>
        public global_prop global_prop_add_as_class_prop(Int64 iid_conception, Int64 iid_class_prop)
        {
            global_prop global_prop = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_add_as_class_prop");
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

            cmdk.Parameters["iid_conception"].Value = iid_conception;
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.ExecuteNonQuery();

            id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
            if (id > 0)
            {
                global_prop = global_prop_by_id(id);
            }

            //Генерируем событие изменения свойства класса
            GlobalPropChangeEventArgs e = new GlobalPropChangeEventArgs(global_prop, eAction.Insert);
            GlobalPropOnChange(e);
            //Возвращаем сущность
            return global_prop;
        }

        /// <summary>
        /// Метод добавляет новое глобальное свойство по свойству класса
        /// </summary>
        public global_prop global_prop_add_as_class_prop(conception Conception, class_prop ClassProp)
        {
            global_prop Result = null;
            if (Conception != null)
            {
                Result = global_prop_add_as_class_prop(Conception.Id, ClassProp.Id);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_add_as_class_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_add_as_class_prop");
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
        /// Метод добавляет новое глобальное свойство по свойству шаблона
        /// </summary>
        public global_prop global_prop_add_as_pos_temp_prop(Int64 iid_conception, Int64 iid_pos_temp_prop)
        {
            global_prop global_prop = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_add_as_pos_temp_prop");
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

            cmdk.Parameters["iid_conception"].Value = iid_conception;
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
            cmdk.ExecuteNonQuery();

            id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
            if (id > 0)
            {
                global_prop = global_prop_by_id(id);
            }
            //Генерируем событие изменения свойства класса
            GlobalPropChangeEventArgs e = new GlobalPropChangeEventArgs(global_prop, eAction.Insert);
            GlobalPropOnChange(e);
            //Возвращаем сущность
            return global_prop;
        }

        /// <summary>
        /// Метод добавляет новое глобальное свойство по свойству шаблона
        /// </summary>
        public global_prop global_prop_add_as_pos_temp_prop(conception Conception, pos_temp_prop PosTempProp)
        {
            global_prop Result = null;
            if (Conception != null)
            {
                Result = global_prop_add_as_pos_temp_prop(Conception.Id, PosTempProp.Id);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_add_as_pos_temp_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_add_as_pos_temp_prop");
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