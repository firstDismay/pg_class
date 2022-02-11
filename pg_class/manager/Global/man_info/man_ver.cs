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
        #region СВОЙСТВА МЕНЕДЖЕРА ДАННЫХ В ЧАСТИ СРАВНЕНИЯ ВЕРСИЙ КЛИЕНТСКИХ БИБИЛИОТЕК И УПРАВЛЕНИЯ РЕЖИМАМИ МЕНЕДЖЕРА
        /// <summary>
        /// Ожидаемая менеджером версия сборки БД учет. Должна совпадать с номером сборки БД Ассистента.
        /// </summary>
        static public Int32 ExpectedVerBD
        {
            get
            {
                return 200;
            }
        }

        private String server_version;
        /// <summary>
        /// Версия сервера БД
        /// </summary>
        public String Server_version
        {
            get
            {
                return server_version;
            }
        }

        private Int32 base_build_id;
        /// <summary>
        /// Версия сборки базы данных ассистента
        /// </summary>
        public Int32 Base_build_id
        {
            get
            {
                return base_build_id;
            }
        }
        private DateTime base_build_date;
        /// <summary>
        /// Дата сборки базы данных ассистента
        /// </summary>
        public DateTime Base_build_date
        {
            get
            {
                return base_build_date;
            }
        }

        /// <summary>
        /// Свойство возвращает версию сборки
        /// </summary>
        static public String AssemblyVersion
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        /// <summary>
        /// Класс определяющий версии компонентов менеджера данных и клиентских сборок
        /// </summary>
        public man_info Info
        {
            get
            {
                return man_get_baseid();
            }
        }
        #endregion

        #region МЕТОДЫ МЕНЕДЖЕРА ДАННЫХ В ЧАСТИ СРАВНЕНИЯ ВЕРСИЙ КЛИЕНТСКИХ БИБИЛИОТЕК
        /// <summary>
        /// Метод обновляет версии клиентских библиотек в БД
        /// </summary>
        public man_info man_set_baseid(String ver_pgclass, String ver_configurator, String ver_client, Boolean on_increment_baseid)
        {
            man_info man_info = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
            
            //=======================
            cmdk = CommandByKey("man_set_baseid");

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

            cmdk.Parameters["ver_pgclass"].Value = ver_pgclass;
            cmdk.Parameters["ver_configurator"].Value = ver_configurator;
            cmdk.Parameters["ver_client"].Value = ver_client;
            cmdk.Parameters["on_increment_baseid"].Value = on_increment_baseid;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                        man_info = man_get_baseid();
                        break;
                default:
                       throw new PgDataException(error, desc_error);
            }
            return man_get_baseid();
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean man_set_baseid(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("man_set_baseid");
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

        //*********************************************************************************************
        /// <summary>
        /// Концепция по идентификатору
        /// </summary>
        public man_info man_get_baseid()
        {
            man_info man_info = null;

            DataTable tbl_man  = TableByName("cfg_base_id");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("man_get_baseid");


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

            cmdk.Fill(tbl_man);
            
            if (tbl_man.Rows.Count > 0)
            {
                man_info = new man_info(tbl_man.Rows[0]);
            }
            return man_info;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean man_get_baseid(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("man_get_baseid");
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

        #region СВОЙСТВА МЕНЕДЖЕРА ДАННЫХ В ЧАСТИ  УПРАВЛЕНИЯ РЕЖИМАМИ МЕНЕДЖЕРА

        private static eManagerMode managermode = eManagerMode.NormalMode;
        /// <summary>
        /// Режим работы менеджера
        /// </summary>
        public static eManagerMode Mode
        {
            get
            {
                return managermode;
            }
            set
            {
                managermode = value;
            }
        }
        #endregion
    }
}
