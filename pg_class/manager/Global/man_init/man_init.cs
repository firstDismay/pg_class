using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System.Net.Sockets;
using pg_class.poolcn;

namespace pg_class
{
    public partial class manager
    {
        #region СТРУКТУРЫ ДЛЯ ВЗАИМОДЕЙСТВИЯ С БД

        /// <summary>
        /// Лист команд взаимодействия с сервером PostgreSQL
        /// </summary>
        private List<NpgsqlCommandKey> command_list;

        /// <summary>
        /// Лист таблиц команд взаимодействия с сервером PostgreSQL
        /// </summary>
        private List<DataTable> datatable_list;

        #endregion

        #region ИНИЦИАЛИЗАЦИЯ КЛАССА ДОСТУПА К ДАННЫМ

        /// <summary>
        /// Метод инициализации класса
        /// </summary>
        protected void InitCommands()
        {
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(0, eEntity.manager, 0, "Инициализация менеджера данных", eAction.Init, eJournalMessageType.information);
            JournalMessageOnReceived(me);

            //Инициализация подключения к БД конфигурации
            connect cn = pool_.Connect_Get(true);

            //Вызов события журнала
            me = new JournalEventArgs(0, eEntity.manager, 0, "Инициализация команд менеджера данных", eAction.Init, eJournalMessageType.information);
            JournalMessageOnReceived(me);
            //Инициализация команд работы с БД
            InitCommand2(cn.CN);
            cn.UnLock();

            //Инициализация концепций
            conception_list_state = eStatus.on;

            //Вызов события журнала
            String msg = String.Format("Инициализация команд менеджера данных завершена, загружено команд: {0}, загружено таблиц: {1}", command_list.Count, datatable_list.Count);
            me = new JournalEventArgs(0, eEntity.manager, 0, msg, eAction.Init, eJournalMessageType.information);
            JournalMessageOnReceived(me);
        }

        #endregion

