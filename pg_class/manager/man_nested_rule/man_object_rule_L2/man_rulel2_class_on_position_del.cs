﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод удаляет разрешающее правило уровня 2 класс на позицию
        /// </summary>
        public void Rulel2_class_on_position_del(Int64 iid_class, Int64 iid_position)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("rulel2_class_on_position_del");

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

            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.ExecuteNonQuery();

            //Вызов события изменения списка вложенности
            Rulel2_Class_On_PositionListChangeEventArgs e;
            e = new Rulel2_Class_On_PositionListChangeEventArgs(iid_position, iid_class, eActionRuleList.delrule);
            OnRulel2_Class_On_PositionListChange(e);
        }

        /// <summary>
        /// Метод удаляет разрешающее правило уровня 2 класс на позицию
        /// </summary>
        public void Rulel2_class_on_position_del(vclass Vclass, position Position)
        {
            Rulel2_class_on_position_del(Vclass.Id, Position.Id);
        }

        /// <summary>
        /// Метод удаляет разрешающее правило уровня 2 класс на позицию
        /// </summary>
        public void Rulel2_class_on_position_del(rulel2_class_on_position RuleL2)
        {
            Rulel2_class_on_position_del(RuleL2.Id_class, RuleL2.Id_position);
        }


        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Rulel2_class_on_position_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("rulel2_class_on_position_del");
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
        /// Метод удаляет разрешающие правила уровня 2 класс на позицию для указанной позиции
        /// </summary>
        public void Rulel2_class_on_position_all_del(Int64 iid_position)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("rulel2_class_on_position_all_del");

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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.ExecuteNonQuery();

            //Вызов события изменения списка вложенности
            Rulel2_Class_On_PositionListChangeEventArgs e;
            e = new Rulel2_Class_On_PositionListChangeEventArgs(iid_position, eActionRuleList.delallrule);
            OnRulel2_Class_On_PositionListChange(e);
        }

        /// <summary>
        /// Метод удаляет разрешающие правила уровня 2 класс на позицию для указанной позиции
        /// </summary>
        public void Rulel2_class_on_position_all_del(position Position)
        {
            Rulel2_class_on_position_all_del(Position.Id);
        }


        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Rulel2_class_on_position_all_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("rulel2_class_on_position_all_del");
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