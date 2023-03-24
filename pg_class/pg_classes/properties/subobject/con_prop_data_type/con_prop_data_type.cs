using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс типа данных свойства концепции
    /// </summary>
    public partial class con_prop_data_type : prop_data_type
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected con_prop_data_type()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public con_prop_data_type(System.Data.DataRow row) : base(row)
        {

            if (row.Table.TableName == "vcon_prop_data_type")
            {
                id_conception = (Int64)row["id_conception"];
                alias = (String)row["alias"];
                sort = (Int32)row["sort"];
                is_create = (Boolean)row["is_create"];
                is_use = (Boolean)row["is_use"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }

        #endregion

        #region СВОЙСТВА КЛАССА
        private Int64 id_conception;
        private String alias;
        private Int32 sort;
        private Boolean is_create;
        private Boolean is_use;

        /// <summary>
        /// Идентификатор концепции типа данных свойства
        /// </summary>
        public Int64 Id_conception
        {
            get
            {
                return id_conception;
            }
        }

        /// <summary>
        /// Назначение типа данных создано
        /// </summary>
        public Boolean Is_create
        {
            get
            {
                return is_create;
            }
        }

        /// <summary>
        /// Назначение типа данных используется
        /// </summary>
        public Boolean Is_use
        {
            get
            {
                return is_use;
            }
        }

        /// <summary>
        /// Наименование типа данных свойства в рамках концепции
        /// </summary>
        public String Alias
        {
            get
            {
                return alias;
            }
            set
            {
                alias = value;
                on_change = true;
            }
        }

        /// <summary>
        /// Поле сортировки в пределах концепции
        /// </summary>
        public Int32 Sort
        {
            get
            {
                return sort;
            }
            set
            {
                sort = value;
                on_change = true;
            }
        }




        /// <summary>
        /// Лист расширений двоичных данных доступных типу данных свойства
        /// </summary>
        public override List<prop_data_bin_ext> Data_bin_ext_list
        {
            get
            {
                return base.Data_bin_ext_list;
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

        #endregion

        #region МЕТОДЫ КЛАССА

        /// <summary>
        /// Обновление параметров назначения типа данных
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                Manager.con_prop_data_type_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Обновление параметров назначения типа данных из БД
        /// </summary>
        public Boolean Refresh()
        {
            con_prop_data_type temp;
            Boolean Result = false;
            temp = Manager.Con_prop_data_type_by_id(id_conception, Id);

            if (temp != null)
            {
                id_conception = temp.Id_conception;
                alias = temp.Alias;
                sort = temp.Sort;
                is_create = temp.Is_create;
                is_use = temp.Is_use;
                Result = true;
            }
            else
            {
                Result = false;
            }
            return Result;
        }


        ///**************************************

        /// <summary>
        /// Лист объектов по идентификатору типа данных концепции
        /// object_by_id_prop_data_type
        /// </summary>
        public List<object_general> Object_get(Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_id_prop_data_type(this);
            }
            else
            {
                Result = Manager.object_by_id_prop_data_type(this);
            }
            return Result;
        }

        /// <summary>
        /// Лист представлений активных классов по идентификатору типа данных концепции
        /// class_act_by_id_prop_data_type
        /// </summary>
        public List<vclass> Class_act_get()
        {
            return Manager.class_act_by_id_prop_data_type(this);
        }

        /// <summary>
        /// Лист представлений снимков классов по идентификатору типа данных концепцииправила пересчета
        /// class_snapshot_by_id_prop_data_type
        /// </summary>
        public List<vclass> Class_snapshot_get()
        {
            return Manager.class_snapshot_by_id_prop_data_type(this);
        }

        /// <summary>
        /// Лист шаблонов по идентификатору типа данных концепции
        /// pos_temp_by_id_prop_data_type
        /// </summary>
        public List<pos_temp> Pos_temp_get()
        {
            return Manager.pos_temp_by_id_prop_data_type(this);
        }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            String Result;
            alias = alias.Trim();
            if (alias.Length > 3)
            {
                Result = alias;
            }
            else
            {
                Result = UserDesc;
            }
            return Result;
        }
        #endregion
    }
}

