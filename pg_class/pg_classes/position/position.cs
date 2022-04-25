using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс позиций
    /// </summary>
    public partial class position
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected position()
        {
            on_change = false;
            child_status = eStatus.all;
            pos_temp_state = eStatus.on;
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public position(System.Data.DataRow row) : this()
        {
            child_status = eStatus.all;

            //if (Модуль.Table is ТаблицаМодулей)
            if (row.Table.TableName == "vposition")
            {
                id = (Int64)row["id"];
                id_pos_temp = (Int64)row["id_pos_temp"];
                id_parent = (Int64)row["id_parent"];
                id_root = (Int64)row["id_root"];
                name = (String)row["name"];
                name_len = row.Table.Columns["name"].MaxLength;
                desc = (String)row["desc"];
                desc_len = row.Table.Columns["desc"].MaxLength;
                id_con = (Int64)row["id_con"];
                id_prototype = (Int32)row["id_prototype"];
                level = (Int32)row["level"];
                sort = (Int32)row["sort"];
                lockdel = (Boolean)row["lockdel"];
                on_recycle = (Boolean)row["on_recycle"];
                on_service = (Boolean)row["on_service"];
                timestamp = Convert.ToDateTime(row["timestamp"]);
                include_object = (Boolean)row["include_object"];
                timestamp_child_change = Convert.ToDateTime(row["timestamp_child_change"]);
                is_root = (Boolean)row["is_root"];
                on_object = (Boolean)row["on_object"];
                on_rulel2_class_on_position = (Boolean)row["on_rulel2_class_on_position"];
                pos_temp_name = (String)row["pos_temp_name"];
                path = (String)row["path"];
                in_recycle = (Boolean)row["in_recycle"];
                include_position = (Boolean)row["include_position"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id = 0;
        private Int64 id_pos_temp;
        private String pos_temp_name;
        private Int64 id_parent;
        private Int64 id_root;
        private String name;
        private Int32 name_len;
        private String desc;
        private Int32 desc_len;
        private Int64 id_con;
        private Int32 id_prototype;
        private Int32 level;
        private Int32 sort;
        private Boolean lockdel;
        private Boolean on_service;
        private Boolean on_recycle;
        private Boolean on_rulel2_class_on_position;
        private DateTime timestamp;
        private Boolean include_object;
        private Boolean include_position;
        private eStatus child_status;
        private DateTime timestamp_child_change;

        private Boolean is_root;
        private Boolean on_object;

        private Boolean in_recycle;


        /// <summary>
        /// Признак корневой позиции
        /// </summary>
        public Boolean Is_root { get => is_root; }
        
        /// <summary>
        /// Признак доступности вложения объектов на основе разрешения прототипа шаблона позиции (уровень 0)
        /// </summary>
        public Boolean On_object { get => on_object; }

        /// <summary>
        /// Признак наличия разрешающих правил уровня 2 класс на позицию
        /// </summary>
        public Boolean On_rulel2_class_on_position { get => on_rulel2_class_on_position; }

        /// <summary>
        /// Штамп времени изменения колличественного состава потомков
        /// </summary>
        public DateTime Timestamp_child_change { get => timestamp_child_change; }

        /// <summary>
        /// Идентификатор позиций
        /// </summary>
        public Int64 Id { get => id;}

        /// <summary>
        /// Идентификатор шаблона позиции
        /// </summary>
        public Int64 Id_pos_temp { get => id_pos_temp; }


        /// <summary>
        /// Наименование шаблона позиции
        /// </summary>
        public String Pos_temp_name { get => pos_temp_name; }

        /// <summary>
        /// Данные шаблона позиции
        /// </summary>
        public String Pos_temp_data
        {
            get
            {
                return String.Format("{0}[{1}]", pos_temp_name, id_prototype);
            }
        }

        /// <summary>
        /// Штамп времени позиции
        /// </summary>
        public DateTime Timestamp { get => timestamp; }

        /// <summary>
        /// Идентификатор родительской позиций, если 0 то позиция root
        /// </summary>
        public Int64 Id_parent { get => id_parent;}
        /// <summary>
        /// Идентификатор корневой позиции ветви позиций
        /// </summary>
        public Int64 Id_root { get => id_root;}
        

        /// <summary>
        /// Наименование позиции совпадает с именем узла дерева
        /// </summary>
        public String NamePosition
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
        public static Int32 NamePosition_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos  = manager.Instance().TableByName("vposition");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["name"].MaxLength;
                }
                return result;
            }
        }
        /// <summary>
        /// Описание позиций
        /// </summary>
        public string Desc
        {
            get
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
        public static  Int32 Desc_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos  = manager.Instance().TableByName("vposition");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["desc"].MaxLength;
                }
                return result;
            }
        }


        /// <summary>
        /// Идентификатор концепции позиции
        /// </summary>
        public Int64 Id_conception { get => id_con;}

        /// <summary>
        /// Идентификатор прототипа шаблона позиции
        /// </summary>
        public Int32 Id_prototype { get => id_prototype; }

        


        /// <summary>
        /// Уровень вложенности позиции, совпадает уровнем вложенности узла дерева
        /// </summary>
        public Int32 LevelPosition { get => level;}

        /// <summary>
        /// Порядок сортировки текущего уровня вложенности позиций
        /// </summary>
        public Int32 Sort
        {
            get
            { 
               return sort;
            }
            set
            {
                if (sort != value)
                {
                    sort = value;
                    on_change = true;
                  
                }
            }
        }

        /// <summary>
        /// Признак доступности удаления позиции
        /// </summary>
        public Boolean LockDel { get => lockdel;}


        /// <summary>
        /// Признак сервисной позиции позиции
        /// </summary>
        public Boolean On_Service { get => on_service; }

        /// <summary>
        /// Признак наличия вложенных объектов позиции
        /// </summary>
        public Boolean Include_object
        {
            get
            {
                //Refresh();
                return   include_object;
            }
        }

        /// <summary>
        /// Признак наличия вложенных позиций
        /// </summary>
        public Boolean Include_position
        {
            get
            {
                //Refresh();
                return include_position;
            }
        }

        /// <summary>
        /// Признак сервисной позиции типа корзина
        /// </summary>
        public Boolean On_Recycle { get => on_recycle; }


        /// <summary>
        /// Признак удаленной сущности
        /// </summary>
        public Boolean In_recycle { get => in_recycle; }


        /// <summary>
        /// Поле определяет режим фильтрации дочерних шаблонов
        /// </summary>
        public eStatus Child_status
        {
            get
            { 
              return child_status;
            }
            set
            {
                if (child_status != value)
                {
                    child_status = value;
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
        public String ImageKey
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (on_recycle)
                {
                    sb.Append("recycle_us");
                }
                else
                {
                 
                    sb.Append("pos_");
                    if (LockDel)
                    {
                        sb.Append("lock_");
                    }
                    sb.Append("us");
                }
                return sb.ToString();
            }
        }
        
                    

    /// <summary>
    /// Ключ выделенного объекта
    /// </summary>
    public String SelectedImageKey
        {
            get
            {
            StringBuilder sb = new StringBuilder();
            if (on_recycle)
            {
                sb.Append("recycle_s");
            }
            else
            {
                sb.Append("pos_");
                if (LockDel)
                {
                    sb.Append("lock_");
                }

                sb.Append("s");
            }
                return sb.ToString();
            }
        }

        #endregion

        #region МЕТОДЫ КЛАССА

        /// <summary>
        /// Свойство определяет актуальность текущего состояния позиции
        /// </summary>
        public eEntityState Is_actual()
        {
            return manager.Instance().pos_is_actual(this);
        }

        /// <summary>
        /// Обновление позиции в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {           
                Manager.pos_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Перенос позиции в пределах текущей концепции с cоблюдением правил вложенности
        /// </summary>
        public void Move(position ParentPos)
        {
            Manager.pos_move(this, ParentPos);
        }

        /// <summary>
        /// Метод переносит дочернюю позицию в корень дерева концепции
        /// </summary>
        public void MoveRoot()
        {
            Manager.pos_move_root(this);
           
        }

        /// <summary>
        /// Метод переносит дочернюю позицию в новую родительскую позицию
        /// </summary>
        public position Pos_move(position ParentPos, position ChildPos)
        {
            return Manager.pos_move(ParentPos, ChildPos);
        }

            /// <summary>
            /// Изменение статуса блокировки позиции в БД
            /// </summary>
            public void Updatepos_changelock(Boolean onlock)
        {
            if (lockdel!= onlock)
            {
                Manager.pos_changelock(this.id, onlock);
                lockdel = onlock;
            }
        }

        /// <summary>
        /// Обновление позиции из БД
        /// </summary>
        public Boolean Refresh()
        {
            position temp;
            Boolean Result = false;
            temp = Manager.pos_by_id(id);

            if (temp !=null)
            {
                id = temp.Id;
                id_pos_temp = temp.Id_pos_temp;
                id_parent = temp.Id_parent;
                id_root = temp.Id_root;
                name = temp.NamePosition;
                desc = temp.Desc;
                id_con = temp.Id_conception;
                id_prototype = temp.Id_prototype;
                level = temp.LevelPosition;
                sort = temp.Sort;
                lockdel = temp.LockDel;
                on_recycle = temp.On_Recycle;
                on_service = temp.On_Service;
                timestamp = temp.Timestamp;
                include_object = temp.Include_object;
                timestamp_child_change = temp.Timestamp_child_change;
                is_root = temp.Is_root;
                on_object = temp.On_object;
                on_rulel2_class_on_position = temp.On_rulel2_class_on_position;
                pos_temp_name = temp.Pos_temp_name;
                in_recycle = temp.In_recycle;
                path = temp.Path();
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
        /// Копирование позиции в текущем расположении
        /// </summary>
        public position Copy(Boolean on_object)
        {
            //Вносим изменения в БД
            return Manager.position_copy(this, on_object);
        }

        /// <summary>
        /// Копирование позиции в указанное расположение
        /// </summary>
        public position CopyTo(position Pos_parent, Boolean on_object)
        {
            //Вносим изменения в БД
            if (Pos_parent != null)
            {
                return Manager.position_copy(this, Pos_parent, on_object);
            }
            else
            {
                return Manager.position_copy(this.Id, 0, on_object);
            }

        }

        /// <summary>
        /// Метод удаляет текущую позицию
        /// pos_del
        /// </summary>
        public void Del()
        {
            Manager.pos_del(this);
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
