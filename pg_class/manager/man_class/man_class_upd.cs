using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет указанное представление класса
        /// </summary>
        public vclass class_upd(Int64 iid, String iname, String idesc, Boolean ion, Boolean ion_extensible,
                            Boolean ion_abstraction, Int32 iid_unit, Int32 iid_unit_conversion_rule, Int64 ibarcode_manufacturer)

        {
            vclass vclass = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_upd");
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

            cmdk.Parameters["iid"].Value = iid;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["ion"].Value = ion;
            cmdk.Parameters["ion_extensible"].Value = ion_extensible;
            cmdk.Parameters["ion_abstraction"].Value = ion_abstraction;
            cmdk.Parameters["iid_unit"].Value = iid_unit;
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.Parameters["ibarcode_manufacturer"].Value = ibarcode_manufacturer;
            cmdk.ExecuteNonQuery();

            vclass = class_act_by_id(iid);
            if (vclass != null)
            {
                //Генерируем событие изменения представления класса
                ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Update);
                ClassOnChange(e);
            }
            //Возвращаем сущность
            return vclass;
        }

        /// <summary>
        /// Метод изменяет указанный абстрактный базовый класс
        /// </summary>
        public vclass class_upd(vclass Vclass)
        {
            vclass Result = null;

            if (Vclass != null)
            {
                Result = class_upd(Vclass.Id, Vclass.Name, Vclass.Desc, Vclass.On, Vclass.On_extensible,
                                    Vclass.On_abstraction, Vclass.Id_unit, Vclass.Id_unit_conversion_rule, Vclass.Barcode_manufacturer);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            cmdk = CommandByKey("class_upd");
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
        /// Метод переносит представление базового абстрактного класса в новую группу
        /// </summary>
        public vclass class_move_to_group(Int64 iid_class, Int64 iid_group)
        {
            vclass vclass = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_move_to_group");
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
            cmdk.Parameters["iid_group"].Value = iid_group;
            cmdk.ExecuteNonQuery();

            vclass = class_act_by_id(iid_class);
            if (vclass != null)
            {
                //Генерируем событие изменения позиции
                ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Move);
                ClassOnChange(e);
            }
            //Возвращаем сущность
            return vclass;
        }

        /// <summary>
        /// Метод переносит представление базового абстрактного класса в новую группу
        /// </summary>
        public vclass class_move_to_group(vclass Class_pattern, group Group_target)
        {
            vclass Result = null;
            if (Class_pattern != null & Group_target != null)
            {
                Result = class_move_to_group(Class_pattern.Id, Group_target.Id);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_move_to_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_move_to_group");
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
        /// Метод переносит активное представление класса в указанный абстрактный класс
        /// </summary>
        public vclass class_move_to_class(Int64 iid_pattern, Int64 iid_target)
        {
            vclass vclass = null;
            Int32 error;
            Int64 id = 0;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_move_to_class");
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
            vclass vclass_del = class_act_by_id(iid_pattern);

            cmdk.Parameters["iid_pattern"].Value = iid_pattern;
            cmdk.Parameters["iid_target"].Value = iid_target;
            cmdk.ExecuteNonQuery();

            vclass = class_act_by_id(id);
            if (vclass != null)
            {
                //Генерируем событие изменения класса
                ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Move);
                ClassOnChange(e);
            }

            //Генерируем событие удаления класса паттерна
            if (vclass_del != null)
            {
                ClassChangeEventArgs e2 = new ClassChangeEventArgs(vclass_del, eAction.Delete);
                ClassOnChange(e2);
            }
            //Возвращаем сущность
            return vclass;
        }

        /// <summary>
        /// Метод переносит активное представление класса в указанный абстрактный класс
        /// </summary>
        public vclass class_move_to_class(vclass Class_pattern, vclass Class_target)
        {
            return class_move_to_class(Class_pattern.Id, Class_target.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_move_to_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_move_to_class");
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
        /// Метод откатывает представление класса к указанному снимку
        /// </summary>
        public vclass class_rollback(Int64 iid_snapshot, System.DateTime timestamp_snapshot)
        {
            vclass vclass = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_rollback");

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

            cmdk.Parameters["iid_snapshot"].Value = iid_snapshot;
            cmdk.Parameters["timestamp_snapshot"].Value = timestamp_snapshot;
            cmdk.ExecuteNonQuery();

            vclass = class_act_by_id(iid_snapshot);
            if (vclass != null)
            {
                //Генерируем событие изменения позиции
                ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Move);
                ClassOnChange(e);
            }
            //Возвращаем сущность
            return vclass;
        }

        /// <summary>
        /// Метод откатывает представление класса к указанному снимку
        /// </summary>
        public vclass class_rollback(vclass Vclass)
        {
            vclass Result = null;
            if (Vclass != null)
            {
                if (Vclass.StorageType == eStorageType.Active)
                {
                    Result = class_rollback(Vclass.Id, Vclass.Timestamp);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        "Метод удаления данных класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_rollback(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_rollback");
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