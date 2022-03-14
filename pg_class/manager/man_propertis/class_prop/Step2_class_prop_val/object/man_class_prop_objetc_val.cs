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
        /// Добавить новое значение объектного свойства активного представления класса
        /// </summary>
        public class_prop_object_val class_prop_object_val_add(Int64 iid_class_prop, Int64 iid_class_val, 
                                     Decimal ibquantity_min, Decimal ibquantity_max,
                                     eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 iembed_class_real_id, Int32 iid_unit_conversion_rule)
        {
            class_prop_object_val class_prop_obj_val_class = null;
            class_prop class_prop = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_prop_object_val_add");

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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
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
                    id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                    if (id > 0)
                    {
                        class_prop_obj_val_class = class_prop_object_val_by_id(id);
                        class_prop = class_prop_by_id(iid_class_prop);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_class_prop, eEntity.class_prop_object_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (class_prop != null)
            {
                //Генерируем событие изменения свойства класса
                ClassPropChangeEventArgs e = new ClassPropChangeEventArgs(class_prop, eAction.Update);
                ClassPropOnChange(e);
            }

            if (class_prop_obj_val_class != null)
            {
                //Генерируем событие изменения значения объектного свойства класса
                ClassPropObjectValChangeEventArgs e2 = new ClassPropObjectValChangeEventArgs(class_prop_obj_val_class, eAction.Insert);
                ClassPropObjectValOnChange(e2);
            }
            //Возвращаем Объект
            return class_prop_obj_val_class;
        }

        /// <summary>
        /// Добавить новое значение объектного свойства активного представления класса
        /// </summary>
        public class_prop_object_val class_prop_object_val_add(class_prop class_prop, vclass class_val,
                       Decimal ibquantity_min, Decimal ibquantity_max,
                                     eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 embed_class_real_id, Int32 iid_unit_conversion_rule)
        {
            class_prop_object_val Result = null;
            if (class_prop != null)
            {
                Result = class_prop_object_val_add(class_prop.Id, class_val.Id, ibquantity_min, ibquantity_max, iembed_mode, iembed_single, embed_class_real_id, iid_unit_conversion_rule);
            }
            return Result;
        }

        /// <summary>
        /// Добавить новое значение объектного свойства активного представления класса
        /// </summary>
        public class_prop_object_val class_prop_object_val_add(class_prop class_prop, vclass class_val,
                       Decimal ibquantity_min, Decimal ibquantity_max,
                                     eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 embed_class_real_id, unit_conversion_rule Unit_conversion_rule)
        {
            class_prop_object_val Result = null;
            if (class_prop != null)
            {
                Result = class_prop_object_val_add(class_prop.Id, class_val.Id, ibquantity_min, ibquantity_max, iembed_mode, iembed_single, embed_class_real_id, Unit_conversion_rule.Id);
            }
            return Result;
        }


        /// <summary>
        /// Добавить новое значение объектного свойства активного представления класса
        /// </summary>
        public class_prop_object_val class_prop_object_val_add(class_prop_object_val Class_prop_object_val)
        {
            class_prop_object_val Result = null;
            if (Class_prop_object_val != null)
            {
                Result = class_prop_object_val_add(Class_prop_object_val.Id_class_prop, Class_prop_object_val.Id_class_val, 
                                        Class_prop_object_val.Bquantity_min, Class_prop_object_val.Bquantity_max,
                                        Class_prop_object_val.Embed_mode, Class_prop_object_val.Embed_single, Class_prop_object_val.Embed_class_real_id, Class_prop_object_val.Id_unit_conversion_rule);
            }
            return Result;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_object_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_object_val_add");
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
        /// Изменить допустимые параметры объектного свойства активного представления класса
        /// </summary>
        public class_prop_object_val class_prop_object_val_upd(Int64 iid_class_prop, Int64 iid_class_val,
                                                                    Decimal ibquantity_min, Decimal ibquantity_max,
                                                                eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 iembed_class_real_id, Int32 iid_unit_conversion_rule)
        {
            class_prop_object_val class_prop_obj_val_class = null;
            class_prop class_prop = null;
            Int64 id;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_prop_object_val_upd");

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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
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
                    id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                    if (id > 0)
                    {
                        class_prop_obj_val_class = class_prop_object_val_by_id(id);
                        class_prop = class_prop_by_id(iid_class_prop);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(class_prop.Id, eEntity.class_prop_object_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (class_prop != null)
            {
                //Генерируем событие изменения свойства класса
                ClassPropChangeEventArgs e = new ClassPropChangeEventArgs(class_prop, eAction.Update);
                ClassPropOnChange(e);
            }

            if (class_prop_obj_val_class != null)
            {
                //Генерируем событие изменения значения объектного свойства класса
                ClassPropObjectValChangeEventArgs e2 = new ClassPropObjectValChangeEventArgs(class_prop_obj_val_class, eAction.Update);
                ClassPropObjectValOnChange(e2);
            }
            //Возвращаем Объект
            return class_prop_obj_val_class;
        }

        /// <summary>
        /// Изменить допустимые параметры объектного свойства активного представления класса
        /// </summary>
        public class_prop_object_val class_prop_object_val_upd(class_prop_object_val Class_prop_object_val)
        {

            class_prop_object_val Result = null;
            if (Class_prop_object_val != null)
            {
                if (Class_prop_object_val.StorageType == eStorageType.Active)
                {
                    Class_prop_object_val = class_prop_object_val_upd(Class_prop_object_val.Id_class_prop, Class_prop_object_val.Id_class_val,
                                                                     Class_prop_object_val.Bquantity_min, Class_prop_object_val.Bquantity_max,
                                        Class_prop_object_val.Embed_mode, Class_prop_object_val.Embed_single, Class_prop_object_val.Embed_class_real_id, Class_prop_object_val.Id_unit_conversion_rule);
                }
                else
                {
                    throw new PgDataException(eEntity.vclass, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод изменения параметров объектного свойства класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_object_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_object_val_upd");
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
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void class_prop_object_val_del(Int64 iid_class_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            class_prop_object_val class_prop_object_val = null;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_prop_object_val_del");

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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;

            //Предварительный запрос данных
            class_prop_object_val = class_prop_object_val_by_id_prop(iid_class_prop);

            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            class_prop class_prop = class_prop_by_id(iid_class_prop);
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_class_prop, eEntity.class_prop_object_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления значения свойства класса
            if (class_prop != null)
            {
                ClassPropChangeEventArgs e = new ClassPropChangeEventArgs(class_prop, eAction.Update);
                ClassPropOnChange(e);
            }

            if (class_prop_object_val != null)
            {
                //Генерируем событие изменения значения объектного свойства класса
                ClassPropObjectValChangeEventArgs e2 = new ClassPropObjectValChangeEventArgs(class_prop_object_val, eAction.Delete);
                ClassPropObjectValOnChange(e2);
            }
        }


        /// <summary>
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void class_prop_object_val_del(class_prop class_prop)
        {
            if (class_prop != null)
            {
                if (class_prop.StorageType == eStorageType.Active)
                {
                    class_prop_object_val_del(class_prop.Id);
                }
                else
                {
                    throw new PgDataException(eEntity.vclass, eAction.Delete, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод удаления значения объектного свойства класса не применим к историческому представлению класса!");
                }
            }
        }

        /// <summary>
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void class_prop_object_val_del(class_prop_object_val ClassPropObjectVal)
        {
            if (ClassPropObjectVal != null)
            {
                if (ClassPropObjectVal.StorageType == eStorageType.Active)
                {
                    class_prop_object_val_del(ClassPropObjectVal.Id_class_prop);
                }
                else
                {
                    throw new PgDataException(eEntity.vclass, eAction.Delete, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод удаления значения объектного свойства класса не применим к историческому представлению класса!");
                }
            }
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_object_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_object_val_del");
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

        #region ВЫБРАТЬ ЗНАЧЕНИЯ СВОЙСТВА ДЛЯ АКТИВНОГО ПРЕДСТАВЛЕНИЯ КЛАССА

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение свойства активного представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_object_val class_prop_object_val_by_id(Int64 iid)
        {
            class_prop_object_val class_prop_obj_val_class = null;

            DataTable tbl_vclass_prop_obj_val_class  = TableByName("vclass_prop_object_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_object_val_by_id");

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

            cmdk.Fill(tbl_vclass_prop_obj_val_class);
            
            if (tbl_vclass_prop_obj_val_class.Rows.Count > 0)
            {
                class_prop_obj_val_class = new class_prop_object_val(tbl_vclass_prop_obj_val_class.Rows[0]);
            }
            return class_prop_obj_val_class;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_object_val_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_object_val_by_id");
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
        /// Выбрать значение свойства активного представления класса по идентификатору свойства
        /// </summary>
        public class_prop_object_val class_prop_object_val_by_id_prop(Int64 iid_class_prop)
        {
            class_prop_object_val class_prop_obj_val_class = null;

            DataTable tbl_vclass_prop_obj_val_class  = TableByName("vclass_prop_object_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_object_val_by_id_prop");

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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;

            cmdk.Fill(tbl_vclass_prop_obj_val_class);
            
            if (tbl_vclass_prop_obj_val_class.Rows.Count > 0)
            {
                class_prop_obj_val_class = new class_prop_object_val(tbl_vclass_prop_obj_val_class.Rows[0]);
            }
            return class_prop_obj_val_class;
        }

        /// <summary>
        /// Выбрать значение свойства активного представления класса по идентификатору свойства
        /// </summary>
        public class_prop_object_val class_prop_object_val_by_id_prop(class_prop Class_prop)
        {
            class_prop_object_val Result = null;
            switch (Class_prop.StorageType)
            {
                case eStorageType.Active:
                    Result = class_prop_object_val_by_id_prop(Class_prop.Id);
                    break;
                case eStorageType.History:
                    throw new PgDataException(505, "Исторический класс class_prop не допустим методе class_prop_object_val_by_id_prop!");
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_object_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_object_val_by_id_prop");
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

        #region ВЫБРАТЬ ЗНАЧЕНИЯ СВОЙСТВА ДЛЯ ИСТОРИЧЕСКОГО ПРЕДСТАВЛЕНИЯ КЛАССА

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение свойства исторического представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_object_val class_prop_object_val_snapshot_by_id(Int64 iid, DateTime itimestamp_class)
        {
            class_prop_object_val class_prop_obj_val_class = null;

            DataTable tbl_vclass_prop_obj_val_class  = TableByName("vclass_prop_object_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_object_val_snapshot_by_id");

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
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;

            cmdk.Fill(tbl_vclass_prop_obj_val_class);
            
            if (tbl_vclass_prop_obj_val_class.Rows.Count > 0)
            {
                class_prop_obj_val_class = new class_prop_object_val(tbl_vclass_prop_obj_val_class.Rows[0]);
            }
            return class_prop_obj_val_class;
        }
        

            //-=ACCESS=-***********************************************************************************
            /// <summary>
            /// Проверка прав доступа к методу
            /// </summary>
            public Boolean class_prop_object_val_snapshot_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_object_val_snapshot_by_id");
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
            /// Выбрать значение свойства исторического представления класса по идентификатору свойства
            /// </summary>
            public class_prop_object_val class_prop_object_val_snapshot_by_id_prop(Int64 iid_class_prop, DateTime itimestamp_class)
        {
            class_prop_object_val class_prop_obj_val_class = null;

            DataTable tbl_vclass_prop_obj_val_class  = TableByName("vclass_prop_object_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_object_val_snapshot_by_id_prop");

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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;

            cmdk.Fill(tbl_vclass_prop_obj_val_class);
            
            if (tbl_vclass_prop_obj_val_class.Rows.Count > 0)
            {
                class_prop_obj_val_class = new class_prop_object_val(tbl_vclass_prop_obj_val_class.Rows[0]);
            }
            return class_prop_obj_val_class;
        }

        /// <summary>
        /// Выбрать значение свойства исторического представления класса по идентификатору свойства
        /// </summary>
        public class_prop_object_val class_prop_object_val_snapshot_by_id_prop(class_prop Class_prop)
        {
            class_prop_object_val Result = null;
            switch (Class_prop.StorageType)
            {
                case eStorageType.History:
                    Result = class_prop_object_val_snapshot_by_id_prop(Class_prop.Id, Class_prop.Timestamp_class);
                    break;
                case eStorageType.Active:
                    throw new PgDataException(505, "Активный класс class_prop не допустим методе class_prop_object_val_snapshot_by_id_prop!");
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_object_val_snapshot_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_object_val_snapshot_by_id_prop");
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
        /// Выбор класса значения объектного свойства активного класса шаг №2
        /// </summary>
        public vclass class_class_prop_object_by_id_class_prop(Int64 iid_class_prop)
        {
            vclass vclass = null;

            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_class_prop_object_by_id_class_prop");

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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;

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
        public vclass class_class_prop_object_by_id_class_prop(class_prop Class_prop)
        {
            vclass Result = null;
            switch (Class_prop.StorageType)
            {
                case eStorageType.Active:
                    Result = class_class_prop_object_by_id_class_prop(Class_prop.Id);
                    break;
                case eStorageType.History:
                    throw new PgDataException(505, "Историческое свойство не допустимо методе class_class_prop_object_by_id_class_prop!");
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_class_prop_object_by_id_class_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_class_prop_object_by_id_class_prop");
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

        #region ВЫБРАТЬ КЛАСС ЗНАЧЕНИЕ ДЛЯ ОБЪЕКТНОГО СВОЙСТВА ИСТОРИЧЕСКОГО ПРЕДСТАВЛЕНИЯ КЛАССА
        /// <summary>
        /// Выбор класса значения объектного свойства исторического класса шаг №2
        /// </summary>
        public vclass class_class_prop_object_snapshot_by_id_class_prop(Int64 iid_class_prop, DateTime itimestamp_classop)
        {
            vclass vclass = null;

            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_class_prop_object_snapshot_by_id_class_prop");

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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_classop;

            cmdk.Fill(tbl_vclass);
            
            if (tbl_vclass.Rows.Count > 0)
            {
                vclass = new vclass(tbl_vclass.Rows[0]);
            }
            return vclass;
        }


        /// <summary>
        /// Выбор класса значения объектного свойства исторического класса шаг №2
        /// </summary>
        public vclass class_class_prop_object_snapshot_by_id_class_prop(class_prop Class_prop)
        {
            vclass Result = null;
            switch (Class_prop.StorageType)
            {
                case eStorageType.History:
                    Result = class_class_prop_object_snapshot_by_id_class_prop(Class_prop.Id, Class_prop.Timestamp_class);
                    break;
                case eStorageType.Active:
                    throw new PgDataException(505, "Актисвное свойство не допустимо методе class_class_prop_object_snapshot_by_id_class_prop!");
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_obj_class_val_step2_snapshot_by_id_class_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_obj_class_val_step2_snapshot_by_id_class_prop");
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
        /// Определить актуальность состояния значения свойства активного представления класса 
        /// </summary>
        public eEntityState class_prop_object_val_is_actual(Int64 iid, DateTime timestamp_class)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_prop_object_val_is_actual");

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
            cmdk.Parameters["timestamp_class"].Value = timestamp_class;

            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;          
        }

        /// <summary>
        /// Определить актуальность состояния значения свойства активного представления класса 
        /// </summary>
        public eEntityState class_prop_object_val_is_actual(class_prop_object_val ClassPropObjValClass)
        {
            eEntityState Result = eEntityState.History;
            if (ClassPropObjValClass.StorageType == eStorageType.Active)
            {
                Result = class_prop_object_val_is_actual(ClassPropObjValClass.Id, ClassPropObjValClass.Timestamp_class);
            }
            return Result;
        }
        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ СВОЙСТВАМИ КЛАССОВ

        /// <summary>
        /// Делегат события изменения значения объектного свойства класса
        /// </summary>
        public delegate void ClassPropObjectValChangeEventHandler(Object sender, ClassPropObjectValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения объектного свойства класса методом доступа к БД
        /// </summary>
        public event ClassPropObjectValChangeEventHandler ClassPropObjectValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения свойства класса
        /// </summary>
        protected virtual void ClassPropObjectValOnChange(ClassPropObjectValChangeEventArgs e)
        {
            ClassPropObjectValChangeEventHandler temp = ClassPropObjectValChange;
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
