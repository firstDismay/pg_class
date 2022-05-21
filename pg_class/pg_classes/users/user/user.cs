using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
    { /// <summary>
    /// Класс пользователей БД учеет
    /// </summary>
    public partial class user
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected user()
        {
            on_change = false;
            imagekey = "user_us";
            selectedimagekey = "user_s";
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public user(System.Data.DataRow row) : this()
        {

            //if (Модуль.Table is ТаблицаМодулей)
            if (row.Table.TableName == "vusers")
            {
                id = Convert.ToInt32(row["id"]);
                oid = Convert.ToInt32(row["oid"]);
                name = (String)row["name"];
                otchestvo = (String)row["otchestvo"];
                familiya = (String)row["familiya"];
                rolname = (String)row["rolname"];
                rolnamenew = (String)row["rolname"];
                rolsuper = (Boolean)row["rolsuper"];
                rolinherit = (Boolean)row["rolinherit"];
                rolcreaterole = (Boolean)row["rolcreaterole"];
                rolcreatedb = (Boolean)row["rolcreatedb"];
                rolcanlogin = (Boolean)row["rolcanlogin"];
                rolcanweblogin = (Boolean)row["rolcanweblogin"];
                rolbypassrls = (Boolean)row["rolbypassrls"];
                timestamp = (DateTime)row["timestamp"];
                iscurrent = (Boolean)row["iscurrent"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id;
        private Int32 oid;
        private String name;
        private String otchestvo;
        private String familiya;
        private String rolname;
        private String rolnamenew;
        private Boolean rolsuper;
        private Boolean rolinherit;
        private Boolean rolcreaterole;
        private Boolean rolcreatedb;
        private Boolean rolcanlogin;
        private Boolean rolcanweblogin;
        private Boolean rolbypassrls;
        private DateTime timestamp;
        private Boolean iscurrent;

        /// <summary>
        /// Уникальный идентификатор учетной записи, глобальный
        /// </summary>
        public Int64 Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Уникальный идентификатор учетной записи, внутрисистемный
        /// </summary>
        public Int32 Oid
        {
            get
            {
                return oid;
            }
        }

        /// <summary>
        /// Штамп времени пользователя
        /// </summary>
        public DateTime Timestamp { get => timestamp; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public String UserName
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Отчество пользователя
        /// </summary>
        public String UserOtchestvo
        {
            get
            {
                return otchestvo;
            }
            set
            {
                if (otchestvo != value)
                {
                    otchestvo = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public String UserFamiliya
        {
            get
            {
                return familiya;
            }
            set
            {
                if (familiya != value)
                {
                    familiya = value;
                    on_change = true;
                   
                }
            }
        }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public String Login
        {
            get
            {
                return rolname;
            }
            set
            {
                rolnamenew = value;
                on_change = true;
            }
        }

        /// <summary>
        /// Если логи соотвествует текущему пользователю интерактивной сессии клиента
        /// </summary>
        public Boolean Is_Current
        {
            get
            {
                return iscurrent;
            }
        }

        /// <summary>
        /// Флаг суперпользователя
        /// </summary>
        public Boolean RolSuper
        {
            get
            {
                return rolsuper;
            }
            set
            {
                if (rolsuper != value)
                {
                    rolsuper = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Флаг наследования привелегий ролей членом которых является пользователь (всегда должно быть TRUE)
        /// </summary>
        public Boolean RolInherit
        {
            get
            {
                return rolinherit;
            }
            set
            {
                if (rolinherit != value)
                {
                    rolinherit = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Флаг определяющий право на создание пользователей
        /// </summary>
        public Boolean RolCreaterole
        {
            get
            {
                return rolcreaterole;
            }
            set
            {
                if (rolcreaterole != value)
                {
                    rolcreaterole = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Флаг определяющий право на создание баз данных
        /// </summary>
        public Boolean RolCreatedb
        {
            get
            {
                return rolcreatedb;
            }
            set
            {
                if (rolcreatedb != value)
                {
                    rolcreatedb = value;
                    on_change = true;
                  
                }
                
            }
        }

        /// <summary>
        /// Флаг определяющий право входа на сервер (всегда должно быть TRUE)
        /// </summary>
        public Boolean RolCanLogin
        {
            get
            {
                return rolcanlogin;
            }
            set
            {
                if (rolcanlogin != value)
                {
                    rolcanlogin = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Флаг определяющий право входа на сервер посредством Web-доступа
        /// </summary>
        public Boolean RolCanWebLogin
        {
            get
            {
                return rolcanweblogin;
            }
            set
            {
                if (rolcanweblogin != value)
                {
                    rolcanweblogin = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Флаг определяющий режим управления обходом RLS
        /// </summary>
        public Boolean RolBypassRLS
        {
            get
            {
                return rolbypassrls;
            }
            set
            {
                if (rolbypassrls != value)
                {
                    rolbypassrls = value;
                    on_change = true;
                }
            }
        }

        //**********************************
        private Boolean on_change;
        /// <summary>
        /// Свойство определяющее потребность в обновлении данных БД
        /// </summary>
        public Boolean On_change
        {
            get
            {
                return on_change;
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

        private String imagekey;
        /// <summary>
        /// Ключ объекта
        /// </summary>
        public string ImageKey
        {
            get
            {
                return imagekey;
            }
        }

        private String selectedimagekey;
        /// <summary>
        /// Ключ выделенного объекта
        /// </summary>
        public string SelectedImageKey
        {
            get
            {
                return selectedimagekey;
            }
        }

        /// <summary>
        /// Уникальный строковый идентификатор пользователя
        /// </summary>
        public String Key
        {
            get
            {
                return String.Format("user_{0}", rolname);
            }
        }

        /// <summary>
        /// Опции текущего пользователя
        /// </summary>
        public user_options Options
        {
            get
            {
                return Manager.user_options_by_current();

            }
        }
        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния пользователя
        /// </summary>
        public eEntityState Is_actual()
        {
            return manager.Instance().user_is_actual(this);
        }

        /// <summary>
        /// Обновление пользователя в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                if (rolname == rolnamenew)
                {
                    Manager.user_upd(this);
                }
                else
                {
                    Manager.user_upd(this, rolnamenew);
                }
                Refresh();
                on_change = false;
               
            }
        }


        /// <summary>
        /// Обновление пользователя из БД
        /// </summary>
        public Boolean Refresh()
        {
            user temp;
            Boolean Result = false;
            temp = Manager.user_by_login(Login);
            if (temp != null)
            {
                oid = temp.Oid;
                name = temp.UserName;
                otchestvo = temp.UserOtchestvo;
                familiya = temp.UserFamiliya;
                rolname = temp.Login;
                rolnamenew = temp.Login;
                rolsuper = temp.RolSuper;
                rolinherit = temp.RolInherit;
                rolcreaterole = temp.RolCreaterole;
                rolcreatedb = temp.RolCreatedb;
                rolcanlogin = temp.RolCanLogin;
                rolbypassrls = temp.RolBypassRLS;
                timestamp = temp.timestamp;
                iscurrent = temp.Is_Current;
                Result = true;
            }
            else
            {
                Result = false;
            }
            return Result;
        }

        /// <summary>
        /// Установить пароль пользователя
        /// </summary>
        public void Set_Pwd(String oldpwd, String newpwd)
        {
            Manager.user_pwd_set(Login, oldpwd, newpwd);
        }

        /// <summary>
        /// Метод определяет членство пользователя в указанной роли
        /// </summary>
        public Boolean is_member_role(role_base vrole, Boolean irecursive)
        {
            return Manager.user_is_member_role(this, vrole, irecursive);
        }

        /// <summary>
        /// Метод определяет членство пользователя в указанной роли
        /// </summary>
        public Boolean is_member_role(role_user vrole, Boolean irecursive)
        {
            return Manager.user_is_member_role(this, vrole, irecursive);
        }

        /// <summary>
        /// Метод определяет доступномть смены пароля для указанного пользователя
        /// </summary>
        public Boolean can_change_pwd(user usr_change_login)
        {
            return Manager.user_pwd_can_change(this, usr_change_login);
        }

        /// <summary>
        /// Метод удаляет текущую позицию
        /// user_del
        /// </summary>
        public void Del()
        {
            Manager.user_del(this);
        }

        /// <summary>
        /// Лист ролей пользователя
        /// </summary>
        public List<role_user> Role_user_list_get(Boolean recursive)
        {
            return Manager.user_role_user_by_login(rolname, recursive);
        }

        /// <summary>
        /// Лист ролей базовых пользователя
        /// </summary>
        public List<role_base> Role_base_list_get(Boolean recursive)
        {
            return Manager.user_role_base_by_login(rolname, recursive);
        }

        /// <summary>
        /// Лист функция пользователя
        /// </summary>
        public List<function> Functions_base_list_get()
        {
            return Manager.user_base_function_by_login(rolname);
        }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            if ((name.Length > 0) && (otchestvo.Length > 0))
            {
                return String.Format("{0} {1}.{2}.", familiya, name.Substring(0, 1), otchestvo.Substring(0, 1));
            }
            else
            {
                return familiya;
            }
        }
        #endregion
    }
}
