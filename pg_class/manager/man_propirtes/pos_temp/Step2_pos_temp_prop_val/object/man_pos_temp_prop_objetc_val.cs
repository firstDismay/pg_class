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
        #region МЕТОДЫ КЛАССА: УПРАВЛЕНИЕ ЗНАЧЕНИЯМИ ОБЪЕКТНЫХ СВОЙСТВ КЛАССОВ ШАГ №02

        #region ДОБАВИТЬ

        /// <summary>
        /// Добавить новое значение объектного свойства шаблона
        /// </summary>
        public pos_temp_prop_object_val pos_temp_prop_object_val_add(Int64 iid_pos_temp_prop, Int64 iid_class_val, 
                                     Decimal ibquantity_min, Decimal ibquantity_max,
                                     eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 iembed_class_real_id, Int32 iid_unit_conversion_rule)
        {
            pos_temp_prop_object_val pos_temp_prop_object_val = null;
            pos_temp_prop pos_temp_prop = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_prop_object_val_add");

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

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
            cmdk.Parameters["iid_class_val"].Value = iid_class_val;
            cmdk.Parameters["ibquantity_min"].Value = ibquantity_min;
            cmdk.Parameters["ibquantity_max"].Value = ibquantity_max;

            cmdk.Parameters["iembed_mode"].Value = (Int32)iembed_mode;
            cmdk.Parameters["iembed_single"].Value = iembed_single;
            cmdk.Parameters["iembed_class_real_id"].Value = iembed_class_real_id;
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    pos_temp_prop = pos_temp_prop_by_id(iid_pos_temp_prop);
                    pos_temp_prop_object_val = pos_temp_prop.object_data_get();
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_pos_temp_prop, eEntity.pos_temp_prop_object_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            PosTempPropChangeEventArgs e = new PosTempPropChangeEventArgs(pos_temp_prop, eAction.Update);
            PosTempPropOnChange(e);
            
            //Генерируем событие изменения значения объектного свойства класса
            PosTempPropObjectValChangeEventArgs e2 = new PosTempPropObjectValChangeEventArgs(pos_temp_prop_object_val, eAction.Insert);
            PosTempPropObjectValOnChange(e2);
            //Возвращаем Объект
            return pos_temp_prop_object_val;
        }

        /// <summary>
        /// Добавить новое значение объектного свойства шаблона
        /// </summary>
        public pos_temp_prop_object_val pos_temp_prop_object_val_add(pos_temp_prop PosTemp_prop, vclass class_val,
                       Decimal ibquantity_min, Decimal ibquantity_max,
                                     eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 embed_class_real_id, Int32 iid_unit_conversion_rule)
        {
            return  pos_temp_prop_object_val_add(PosTemp_prop.Id, class_val.Id, ibquantity_min, ibquantity_max, iembed_mode, iembed_single, embed_class_real_id, iid_unit_conversion_rule);
        }


        /// <summary>
        /// Добавить новое значение объектного свойства шаблона
        public pos_temp_prop_object_val pos_temp_prop_object_val_add(pos_temp_prop PosTemp_prop, vclass class_val,
                       Decimal ibquantity_min, Decimal ibquantity_max,
                                     eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 embed_class_real_id, unit_conversion_rule Unit_conversion_rule)
        {
            pos_temp_prop_object_val Result = null;
            if (PosTemp_prop != null)
            {
                Result = pos_temp_prop_object_val_add(PosTemp_prop.Id, class_val.Id, ibquantity_min, ibquantity_max, iembed_mode, iembed_single, embed_class_real_id, Unit_conversion_rule.Id);
            }
            return Result;
        }


        /// <summary>
        /// Добавить новое значение объектного свойства шаблона
        /// </summary>
        public pos_temp_prop_object_val pos_temp_prop_object_val_add(pos_temp_prop_object_val PosTemp_prop_object_val)
        {
            pos_temp_prop_object_val Result = null;
            if (PosTemp_prop_object_val != null)
            {
                Result = pos_temp_prop_object_val_add(PosTemp_prop_object_val.Id_pos_temp_prop, PosTemp_prop_object_val.Id_class_val, PosTemp_prop_object_val.Bquantity_min, 
                    PosTemp_prop_object_val.Bquantity_max,
                                        PosTemp_prop_object_val.Embed_mode, PosTemp_prop_object_val.Embed_single, PosTemp_prop_object_val.Embed_class_real_id, PosTemp_prop_object_val.Id_unit_conversion_rule);
            }
            return Result;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_object_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_object_val_add");
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
        /// Изменить данные значения объектного свойства шаблона
        /// </summary>
        public pos_temp_prop_object_val pos_temp_prop_object_val_upd(Int64 iid_pos_temp_prop, Int64 iid_class_val,
                                                                    Decimal ibquantity_min, Decimal ibquantity_max,
                                                                eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 iembed_class_real_id, Int32 iid_unit_conversion_rule)
        {
            pos_temp_prop_object_val pos_temp_prop_object_val = null;
            pos_temp_prop pos_temp_prop = null;
            Int64 id;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_prop_object_val_upd");

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

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
            cmdk.Parameters["iid_class_val"].Value = iid_class_val;

            cmdk.Parameters["ibquantity_min"].Value = ibquantity_min;
            cmdk.Parameters["ibquantity_max"].Value = ibquantity_max;

            cmdk.Parameters["iembed_mode"].Value = (Int32)iembed_mode;
            cmdk.Parameters["iembed_single"].Value = iembed_single;
            cmdk.Parameters["iembed_class_real_id"].Value = iembed_class_real_id;
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
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
                    pos_temp_prop = pos_temp_prop_by_id(iid_pos_temp_prop);
                    pos_temp_prop_object_val = pos_temp_prop.object_data_get();
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_pos_temp_prop, eEntity.pos_temp_prop_object_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            
            //Генерируем событие изменения свойства шаблона
            PosTempPropChangeEventArgs e = new PosTempPropChangeEventArgs(pos_temp_prop, eAction.Update);
            PosTempPropOnChange(e);
            
            //Генерируем событие изменения данных значения объектного свойства шаблона
            PosTempPropObjectValChangeEventArgs e2 = new PosTempPropObjectValChangeEventArgs(pos_temp_prop_object_val, eAction.Update);
            PosTempPropObjectValOnChange(e2);
            //Возвращаем Объект
            return pos_temp_prop_object_val;
        }

        /// <summary>
        /// Изменить данные значения объектного свойства шаблона
        /// </summary>
        public pos_temp_prop_object_val pos_temp_prop_object_val_upd(pos_temp_prop_object_val PosTemp_prop_obj_val)
        {

            pos_temp_prop_object_val Result = null;
            if (PosTemp_prop_obj_val != null)
            {
                Result = pos_temp_prop_object_val_upd(PosTemp_prop_obj_val.Id_pos_temp_prop, PosTemp_prop_obj_val.Id_class_val,
                                                                     PosTemp_prop_obj_val.Bquantity_min, PosTemp_prop_obj_val.Bquantity_max,
                                        PosTemp_prop_obj_val.Embed_mode, PosTemp_prop_obj_val.Embed_single, PosTemp_prop_obj_val.Embed_class_real_id, PosTemp_prop_obj_val.Id_unit_conversion_rule);
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_object_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_object_val_upd");
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
        /// Удалить данные значени объектного свойства шаблона
        /// </summary>
        public void pos_temp_prop_object_val_del(Int64 iid_pos_temp_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            pos_temp_prop_object_val pos_temp_prop_object_val = null;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_prop_object_val_del");

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

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            //Предварительный запрос данных
            pos_temp_prop_object_val = pos_temp_prop_object_val_by_id_prop(iid_pos_temp_prop);

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            pos_temp_prop pos_temp_prop = pos_temp_prop_by_id(iid_pos_temp_prop);
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_pos_temp_prop, eEntity.class_prop_object_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления значения свойства класса
            if (pos_temp_prop != null)
            {
                PosTempPropChangeEventArgs e = new PosTempPropChangeEventArgs(pos_temp_prop, eAction.Update);
                PosTempPropOnChange(e);

                //Генерируем событие изменения значения объектного свойства класса
                PosTempPropObjectValChangeEventArgs e2 = new PosTempPropObjectValChangeEventArgs(pos_temp_prop_object_val, eAction.Delete);
                PosTempPropObjectValOnChange(e2);
            }
        }


        /// <summary>
        /// Удалить данные значени объектного свойства шаблона
        /// </summary>
        public void pos_temp_prop_object_val_del(pos_temp_prop PosTemp_prop)
        {
            if (PosTemp_prop != null)
            {
                pos_temp_prop_object_val_del(PosTemp_prop.Id);
            }
        }

        /// <summary>
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void pos_temp_prop_object_val_del(pos_temp_prop_object_val PosTempPropObjectVal)
        {
            if (PosTempPropObjectVal != null)
            {
                pos_temp_prop_object_val_del(PosTempPropObjectVal.Id_pos_temp_prop);
            }
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_object_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_object_val_del");
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

        #region ВЫБРАТЬ ДАННЫЕ ЗНАЧЕНИЯ СВОЙСТВА ДЛЯ ШАБЛОНА

        //*********************************************************************************************
        /// <summary>
        /// Выбрать данные значения объектного свойства шаблона по идентификатору значения свойства
        /// </summary>
        public pos_temp_prop_object_val pos_temp_prop_object_val_by_id(Int64 iid)
        {
            pos_temp_prop_object_val pos_temp_prop_object_val = null;

            DataTable tbl_Entity  = TableByName("vpos_temp_prop_object_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_prop_object_val_by_id");

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

            cmdk.Fill(tbl_Entity);
            
            if (tbl_Entity.Rows.Count > 0)
            {
                pos_temp_prop_object_val = new pos_temp_prop_object_val(tbl_Entity.Rows[0]);
            }
            return pos_temp_prop_object_val;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_object_val_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_object_val_by_id");
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
        /// Выбрать данные значения объектного свойства шаблона по идентификатору свойства
        /// </summary>
        public pos_temp_prop_object_val pos_temp_prop_object_val_by_id_prop(Int64 iid_pos_temp_prop)
        {
            pos_temp_prop_object_val pos_temp_prop_object_val = null;

            DataTable tbl_Entity  = TableByName("vpos_temp_prop_object_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_prop_object_val_by_id_prop");

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

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            cmdk.Fill(tbl_Entity);
            
            if (tbl_Entity.Rows.Count > 0)
            {
                pos_temp_prop_object_val = new pos_temp_prop_object_val(tbl_Entity.Rows[0]);
            }
            return pos_temp_prop_object_val;
        }

        /// <summary>
        /// Выбрать значение свойства активного представления класса по идентификатору свойства
        /// </summary>
        public pos_temp_prop_object_val pos_temp_prop_object_val_by_id_prop(pos_temp_prop PosTemp_prop)
        {
            return pos_temp_prop_object_val_by_id_prop(PosTemp_prop.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_object_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_object_val_by_id_prop");
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

        #region ВЫБРАТЬ КЛАСС ЗНАЧЕНИЕ ДЛЯ ОБЪЕКТНОГО СВОЙСТВА АКТИВНОГО ПРЕДСТАВЛЕНИЯ КЛАССА
        /// <summary>
        /// Выбор класса значения объектного свойства шаблона step№2 по идентификатору свойства шаблона
        /// </summary>
        public vclass class_pos_temp_prop_object_by_id_pos_temp_prop(Int64 iid_pos_temp_prop)
        {
            vclass vclass = null;

            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_pos_temp_prop_object_by_id_pos_temp_prop");

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

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            cmdk.Fill(tbl_vclass);
            
            if (tbl_vclass.Rows.Count > 0)
            {
                vclass = new vclass(tbl_vclass.Rows[0]);
            }
            return vclass;
        }


        /// <summary>
        /// Выбор класса значения объектного свойства активного класса шаг №2
        /// </summary>
        public vclass class_pos_temp_prop_object_by_id_pos_temp_prop(pos_temp_prop PosTemp_prop)
        {
            return class_pos_temp_prop_object_by_id_pos_temp_prop(PosTemp_prop.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_pos_temp_prop_object_by_id_pos_temp_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_pos_temp_prop_object_by_id_pos_temp_prop");
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
        
        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ СВОЙСТВАМИ КЛАССОВ

        /// <summary>
        /// Делегат события изменения значения свойства класса
        /// </summary>
        public delegate void PosTempPropObjectValChangeEventHandler(Object sender, PosTempPropObjectValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения свойства шаблона
        /// </summary>
        public event PosTempPropObjectValChangeEventHandler PosTempPropObjectValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения свойства шаблона
        /// </summary>
        protected virtual void PosTempPropObjectValOnChange(PosTempPropObjectValChangeEventArgs e)
        {
            PosTempPropObjectValChangeEventHandler temp = PosTempPropObjectValChange;
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
