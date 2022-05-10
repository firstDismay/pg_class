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
     
        
        
        
        #region МЕТОДЫ КЛАССА: УПРАВЛЕНИЕ СВОЙСТВАМИ КЛАССОВ ШАГ №01

        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новое свойство класса
        /// </summary>
        public class_prop class_prop_add( Int64 iid_class, Int32 iid_prop_type, Boolean ion_override, Int32 iid_data_type, String iname, String idesc, String itag, Int32 isort)
        {
            class_prop class_prop = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_prop_add2");

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

            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.Parameters["iid_prop_type"].Value = iid_prop_type;
            cmdk.Parameters["ion_override"].Value = ion_override;
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["itag"].Value = itag;
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
                        class_prop = class_prop_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.class_prop, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (class_prop != null)
            {
                //Генерируем событие изменения свойства класса
                ClassPropChangeEventArgs e = new ClassPropChangeEventArgs(class_prop, eAction.Insert);
                ClassPropOnChange(e);
            }
            //Возвращаем Объект
            return class_prop;
        }

        /// <summary>
        /// Метод добавляет новое свойство класса
        /// </summary>
        public class_prop class_prop_add(vclass Class, prop_type Prop_type, Boolean On_Override, con_prop_data_type Data_type, String iname, String idesc, String itag, Int32 isort)
        {
            class_prop Result = null;
            if (Class != null)
            {
                if (Class.StorageType == eStorageType.Active)
                {
                    Result = class_prop_add(Class.Id, Prop_type.Id, On_Override, Data_type.Id, iname, idesc, itag, isort);
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop, eAction.Insert, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод обновления данных класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_add2");
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
        /// Метод изменяет свойство активного представления класса
        /// </summary>
        public class_prop class_prop_upd(Int64 iid, Int32 iid_prop_type, Boolean ion_override, Boolean ion_inherit, Int32 iid_data_type, String iname, String idesc, String itag, Int32 isort)
        {
            class_prop class_prop = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_prop_upd2");

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
            cmdk.Parameters["ion_inherit"].Value = ion_inherit;
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["itag"].Value = itag;
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
                    class_prop = class_prop_by_id(iid);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid, eEntity.class_prop, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (class_prop != null)
            {
                //Генерируем событие изменения свойства класса
                ClassPropChangeEventArgs e = new ClassPropChangeEventArgs(class_prop, eAction.Update);
                ClassPropOnChange(e);
            }
            //Возвращаем Объект
            return class_prop;
        }

        /// <summary>
        /// Метод изменяет свойство активного представления класса
        /// </summary>
        public class_prop class_prop_upd(class_prop Class_prop)
        {

            class_prop Result = null;
            if (Class_prop != null)
            {
                if (Class_prop.StorageType == eStorageType.Active)
                {
                    Result = class_prop_upd(Class_prop.Id, Class_prop.Id_prop_type, Class_prop.On_override, Class_prop.On_inherit, Class_prop.Id_data_type, Class_prop.Name, Class_prop.Desc, Class_prop.Tag, Class_prop.Sort);
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод обновления данных свойства класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_upd2");
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

        #region ИЗМЕНИТЬ НАСЛЕДУЮЩИЕ
        /// <summary>
        /// Метод изменяет флаг переопределяемости в свойствах наследующих вещественных классов
        /// </summary>
        public class_prop class_prop_inheriting_override_set(Int64 iid, Boolean ion_override)
        {
            class_prop class_prop = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_prop_inheriting_override_set");

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
            cmdk.Parameters["ion_override"].Value = ion_override;
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
                    class_prop = class_prop_by_id(iid);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid, eEntity.class_prop, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (class_prop != null)
            {
                //Генерируем событие изменения свойства класса
                ClassPropChangeEventArgs e = new ClassPropChangeEventArgs(class_prop, eAction.Update);
                ClassPropOnChange(e);
            }
            //Возвращаем Объект
            return class_prop;
        }

        /// <summary>
        /// Метод изменяет флаг переопределяемости в свойствах наследующих вещественных классов
        /// </summary>
        public class_prop class_prop_inheriting_override_set(class_prop Class_prop, Boolean ion_override)
        {
            class_prop Result = null;
            if (Class_prop != null)
            {
                if (Class_prop.StorageType == eStorageType.Active)
                {
                    Result = class_prop_inheriting_override_set(Class_prop.Id, ion_override);
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод обновления данных свойства класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_inheriting_override_set(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_inheriting_override_set");
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
        /// Метод удаляет свойство класса и все наследующие свойства
        /// </summary>
        public void class_prop_del_cascade(Int64 iid)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_prop_del_cascade");

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
            class_prop class_prop = class_prop_by_id(iid);

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid, eEntity.class_prop, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления свойства класса
            if (class_prop != null)
            {
                ClassPropChangeEventArgs e = new ClassPropChangeEventArgs(class_prop, eAction.Delete);
                ClassPropOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет свойство класса и все наследующие свойства
        /// </summary>
        public void class_prop_del_cascade(class_prop Class_Prop)
        {
            if (Class_Prop != null)
            {
                if (Class_Prop.StorageType == eStorageType.Active)
                {
                    class_prop_del_cascade(Class_Prop.Id);
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop, eAction.Delete, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод удаления свойства класса не применим к историческому представлению класса!");
                }
            }
            
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_del_cascade(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_del_cascade");
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
        /// Выбор свойства активного представления класса по идентификатору свойства
        /// </summary>
        public class_prop class_prop_by_id(Int64 iid)
        {
            class_prop class_prop = null;

            DataTable tbl_vclass_prop  = TableByName("vclass_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_by_id");

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

            cmdk.Fill(tbl_vclass_prop);
            
            if (tbl_vclass_prop.Rows.Count > 0)
            {
                class_prop = new class_prop(tbl_vclass_prop.Rows[0]);
            }
            return class_prop;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_by_id");
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
        /// Выбор свойства активного представления класса по идентификатору глобального свойства
        /// </summary>
        public class_prop class_prop_by_id_global_prop(Int64 iid_class, Int64 iid_global_prop)
        {
            class_prop class_prop = null;

            DataTable tbl_vclass_prop  = TableByName("vclass_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_by_id_global_prop");

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

            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;

            cmdk.Fill(tbl_vclass_prop);
            
            if (tbl_vclass_prop.Rows.Count > 0)
            {
                class_prop = new class_prop(tbl_vclass_prop.Rows[0]);
            }
            return class_prop;
        }

        /// <summary>
        /// Выбор свойства активного представления класса по идентификатору глобального свойства
        /// </summary>
        public class_prop class_prop_by_id_global_prop(vclass Class, global_prop Global_prop)
        {
            return class_prop_by_id_global_prop(Class.Id, Global_prop.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_by_id_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_by_id_global_prop");
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
        /// Лист свойств представления активного класса по идентификатору класса с пустым тэгом
        /// </summary>
        public List<class_prop> class_prop_by_id_class(Int64 iid_class)
        {
            List<class_prop> class_prop_list = new List<class_prop>();

            
            DataTable tbl_class_prop  = TableByName("vclass_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_by_id_class");

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

            cmdk.Parameters["iid_class"].Value = iid_class;

            cmdk.Fill(tbl_class_prop);
            
            class_prop cp;
            if (tbl_class_prop.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_class_prop.Rows)
                {
                    cp = new class_prop(dr);
                    class_prop_list.Add(cp);
                }
            }
            return class_prop_list;
        }

        /// <summary>
        /// Лист свойств представления активного класса по идентификатору класса с пустым тэгом
        /// </summary>
        public List<class_prop> class_prop_by_id_class(vclass Class)
        {
            return class_prop_by_id_class(Class.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_by_id_class");
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

        #region ПОИСК ОПРЕДЕЛЯЮЩИХ СВОЙСТВ И КЛАССОВ ОПРЕДЕЛЯЮЩИХ СВОЙСТВА
        //*********************************************************************************************
        /// <summary>
        /// Определяющее свойство, свойства указанного по идентификатору
        /// </summary>
        public class_prop class_prop_definition_by_id_class_prop(Int64 iid_class_prop, DateTime itimestamp_class, eStorageType storagetype)
        {
            class_prop class_prop = null;

            DataTable tbl_vclass_prop  = TableByName("vclass_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_definition_by_id_class_prop");

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
            cmdk.Parameters["storagetype"].Value = storagetype.ToString("G");

            cmdk.Fill(tbl_vclass_prop);
            
            if (tbl_vclass_prop.Rows.Count > 0)
            {
                class_prop = new class_prop(tbl_vclass_prop.Rows[0]);
            }
            return class_prop;
        }

        /// <summary>
        /// Определяющее свойство, свойства указанного по идентификатору
        /// </summary>
        public class_prop class_prop_definition_by_id_class_prop(class_prop ClassProp)
        {
            return class_prop_definition_by_id_class_prop(ClassProp.Id, ClassProp.Timestamp_class, ClassProp.StorageType);
        }

        /// <summary>
        /// Определение свойства, указанного по идентификатору
        /// </summary>
        public class_prop class_prop_definition_by_id_class_prop(object_prop ObjectProp)
        {
            return class_prop_definition_by_id_class_prop(ObjectProp.Id_class_prop, ObjectProp.Timestamp_class, eStorageType.History);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_definition_by_id_class_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_definition_by_id_class_prop");
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
        /// Класс определяющий свойство, указанное по идентификатору
        /// </summary>
        public vclass class_definition_by_id_class_prop(Int64 iid_class_prop, DateTime itimestamp_class, eStorageType storagetype)
        {
            vclass vclass = null;

            DataTable tbl_vclass  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_definition_by_id_class_prop");

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
            cmdk.Parameters["storagetype"].Value = storagetype.ToString("G");

            cmdk.Fill(tbl_vclass);
            
            if (tbl_vclass.Rows.Count > 0)
            {
                vclass = new vclass(tbl_vclass.Rows[0]);
            }
            return vclass;
        }

        /// <summary>
        /// Класс определяющий свойство, указанное по идентификатору
        /// </summary>
        public vclass class_definition_by_id_class_prop(class_prop ClassProp)
        {
            return class_definition_by_id_class_prop(ClassProp.Id, ClassProp.Timestamp_class, ClassProp.StorageType);
        }

        /// <summary>
        /// Класс определяющий свойство, указанное по идентификатору
        /// </summary>
        public vclass class_definition_by_id_class_prop(object_prop ObjectProp)
        {
            return class_definition_by_id_class_prop(ObjectProp.Id_class_prop, ObjectProp.Timestamp_class, eStorageType.History);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_definition_by_id_class_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_definition_by_id_class_prop");
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
        #endregion

        #region ВЫБРАТЬ: ПОИСКОВЫЕ МЕТОДЫ ДЛЯ СВОЙСТВ КЛАССОВ
        /// <summary>
        /// Лист свойств для формирования формата имени объекта
        /// </summary>
        public List<class_prop> class_prop_for_format_by_id_class(Int64 iid_class)
        {
            List<class_prop> class_prop_list = new List<class_prop>();


            DataTable tbl_class_prop  = TableByName("vclass_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_for_format_by_id_class");

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

            cmdk.Parameters["iid_class"].Value = iid_class;

            cmdk.Fill(tbl_class_prop);
            
            class_prop cp;
            if (tbl_class_prop.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_class_prop.Rows)
                {
                    cp = new class_prop(dr);
                    class_prop_list.Add(cp);
                }
            }
            return class_prop_list;
        }

        /// <summary>
        /// Лист свойств представления активного класса по идентификатору класса
        /// </summary>
        public List<class_prop> class_prop_for_format_by_id_class(vclass Class)
        {
            return class_prop_for_format_by_id_class(Class.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Лист свойств представления активного класса по идентификатору класса
        /// </summary>
        public Boolean class_prop_for_format_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_for_format_by_id_class");
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
        public eEntityState class_prop_is_actual(Int64 iid, DateTime timestamp_class)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_prop_is_actual");

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
        /// Метод определяет актуальность состояния свойства активного класса 
        /// </summary>
        public eEntityState class_prop_is_actual(class_prop ClassProp)
        {
            eEntityState Result = eEntityState.History;
            if (ClassProp.StorageType == eStorageType.Active)
            {
                Result = class_prop_is_actual(ClassProp.Id, ClassProp.Timestamp_class);
            }
            return Result;
        }


        //*********************************************************************************************
        /// <summary>
        /// Метод определяет готовность свойства к линковке с глобальными свойствами
        /// </summary>
        public ePropStateForGlobalPropLink class_prop_state_for_global_prop_link(Int64 iid_class_prop)
        {
            Int32 class_prop_state = 0;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_prop_state_for_global_prop_link");

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

            //Начало транзакции
            class_prop_state = (Int32)cmdk.ExecuteScalar();
            
            return (ePropStateForGlobalPropLink)class_prop_state;
        }

        /// <summary>
        /// Метод определяет готовность свойства к линковке с глобальными свойствами
        /// </summary>
        public ePropStateForGlobalPropLink class_prop_state_for_global_prop_link(class_prop ClassProp)
        {
            ePropStateForGlobalPropLink Result = ePropStateForGlobalPropLink.ready;
            if (ClassProp.StorageType == eStorageType.Active)
            {
                Result = class_prop_state_for_global_prop_link(ClassProp.Id);
            }
            return Result;
        }

        /// <summary>
        /// Метод определяет наличие свойств вещественных классов переопределяемых по значению в объектах указанной позиции
        /// </summary>
        public Boolean class_prop_has_object_prop_override_by_id_pos(Int64 iid_position, Int64 iid_class_prop, DateTime itimestamp_class, Boolean on_internal = false)
        {
            Boolean Result = false;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********

            //=======================
            cmdk = CommandByKey("class_prop_has_object_prop_override_by_id_pos");

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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;
            cmdk.Parameters["on_internal"].Value = on_internal;

            //Начало транзакции
            Result = (Boolean)cmdk.ExecuteScalar();

            return Result;
        }

        /// <summary>
        /// Метод определяет наличие свойств вещественных классов переопределяемых по значению в объектах указанной позиции
        /// </summary>
        public Boolean class_prop_has_object_prop_override_by_id_pos(position Position_parent, class_prop Class_prop, Boolean on_internal = false)
        {
            return class_prop_has_object_prop_override_by_id_pos(Position_parent.Id, Class_prop.Id, Class_prop.Timestamp_class, on_internal); 
        }

        /// <summary>
        /// Метод определяет наличие свойств вещественных классов переопределяемых по значению в объектах указанной позиции
        /// </summary>
        public Boolean class_prop_has_object_prop_override_by_id_pos(Int64 Id_position_parent, class_prop Class_prop, Boolean on_internal = false)
        {
            return class_prop_has_object_prop_override_by_id_pos(Id_position_parent, Class_prop.Id, Class_prop.Timestamp_class, on_internal);
        }
        #endregion

        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ СВОЙСТВАМИ КЛАССОВ

        /// <summary>
        /// Делегат события изменения свойства класса
        /// </summary>
        public delegate void ClassPropChangeEventHandler(Object sender, ClassPropChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении свойства класса методом доступа к БД
        /// </summary>
        public event ClassPropChangeEventHandler ClassPropChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения свойства класса
        /// </summary>
        protected virtual void ClassPropOnChange(ClassPropChangeEventArgs e)
        {
            ClassPropChangeEventHandler temp = ClassPropChange;
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
