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
        #region МЕТОДЫ КЛАССА: ПОЗИЦИЙ

        #region ДОБАВИТЬ
        
        /// <summary>
        /// Метод добавляет новую позиций
        /// </summary>
        public position pos_add( Int64 id_parent, Int64 id_pos_temp, String iname, String idesc, Int32 isort)
        {
            position position = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("position_add");

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
            cmdk.Parameters["iid_pos_temp"].Value = id_pos_temp;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
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
                        position = pos_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.position, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (position != null)
            {
                //Генерируем событие изменения позиции
                PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Insert);
                PositionOnChange(e);
            }
            //Возвращаем Объект
            return position;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_add");
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
        /// Метод копирует выбранную позицию в указанное расположение
        /// </summary>
        public position position_copy(Int64 iid_pattern, Int64 iid_parent, Boolean on_object)
        {
            position position = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("position_copy");

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
            cmdk.Parameters["on_object"].Value = on_object;

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
                        position = pos_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.position, error, desc_error, eAction.Copy, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (position != null)
            {
                //Генерируем событие изменения позиции
                PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Insert);
                PositionOnChange(e);
            }
            //Возвращаем Объект
            return position;
        }

        /// <summary>
        /// Метод копирует выбранную позицию в указанное расположение
        /// </summary>
        public position position_copy(position Pos_pattern, position Pos_parent, Boolean on_object)
        {
            return position_copy(Pos_pattern.Id, Pos_parent.Id, on_object);
        }

        /// <summary>
        /// Метод копирует выбранную позицию в текущее расположение
        /// </summary>
        public position position_copy(position Pos_pattern, Boolean on_object)
        {
            return position_copy(Pos_pattern.Id, Pos_pattern.Id_parent, on_object);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_copy(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_copy");
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

        #region ИЗМЕНИТЬ
        /// <summary>
        /// Метод изменяет указанную позицию
        /// </summary>
        public position pos_upd(Int64 id, String iname, String idesc, Int32 isort)
        {
            position position = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("position_upd");

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
                        position = pos_by_id(id);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.position, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (position != null)
            {
                //Генерируем событие изменения позиции
                PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Update);
                PositionOnChange(e);
            }
            //Возвращаем Объект
            return position;
        }
        
        /// <summary>
        /// Метод изменяет указанную позицию
        /// </summary>
        public position pos_upd(position pos)
        {
            return pos_upd(pos.Id, pos.NamePosition, pos.Desc, pos.Sort);
        }
       

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_upd");
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
        /// Метод переносит дочернюю позицию в новую родительскую позицию
        /// </summary>
        public position pos_move(Int64 ChildPos, Int64 ParentPos)
        {
            position position = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("position_move");

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

            cmdk.Parameters["iid"].Value = ChildPos;
            cmdk.Parameters["iid_parent"].Value = ParentPos;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    position = pos_by_id(ChildPos);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(ChildPos, eEntity.position, error, desc_error, eAction.Move, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (position != null)
            {
                //Генерируем событие изменения позиции
                PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Move);
                PositionOnChange(e);
            }
            //Возвращаем Объект
            return position;
        }

        /// <summary>
        /// Метод переносит дочернюю позицию в новую родительскую позицию
        /// </summary>
        public position pos_move(position ChildPos, position ParentPos)
        {
            return pos_move(ChildPos.Id, ParentPos.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_move(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_move");
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
        /// Метод переносит дочернюю позицию в корень дерева концепции
        /// </summary>
        public position pos_move_root(Int64 ChildPos)
        {
            position position = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("position_move");

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

            cmdk.Parameters["iid"].Value = ChildPos;
            cmdk.Parameters["iid_parent"].Value = 0;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    position = pos_by_id(ChildPos);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(ChildPos, eEntity.position, error, desc_error, eAction.Move, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (position != null)
            {
                //Генерируем событие изменения позиции
                PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Move);
                PositionOnChange(e);
            }
            //Возвращаем Объект
            return position;
        }

        /// <summary>
        /// Метод переносит дочернюю позицию в корень дерева концепции
        /// </summary>
        public position pos_move_root(position ChildPos)
        {
            return pos_move_root(ChildPos.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_move_root(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_move");
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
        /// Метод изменяет блокировку позиции
        /// </summary>
        public position pos_changelock(Int64 iid, Boolean onlock)
        {
            position position = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("position_changelock");

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
            cmdk.Parameters["onlock"].Value = onlock;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            //Генерируем событие изменения позиции
            eAction Action;
            if (onlock)
            {
                Action = eAction.Lock;
            }
            else
            {
                Action = eAction.UnLock;
            }
            switch (error)
            {
                case 0:
                    position = pos_by_id(iid);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid, eEntity.position, error, desc_error, Action, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (position != null)
            {
                PositionChangeEventArgs e = new PositionChangeEventArgs(position, Action);
                PositionOnChangeLock(e);
            }
            //Возвращаем Объект
            return position;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_changelock(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_changelock");
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

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанную позицию
        /// </summary>
        public void pos_del(Int64 id)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("position_del");

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

            position position = pos_by_id(id);

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
                JournalEventArgs me = new JournalEventArgs(id, eEntity.position, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие изменения концепции
            if (position != null)
            {
                PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Delete);
                PositionOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет указанную позицию
        /// </summary>
        public void pos_del(position pos)
        {
            pos_del(pos.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_del");
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
        /// Позиция по идентификатору
        /// </summary>
        public position pos_by_id(Int64 id)
        {
            position position = null;

            DataTable tbl_pos  = TableByName("vposition");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_by_id");

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
                cmdk.Fill(tbl_pos);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            
            if (tbl_pos.Rows.Count > 0)
            {
                position = new position(tbl_pos.Rows[0]);
            }
            return position;
        }

        /// <summary>
        /// Позиция по объекту pos_path
        /// </summary>
        public position pos_by_pos_path(pos_path pos_path)
        {
            return pos_by_id(pos_path.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_by_id");
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
        /// Лист позиций по идентификатору родительской позиции
        /// position_by_id_parent
        /// </summary>
        public List<position> pos_by_id_parent(Int64 id_parent, Int64 id_con)
        {
            List<position>  pos_list = new List<position>();

            
            DataTable tbl_pos  = TableByName("vposition");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_by_id_parent");

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
                cmdk.Fill(tbl_pos);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            position pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = new position(dr);
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист позиций по идентификатору родительской позиции
        /// position_by_id_parent
        /// </summary>
        public List<position> pos_by_id_parent(position Position)
        {
            return pos_by_id_parent(Position.Id, Position.Id_conception);
        }

        /// <summary>
        /// Лист позиций по идентификатору родительской позиции с учетом шаблона позиции
        /// position_by_id_parent
        /// </summary>
        public List<position> pos_by_id_parent(Int64 id_parent, Int64 id_con, Int64 id_pos_temp)
        {
            return pos_by_id_parent(id_parent, id_con).FindAll(x => x.Id_pos_temp == id_pos_temp);
        }

        /// <summary>
        /// Лист позиций по идентификатору родительской позиции с учетом шаблона позиции
        /// position_by_id_parent
        /// </summary>
        public List<position> pos_by_id_parent(position Position, pos_temp Pos_temp)
        {
            return pos_by_id_parent(Position.Id, Position.Id_conception, Pos_temp.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// position_by_id_parent
        /// </summary>
        public Boolean pos_by_id_parent(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_by_id_parent");
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
        /// Лист позиций по идентификатору шаблона позиции
        /// </summary>
        public List<position> pos_by_id_pos_temp(Int64 id_pos_temp)
        {
            List<position> pos_list = new List<position>();
            DataTable tbl_pos  = TableByName("vposition");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_by_id_pos_temp");

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

            cmdk.Parameters["iid_pos_temp"].Value = id_pos_temp;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_pos);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            position pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = new position(dr);
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист позиций по идентификатору шаблона позиции
        /// </summary>
        public List<position> pos_by_id_pos_temp(pos_temp pos_temp)
        {
            return pos_by_id_pos_temp(pos_temp.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_by_id_pos_temp");
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
        /// Лист позиций по идентификатору глобального свойства
        /// </summary>
        public List<position> position_by_id_global_prop(Int64 iid_global_prop)
        {
            List<position> pos_list = new List<position>();
            DataTable tbl_pos = TableByName("vposition");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_by_id_global_prop");

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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_pos);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            position pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = new position(dr);
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист позиций по идентификатору глобального свойства
        /// </summary>
        public List<position> position_by_id_global_prop(global_prop Global_prop)
        {
            return position_by_id_global_prop(Global_prop.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_by_id_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_by_id_global_prop");
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
        /// Лист позиций по идентификатору типа данных свойств
        /// </summary>
        public List<position> position_by_id_prop_data_type(Int64 iid_conception, Int64 iid_prop_data_type)
        {
            List<position> pos_list = new List<position>();
            DataTable tbl_pos = TableByName("vposition");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_by_id_prop_data_type");

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

            cmdk.Parameters["iid_conception"].Value = iid_conception;
            cmdk.Parameters["iid_prop_data_type"].Value = iid_prop_data_type;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_pos);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            position pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = new position(dr);
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист позиций по идентификатору типа данных свойств
        /// </summary>
        public List<position> position_by_id_prop_data_type(con_prop_data_type Con_prop_data_type)
        {
            return position_by_id_prop_data_type(Con_prop_data_type.Id_conception, Con_prop_data_type.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_by_id_prop_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_by_id_prop_data_type");
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
        /// Лист позиций по идентификатору перечисления
        /// </summary>
        public List<position> position_by_id_prop_enum(Int64 iid_prop_enum)
        {
            List<position> pos_list = new List<position>();
            DataTable tbl_pos = TableByName("vposition");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_by_id_prop_enum");

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

            cmdk.Parameters["iid_prop_enum"].Value = iid_prop_enum;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_pos);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            position pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = new position(dr);
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист позиций по идентификатору перечисления
        /// </summary>
        public List<position> position_by_id_prop_enum(prop_enum Prop_enum)
        {
            return position_by_id_prop_enum(Prop_enum.Id_prop_enum);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_by_id_prop_enum(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_by_id_prop_enum");
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
        /// Лист позиций по идентификатору элемента перечисления
        /// </summary>
        public List<position> position_by_id_prop_enum_val(Int64 iid_prop_enum_val)
        {
            List<position> pos_list = new List<position>();
            DataTable tbl_pos = TableByName("vposition");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_by_id_prop_enum_val");

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

            cmdk.Parameters["iid_prop_enum_val"].Value = iid_prop_enum_val;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_pos);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            position pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = new position(dr);
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист шаблонов по идентификатору элемента перечисления
        /// </summary>
        public List<position> position_by_id_prop_enum_val(prop_enum_val Prop_enum_val)
        {
            return position_by_id_prop_enum_val(Prop_enum_val.Id_prop_enum_val);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_by_id_prop_enum_val(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_by_id_prop_enum_val");
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
        /// Лист макетов наименований позиций по идентификатору шаблона позиции
        /// </summary>
        public List<String> position_name_layout_by_id_pos_temp(Int64 iid_pos_temp)
        {
            List<String> pos_list = new List<String>();
            DataTable tbl_pos = new DataTable();
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_name_layout_by_id_pos_temp");

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

            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_pos);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            String pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = (String)dr[0];
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист макетов наименований позиций по идентификатору шаблона позиции
        /// </summary>
        public List<String> position_name_layout_by_id_pos_temp(pos_temp pos_temp)
        {
            return position_name_layout_by_id_pos_temp(pos_temp.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_name_layout_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_name_layout_by_id_pos_temp");
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
        /// Лист дочерних позиций по строгому соотвествию имени
        /// </summary>
        public List<position> position_by_name(Int64 iid_parent, String iname)
        {
            List<position> pos_list = new List<position>();


            DataTable tbl_pos  = TableByName("vposition");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_by_name");

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
                cmdk.Fill(tbl_pos);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            position pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = new position(dr);
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист дочерних позиций по строгому соотвествию имени
        /// </summary>
        public List<position> position_by_name(position Position, String iname)
        {
            return position_by_name(Position.Id, iname);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_by_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_by_name");
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

        #region СВОЙСТВА ПОЛУЧАЕМЫЕ ИЗ БД
        //*********************************************************************************************
        /// <summary>
        /// Метод определяет актуальность состояния позиции
        /// </summary>
        public eEntityState pos_is_actual(Int64 iid, DateTime itimestamp, DateTime itimestamp_child_change)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("position_is_actual3");

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
            ;
        }

        /// <summary>
        /// Метод определяет актуальность состояния шаблона позиции
        /// </summary>
        public eEntityState pos_is_actual(position Position)
        {
            return pos_is_actual(Position.Id, Position.Timestamp, Position.Timestamp_child_change);
        }
        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ ШАБЛОНАМИ ПОЗИЦИЙ

        /// <summary>
        /// Делегат события изменения позиции
        /// </summary>
        public delegate void PositionChangeEventHandler(Object sender, PositionChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении позиции методом доступа к БД
        /// </summary>
        public event PositionChangeEventHandler PositionChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения позиции
        /// </summary>
        protected virtual void PositionOnChange(PositionChangeEventArgs e)
        {
            PositionChangeEventHandler temp = PositionChange;

            if (temp != null)
            {
                temp(this, e);
            }
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(e);
            JournalMessageOnReceived(me);
        }

        /// <summary>
        /// Событие возникает при изменении блокировки позиции методом доступа к БД
        /// </summary>
        public event PositionChangeEventHandler PositionChangeLock;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения блокировки позиции
        /// </summary>
        protected virtual void PositionOnChangeLock(PositionChangeEventArgs e)
        {
            PositionChangeEventHandler temp = PositionChangeLock;

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
