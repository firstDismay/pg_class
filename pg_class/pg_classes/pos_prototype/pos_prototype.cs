using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс прототипов позиций
    /// </summary>
    public partial class pos_prototype
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected pos_prototype()
        {
            imagekey = "proto_us";
            selectedimagekey = "proto_s";
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public pos_prototype(System.Data.DataRow row) : this()
        {

            //if (Модуль.Table is ТаблицаМодулей)
            if (row.Table.TableName == "vpos_prototype")
            {
                id = (Int32)row["id"];
                sort = (Int32)row["sort"];
                on_root = (Boolean)row["on_root"];
                on_this = (Boolean)row["on_this"];
                on_pos = (Boolean)row["on_pos"];
                on_obj = (Boolean)row["on_obj"];
                desc = (String)row["desc"];
                on_service = (Boolean)row["on_service"];
                if (on_service)
                {
                    imagekey = "proto_service_us";
                    selectedimagekey = "proto_service_s";
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private Int32 id;
        private Int32 sort;
        private Boolean on_pos;
        private Boolean on_obj;
        private String desc;
        private Boolean on_this;
        private Boolean on_root;
        private Boolean on_service;

        /// <summary>
        /// Идентификатор прототипа
        /// </summary>
        public int Id { get => id; }

        /// <summary>
        /// Номер сортировки определяющий позицию в цепи вложенности
        /// </summary>
        public int Sort { get => sort; }

        /// <summary>
        /// Признак доступности вложения позиций
        /// </summary>
        public bool On_pos { get => on_pos; }
        /// <summary>
        /// Признак доступности вложения объектов
        /// </summary>
        public bool On_obj { get => on_obj; }

        /// <summary>
        /// Полное описание прототипа позиции
        /// </summary>
        public string Desc { get => desc; }

        /// <summary>
        /// Полное описание прототипа позиции
        /// </summary>
        public string Desc2 { get => "- " + desc.Replace("; ", Environment.NewLine + "- "); }

        /// <summary>
        /// Составное наименование прототипа
        /// </summary>
        public string Name()
        {
            return String.Format("RNK:{0} ON ROOT:{1} ON THIS:{2} ON POS:{3} ON OBJ:{4}",
                Sort,
                Convert.ToInt32(on_root),
                Convert.ToInt32(on_this),
                Convert.ToInt32(on_pos),
                Convert.ToInt32(on_obj));
        }

        /// <summary>
        /// Составное наименование прототипа
        /// </summary>
        public string ShortName()
        {
            return String.Format("RANK:{0} ROOT:{1} THIS:{2} POS:{3} OBJ:{4}",
                Sort,
                Convert.ToInt32(on_root),
                Convert.ToInt32(on_this),
                Convert.ToInt32(on_pos),
                Convert.ToInt32(on_obj));
        }

        /// <summary>
        /// Признак доступности вложения позиции в саму себя
        /// </summary>
        public bool On_this { get => on_this; }

        /// <summary>
        /// Признак доступности создания корневых позиций
        /// </summary>
        public bool On_root { get => on_root; }

        /// <summary>
        /// Признак сервисного прототипа шаблонов позиций
        /// </summary>
        public bool On_Service { get => on_service; }


        /// <summary>
        /// Свойство возвращает лист прототипов дотупных к вложению в текущий прототип
        /// </summary>
        public List<pos_prototype> Pos_prototype_nested_list
        {
            get
            {
                return Manager.pos_prototype_nested_by_id_prototype(id);
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
        /// Метод обновляет листы узлов
        /// </summary>
        public List<pos_prototype> pos_prototype_nested_list_get()
        {
            return Manager.pos_prototype_nested_by_id_prototype(id);
        }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return ShortName();
        }
        #endregion

    }
}
