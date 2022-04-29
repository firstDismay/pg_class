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
using Newtonsoft.Json;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод выполняет приведение объекта к указанному снимку класса
        /// </summary>
        public object_general object_cast(Int64 iid_object, DateTime itimestamp_class)

        {
            object_general Object = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_cast");

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

            cmdk.Parameters["iid_object"].Value = iid_object;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;

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
                    Object = object_by_id(iid_object);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_object, eEntity.vobject, error, desc_error, eAction.Cast, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (Object != null)
            {
                //Генерируем событие изменения
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object, eAction.Cast);
                ObjectOnChange(e);
            }
            //Возвращаем Объект
            return Object;
        }

        /// <summary>
        /// Метод выполняет приведение объекта к указанному снимку класса
        /// </summary>
        public object_general object_cast(object_general Object, vclass Class_target)
        {
            return object_cast(Object.Id, Class_target.Timestamp);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_cast(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_cast");
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
        ///  Метод выполняет приведение всех объектов к указанному снимку класса
        /// </summary>
        public List<errarg_cast> object_cast_for_class(Int64 iid_class, DateTime itimestamp_class)
        {
            List<errarg_cast> object_cast_list = new List<errarg_cast>();


            DataTable tbl_result = TableByName("errarg_cast");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_cast_for_class");

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
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;

            cmdk.Fill(tbl_result);
            
            errarg_cast og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new errarg_cast(dr);
                    object_cast_list.Add(og);
                }
            }
            //Генерируем событие изменения представления класса
           /* vclass vclass = class_act_by_id(iid_class);
            ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Cast);
            ClassOnChange(e);*/
            return object_cast_list;
        }

        /// <summary>
        ///  Метод выполняет приведение всех объектов к указанному снимку класса
        /// </summary>
        public List<errarg_cast> object_cast_for_class(vclass Class_target)
        {
            return object_cast_for_class(Class_target.Id, Class_target.Timestamp);
        }
            //-=ACCESS=-***********************************************************************************
            /// <summary>
            /// Проверка прав доступа к методу
            /// </summary>
        public Boolean object_cast_for_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_cast_for_class");
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
        ///  Метод приводит все объекты к активным состояниям классов рекурсивно начиная с указанного
        /// </summary>
        public List<errarg_cast> object_cast_for_class_act(Int64 iid_class)
        {
            List<errarg_cast> object_cast_list = new List<errarg_cast>();


            DataTable tbl_result = TableByName("errarg_cast");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_cast_for_class_act");

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

            cmdk.Fill(tbl_result);
            
            errarg_cast og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new errarg_cast(dr);
                    object_cast_list.Add(og);
                }
            }
            //Генерируем событие изменения представления класса
            /*vclass vclass = class_act_by_id(iid_class);
            ClassChangeEventArgs e = new ClassChangeEventArgs(vclass, eAction.Cast);
            ClassOnChange(e);*/
            return object_cast_list;
        }

        /// <summary>
        ///  Метод приводит все объекты к активным состояниям классов рекурсивно начиная с указанного
        /// </summary>
        public List<errarg_cast> object_cast_for_class_act(vclass Class_target)
        {
            return object_cast_for_class_act(Class_target.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_cast_for_class_act(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_cast_for_class_act");
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
        ///  Метод приводит все объекты к активным состояниям классов указанной группы
        /// </summary>
        public List<errarg_cast> object_cast_for_class_act_by_id_group(Int64 iid_group)
        {
            List<errarg_cast> object_cast_list = new List<errarg_cast>();

            DataTable tbl_result = TableByName("errarg_cast");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_cast_for_class_act_by_id_group");

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

            cmdk.Parameters["iid_group"].Value = iid_group;

            cmdk.Fill(tbl_result);
            
            errarg_cast og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new errarg_cast(dr);
                    object_cast_list.Add(og);
                }
            }
            //Генерируем событие изменения представления класса
            /*group group = group_by_id(iid_group);
            GroupChangeEventArgs e = new GroupChangeEventArgs(group, eAction.Cast);
            GroupOnChange(e);*/
            return object_cast_list;
        }

        /// <summary>
        ///  Метод приводит все объекты к активным состояниям классов указанной группы
        /// </summary>
        public List<errarg_cast> object_cast_for_class_act_by_id_group(group Group_target)
        {
            return object_cast_for_class_act_by_id_group(Group_target.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_cast_for_class_act_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_cast_for_class_act_by_id_group");
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
        ///  Метод приводит все объекты позции к активным состояниям классов рекурсивно
        /// </summary>
        public List<errarg_cast> object_cast_for_class_act_by_id_position(Int64 iid_position)
        {
            List<errarg_cast> object_cast_list = new List<errarg_cast>();


            DataTable tbl_result = TableByName("errarg_cast");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_cast_for_class_act_by_id_position");

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

            cmdk.Fill(tbl_result);
            
            errarg_cast og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new errarg_cast(dr);
                    object_cast_list.Add(og);
                }
            }
            //Генерируем событие изменения представления класса
            /*position position = pos_by_id(iid_position);
            PositionChangeEventArgs e = new PositionChangeEventArgs(position, eAction.Cast);
            PositionOnChange(e);*/
            return object_cast_list;
        }

        /// <summary>
        ///  Метод приводит все объекты позции к активным состояниям классов рекурсивно
        /// </summary>
        public List<errarg_cast> object_cast_for_class_act_by_id_position(position Position_target)
        {
            return object_cast_for_class_act_by_id_position(Position_target.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_cast_for_class_act_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_cast_for_class_act_by_id_position");
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
