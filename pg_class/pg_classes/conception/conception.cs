using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс концепций классификатора позиций
    /// </summary>
    public partial class conception 
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected conception()
        {
            on_change = false;
            //Инициализация шаблонов позиций
            Init_pos_temp();
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public conception(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "vconception")
            {
                id = (Int64)row["id"];
                name = (String)row["name"];
                name_len = row.Table.Columns["name"].MaxLength;
                desc = (String)row["desc"];
                desc_len = row.Table.Columns["desc"].MaxLength;

                on = (Boolean)row["on"];
                on_root_create = (Boolean)row["on_root_create"];
                default_conception = (Boolean)row["default"];
                
                id_pos_recycle = (Int64)row["pos_recycle"];
                id_group_recycle = (Int64)row["group_recycle"];
                id_pos_temp_recycle = (Int64)row["pos_temp_recycle"];
                actcatalog = (Int32)row["actcatalog"];

                timestamp = Convert.ToDateTime(row["timestamp"]);
            }
            else
            {
                //throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id;
        private Int64 id_pos_recycle;
        private Int64 id_group_recycle;
        private Int64 id_pos_temp_recycle;
        private Int32 actcatalog;
        private String name;
        private Int32 name_len;
        private Boolean on;
        private Boolean on_root_create;
        private Boolean default_conception;
        private String desc;
        private Int32 desc_len;
        private DateTime timestamp;

        /// <summary>
        /// Идентификатор концепции
        /// </summary>
        public Int64 Id { get => id; }


        /// <summary>
        /// Идентификатор позиции корзины концепции
        /// </summary>
        public Int64 Id_Pos_Recycle { get => id_pos_recycle; }


        /// <summary>
        /// Идентификатор группы корзины концепции
        /// </summary>
        public Int64 Id_Group_Recycle { get => id_group_recycle; }

        /// <summary>
        /// Идентификатор шаблона позиции корзины концепции
        /// </summary>
        public Int64 Id_Pos_temp_Recycle { get => id_pos_temp_recycle; }

        /// <summary>
        /// Активный каталог библиотеки документов концепции
        /// </summary>
        public Int32 Act_Catalog { get => actcatalog; }


        /// <summary>
        /// Штамп времени концепции
        /// </summary>
        public DateTime Timestamp { get => timestamp; }


        /// <summary>
        /// Состояние концепции 
        /// </summary>
        public Boolean On {
            get
            {
                return on;
            }
            set
            {
                if (on != value)
                {
                    on = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Определяет доступность создания корневых позиций концепции, при создании true по умолчанию
        /// </summary>
        public bool On_root_create
        {
            get
            {
                return on_root_create;
            }
            set
            {
                if (on_root_create != value)
                {
                    on_root_create = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Наименование шаблона позиции совпадает с именем узла дерева
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    if (value.Length > name_len)
                    {
                        value = value.Substring(0, name_len);
                    }
                    name = value;
                    on_change = true;
                }
            }

        }

        /// <summary>
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public static Int32 NameConception_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_con  = manager.Instance().TableByName("vconception");
                if (tbl_con != null)
                {
                    result = tbl_con.Columns["name"].MaxLength;
                }
                return result;
            }
        }
        /// <summary>
        /// Описание концепции
        /// </summary>
        public string Desc
        { get
            {
                return desc;
            }
            set
            {
                if (desc != value)
                {
                    if (value.Length > desc_len)
                    {
                        value = value.Substring(0, desc_len);
                    }
                    desc = value;
                    on_change = true;
                }
                
            }
        }

        /// <summary>
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public static Int32 Desc_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_con  = manager.Instance().TableByName("vconception");
                if (tbl_con != null)
                {
                    result = tbl_con.Columns["desc"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Концепция назначенная по умолчанию
        /// </summary>
        public bool Default_Conception
        {
            get
            {
                return default_conception;
            }
            set
            {
                if (default_conception != value)
                {
                    default_conception = value;
                    on_change = true;
                 
                }
            }
        }

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

        
        /// <summary>
        /// Ключ объекта
        /// </summary>
        public string ImageKey
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("con");
                if (on)
                {
                    sb.Append("_on_us");
                }
                else
                {
                    sb.Append("_off_us");
                }

                return sb.ToString();
            }
        }


        /// <summary>
        /// Ключ выделенного объекта
        /// </summary>
        public string SelectedImageKey
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("con");
                if (on)
                {
                    sb.Append("_on_s");
                }
                else
                {
                    sb.Append("_off_s");
                }
                return sb.ToString();
            }

        }

        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Метод определяет актуальность текущего состояния концепции
        /// con_is_actual
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.con_is_actual(this);
        }

        /// <summary>
        /// Обновление концепции в БД
        /// conception_upd
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                Manager.conception_upd(this);
                Refresh();
                on_change = false;
            }
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Update(out eAccess Access)
        {
            return Manager.conception_upd(out Access);
        }
        //*************************************************************************************

        /// <summary>
        /// удаление текущей концепции
        /// conception_del
        /// </summary>
        public void Del()
        {
            Manager.conception_del(this);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Del(out eAccess Access)
        {
            return Manager.conception_del(out Access);
        }
        //*************************************************************************************

        /// <summary>
        /// Обновление концепции из БД
        /// conception_by_id
        /// </summary>
        public Boolean Refresh()
        {
            conception temp;
            Boolean Result = false;
            temp =  Manager.conception_by_id(id);

            if (temp != null)
            {
                id = temp.Id;
                name = temp.Name;
                on = temp.On;
                desc = temp.Desc;
                default_conception = temp.Default_Conception;
                on_root_create = temp.On_root_create;
                timestamp = temp.timestamp;
                id_pos_recycle = temp.Id_Pos_Recycle;
                id_group_recycle = temp.Id_Group_Recycle;
                id_pos_temp_recycle = temp.Id_Pos_temp_Recycle;
                Result = true;
                on_change = false;
            }
            else
            {
                Result = false;
            }
            return Result;
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Refresh(out eAccess Access)
        {
            return Manager.conception_by_id(out Access);
        }
        //*************************************************************************************

        /// <summary>
        /// Позиция корзины концепции
        /// position_by_id
        /// </summary>
        public position Pos_recycle_get()
        {
            return Manager.position_by_id(id_pos_recycle);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Pos_recycle_get(out eAccess Access)
        {
            return Manager.position_by_id(out Access);
        }
        //*************************************************************************************

        /// <summary>
        /// Группа корзины концепции
        /// </summary>
        public group Group_recycle_get()
        {
            return Manager.group_by_id(id_group_recycle);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Group_recycle_get(out eAccess Access)
        {
            return Manager.group_by_id(out Access);
        }
        //*************************************************************************************

        /// <summary>
        /// Шаблон позиция корзины концепции
        /// pos_temp_by_id
        /// </summary>
        public pos_temp Pos_temp_recycle_get()
        {
            return Manager.pos_temp_by_id(id_pos_temp_recycle);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Pos_temp_recycle_get(out eAccess Access)
        {
            return Manager.pos_temp_by_id(out Access);
        }
        //*************************************************************************************

        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Is_actual(out eAccess Access)
        {
            return Manager.con_is_actual(out Access);
        }
        //*************************************************************************************

        /// <summary>
        /// Восстановление концепции
        /// conception_upd
        /// </summary>
        public void Restore()
        {
            Manager.conception_restore(this);
            Refresh();
        }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return name;
        }
        #endregion
    }
}
