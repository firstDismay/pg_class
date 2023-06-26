using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        #region ИЗМЕНИТЬ СОРТИРОВКУ ЭЕЛЕМНТОВ СПИСКА
        #region ПОДНЯТЬ ВВЕРХ
        /// <summary>
        /// Метод изменяет сортировку позиций поднимая указанную позицию вверх
        /// </summary>
        public position position_sort_top(Int64 iid_position)
        {
            position position = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_sort_top");
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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.ExecuteNonQuery();

            position = position_by_id(iid_position);
            if (position.Id_parent > 0)
            {
                position = position_by_id(position.Id_parent);
            }
            //Генерируем событие применения метода сортировки
            if (position != null)
            {
                PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Update);
                PositionSortOnChange(e);
            }

            //Возвращаем сущность
            return position;
        }

        /// <summary>
        /// Метод изменяет сортировку позиций поднимая указанную позицию вверх
        /// </summary>
        public position position_sort_top(position Position)
        {
            return position_sort_top(Position.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_sort_top(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_sort_top");
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
        #endregion

        #region ПОДНЯТЬ ВВЕРХ НА ОДИН
        /// <summary>
        /// Метод изменяет сортировку позициb поднимая указанную позицию на один пункт вверх
        /// </summary>
        public position position_sort_up(Int64 iid_position)
        {
            position position = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_sort_up");
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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.ExecuteNonQuery();

            position = position_by_id(iid_position);
            if (position.Id_parent > 0)
            {
                position = position_by_id(position.Id_parent);
            }
            //Генерируем событие применения метода сортировки
            if (position != null)
            {
                PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Update);
                PositionSortOnChange(e);
            }

            //Возвращаем сущность
            return position;
        }

        /// <summary>
        /// Метод изменяет сортировку позициb поднимая указанную позицию на один пункт вверх
        /// </summary>
        public position position_sort_up(position Position)
        {
            return position_sort_up(Position.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_sort_up(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_sort_up");
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
        #endregion

        #region ОПУСТИТЬ ВНИЗ НА ОДИН
        /// <summary>
        /// Метод изменяет сортировку позиции опуская указанную позицию на один пункт вниз
        /// </summary>
        public position position_sort_down(Int64 iid_position)
        {
            position position = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_sort_down");
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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.ExecuteNonQuery();

            position = position_by_id(iid_position);
            if (position.Id_parent > 0)
            {
                position = position_by_id(position.Id_parent);
            }
            //Генерируем событие применения метода сортировки
            if (position != null)
            {
                PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Update);
                PositionSortOnChange(e);
            }

            //Возвращаем сущность
            return position;
        }

        /// <summary>
        /// Метод изменяет сортировку позиции опуская указанную позицию на один пункт вниз
        /// </summary>
        public position position_sort_down(position Position)
        {
            return position_sort_down(Position.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_sort_down(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_sort_down");
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
        #endregion

        #region ОПУСТИТЬ ВНИЗ
        /// <summary>
        /// Метод изменяет сортировку позиций опуская указанную позицию вниз
        /// </summary>
        public position position_sort_bottom(Int64 iid_position)
        {
            position position = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_sort_bottom");
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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.ExecuteNonQuery();

            position = position_by_id(iid_position);
            if (position.Id_parent > 0)
            {
                position = position_by_id(position.Id_parent);
            }
            //Генерируем событие применения метода сортировки
            if (position != null)
            {
                PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Update);
                PositionSortOnChange(e);
            }

            //Возвращаем сущность
            return position;
        }

        /// <summary>
        /// Метод изменяет сортировку позиций опуская указанную позицию вниз
        /// </summary>
        public position position_sort_bottom(position Position)
        {
            return position_sort_bottom(Position.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_sort_bottom(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_sort_bottom");
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
        #endregion

        #region СОРТИРОВКА ПО ИМЕНИ
        /// <summary>
        /// Метод изменяет сортировку позиций на сортировку по имени
        /// </summary>
        public position position_sort_by_name(Int64 iid_position_parent)
        {
            position position = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_sort_by_name");
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

            cmdk.Parameters["iid_position_parent"].Value = iid_position_parent;
            cmdk.ExecuteNonQuery();

            position = position_by_id(iid_position_parent);
            if (position.Id_parent > 0)
            {
                position = position_by_id(position.Id_parent);
            }
            //Генерируем событие применения метода сортировки
            if (position != null)
            {
                PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Update);
                PositionSortOnChange(e);
            }

            //Возвращаем сущность
            return position;
        }

        /// <summary>
        /// Метод изменяет сортировку позиций опуская указанную позицию вниз
        /// </summary>
        public position position_sort_by_name(position Position)
        {
            return position_sort_by_name(Position.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_sort_by_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_sort_by_name");
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
        /// Метод изменяет сортировку позиций на сортировку по имени
        /// </summary>
        public conception position_root_sort_by_name(Int64 iid_conception)
        {
            conception conception = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_root_sort_by_name");
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
            cmdk.ExecuteNonQuery();

            conception = conception_by_id(iid_conception);
            //Генерируем событие применения метода сортировки
            if (conception != null)
            {
                ConceptionChangeEventArgs e = new ConceptionChangeEventArgs(conception, eAction.Update);
                PositionSortOnChange(e);
            }

            //Возвращаем сущность
            return conception;
        }

        /// <summary>
        /// Метод изменяет сортировку позиций опуская указанную позицию вниз
        /// </summary>
        public conception position_root_sort_by_name(conception Conception)
        {
            return position_root_sort_by_name(Conception.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_root_sort_by_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_root_sort_by_name");
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
        #endregion
        #endregion
    }
}