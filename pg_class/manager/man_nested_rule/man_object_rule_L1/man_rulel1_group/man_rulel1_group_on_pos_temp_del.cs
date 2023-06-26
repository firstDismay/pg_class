﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод удаляет разрешающее правило уровня 1 группа на шаблон
        /// </summary>
        public void rulel1_group_on_pos_temp_del(Int64 iid_group, Int64 iid_pos_temp)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("rulel1_group_on_pos_temp_del");
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

            cmdk.Parameters["iid_group"].Value = iid_group;
            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;
            cmdk.ExecuteNonQuery();

            //Вызов события изменения списка правил вложенности вложенности
            Rulel1_Group_On_Pos_tempListChangeEventArgs e;
            e = new Rulel1_Group_On_Pos_tempListChangeEventArgs(iid_group, iid_pos_temp, eActionRuleList.delrule);
            OnRulel1_Group_On_Pos_tempListChange(e);
        }

        /// <summary>
        /// Метод удаляет разрешающее правило уровня 1 группа на шаблон
        /// </summary>
        public void rulel1_group_on_pos_temp_del(group Group, pos_temp Pos_temp)
        {
            rulel1_group_on_pos_temp_del(Group.Id, Pos_temp.Id);
        }

        /// <summary>
        /// Метод удаляет разрешающее правило уровня 1 группа на шаблон
        /// </summary>
        public void rulel1_group_on_pos_temp_del(rulel1_group_on_pos_temp RuleL1)
        {
            rulel1_group_on_pos_temp_del(RuleL1.Id_group, RuleL1.Id_pos_temp);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("rulel1_group_on_pos_temp_del");
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