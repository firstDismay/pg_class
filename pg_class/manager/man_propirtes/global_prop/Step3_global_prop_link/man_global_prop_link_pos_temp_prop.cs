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
        #region ВКЛЮЧИТЬ

        /// <summary>
        /// Метод добавляет свойство класса к глобальному свойству
        /// </summary>
        public global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop_include( Int64 iid_global_prop, Int64 iid_pos_temp_prop)
        {
            global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop = null;
            pos_temp_prop prop_link;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("global_prop_link_pos_temp_prop_include");

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
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            //Начало транзакции
            cmdk.ExecuteNonQuery();

            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    global_prop_link_pos_temp_prop = global_prop_link_pos_temp_prop_by_id(iid_global_prop, iid_pos_temp_prop);
                    prop_link = pos_temp_prop_by_id(iid_pos_temp_prop);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_global_prop, iid_pos_temp_prop, eEntity.global_prop_link_pos_temp_prop, error, desc_error, eAction.Include, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (global_prop_link_pos_temp_prop != null)
            {
                //Генерируем событие изменения
                GlobalPropLinkPosTempPropChangeEventArgs e = new GlobalPropLinkPosTempPropChangeEventArgs(global_prop_link_pos_temp_prop, eAction.Include);
                GlobalPropLinkPosTempPropOnChange(e);
            }

            if (prop_link != null)
            {
                //Генерируем событие изменения свойства шаблона
                PosTempPropChangeEventArgs e2 = new PosTempPropChangeEventArgs(prop_link, eAction.Update);
                PosTempPropOnChange(e2);
            }
            //Возвращаем Объект
            return global_prop_link_pos_temp_prop;
        }

        /// <summary>
        /// Метод добавляет свойство класса к глобальному свойству
        /// </summary>
        public global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop_include(global_prop GlobalProp, pos_temp_prop PosTempProp)
        {
            global_prop_link_pos_temp_prop Result = null;
            if ((GlobalProp != null) & (PosTempProp != null))
            {
                Result = global_prop_link_pos_temp_prop_include(GlobalProp.Id, PosTempProp.Id);
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_link_pos_temp_prop_include(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_link_pos_temp_prop_include");
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

        #region ИСКЛЮЧИТЬ
        /// <summary>
        /// Метод удаляет свойство класса из глобального свойства
        /// </summary>
        public global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop_exclude(Int64 iid_global_prop, Int64 iid_pos_temp_prop)
        {
            Int32 error;
            String desc_error;
            global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop;
            pos_temp_prop prop_link;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("global_prop_link_pos_temp_prop_exclude");

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
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            //Запрос удаляемой сущности
            global_prop_link_pos_temp_prop = global_prop_link_pos_temp_prop_by_id(iid_global_prop, iid_pos_temp_prop);
            //Начало транзакции
            cmdk.ExecuteNonQuery();
           
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();

            //=======================
            if (error == 0)
            {
                prop_link = pos_temp_prop_by_id(iid_pos_temp_prop);
            }
            else
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_global_prop, iid_pos_temp_prop, eEntity.global_prop_link_class_prop, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }
            if (global_prop_link_pos_temp_prop != null)
            {
                //Генерируем событие изменения
                GlobalPropLinkPosTempPropChangeEventArgs e = new GlobalPropLinkPosTempPropChangeEventArgs(global_prop_link_pos_temp_prop, eAction.Delete);
                GlobalPropLinkPosTempPropOnChange(e);
            }

            if (prop_link != null)
            {
                //Генерируем событие изменения свойства шаблона
                PosTempPropChangeEventArgs e2 = new PosTempPropChangeEventArgs(prop_link, eAction.Update);
                PosTempPropOnChange(e2);
            }
            //Возвращаем Объект
            return global_prop_link_pos_temp_prop;
        }

        /// <summary>
        /// Метод удаляет свойство класса из глобального свойства
        /// </summary>
        public global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop_exclude(global_prop GlobalProp, pos_temp_prop PosTempProp)
        {
            global_prop_link_pos_temp_prop Result = null;
            if ((GlobalProp != null) & (PosTempProp != null))
            {
                Result = global_prop_link_pos_temp_prop_exclude(GlobalProp.Id, PosTempProp.Id);
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_link_pos_temp_prop_exclude(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_link_pos_temp_prop_exclude");
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
        /// Выбор ссылки глобального свойства на свойство класса по идентификатору ссылки
        /// </summary>
        public global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop_by_id(Int64 iid_global_prop, Int64 iid_pos_temp_prop)
        {
            global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop = null;

            DataTable tbl_vglobal_prop_link  = TableByName("vglobal_prop_link_pos_temp_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("global_prop_link_pos_temp_prop_by_id");

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
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            cmdk.Fill(tbl_vglobal_prop_link);
            
            if (tbl_vglobal_prop_link.Rows.Count > 0)
            {
                global_prop_link_pos_temp_prop = new global_prop_link_pos_temp_prop(tbl_vglobal_prop_link.Rows[0]);
            }
            return global_prop_link_pos_temp_prop;
        }

        /// <summary>
        /// Выбор ссылки глобального свойства на свойство класса по идентификатору ссылки
        /// </summary>
        public global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop_by_id(global_prop GlobalProp, pos_temp_prop PosTempProp)
        {
            return global_prop_link_pos_temp_prop_by_id(GlobalProp.Id, PosTempProp.Id);
        }

        /// <summary>
        /// Выбор ссылки глобального свойства на свойство класса по идентификатору ссылки
        /// </summary>
        public global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop_by_id(global_prop_link_pos_temp_prop GlobalPropLink)
        {
            return global_prop_link_pos_temp_prop_by_id(GlobalPropLink.Id_global_prop, GlobalPropLink.Id_pos_temp_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_link_pos_temp_prop_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_link_pos_temp_prop_by_id");
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
        /// Лист ссылок глобального свойства на свойства классов по идентификатору глобального свойства
        /// </summary>
        public List<global_prop_link_pos_temp_prop> global_prop_link_pos_temp_prop_by_id_global_prop(Int64 iid_global_prop)
        {
            List<global_prop_link_pos_temp_prop> global_prop_link_list = new List<global_prop_link_pos_temp_prop>();

            
            DataTable tbl_global_prop_link  = TableByName("vglobal_prop_link_pos_temp_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("global_prop_link_pos_temp_prop_by_id_global_prop");

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

            cmdk.Fill(tbl_global_prop_link);
            
            global_prop_link_pos_temp_prop gpl;
            if (tbl_global_prop_link.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_global_prop_link.Rows)
                {
                    gpl = new global_prop_link_pos_temp_prop(dr);
                    global_prop_link_list.Add(gpl);
                }
            }
            return global_prop_link_list;
        }

        /// <summary>
        /// Лист ссылок глобального свойства на свойства классов по идентификатору глобального свойства
        /// </summary>
        public List<global_prop_link_pos_temp_prop> global_prop_link_pos_temp_prop_by_id_global_prop(global_prop GlobalProp)
        {
            return global_prop_link_pos_temp_prop_by_id_global_prop(GlobalProp.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_link_pos_temp_prop_by_id_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_link_pos_temp_prop_by_id_global_prop");
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
        /// Метод определяет актуальность данных значения глобального свойства концепции
        /// </summary>
        public eEntityState global_prop_link_pos_temp_prop_is_actual(Int64 iid_global_prop, Int64 iid_pos_temp_prop)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
           
            //=======================
            cmdk = CommandByKey("global_prop_link_pos_temp_prop_is_actual");

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
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            is_actual = (Int32)cmdk.ExecuteScalar();
            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Метод определяет актуальность данных значения глобального свойства концепции
        /// </summary>
        public eEntityState global_prop_link_pos_temp_prop_is_actual(global_prop_link_pos_temp_prop GlobalPropLinkPosTempProp)
        {
            return global_prop_link_pos_temp_prop_is_actual(GlobalPropLinkPosTempProp.Id_global_prop, GlobalPropLinkPosTempProp.Id_pos_temp_prop); ;
        }
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ СВОЙСТВАМИ

        /// <summary>
        /// Делегат события изменения привязки глобального свойства
        /// </summary>
        public delegate void GlobalPropLinkPosTempPropChangeEventHandler(Object sender, GlobalPropLinkPosTempPropChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении привязки глобального свойства
        /// </summary>
        public event GlobalPropLinkPosTempPropChangeEventHandler GlobalPropLinkPosTempPropChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения привязки глобального свойства
        /// </summary>
        protected virtual void GlobalPropLinkPosTempPropOnChange(GlobalPropLinkPosTempPropChangeEventArgs e)
        {
            GlobalPropLinkPosTempPropChangeEventHandler temp = GlobalPropLinkPosTempPropChange;
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
