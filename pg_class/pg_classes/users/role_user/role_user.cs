using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{ /// <summary>
  /// Класс пользователей БД учеет
  /// </summary>
    public partial class role_user
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected role_user()
        {
            on_change = false;
            imagekey = "role_user_us";
            selectedimagekey = "role_user_s";
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public role_user(System.Data.DataRow row) : this()
        {

            //if (Модуль.Table is ТаблицаМодулей)
            if (row.Table.TableName == "vrole_user")
            {
                id = Convert.ToInt32(row["id"]);
                oid = Convert.ToInt32(row["oid"]);
                name = (String)row["name"];
                description = (String)row["description"];
                namesys = (String)row["namesys"];
                newnamesys = (String)row["namesys"];
                rolsuper = (Boolean)row["rolsuper"];
                rolinherit = (Boolean)row["rolinherit"];
                rolcreaterole = (Boolean)row["rolcreaterole"];
                rolcreatedb = (Boolean)row["rolcreatedb"];
                rolcanlogin = (Boolean)row["rolcanlogin"];
                rolbypassrls = (Boolean)row["rolbypassrls"];
                timestamp = (DateTime)row["timestamp"];
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
        private String description;
        private String namesys;
        private String newnamesys;
        private Boolean rolsuper;
        private Boolean rolinherit;
        private Boolean rolcreaterole;
        private Boolean rolcreatedb;
        private Boolean rolcanlogin;
        private Boolean rolbypassrls;
        private DateTime timestamp;



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
        public String Name
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
        public String Desc
        {
            get
            {
                return description;
            }
            set
            {
                if (description != value)
                {
                    description = value;
                    on_change = true;
                }
            }
        }



        /// <summary>
        /// Системное имя роли
        /// </summary>
        public String NameSystem
        {
            get
            {
                return namesys;
            }
            set
            {
                newnamesys = value;
                on_change = true;
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
                return String.Format("role_user_{0}", namesys);
            }
        }
        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния пользователя
        /// </summary>
        public eEntityState Is_actual()
        {
            return eEntityState.NotFound;
            //return manager.Instance().user_is_actual(this);
        }

        /// <summary>
        /// Обновление пользователя в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                if (namesys == newnamesys)
                {
                    Manager.user_role_user_upd(this);
                }
                else
                {
                    Manager.user_role_user_upd(this, newnamesys);
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
            role_user temp;
            Boolean Result = false;
            temp = Manager.user_role_user_by_namesys(namesys);
            if (temp != null)
            {
                oid = temp.Oid;
                name = temp.Name;
                description = temp.Desc;
                namesys = temp.NameSystem;
                newnamesys = temp.NameSystem;
                rolsuper = temp.RolSuper;
                rolinherit = temp.RolInherit;
                rolcreaterole = temp.RolCreaterole;
                rolcreatedb = temp.RolCreatedb;
                rolcanlogin = temp.RolCanLogin;
                timestamp = temp.timestamp;
                Result = true;
            }
            else
            {
                Result = false;
            }
            return Result;
        }

        /// <summary>
        /// Метод определяет членство пользователя в указанной роли
        /// </summary>
        public Boolean is_member_role(role_base vrole, Boolean irecursive)
        {
            return Manager.user_is_member_role(NameSystem, vrole.NameSystem, irecursive);
        }


        /// <summary>
        /// Метод удаляет текущую позицию
        /// user_del
        /// </summary>
        public void Del()
        {
            Manager.user_role_user_del(this);
        }


        /// <summary>
        /// Лист ролей пользователя
        /// </summary>
        public List<role_base> Roles_base_list_get(Boolean recursive)
        {
            return Manager.user_role_base_by_login(namesys, recursive);
        }

        /// <summary>
        /// Лист пользователей роли 
        /// </summary>
        public List<user> Users_list_get()
        {
            return Manager.user_by_roles(namesys);
        }

        /// <summary>
        /// Лист доступных базовых функций
        /// </summary>
        public List<function> Functions_base_list_get()
        {
            return Manager.user_base_function_by_login(namesys);
        }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return String.Format("{0}", name.Substring(0, 1));
        }
        #endregion
    }
}
