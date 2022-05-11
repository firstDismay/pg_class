using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Npgsql;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод возвращает историческое правило уровня 2 класс на позицию по идентификатору правила
        /// </summary>
        public rulel2_class_snapshot_on_position Rulel2_class_snapshot_on_position_by_id(Int64 iid_class, DateTime itimestamp_class, Int64 iid_position)
        {
            rulel2_class_snapshot_on_position rulel2 = null;

            DataTable tbl_rulel2  = TableByName("vrulel2_class_snapshot_on_position");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("rulel2_class_snapshot_on_position_by_id");

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
            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;

            cmdk.Fill(tbl_rulel2);
            
            if (tbl_rulel2.Rows.Count > 0)
            {
                rulel2 = new rulel2_class_snapshot_on_position(tbl_rulel2.Rows[0]);
            }

            return rulel2;
        }

        /// <summary>
        /// Метод возвращает историческое правило уровня 2 класс на позицию по идентификатору правила
        /// </summary>
        public rulel2_class_snapshot_on_position Rulel2_class_snapshot_on_position_by_id(vclass Class, position Position)
        {
            return Rulel2_class_snapshot_on_position_by_id(Class.Id, Class.Timestamp, Position.Id);
        }

        /// <summary>
        /// Метод возвращает историческое правило уровня 2 класс на позицию по идентификатору правила
        /// </summary>
        public rulel2_class_snapshot_on_position Rulel2_class_snapshot_on_position_by_id(object_general Object)
        {
            if (Object.Is_inside)
            {
                throw (new PgDataException(404,"Метод не применим для встроенных объектов входящих в состав объектных агрегатов!"));
            }
            return Rulel2_class_snapshot_on_position_by_id(Object.Id_class, Object.Timestamp_class, Object.Id_position);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Rulel2_class_snapshot_on_position_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel2_class_snapshot_on_position_by_id");
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
        /// Метод возвращает исторические правила уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<rulel2_class_snapshot_on_position> Rulel2_class_snapshot_on_position_by_id_position(Int64 iid_position)
        {
            List<rulel2_class_snapshot_on_position> rule_list = new List<rulel2_class_snapshot_on_position>();


            DataTable tbl_rule_list  = TableByName("vrulel2_class_snapshot_on_position");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("rulel2_class_snapshot_on_position_by_id_position");

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

            cmdk.Fill(tbl_rule_list);
            
            rulel2_class_snapshot_on_position rule;
            if (tbl_rule_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule_list.Rows)
                {
                    rule = new rulel2_class_snapshot_on_position(dr);
                    rule_list.Add(rule);
                }
            }
            return rule_list;
        }

        /// <summary>
        /// Метод возвращает исторические правила уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<rulel2_class_snapshot_on_position> Rulel2_class_snapshot_on_position_by_id_position(position Position)
        {
            return Rulel2_class_snapshot_on_position_by_id_position(Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Rulel2_class_snapshot_on_position_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("rulel2_class_snapshot_on_position_by_id_position");
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