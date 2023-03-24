using System;
using System.Data;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс позиций
    /// </summary>
    public partial class group
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected group()
        {
            on_change = false;
            imagekey = "group_us";
            selectedimagekey = "group_s";
            child_status = eStatus.all;
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public group(System.Data.DataRow row) : this()
        {
            child_status = eStatus.all;

            if (row.Table.TableName == "vgroup")
            {
                id = (Int64)row["id"];
                id_parent = (Int64)row["id_parent"];
                id_root = (Int64)row["id_root"];
                name = (String)row["name"];
                name_len = row.Table.Columns["name"].MaxLength;
                desc = (String)row["desc"];
                desc_len = row.Table.Columns["desc"].MaxLength;
                id_con = (Int64)row["id_con"];
                level = (Int32)row["level"];
                sort = (Int32)row["sort"];
                on_recycle = (Boolean)row["on_recycle"];
                timestamp = Convert.ToDateTime(row["timestamp"]);
                on_class = (Boolean)row["on_class"];
                include_act_class = (Boolean)row["include_act_class"];
                timestamp_child_change = Convert.ToDateTime(row["timestamp_child_change"]);
                in_recycle = (Boolean)row["in_recycle"];
                include_child_group = (Boolean)row["include_child_group"];
                path = (String)row["path"];
                if (on_recycle)
                {
                    imagekey = "recycle_us";
                    selectedimagekey = "recycle_s";
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id = 0;
        private Int64 id_parent;
        private Int64 id_root;
        private String name;
        private Int32 name_len;
        private String desc;
        private Int32 desc_len;
        private Int64 id_con;
        private Int32 level;
        private Int32 sort;
        private Boolean on_recycle;
        private DateTime timestamp;
        private Boolean on_class;
        private Boolean include_act_class;
        private DateTime timestamp_child_change;
        private Boolean in_recycle;
        private Boolean include_child_group;

        /// <summary>
        /// Штамп времени изменения колличественного состава потомков
        /// </summary>
        public DateTime Timestamp_child_change { get => timestamp_child_change; }

        private eStatus child_status;
        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public Int64 Id { get => id; }

        /// <summary>
        /// Штамп времени группы
        /// </summary>
        public DateTime Timestamp { get => timestamp; }


        /// <summary>
        /// Идентификатор родительской группы, если 0 то группа root (корень ветви)
        /// </summary>
        public long Id_parent { get => id_parent; }

        /// <summary>
        /// Идентификатор корневой группы ветви групп
        /// </summary>
        public long Id_root { get => id_root; }


        /// <summary>
        /// Наименование группы
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
        public static Int32 Name_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos = manager.Instance().TableByName("vgroup");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["name"].MaxLength;
                }
                return result;
            }
        }
        /// <summary>
        /// Описание группы
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
        public static Int32 Desc_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos = manager.Instance().TableByName("vgroup");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["desc"].MaxLength;
                }
                return result;
            }
        }


        /// <summary>
        /// Идентификатор концепции группы
        /// </summary>
        public long Id_conception { get => id_con; }



        /// <summary>
        /// Уровень вложенности группы (с нуля)
        /// </summary>
        public int LevelGroup { get => level; }

        /// <summary>
        /// Порядок сортировки текущего уровня вложенности групп
        /// </summary>
        public int Sort
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
        /// Признак корзины групп
        /// </summary>
        public bool On_Recycle { get => on_recycle; }

        /// <summary>
        /// Признак удаленной сущности
        /// </summary>
        public Boolean In_recycle { get => in_recycle; }


        /// <summary>
        /// Поле определяет режим фильтрации дочерних групп
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
        /// Свойство определяет доступность вложения клссасов в группу
        /// </summary>
        public Boolean On_class
        {
            get
            {
                return on_class;
            }
            set
            {
                if (on_class != value)
                {
                    on_class = value;
                    on_change = true;

                }
            }
        }

        /// <summary>
        /// Свойство определяет наличие вложенных активных представлений классов в группе
        /// </summary>
        public Boolean Include_act_class
        {
            get
            {
                return include_act_class;
            }
        }

        /// <summary>
        /// Свойство определяет наличие вложенных групп
        /// </summary>
        public Boolean Include_child_group
        {
            get
            {
                return include_child_group;
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

        #endregion

        #region МЕТОДЫ КЛАССА

        /// <summary>
        /// Свойство определяет актуальность текущего состояния группы
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.group_is_actual(this);
        }


        /// <summary>
        /// Обновление группы в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                Manager.group_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Перенос группы в пределах текущей концепции с cоблюдением правил вложенности
        /// null переносит группу в корневое расположение
        /// </summary>
        public void Move(group ParentGroup)
        {
            Manager.group_move(this, ParentGroup);
        }


        /// <summary>
        /// Метод переносит группу в указанную родительскую группу
        /// </summary>
        public group Group_move(group ParentGroup, group ChildGroup)
        {
            return Manager.group_move(ParentGroup, ChildGroup);
        }

        /// <summary>
        /// Обновление группы из БД
        /// </summary>
        public Boolean Refresh()
        {
            group temp;
            Boolean Result = false;
            temp = Manager.group_by_id(id);

            if (temp != null)
            {
                id = temp.Id;
                id_parent = temp.Id_parent;
                id_root = temp.Id_root;
                name = temp.Name;
                desc = temp.Desc;
                id_con = temp.Id_conception;
                level = temp.LevelGroup;
                sort = temp.Sort;
                on_recycle = temp.On_Recycle;
                timestamp = temp.Timestamp;
                on_class = temp.On_class;
                include_act_class = temp.Include_act_class;
                timestamp_child_change = temp.Timestamp_child_change;
                in_recycle = temp.In_recycle;
                include_child_group = temp.Include_child_group;
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
        /// Группа назначена в одно или более разрешения уровня 1 группа на шаблон
        /// </summary>
        public Boolean Assigned_to_rule_l1()
        {
            throw (new Exception("Метод не определен!"));
        }

        /// <summary>
        /// удаление текущей группы
        /// group_del
        /// </summary>
        public void Del()
        {
            Manager.group_del(this);
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
