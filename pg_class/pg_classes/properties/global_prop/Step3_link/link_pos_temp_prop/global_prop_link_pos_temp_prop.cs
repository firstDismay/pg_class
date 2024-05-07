using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс ссылка глобального свойства концепции на свойство класса
    /// </summary>
    public partial class global_prop_link_pos_temp_prop
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected global_prop_link_pos_temp_prop()
        {
            on_change = false;
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public global_prop_link_pos_temp_prop(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vglobal_prop_link_pos_temp_prop")
            {
                id_conception = (Int64)row["id_conception"];
                id_global_prop = (Int64)row["id_global_prop"];
                id_pos_temp = (Int64)row["id_pos_temp"];
                id_pos_temp_prop = (Int64)row["id_pos_temp_prop"];
                id_prop_type = (Int32)row["id_prop_type"];
                id_data_type = (Int32)row["id_data_type"];
                name = (String)row["name"];
                name_len = row.Table.Columns["name"].MaxLength;
                desc = (String)row["desc"];
                desc_len = row.Table.Columns["desc"].MaxLength;
                name_link = (String)row["name_link"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }

        #endregion

        #region СВОЙСТВА КЛАССА
        private Int64 id_conception = 0;
        private Int64 id_global_prop = 0;
        private Int64 id_pos_temp = 0;
        private Int64 id_pos_temp_prop = 0;
        private Int32 id_prop_type;
        private Int32 id_data_type;
        private String name;
        private Int32 name_len;
        private String desc;
        private Int32 desc_len;
        private String name_link;


        /// <summary>
        /// Идентификатор глобального свойства концепции
        /// </summary>
        public Int64 Id_global_prop { get => id_global_prop; }

        /// <summary>
        /// Идентификатор несущего шаблона позиции
        /// </summary>
        public Int64 Id_pos_temp { get => id_pos_temp; }

        /// <summary>
        /// Идентификатор свойства шаблона позиции
        /// </summary>
        public Int64 Id_pos_temp_prop { get => id_pos_temp_prop; }

        /// <summary>
        /// Идентификатор концепции свойства
        /// </summary>
        public Int64 Id_conception { get => id_conception; }



        /// <summary>
        /// Наименование
        /// </summary>
        public string Name
        {
            get
            {
                return name;
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
                DataTable tbl_pos = manager.Instance().TableByName("vclass_prop");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["name"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Наименование ссылки на свойство класса
        /// </summary>
        public string Name_link
        {
            get
            {
                return name_link;
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
        }

        /// <summary>
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public static Int32 Desc_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos = manager.Instance().TableByName("vclass_prop");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["desc"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Идентификатор типа свойства
        /// </summary>
        public Int32 Id_prop_type
        {
            get
            {
                return id_prop_type;
            }
        }

        /// <summary>
        /// Тип свойства
        /// </summary>
        public ePropType Prop_type
        {
            get
            {
                return (ePropType)id_prop_type;
            }
        }

        /// <summary>
        /// Идентификатор типа данных свойства
        /// </summary>
        public Int32 Id_data_type
        {
            get
            {
                return id_data_type;
            }
        }

        /// <summary>
        /// Тип данных свойства
        /// </summary>
        public eDataType Datatype
        {
            get
            {
                return (eDataType)id_data_type;
            }
        }

        /// <summary>
        /// Тип данных свойства в среде Postgre SQL
        /// </summary>
        public NpgsqlTypes.NpgsqlDbType DataTypeNpgsql
        {
            get
            {
                return Manager.DataTypeNpgsql(Datatype);
            }
        }

        ///////**************************
        /// <summary>
        /// Тип данных свойства в среде .Net 
        /// </summary>
        public eDataTypeNet DataTypeNet
        {
            get
            {
                return Manager.DataTypeNet(Datatype); ;
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
        protected manager Manager
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
                sb.Append("global_prop_");
                sb.Append("us");
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
                sb.Append("global_prop_");
                sb.Append("s");
                return sb.ToString();
            }
        }

        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния
        /// </summary>
        public eEntityState Is_actual()
        {
            return manager.Instance().global_prop_link_pos_temp_prop_is_actual(this);
        }

        /// <summary>
        /// Обновление представления класса из БД, для исторических представлений всегда true
        /// </summary>
        public Boolean Refresh()
        {
            global_prop_link_pos_temp_prop temp = null;
            Boolean Result = false;
            temp = Manager.global_prop_link_pos_temp_prop_by_id(id_pos_temp_prop);
            if (temp != null)
            {
                id_conception = temp.Id_conception;
                id_global_prop = temp.Id_global_prop;
                id_pos_temp = temp.Id_pos_temp;
                id_pos_temp_prop = temp.Id_pos_temp_prop;
                id_prop_type = temp.Id_prop_type;
                id_data_type = temp.Id_data_type;
                name = temp.Name;
                desc = temp.Desc;
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
        /// Тип свойства
        /// </summary>
        public prop_type prop_type_get()
        {
            return Manager.prop_type_by_id(id_prop_type);
        }

        /// <summary>
        /// Тип данных свойства
        /// </summary>
        public con_prop_data_type prop_data_type_get()
        {
            return Manager.сon_prop_data_type_by_id(Id_conception, Id_data_type);
        }


        /// <summary>
        /// Концепция свойства класса
        /// </summary>
        public conception Conception_get()
        {
            return Manager.conception_by_id(id_conception);
        }

        /// <summary>
        /// Метод удаляет текущее свойство
        /// class_prop_del
        /// </summary>
        public void Del()
        {
            Manager.global_prop_link_pos_temp_prop_exclude(id_pos_temp_prop);
        }

        #endregion

        #region СВОЙСТВА МЕТОДЫ ДЛЯ РАБОТЫ ТИПАМИ ДАННЫХ СВОЙСТВ
        /// <summary>
        /// Лист всех типов данных свойств класса
        /// </summary>
        public List<prop_data_type> Prop_data_type_all
        {
            get
            {
                return Manager.prop_data_type_by_all();
            }
        }

        /// <summary>
        /// Лист типов данных свойств класса по типу свойства
        /// </summary>
        public List<con_prop_data_type> Prop_data_type
        {
            get
            {
                return Manager.сon_prop_data_type_by_id_prop_type(Id_conception, Id_prop_type);
            }
        }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return name_link;
        }
        #endregion

    }
}
