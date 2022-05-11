﻿using System;
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
        /// Метод определяет наличие разрешения RL1 класс на шаблон для переданной пары
        /// </summary>
        public Boolean rulel1_class_on_pos_temp_check_access(Int64 iid_pos_temp, Int64 iid_class)
        {
            //=======================
            NpgsqlCommandKey cmdk;
            //**********

            //=======================
            cmdk = CommandByKey("rulel1_class_on_pos_temp_check_access");

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

            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;
            cmdk.Parameters["iid_class"].Value = iid_class;

            //Начало транзакции
            return (Boolean)cmdk.ExecuteScalar();
        }

        /// <summary>
        /// Метод определяет наличие разрешения RL1 класс на шаблон для переданной пары
        /// </summary>
        public Boolean rulel1_class_on_pos_temp_check_access(pos_temp Pos_temp, vclass Class)
        {
            return rulel1_class_on_pos_temp_check_access(Pos_temp.Id, Class.Id);
        }
    }
}
