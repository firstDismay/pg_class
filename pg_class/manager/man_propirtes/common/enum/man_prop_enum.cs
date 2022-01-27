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
        #region МЕТОДЫ КЛАССА: УПРАВЛЕНИЕ ПРЕЧИСЛЕНИЯМИ ДЛЯ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ КЛАССОВ ШАГ №02

        #region ДОБАВИТЬ
        /// <summary>
        /// Добавить новое перечисление для свойств
        /// </summary>
        public prop_enum prop_enum_add(Int64 iid_conception, String iname, String idesc, Int32 iid_prop_enum_use_area, Int32 iid_data_type)
        {
            prop_enum Prop_enum = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
            cmdk = CommandByKey("prop_enum_add");

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
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["iid_prop_enum_use_area"].Value = iid_prop_enum_use_area;
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;

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
                        Prop_enum = prop_enum_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.prop_enum, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            PropEnumChangeEventArgs e = new PropEnumChangeEventArgs(Prop_enum, eAction.Insert);
            PropEnumOnChange(e);
            
            //Возвращаем Сущность
            return Prop_enum;
        }

        /// <summary>
        /// Добавить новое перечисление для свойств
        /// </summary>
        public prop_enum prop_enum_add(Int64 iid_conception, String iname, String idesc, prop_enum_use_area iprop_enum_use_area, Int32 iid_data_type)
        {
            return prop_enum_add(iid_conception, iname, idesc, iprop_enum_use_area.Id, iid_data_type);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_add");
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
        /// Копировать перечисление в указанную концепцию
        /// </summary>
        public prop_enum prop_enum_copy_to( Int64 iid_prop_enum , Int64 iid_conception)
        {
            prop_enum Prop_enum = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
            cmdk = CommandByKey("prop_enum_copy_to");

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
            cmdk.Parameters["iid_conception"].Value = iid_conception;


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
                        Prop_enum = prop_enum_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.prop_enum, error, desc_error, eAction.Copy, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            PropEnumChangeEventArgs e = new PropEnumChangeEventArgs(Prop_enum, eAction.Copy);
            PropEnumOnChange(e);

            //Возвращаем Сущность
            return Prop_enum;
        }

        /// <summary>
        /// Копировать перечисление в указанную концепцию
        /// </summary>
        public prop_enum prop_enum_copy_to(prop_enum Prop_enum, conception Conception)
        {
            return prop_enum_copy_to(Prop_enum.Id_prop_enum, Conception.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_copy_to(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_copy_to");
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
        /// Изменить новое перечисление для свойств
        /// </summary>
        public prop_enum prop_enum_upd(Int64 iid_prop_enum, Int64 iid_conception, String iname, String idesc, Int32 iid_prop_enum_use_area, Int32 iid_data_type)
        {
            prop_enum Prop_enum = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
            cmdk = CommandByKey("prop_enum_upd");

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
            cmdk.Parameters["iid_conception"].Value = iid_conception;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["iid_prop_enum_use_area"].Value = iid_prop_enum_use_area;
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================     
            switch (error)
            {
                case 0:
                    Prop_enum = prop_enum_by_id(iid_prop_enum);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_prop_enum, eEntity.prop_enum, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            PropEnumChangeEventArgs e = new PropEnumChangeEventArgs(Prop_enum, eAction.Update);
            PropEnumOnChange(e);

            //Возвращаем Сущность
            return Prop_enum;
        }


        /// <summary>
        /// Изменить новое перечисление для свойств
        /// </summary>
        public prop_enum prop_enum_upd(prop_enum Prop_enum)
        {
            return prop_enum_upd(Prop_enum.Id_prop_enum, Prop_enum.Id_conception, Prop_enum.NameEnum, Prop_enum.Desc, Prop_enum.Id_prop_enum_use_area, Prop_enum.Id_data_type);
        }

        /// <summary>
        /// Изменить новое перечисление для свойств
        /// </summary>
        public prop_enum prop_enum_upd(Int64 iid_prop_enum, Int64 iid_conception, String iname, String idesc, prop_enum_use_area iprop_enum_use_area, Int32 iid_data_type)
        {
            return prop_enum_upd(iid_prop_enum, iid_conception, iname, idesc, iprop_enum_use_area.Id, iid_data_type);
        }
            //-=ACCESS=-***********************************************************************************
            /// <summary>
            /// Проверка прав доступа к методу
            /// </summary>
            public Boolean prop_enum_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_upd");
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
        /// Удалить новое перечисление для свойств
        /// </summary>
        public void prop_enum_del(Int64 iid_prop_enum, Int64 iid_conception)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("prop_enum_del");

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
            cmdk.Parameters["iid_conception"].Value = iid_conception;

            //Запрос удаляемой сущности
            prop_enum Prop_enum = prop_enum_by_id(iid_prop_enum);
            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================

            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_prop_enum, eEntity.prop_enum, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления перечисления для свойства
            if (Prop_enum != null)
            {
                PropEnumChangeEventArgs e = new PropEnumChangeEventArgs(Prop_enum, eAction.Delete);
                PropEnumOnChange(e);
            }
        }


        /// <summary>
        /// Удалить новое перечисление для свойств
        /// </summary>
        public void prop_enum_del(prop_enum Prop_enum)
        {
            prop_enum_del(Prop_enum.Id_prop_enum, Prop_enum.Id_conception);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_del");
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
        /// Выбрать перечисление для свойства по идентификатору перечисления
        /// </summary>
        public prop_enum prop_enum_by_id(Int64 iid_prop_enum)
        {
            prop_enum prop_enum = null;

            DataTable tbl_entity  = TableByName("vprop_enum");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_enum_by_id");

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

            cmdk.Fill(tbl_entity);
            
            if (tbl_entity.Rows.Count > 0)
            {
                prop_enum = new prop_enum(tbl_entity.Rows[0]);
            }
            return prop_enum;
        }
        
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_by_id");
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
        ///  Выбрать все перечисления для свойства по идентификатору концепции
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception( Int64 iid_conception)
        {
            List<prop_enum> entity_list = new List<prop_enum>();

            DataTable tbl_entity  = TableByName("vprop_enum");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_enum_by_id_conception");

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

            cmdk.Fill(tbl_entity);
            
            prop_enum prop_enum;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    prop_enum = new prop_enum(dr);
                    entity_list.Add(prop_enum);
                }
            }
            return entity_list;
        }

        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception(conception Conception)
        {
            return prop_enum_by_id_conception(Conception.Id);
        }
        
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_by_id_conception");
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

        //=-***********************************************************************************
        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом области применения
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception_use_area(Int64 iid_conception, Int32 iid_prop_enum_use_area)
        {
            List<prop_enum> entity_list = new List<prop_enum>();

            DataTable tbl_entity  = TableByName("vprop_enum");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_enum_by_id_conception_use_area");

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
            cmdk.Parameters["iid_prop_enum_use_area"].Value = iid_prop_enum_use_area;

            cmdk.Fill(tbl_entity);
            
            prop_enum prop_enum;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    prop_enum = new prop_enum(dr);
                    entity_list.Add(prop_enum);
                }
            }
            return entity_list;
        }

        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом области применения
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception_use_area(conception Conception, prop_enum_use_area Prop_enum_use_area )
        {
            return prop_enum_by_id_conception_use_area(Conception.Id, Prop_enum_use_area.Id);
        }

        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом области применения
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception_use_area(conception Conception, eProp_enum_use_area Prop_enum_use_area)
        {
            return prop_enum_by_id_conception_use_area(Conception.Id, (Int32)Prop_enum_use_area);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_by_id_conception_use_area(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_by_id_conception_use_area");
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

        //=-***********************************************************************************
        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом области применения и типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception_use_area_data_type(Int64 iid_conception, Int32 iid_prop_enum_use_area, Int32 iid_data_type)
        {
            List<prop_enum> entity_list = new List<prop_enum>();

            DataTable tbl_entity  = TableByName("vprop_enum");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_enum_by_id_conception_use_area_data_type");

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
            cmdk.Parameters["iid_prop_enum_use_area"].Value = iid_prop_enum_use_area;
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;

            cmdk.Fill(tbl_entity);
            
            prop_enum prop_enum;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    prop_enum = new prop_enum(dr);
                    entity_list.Add(prop_enum);
                }
            }
            return entity_list;
        }

        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом области применения и типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception_use_area_data_type(conception Conception, prop_enum_use_area Prop_enum_use_area, con_prop_data_type Data_type)
        {
            return prop_enum_by_id_conception_use_area_data_type(Conception.Id, Prop_enum_use_area.Id, Data_type.Id);
        }

        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом области применения и типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception_use_area_data_type(conception Conception, eProp_enum_use_area Prop_enum_use_area, eDataType DataType)
        {
            return prop_enum_by_id_conception_use_area_data_type(Conception.Id, (Int32)Prop_enum_use_area, (Int32)DataType);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_by_id_conception_use_area_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_by_id_conception_use_area_data_type");
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
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом типа денных
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception_data_type(Int64 iid_conception, Int32 iid_data_type)
        {
            List<prop_enum> entity_list = new List<prop_enum>();

            DataTable tbl_entity  = TableByName("vprop_enum");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_enum_by_id_conception_data_type");

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
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;

            cmdk.Fill(tbl_entity);
            
            prop_enum prop_enum;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    prop_enum = new prop_enum(dr);
                    entity_list.Add(prop_enum);
                }
            }
            return entity_list;
        }

        /// <summary>
        ///  Выбрать все перечисления для свойства по идентификатору концепции с учетом типа денных
        /// </summary>
        public List<prop_enum> prop_enum_by_id_conception_data_type(conception Conception , con_prop_data_type Data_type)
        {
            return prop_enum_by_id_conception_data_type(Conception.Id, Data_type.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_by_id_conception_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_by_id_conception_data_type");
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
        
        //=-***********************************************************************************
        /// <summary>
        ///  Выбрать все перечисления для свойств объектов по идентификатору концепции с типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_for_object_by_id_conception_data_type(Int64 iid_conception, Int32 iid_data_type)
        {
            List<prop_enum> entity_list = new List<prop_enum>();

            DataTable tbl_entity  = TableByName("vprop_enum");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_enum_for_object_by_id_conception_data_type");

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
            
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;

            cmdk.Fill(tbl_entity);
            
            prop_enum prop_enum;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    prop_enum = new prop_enum(dr);
                    entity_list.Add(prop_enum);
                }
            }
            return entity_list;
        }

        /// <summary>
        ///  Выбрать все перечисления для свойств объектов по идентификатору концепции с типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_for_object_by_id_conception_data_type(conception Conception, con_prop_data_type Data_type)
        {
            return prop_enum_for_object_by_id_conception_data_type(Conception.Id, Data_type.Id);
        }

        /// <summary>
        ///  Выбрать все перечисления для свойств объектов по идентификатору концепции с типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_for_object_by_id_conception_data_type(conception Conception, eDataType DataType)
        {
            return prop_enum_for_object_by_id_conception_data_type(Conception.Id, (Int32)DataType);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_for_object_by_id_conception_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_for_object_by_id_conception_data_type");
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
     
         //=-***********************************************************************************
        /// <summary>
        ///  Выбрать все перечисления для свойств позиций по идентификатору концепции с типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_for_position_by_id_conception_data_type(Int64 iid_conception, Int32 iid_data_type)
        {
            List<prop_enum> entity_list = new List<prop_enum>();

            DataTable tbl_entity  = TableByName("vprop_enum");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_enum_for_position_by_id_conception_data_type");

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

            cmdk.Parameters["iid_data_type"].Value = iid_data_type;

            cmdk.Fill(tbl_entity);
            
            prop_enum prop_enum;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    prop_enum = new prop_enum(dr);
                    entity_list.Add(prop_enum);
                }
            }
            return entity_list;
        }

        /// <summary>
        ///  Выбрать все перечисления для свойств позиций по идентификатору концепции с типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_for_position_by_id_conception_data_type(conception Conception, con_prop_data_type Data_type)
        {
            return prop_enum_for_position_by_id_conception_data_type(Conception.Id, Data_type.Id);
        }

        /// <summary>
        ///  Выбрать все перечисления для свойств позиций по идентификатору концепции с типа данных перечисления
        /// </summary>
        public List<prop_enum> prop_enum_for_position_by_id_conception_data_type(conception Conception, eDataType DataType)
        {
            return prop_enum_for_position_by_id_conception_data_type(Conception.Id, (Int32)DataType);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_for_position_by_id_conception_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_for_position_by_id_conception_data_type");
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
        /// Определить актуальность состояния перечисления для свойства
        /// </summary>
        public eEntityState prop_enum_is_actual(Int64 iid, DateTime itimestamp)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("prop_enum_is_actual");

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
        /// Определить актуальность состояния перечисления для свойства
        /// </summary>
        public eEntityState prop_enum_is_actual(prop_enum Prop_enum)
        {
            return prop_enum_is_actual(Prop_enum.Id_prop_enum, Prop_enum.Timestamp);
        }

        
        //*********************************************************************************************
        /// <summary>
        /// Метод возвращает общее количество элементов в перечислении
        /// </summary>
        public Int32 prop_enum_count_val_by_id(Int64 iid_prop_enum)
        {
            Int32 Result = 0;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("prop_enum_count_val_by_id");

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

            //Начало транзакции
            Result = (Int32)cmdk.ExecuteScalar();
           
            return Result;
        }

        //*********************************************************************************************
        /// <summary>
        /// Метод возвращает общее количество элементов в перечислении
        /// </summary>
        public Int32 prop_enum_count_val_by_id(prop_enum Prop_enum)
        {
            return prop_enum_count_val_by_id(Prop_enum.Id_prop_enum);
        }
        #endregion
        #endregion


        #region МЕТОДЫ КЛАССА: ОБЛАСТИ ПРИМЕНЕНИЯ ПЕРЕЧИСЛЕНИЙ КОНЦЕПЦИИ
        #region ВЫБРАТЬ


        /// <summary>
        /// Лист доступных областей назначения для перечислений
        /// </summary>
        public List<prop_enum_use_area> prop_enum_use_area_by_all()
        {
            List<prop_enum_use_area> prop_enum_use_area_list = new List<prop_enum_use_area>();


            DataTable tbl_data_type  = TableByName("vprop_enum_use_area");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_enum_use_area_by_all");

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

            cmdk.Fill(tbl_data_type);
            
            prop_enum_use_area prop_enum_use_area;
            if (tbl_data_type.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_data_type.Rows)
                {
                    prop_enum_use_area = new prop_enum_use_area(dr);
                    prop_enum_use_area_list.Add(prop_enum_use_area);
                }
            }
            return prop_enum_use_area_list;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_use_area_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_use_area_by_all");
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
        /// Тип  свойства по ИД
        /// </summary>
        public prop_enum_use_area prop_enum_use_area_by_id(Int32 id)
        {
            prop_enum_use_area prop_enum_use_area = null;

            DataTable tbl_type  = TableByName("vprop_enum_use_area");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_enum_use_area_by_id");

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

            cmdk.Fill(tbl_type);
            
            if (tbl_type.Rows.Count > 0)
            {
                prop_enum_use_area = new prop_enum_use_area(tbl_type.Rows[0]);
            }

            return prop_enum_use_area;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_use_area_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_use_area_by_id");
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


        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ СВОЙСТВАМИ КЛАССОВ

        /// <summary>
        /// Делегат события изменения значения перечисления для свойства
        /// </summary>
        public delegate void PropEnumChangeEventHandler(Object sender, PropEnumChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении перечисления для свойств
        /// </summary>
        public event PropEnumChangeEventHandler PropEnumChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения перечисления для свойств
        /// </summary>
        protected virtual void PropEnumOnChange(PropEnumChangeEventArgs e)
        {
            PropEnumChangeEventHandler temp = PropEnumChange;
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
