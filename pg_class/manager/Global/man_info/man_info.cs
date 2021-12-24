using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс определяющий версии компонентов менеджера данных и клиентских сборок
    /// </summary>
    public class man_info
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected man_info()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public man_info(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "cfg_base_id")
            {
                base_build_id = Convert.ToInt32(row["baseid"]);
                base_build_date = Convert.ToDateTime(row["date"]);
                base_pgclass = new Version(Convert.ToString(row["pgclass"]));
                base_configurator = new Version(Convert.ToString(row["configurator"]));
                base_client = new Version(Convert.ToString(row["client"]));

            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        /// <summary>
        /// Версия сборки базы данных (КЛИЕНТ)
        /// </summary>
        public Int32 Current_Build_Id
        {
            get
            {
                return manager.ExpectedVerBD;
            }
        }

        Int32 base_build_id;
        /// <summary>
        /// Версия сборки базы данных (СЕРВЕР)
        /// </summary>
        public Int32 Base_Build_Id { get => base_build_id;}

        DateTime base_build_date;
        /// <summary>
        /// Дата сборки базы данных  (СЕРВЕР)
        /// </summary>
        public DateTime Base_Build_Date
        {
            get
            {
                return base_build_date;
            }
        }

        Version base_pgclass;
        /// <summary>
        /// Версия сборки класса доступа  (СЕРВЕР)
        /// </summary>
        public Version Base_PGclass
        {
            get
            {
                return base_pgclass;
            }
        }
        /// <summary>
        /// Версия сборки класса доступа  (КЛИЕНТ)
        /// </summary>
        public Version Current_PGclass
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            }
        }
        /// <summary>
        /// Состояние версии библиотеки доступа
        /// </summary>
        public Boolean PGclassState
        {
            get
            {
                Boolean Result = true;
                if (Base_PGclass > Current_PGclass)
                {
                    Result = false;
                }
                return Result;
            }
        }

        private Version base_configurator;
        /// <summary>
        /// Версия сборки конфигуратора  (СЕРВЕР)
        /// </summary>
        public Version Base_Configurator
        {
            get
            {
                return base_configurator;
            }
        }

        private Version current_configurator;
        /// <summary>
        /// Версия сборки конфигуратора  (КЛИЕНТ)
        /// </summary>
        public Version Current_Configurator
        {
            get
            {
                return current_configurator;
            }
            set
            {
                current_configurator = value;
            }
        }
        /// <summary>
        /// Состояние версии конфигуратора
        /// </summary>
        public Boolean ConfiguratorState
        {
            get
            {
                Boolean Result = true;
                if (Base_Configurator > Current_Configurator)
                {
                    Result = false;
                }
                return Result;
            }
        }
        Version base_client;
        /// <summary>
        /// Версия сборки клиента (СЕРВЕР)
        /// </summary>
        public Version Base_Client
        {
            get
            {
                return base_client;
            }
        }

        private Version current_client;
        /// <summary>
        /// Версия сборки клиента (КЛИЕНТ)
        /// </summary>
        public Version Current_Client
        {
            get
            {
                return current_client;
            }
            set
            {
                current_client = value;
            }
        }
        /// <summary>
        /// Состояние версии Клиента
        /// </summary>
        public Boolean ClientState
        {
            get
            {

                Boolean Result = true;
                if (Current_Client != null)
                {
                    if (Base_Client > Current_Client)
                    {
                        Result = false;
                    }
                }
                else
                {
                    Result = false;
                }
                return Result;
            }
        }

        /// <summary>
        /// Свойство имеет значение true если текущие библиотеки имеют более позние версие чем указано в БД
        /// </summary>
        public Boolean IsNewer
        {
            get
            {
                Boolean Result = false;
                if (Current_PGclass > Base_PGclass)
                {
                    Result = true;
                }

                if (Current_Configurator != null)
                {
                    if (Current_Configurator > Base_Configurator)
                    {
                        Result = true;
                    }
                }

                if (Current_Client != null)
                {
                    if (Current_Client > Base_Client)
                    {
                        Result = true;
                    }
                }
                return Result;
            }
        }
        /// <summary>
        /// Ссылка на менеджера данных
        /// </summary>
        private manager Manager
        {
            get
            {
                return manager.Instance();
            }
        }

        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Метод обновляет версии компонентов менеджера данных и клиентских сборок в БД
        /// man_set_baseid
        /// </summary>
        public void Update(Boolean on_increment_baseid)
        {

            String ver_pgclass_next = Base_PGclass.ToString(); 
            String ver_configurator_next = Base_Configurator.ToString();
            String ver_client_next = Base_Client.ToString();

            if (Current_PGclass > Base_PGclass)
            {
                ver_pgclass_next = Current_PGclass.ToString();
            }

            if (Current_Configurator != null)
            {
                if (Current_Configurator > Base_Configurator)
                {
                    ver_configurator_next = Current_Configurator.ToString();
                }
            }

            if (Current_Client != null)
            {
                if (Current_Client > Base_Client)
                {
                    ver_configurator_next = Current_Client.ToString();
                }
            }
            if (IsNewer || on_increment_baseid)
            {
                Manager.man_set_baseid(ver_pgclass_next, ver_configurator_next, ver_client_next, on_increment_baseid);
            }
        }

        /// <summary>
        /// Метод обновляет версии компонентов менеджера данных и клинтских сборок в БД
        /// </summary>
        public void UpdatePGClass(Version Current_pgClass)
        {
            current_client = Current_pgClass;
            this.Update(false);
        }

        /// <summary>
        /// Метод обновляет версии компонентов менеджера данных и клинтских сборок в БД
        /// </summary>
        public void UpdateConfigurator(Version Current_Configurator)
        {
            current_configurator = Current_Configurator;
            this.Update(false);
        }

        /// <summary>
        /// Обновление класса из БД
        /// </summary>
        public Boolean Refresh()
        {
            man_info temp;
            Boolean Result = false;
            temp = Manager.man_get_baseid(); 

            if (temp != null)
            {
                base_build_id = temp.Base_Build_Id;
                base_build_date = temp.Base_Build_Date;
                base_pgclass = temp.Base_PGclass;
                base_configurator = temp.Base_Configurator;
                base_client = temp.Base_Client;
                Result = true;
            }
            else
            {
                Result = false;
            }
            return Result;
        }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА

        #endregion

    }
}