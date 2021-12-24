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
        #region МЕТОДЫ КЛАССА: СВОЙСТВА ШАБЛОНА ПОЗИЦИИ

        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новое свойство шаблона
        /// </summary>
        public pos_temp_prop pos_temp_prop_add(Int64 iid_pos_temp, Int32 iid_prop_type, Boolean ion_override, Int32 iid_data_type, String iname, String idesc, Int32 isort)
        {
            pos_temp_prop pos_temp_prop = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_prop_add");

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
            cmdk.Parameters["iid_prop_type"].Value = iid_prop_type;
            cmdk.Parameters["ion_override"].Value = ion_override;
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;
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
                        pos_temp_prop = pos_temp_prop_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.pos_temp_prop, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства
            PosTempPropChangeEventArgs e = new PosTempPropChangeEventArgs(pos_temp_prop, eAction.Insert);
            PosTempPropOnChange(e);
            //Возвращаем Объект
            return pos_temp_prop;
        }

        /// <summary>
        /// Метод добавляет новое свойство класса
        /// </summary>
        public pos_temp_prop pos_temp_prop_add(pos_temp PosTemp, prop_type Prop_type, Boolean On_Override, con_prop_data_type Data_type, String iname, String idesc, Int32 isort)
        {
            return pos_temp_prop_add(PosTemp.Id, Prop_type.Id, On_Override, Data_type.Id, iname, idesc, isort);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_add");
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
        /// Метод изменяет свойство шаблона
        /// </summary>
        public pos_temp_prop pos_temp_prop_upd(Int64 iid, Int32 iid_prop_type, Boolean ion_override, Int32 iid_data_type, String iname, String idesc, Int32 isort)
        {
            pos_temp_prop pos_temp_prop = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_prop_upd");

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
            cmdk.Parameters["iid_prop_type"].Value = iid_prop_type;
            cmdk.Parameters["ion_override"].Value = ion_override;
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["isort"].Value = isort;
            //=======================

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    pos_temp_prop = pos_temp_prop_by_id(iid);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid, eEntity.pos_temp_prop, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства
            PosTempPropChangeEventArgs e = new PosTempPropChangeEventArgs(pos_temp_prop, eAction.Update);
            PosTempPropOnChange(e);
            //Возвращаем Объект
            return pos_temp_prop;
        }

        /// <summary>
        /// Метод изменяет свойство активного представления класса
        /// </summary>
        public pos_temp_prop pos_temp_prop_upd(pos_temp_prop PosTempProp)
        {
            return pos_temp_prop_upd(PosTempProp.Id, PosTempProp.Id_prop_type, PosTempProp.On_override, PosTempProp.Id_data_type, PosTempProp.Name, PosTempProp.Desc, PosTempProp.Sort);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_upd");
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
        /// Метод удаляет свойство шаблона
        /// </summary>
        public void pos_temp_prop_del(Int64 iid)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_prop_del");

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

            //Запрос удаляемой сущности
            pos_temp_prop pos_temp_prop = pos_temp_prop_by_id(iid);

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid, eEntity.pos_temp_prop, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления свойства
            if (pos_temp_prop != null)
            {
                PosTempPropChangeEventArgs e = new PosTempPropChangeEventArgs(pos_temp_prop, eAction.Delete);
                PosTempPropOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет свойство шаблона
        /// </summary>
        public void pos_temp_prop_del(pos_temp_prop PosTempProp)
        {
            if (PosTempProp != null)
            {
                pos_temp_prop_del(PosTempProp.Id);
            }
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_del");
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
        /// Выбор свойства шаблона по идентификатору свойства
        /// </summary>
        public pos_temp_prop pos_temp_prop_by_id(Int64 iid)
        {
            pos_temp_prop pos_temp_prop = null;

            DataTable tbl_vpos_temp_prop  = TableByName("vpos_temp_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_prop_by_id");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vpos_temp_prop);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_vpos_temp_prop.Rows.Count > 0)
            {
                pos_temp_prop = new pos_temp_prop(tbl_vpos_temp_prop.Rows[0]);
            }
            return pos_temp_prop;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_by_id");
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
        /// Выбор свойства шаблона по идентификатору глобального свойства
        /// </summary>
        public pos_temp_prop pos_temp_prop_by_id_global_prop(Int64 iid_pos_temp, Int64 iid_global_prop)
        {
            pos_temp_prop pos_temp_prop = null;

            DataTable tbl_vpos_temp_prop  = TableByName("vpos_temp_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_prop_by_id_global_prop");

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
            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vpos_temp_prop);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_vpos_temp_prop.Rows.Count > 0)
            {
                pos_temp_prop = new pos_temp_prop(tbl_vpos_temp_prop.Rows[0]);
            }
            return pos_temp_prop;
        }

        /// <summary>
        /// Выбор свойства шаблона по идентификатору глобального свойства
        /// </summary>
        public pos_temp_prop pos_temp_prop_by_id_global_prop(pos_temp Pos_temp, global_prop Global_prop)
        {
            return pos_temp_prop_by_id_global_prop(Pos_temp.Id, Global_prop.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_by_id_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_by_id_global_prop");
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
        /// Лист свойств шаблона по идентификатору шаблона
        /// </summary>
        public List<pos_temp_prop> pos_temp_prop_by_id_pos_temp(Int64 iid_pos_temp)
        {
            List<pos_temp_prop> pos_temp_prop_list = new List<pos_temp_prop>();


            DataTable tbl_pos_temp_prop  = TableByName("vpos_temp_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_prop_by_id_pos_temp");

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
                cmdk.Fill(tbl_pos_temp_prop);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            pos_temp_prop cp;
            if (tbl_pos_temp_prop.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos_temp_prop.Rows)
                {
                    cp = new pos_temp_prop(dr);
                    pos_temp_prop_list.Add(cp);
                }
            }
            return pos_temp_prop_list;
        }

        /// <summary>
        /// Лист свойств представления активного класса по идентификатору класса
        /// </summary>
        public List<pos_temp_prop> pos_temp_prop_by_id_pos_temp(pos_temp PosTemp)
        {
            return pos_temp_prop_by_id_pos_temp(PosTemp.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_by_id_pos_temp");
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
        /// Метод определяет актуальность состояния свойства активного класса 
        /// </summary>
        public eEntityState pos_temp_prop_is_actual(Int64 iid, DateTime itimestamp)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_prop_is_actual");

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

            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
           
            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Метод определяет актуальность состояния свойства активного класса 
        /// </summary>
        public eEntityState pos_temp_prop_is_actual(pos_temp_prop PosTempProp)
        {
            return pos_temp_prop_is_actual(PosTempProp.Id, PosTempProp.Timestamp);
        }
        #endregion

        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ СВОЙСТВАМИ ШАБЛОНОВ

        /// <summary>
        /// Делегат события изменения свойства шаблона позиции
        /// </summary>
        public delegate void PosTempPropChangeEventHandler(Object sender, PosTempPropChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении свойства шаблона позиции методом доступа к БД
        /// </summary>
        public event PosTempPropChangeEventHandler PosTempPropChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения свойства позиции
        /// </summary>
        protected virtual void PosTempPropOnChange(PosTempPropChangeEventArgs e)
        {
            PosTempPropChangeEventHandler temp = PosTempPropChange;

            if (temp != null)
            {
                temp(this, e);
            }
        }

        #endregion
    }
}
