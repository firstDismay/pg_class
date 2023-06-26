using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет указанную группу
        /// </summary>
        public group group_upd(Int64 id, String iname, String idesc, Boolean ion_class, Int32 isort)
        {
            group group = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("group_upd");
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

            cmdk.Parameters["iid"].Value = id;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["ion_class"].Value = ion_class;
            cmdk.Parameters["isort"].Value = isort;
            cmdk.ExecuteNonQuery();

            group = group_by_id(id);
            if (group != null)
            {
                //Генерируем событие изменения группы
                GroupChangeEventArgs e = new GroupChangeEventArgs(group, eAction.Update);
                GroupOnChange(e);
            }
            //Возвращаем сущность
            return group;
        }

        /// <summary>
        /// Метод изменяет указанную группу
        /// </summary>
        public group group_upd(group Group)
        {
            return group_upd(Group.Id, Group.Name, Group.Desc, Group.On_class, Group.Sort);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("group_upd");
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
        /// Метод переносит группу в новую родительскую группу
        /// </summary>
        public group group_move(Int64 ChildGroup, Int64 ParentGroup)
        {
            group group = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("group_move");
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

            cmdk.Parameters["iid"].Value = ChildGroup;
            cmdk.Parameters["iid_parent"].Value = ParentGroup;
            cmdk.ExecuteNonQuery();

            group = group_by_id(ChildGroup);
            if (group != null)
            {
                //Генерируем событие изменения позиции
                GroupChangeEventArgs e = new GroupChangeEventArgs(group, eAction.Move);
                GroupOnChange(e);
            }
            //Возвращаем сущность
            return group;
        }

        /// <summary>
        /// Метод переносит группу в новую родительскую группу
        /// </summary>
        public group group_move(group ChildGroup, group ParentGroup)
        {
            if (ParentGroup != null)
            {
                return group_move(ChildGroup.Id, ParentGroup.Id);
            }
            else
            {
                return group_move(ChildGroup.Id, 0);
            }
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_move(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("group_move");
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