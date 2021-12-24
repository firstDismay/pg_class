using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

namespace pg_class
{
    public partial class manager
    {
        #region МЕТОДЫ КЛАССА: ГРУПП

        #region ДОБАВИТЬ
        
        /// <summary>
        /// Метод добавляет новую группу
        /// </summary>
        public group group_add( Int64 iid_parent, Int64 iid_con,  String iname, String idesc, Boolean ion_class, Int32 isort)
        {
            group group = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("group_add");

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
            //=======================

            cmdk.Parameters["iid_parent"].Value = iid_parent;
            cmdk.Parameters["iid_con"].Value = iid_con;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["ion_class"].Value = ion_class;
            cmdk.Parameters["isort"].Value = isort;

            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                    if (id > 0)
                    {
                        group = group_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.group, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (group != null)
            {
                //Генерируем событие изменения группы
                GroupChangeEventArgs e = new GroupChangeEventArgs(group, eAction.Insert);
                GroupOnChange(e);
            }
            //Возвращаем Объект
            return group;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("group_add");
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
        //*********************************************************************************************
        
        /// <summary>
        /// Метод копирует группу в новую родительскую группу
        /// </summary>
        public group group_copy(Int64 iid_pattern, Int64 iid_parent)
        {
            group group = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("group_copy");

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
            //=======================

            cmdk.Parameters["iid_pattern"].Value = iid_pattern;
            cmdk.Parameters["iid_parent"].Value = iid_parent;
            cmdk.Parameters["recursivecall"].Value = false;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                    if (id > 0)
                    {
                        group = group_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.group, error, desc_error, eAction.Copy, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (group != null)
            {
                //Генерируем событие изменения позиции
                GroupChangeEventArgs e = new GroupChangeEventArgs(group, eAction.Move);
                GroupOnChange(e);
            }
            //Возвращаем Объект
            return group;
        }

        /// <summary>
        /// Метод копирует группу в новую родительскую группу
        /// </summary>
        public group group_copy(group Pattern, group Parent)
        {
            if (Parent != null)
            {
                return group_copy(Pattern.Id, Parent.Id);
            }
            else
            {
                return group_copy(Pattern.Id, 0);
            }
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_copy(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("group_copy");
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

        #region ИЗМЕНИТЬ
        /// <summary>
        /// Метод изменяет указанную группу
        /// </summary>
        public group group_upd(Int64 id, String iname, String idesc,  Boolean ion_class, Int32 isort)
        {
            group group = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
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
            //=======================

            cmdk.Parameters["iid"].Value = id;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["ion_class"].Value = ion_class;
            cmdk.Parameters["isort"].Value = isort;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    group = group_by_id(id);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.group, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (group != null)
            {
                //Генерируем событие изменения группы
                GroupChangeEventArgs e = new GroupChangeEventArgs(group, eAction.Update);
                GroupOnChange(e);
            }
            //Возвращаем Объект
            return group;
        }
        
        /// <summary>
        /// Метод изменяет указанную группу
        /// </summary>
        public group group_upd(group Group)
        {
            return group_upd(Group.Id, Group.Name, Group.Desc, Group.On_class, Group.Sort);
        }
       

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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
        //*********************************************************************************************

        /// <summary>
        /// Метод переносит группу в новую родительскую группу
        /// </summary>
        public group group_move(Int64 ChildGroup, Int64 ParentGroup)
        {
            group group = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
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
            //=======================

            cmdk.Parameters["iid"].Value = ChildGroup;
            cmdk.Parameters["iid_parent"].Value = ParentGroup;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    group = group_by_id(ChildGroup);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(ChildGroup, eEntity.group, error, desc_error, eAction.Move, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (group != null)
            {
                //Генерируем событие изменения позиции
                GroupChangeEventArgs e = new GroupChangeEventArgs(group, eAction.Move);
                GroupOnChange(e);
            }
            //Возвращаем Объект
            return group;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        /// 

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

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_move(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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

        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанную группу
        /// </summary>
        public void group_del(Int64 id)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("group_del");

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
            //=======================

            group group = group_by_id(id);

            cmdk.Parameters["iid"].Value = id;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(id, eEntity.group, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие изменения концепции
            if (group != null)
            {
                GroupChangeEventArgs e = new GroupChangeEventArgs(group, eAction.Delete);
                GroupOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет указанную группу
        /// </summary>
        public void group_del(group Group)
        {
            group_del(Group.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("group_del");
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
        //*********************************************************************************************
        #endregion

        #region ВЫБРАТЬ

        //*********************************************************************************************
        /// <summary>
        /// Группа по идентификатору
        /// </summary>
        public group group_by_id(Int64 id)
        {
            group group = null;

            DataTable tbl_group  = TableByName("vgroup");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("group_by_id");

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
            //=======================

            cmdk.Parameters["iid"].Value = id;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_group);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            
            if (tbl_group.Rows.Count > 0)
            {
                group = new group(tbl_group.Rows[0]);
            }
            return group;
        }

        /// <summary>
        /// Позиция по объекту group_path
        /// </summary>
        public group group_by_group_path(group_path Group_path)
        {
            return group_by_id(Group_path.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("group_by_id");
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
        //*********************************************************************************************

        //*********************************************************************************************
        /// <summary>
        /// Лист групп по идентификатору родительской группы
        /// </summary>
        public List<group> group_by_id_parent(Int64 id_parent, Int64 id_con)
        {
            List<group>  group_list = new List<group>();

            
            DataTable tbl_group  = TableByName("vgroup");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("group_by_id_parent");

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
            //=======================

            cmdk.Parameters["iid_parent"].Value = id_parent;
            cmdk.Parameters["iid_con"].Value = id_con;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_group);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            group gt;
            if (tbl_group.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_group.Rows)
                {
                    gt = new group(dr);
                    group_list.Add(gt);
                }
            }

            return group_list;
        }

        /// <summary>
        /// Лист групп по идентификатору родительской группы
        /// </summary>
        public List<group> group_by_id_parent(group Group)
        {
            return group_by_id_parent(Group.Id, Group.Id_conception);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_by_id_parent(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("group_by_id_parent");
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
        
        //*********************************************************************************************
        /// <summary>
        /// Лист дочерних групп по строгому соотвествию имени
        /// </summary>
        public List<group> group_by_name(Int64 iid_parent, String iname)
        {
            List<group> group_list = new List<group>();


            DataTable tbl_group  = TableByName("vgroup");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("group_by_name");

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
            //=======================

            cmdk.Parameters["iid_parent"].Value = iid_parent;
            cmdk.Parameters["iname"].Value = iname;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_group);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            group gt;
            if (tbl_group.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_group.Rows)
                {
                    gt = new group(dr);
                    group_list.Add(gt);
                }
            }

            return group_list;
        }

        /// <summary>
        /// Лист дочерних групп по строгому соотвествию имени
        /// </summary>
        public List<group> group_by_name(group Group_parent, String iname)
        {
            return group_by_name(Group_parent.Id, iname);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_by_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("group_by_name");
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

        #region СВОЙСТВА ПОЛУЧАЕМЫЕ ИЗ БД
        //*********************************************************************************************
        /// <summary>
        /// Метод определяет актуальность состояния группы
        /// </summary>
        public eEntityState group_is_actual(Int64 iid, DateTime itimestamp, DateTime itimestamp_child_change)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("group_is_actual3");

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
            //=======================

            cmdk.Parameters["iid"].Value = iid;
            cmdk.Parameters["itimestamp"].Value = itimestamp;
            cmdk.Parameters["itimestamp_child_change"].Value = itimestamp_child_change;

            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Метод определяет актуальность состояния группы
        /// </summary>
        public eEntityState group_is_actual(group Group)
        {
            return group_is_actual(Group.Id, Group.Timestamp, Group.Timestamp_child_change);
        }
        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ ГРУППАМИ

        /// <summary>
        /// Делегат события изменения группы
        /// </summary>
        public delegate void GroupChangeEventHandler(Object sender, GroupChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении группы методом доступа к БД
        /// </summary>
        public event GroupChangeEventHandler GroupChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения группы
        /// </summary>
        protected virtual void GroupOnChange(GroupChangeEventArgs e)
        {
            GroupChangeEventHandler temp = GroupChange;
            if (temp != null)
            {
                temp(this, e);
            }
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(e);
            JournalMessageOnReceived(me);
        }

        #endregion
    }
}
