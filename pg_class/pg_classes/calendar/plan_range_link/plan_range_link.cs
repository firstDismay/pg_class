using NpgsqlTypes;
using System;

namespace pg_class.pg_classes.calendar
{
    /// <summary>
    /// Класс файла документов 
    /// </summary>
    public partial class plan_range_link
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected plan_range_link()
        {
            imagekey = "plan_range_link_us";
            selectedimagekey = "plan_range_link_s";
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public plan_range_link(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vplan_range_link")
            {
                id = (Int64)row["id"];
                id_conception = (Int64)row["id_conception"];
                id_plan_range = (Int64)row["id_plan_range"];

                range_plan = (NpgsqlRange<DateTime>)row["range_plan"];

                id_entity = (Int32)row["id_entity"];
                id_entity_instance = (Int64)row["id_entity_instance"];
                id_sub_entity_instance = (Int64)row["id_sub_entity_instance"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }

        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id;
        private Int64 id_conception;
        private Int64 id_plan_range;
        private NpgsqlRange<DateTime> range_plan;
        private Int32 id_entity;
        private Int64 id_entity_instance;
        private Int64 id_sub_entity_instance;

        /// <summary>
        /// Идентификатор ссылки на документ документа
        /// </summary>
        public Int64 Id { get => id; }

        /// <summary>
        /// Идентификатор концепции документа
        /// </summary>
        public Int64 Id_conception { get => id_conception; }

        /// <summary>
        /// Идентификатор планового диапазона
        /// </summary>
        public Int64 Id_plan_range { get => id_plan_range; }

        /// <summary>
        /// Значение планового диапазона
        /// </summary>
        public NpgsqlRange<DateTime> Range_plan
        {
            get
            {
                return range_plan;
            }
        }

        /// <summary>
        /// Перечисление ссылающейся сущности определяющей тип ссылочного объекта
        /// </summary>
        public eEntity Link_e_entity
        {
            get
            {
                return (eEntity)id_entity;
            }
        }

        /// <summary>
        /// Идентификатор ссылающейся сущности
        /// </summary>
        public Int32 Link_id_entity { get => id_entity; }

        /// <summary>
        /// Идентификатор экземпляра ссылающейся сущности
        /// </summary>
        public Int64 Link_id_entity_instance { get => id_entity_instance; }

        /// <summary>
        /// Дополнительный идентификатор ссылающейся сущности
        /// </summary>
        public Int64 Link_id_sub_entity_instance { get => id_sub_entity_instance; }

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
        /// Свойство определяет актуальность текущего состояния документа
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.plan_range_link_is_actual(id);
        }


        /// <summary>
        /// Обновление группы из БД
        /// </summary>
        public Boolean Refresh()
        {
            plan_range_link temp;
            Boolean Result = false;
            temp = Manager.plan_range_link_by_id(id);

            if (temp != null)
            {
                id = temp.Id;
                id_conception = temp.Id_conception;
                id_plan_range = temp.Id_plan_range;

                range_plan = temp.Range_plan;

                id_entity = temp.Link_id_entity;
                id_entity_instance = temp.Link_id_entity_instance;
                id_sub_entity_instance = temp.Link_id_sub_entity_instance;
                Result = true;
            }
            else
            {
                Result = false;
            }
            return Result;
        }

        /// <summary>
        /// удаление ссылки документа
        /// doc_link_del
        /// </summary>
        public void Del()
        {
            Manager.plan_range_link_del(id_plan_range, id);
        }

        /// <summary>
        /// Метод возвращает экземпляр сущности в которую входит экземпляр значения
        /// </summary>
        public object Link_entity_instance_get()
        {
            object Result = null;
            switch (Link_e_entity)
            {
                case eEntity.user:
                    Result = Manager.user_by_id(id_entity_instance);
                    break;
                case eEntity.pos_temp:
                    Result = Manager.pos_temp_by_id(id_entity_instance);
                    break;
                case eEntity.position:
                    Result = Manager.position_by_id(id_entity_instance);
                    break;
                case eEntity.position_prop:
                    Result = Manager.position_prop_by_id(id_entity_instance, id_sub_entity_instance);
                    break;
                case eEntity.pos_temp_prop:
                    Result = Manager.pos_temp_prop_by_id(id_entity_instance);
                    break;
                case eEntity.group:
                    Result = Manager.group_by_id(id_entity_instance);
                    break;
                case eEntity.vclass:
                    Result = Manager.class_act_by_id(id_entity_instance);
                    break;
                case eEntity.class_prop:
                    Result = Manager.class_prop_by_id(id_entity_instance);
                    break;
                case eEntity.vobject:
                    Result = Manager.object_by_id(id_entity_instance);
                    break;
                case eEntity.object_prop:
                    Result = Manager.object_prop_by_id(id_entity_instance, id_sub_entity_instance);
                    break;
                case eEntity.document:
                    Result = Manager.document_by_id(id_entity_instance);
                    break;
                case eEntity.log:
                    Result = Manager.log_by_id(id_entity_instance);
                    break;
                default:
                    Result = Manager.entity_by_id(Convert.ToInt32(id_entity));
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Значение свойства типа ссылка установить
        /// </summary>
        public void value_set_instance(Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            id_entity_instance = iid_entity_instance;
            id_sub_entity_instance = iid_sub_entity_instance;
        }

        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод
        /// </summary>
        public override string ToString()
        {
            return range_plan.ToString();
        }
        #endregion
    }
}
