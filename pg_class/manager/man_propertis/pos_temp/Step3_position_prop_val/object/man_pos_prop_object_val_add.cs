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
        /// <summary>
        /// Метод добавляет новый объект и встраивает его в объектное свойство в качестве значения
        /// </summary>
        public object_general position_prop_object_val_add_new(Int64 iid_position_carrier, Int64 iid_pos_temp_prop, Int64 iid_class_real, Int32 iid_unit_conversion_rule, Decimal icquantity)
        {
            object_general Object = null;
            position_prop_object_val PositionPropObjectVal = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("position_prop_object_val_add_new");

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

            cmdk.Parameters["iid_position_carrier"].Value = iid_position_carrier;
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
            cmdk.Parameters["iid_class_real"].Value = iid_class_real;
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.Parameters["icquantity"].Value = icquantity;


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
                        Object = object_by_id(id);
                        PositionPropObjectVal = position_prop_object_val_by_id_prop(iid_position_carrier, iid_pos_temp_prop);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.vobject, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения объекта
            if (Object != null)
            {
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object, eAction.Insert);
                ObjectOnChange(e);
            }

            if (PositionPropObjectVal != null)
            {
                //Генерируем событие изменения значения данных значения объектного свойства объекта
                PositionPropObjectValChangeEventArgs e2 = new PositionPropObjectValChangeEventArgs(PositionPropObjectVal, eAction.Insert);
                PositionPropObjectValOnChange(e2);
            }
            //Возвращаем данные значения объетного свойства
            return Object;
        }

        /// <summary>
        /// Метод добавляет новый объект и встраивает его в объектное свойство в качестве значения
        /// </summary>
        public object_general position_prop_object_val_add_new(position_prop Position_prop, vclass Class_real, unit_conversion_rule Unit_conversion_rule, Decimal icquantity)
        {
            return position_prop_object_val_add_new(Position_prop.Id_position_carrier, Position_prop.Id_pos_temp_prop, Class_real.Id, Unit_conversion_rule.Id, icquantity);
        }
            


        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
       public Boolean position_prop_object_val_add_new(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_prop_object_val_add_new");
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
        /// Метод встраивает существующий объект в объектное свойство в качестве значения STEP3
        /// </summary>
        public object_general position_prop_object_val_add(Int64 iid_position_carrier, Int64 iid_pos_temp_prop, Int64 iid_object_val, Decimal icquantity)
        {
            object_general Object_embed = null;
            object_general Object_change = null;

            position_prop_object_val PositionPropObjectVal = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("position_prop_object_val_add");

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

            cmdk.Parameters["iid_position_carrier"].Value = iid_position_carrier;
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
            cmdk.Parameters["iid_object_val"].Value = iid_object_val;
            cmdk.Parameters["icquantity"].Value = icquantity;

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
                        Object_embed = object_by_id(id);
                        PositionPropObjectVal = position_prop_object_val_by_id_prop(iid_position_carrier, iid_pos_temp_prop);

                        //Если идет частичное встраивание с созданием нового объекта находим остаток
                        if (id != iid_object_val)
                        {
                            Object_change = object_by_id(iid_object_val);
                        }

                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_object_val, eEntity.vobject, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения встроенного объекта
            if (Object_embed != null)
            {
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object_embed, eAction.Insert);
                ObjectOnChange(e);
            }

            //Если есть остаток то генерируем изменение остатка
            if (Object_change != null)
            {
                ObjectChangeEventArgs e3 = new ObjectChangeEventArgs(Object_change, eAction.Update);
                ObjectOnChange(e3);
            }

            if (PositionPropObjectVal != null)
            {
                //Генерируем событие изменения данных значения объектного свойства
                PositionPropObjectValChangeEventArgs e2 = new PositionPropObjectValChangeEventArgs(PositionPropObjectVal, eAction.Insert);
                PositionPropObjectValOnChange(e2);
            }

            //Возвращаем Объект
            return Object_embed;
        }

        /// <summary>
        /// Метод встраивает существующий объект в объектное свойство в качестве значения STEP3
        /// </summary>
        public object_general position_prop_object_val_add(position_prop Position_prop, object_general Object_Val, Decimal icquantity)
        {
            return position_prop_object_val_add(Position_prop.Id_position_carrier, Position_prop.Id_pos_temp_prop, Object_Val.Id, icquantity);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_object_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_prop_object_val_add");
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