        #region ИНИЦИАЛИЗАЦИЯ КОМАНД КЛАССА ВЕРСИЯ 4
        /// <summary>
        /// Инициализация команд и таблиц данных менеджера доступа к БД
        /// </summary>
        private void InitCommand2(NpgsqlConnection CN_local)
        {
            NpgsqlCommand NCM;
            NpgsqlDataAdapter NDA;
            DataTable proc_DT;
            DataTable build_BD;
            NpgsqlTransaction trans;

            //ИНИЦИАЛИЗАЦИЯ СВОЙСТВ ВЕРСИИ И СБОРКИ СЕРВЕРА БД
            trans = CN_local.BeginTransaction(IsolationLevel.RepeatableRead);
            NCM = new NpgsqlCommand();
            NCM.Connection = CN_local;
            NCM.Transaction = trans;
            NCM.CommandType = CommandType.Text;
            NCM.CommandText = "SELECT * FROM version();";
            try
            {
                server_version = (String)NCM.ExecuteScalar();
                NCM.CommandText = "SELECT * FROM cfg_get_baseid();";
                build_BD = new DataTable();
                NDA = new NpgsqlDataAdapter();
                NDA.SelectCommand = NCM;
                NDA.Fill(build_BD);

                if (build_BD.Rows.Count > 0)
                {
                    DataRow drbd;
                    drbd = build_BD.Rows[0];
                    base_build_id = Convert.ToInt32(drbd["baseid"]);
                    base_build_date = Convert.ToDateTime(drbd["date"]);
                }
                //Запрос списка процедур API
                NCM.CommandText = String.Format("SELECT * FROM cfg_m_initproc_base_{0};", ExpectedVerBD);
                proc_DT = new DataTable();
                NDA = new NpgsqlDataAdapter();
                NDA.SelectCommand = NCM;
                NDA.Fill(proc_DT);

                if (proc_DT.Rows.Count > 0)
                {
                    UInt32 proc_oid;
                    String proc_name;
                    Int32 proc_args;
                    pg_argument[] proc_args_list;
                    String proc_argsignature;
                    Boolean proc_access;

                    NpgsqlCommand cmd;
                    NpgsqlCommandKey cmdk;

                    String arg_name;
                    String arg_type;
                    String arg_mode;

                    NpgsqlParameter cmd_sp;

                    //Инициализация листа команд БД
                    command_list = new List<NpgsqlCommandKey>();

                    //Создание списка процедур
                    foreach (DataRow dr in proc_DT.Rows)
                    {
                        proc_oid = Convert.ToUInt32(dr["oid"]);
                        proc_name = Convert.ToString(dr["proname"]);
                        proc_args = Convert.ToInt32(dr["proargs"]);
                        proc_args_list = (pg_argument[])dr["proargslist"];
                        proc_argsignature = Convert.ToString(dr["argsignature"]);
                        proc_access = Convert.ToBoolean(dr["access"]);
                        cmd = new NpgsqlCommand();
                        cmd.Connection = CN_local;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = proc_name;
                        if (proc_args > 0)
                        {
                            //Инициализация команды с параметрами
                            if (proc_args_list.Length > 0)
                            {
                                //Инициализация списка аргументов
                                foreach (pg_argument arg in proc_args_list)
                                {
                                    arg_name = arg.name;
                                    arg_type = arg.type;
                                    arg_mode = arg.mode;

                                    cmd_sp = cmd.Parameters.Add(arg_name, Name_To_NpgsqlType(arg_type));
                                    switch (arg_mode)
                                    {
                                        case "i":
                                            cmd_sp.Direction = ParameterDirection.Input;
                                            break;
                                        case "o":
                                            cmd_sp.Direction = ParameterDirection.Output;
                                            break;
                                        case "b":
                                            cmd_sp.Direction = ParameterDirection.InputOutput;
                                            break;
                                    }
                                }
                            }
                        }
                        cmdk = new NpgsqlCommandKey(proc_oid, cmd, proc_name, proc_args, proc_argsignature, proc_access);
                        //cmdk.Prepare();
                        command_list.Add(cmdk);
                    }
                }
                //ИНИЦИАЛИЗАЦИЯ ТАБЛИЦ КВАНТОВЫХ КЛАССОВ

                //Инициализация листа квантовых таблиц данных
                datatable_list = new List<DataTable>();

                //NCM.CommandType = CommandType.Text;
                NCM.CommandText = String.Format("SELECT * FROM cfg_m_inittable_base_{0};", ExpectedVerBD);
                proc_DT = new DataTable();
                NDA.SelectCommand = NCM;
                NDA.Fill(proc_DT);
                if (proc_DT.Rows.Count > 0)
                {
                    UInt32 table_oid;
                    String table_name;
                    pg_tblcol2[] table_col_list;

                    DataTable tbl;
                    DataColumn cl;
                    Int32 len;

                    foreach (DataRow dr in proc_DT.Rows)
                    {
                        table_oid = Convert.ToUInt32(dr["oid"]);
                        table_name = Convert.ToString(dr["relname"]);
                        table_col_list = (pg_tblcol2[])dr["columnlist"];
                        tbl = new DataTable();
                        tbl.TableName = table_name;

                        //Определение коллекции столбцов квантовой таблицы
                        if (table_col_list.Length > 0)
                        {
                            foreach (pg_tblcol2 col in table_col_list)
                            {
                                cl = tbl.Columns.Add(col.name, Name_To_Type(col.type, col.typcategory));
                                len = col.length;
                                if (len > 0)
                                {
                                    cl.MaxLength = len;
                                }
                            }
                        }
                        datatable_list.Add(tbl);
                    }
                }
                trans.Commit();
            }
            catch (Npgsql.PostgresException pex)
            {
                if (pex.SqlState == "42P01" && (pex.Message.Contains("cfg_m_initproc_base_") || pex.Message.Contains("cfg_m_inittable_base")))
                {
                    String sb = String.Format("Затребованная клиентом версия API: {0} не поддерживается сервером, дополнительные сведения: {1}", ExpectedVerBD, pex.Message);
                    
                    throw new PgManagerException(404, sb, pex.Message);
                }
                else
                {
					StringBuilder sb = new StringBuilder();
					sb.Append("Сбой процедуры инициализации команд менеджера данных, дополнительные сведения: ");
					sb.Append(pex.Message);
					throw new PgManagerException(1101, sb.ToString(), pex.Message);
				}
            }
            catch (Exception ex)
            {
                try
                {
                    trans.Rollback();
                }
                finally { }

                StringBuilder sb = new StringBuilder();
                sb.Append("Сбой процедуры инициализации команд менеджера данных, дополнительные сведения: ");
                sb.Append(ex.Message);
                throw new PgManagerException(1101, sb.ToString(), ex.Message);
            }
        }
        #endregion
    }
}