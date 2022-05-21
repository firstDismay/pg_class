using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    /// <summary>
    /// 
    /// </summary>
    public partial class role_base
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected role_base() 
        {
            on_change = false;
            imagekey = "role_base_us";
            selectedimagekey = "role_base_s";

        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public role_base(System.Data.DataRow row) : this()
        {

            //if (Модуль.Table is ТаблицаМодулей)
            if (row.Table.TableName == "vrole_base")
            {
                oid = Convert.ToInt32(row["oid"]);
                rolinherit = (Boolean) row["rolinherit"];
                namesys = (String) row["namesys"];
                description = (String)row["description"];     
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int32 oid;
        private Boolean rolinherit;
        private String namesys;
        private String description;
    
        /// <summary>
        /// Уникальный идентификатор учетной записи
        /// </summary>
        public Int32 Oid
        {
            get
            {
                return oid;
            }
        }

        /// <summary>
        /// Техническое имя роли
        /// </summary>
        public String NameSystem
        {
            get
            {
                return namesys;
            }
        }

        /// <summary>
        /// Отображаемое имя роли
        /// </summary>
        public String Name
        {
            get
            {
                return namesys.Substring(4).ToString();
            }
        }

        /// <summary>
        /// Описание роли
        /// </summary>
        public String RoleDesc
        {
            get
            {
                return description;
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
                return String.Format("role_base_{0}", namesys);
            }
        }
        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Метод определяет членство пользователя в роли
        /// </summary>
        public Boolean is_member(user vuser, Boolean irecursive)
        {
            return Manager.user_is_member_role(vuser, this, irecursive);
        }

        /// <summary>
        /// Лист пользователей роли 
        /// </summary>
        public List<user> Users_list_get()
        {
             return Manager.user_by_roles(namesys);
        }

        /// <summary>
        /// Лист ролей пользователя включенных в базовую роль
        /// </summary>
        public List<role_user> Role_user_list_get()
        {
            return Manager.user_role_user_by_role_base(this);
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
            
            return Name;
        }
        #endregion
    }
}
