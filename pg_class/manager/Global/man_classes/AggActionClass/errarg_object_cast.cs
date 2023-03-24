using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Квантовый класс для возврата результатов групповых операций приведения объектов
    /// </summary>
    public class errarg_cast
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected errarg_cast()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public errarg_cast(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "errarg_cast")
            {
                err_id = (Int32)row["err_id"];
                errdesc = (String)row["errdesc"];
                entity_id = (Int32)row["entity_id"];
                entity_instance_id = (Int64)row["entity_instance_id"];
                entity_instance_name = (String)row["entity_instance_name"];
                action_id = (Int32)row["action_id"];
                action_desc = (String)row["action_desc"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int32 err_id;
        private String errdesc;
        private Int32 entity_id;
        private Int64 entity_instance_id;
        private String entity_instance_name;
        private Int32 action_id;
        private String action_desc;

        /// <summary>
        /// Идентификатор ошибки
        /// </summary>
        public Int32 Err_id { get => err_id; }

        /// <summary>
        /// Описание ошибки
        /// </summary>
        public String Errdesc { get => errdesc; }

        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public Int32 Entity_id { get => entity_id; }

        /// <summary>
        /// Cущность
        /// </summary>
        public eEntity Entity { get => (eEntity)entity_id; }

        /// <summary>
        /// Идентификатор экземпляра сущности
        /// </summary>
        public Int64 Entity_instance_id { get => entity_instance_id; }

        /// <summary>
        /// Наименование экземпляра сущности
        /// </summary>
        public String Entity_instance_name { get => entity_instance_name; }


        /// <summary>
        /// Идентификатор действия
        /// </summary>
        public Int32 Action_id { get => action_id; }

        /// <summary>
        /// Действие
        /// </summary>
        public eAction Action { get => (eAction)action_id; }

        /// <summary>
        /// Описание дейсвтвия
        /// </summary>
        public String Action_desc { get => action_desc; }

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
        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Сущность БД
        /// </summary>
        public entity Entity_get()
        {
            return Manager.entity_by_id(entity_id);
        }

        /// <summary>
        /// Метод возвращает экземпляр сущности в которую входит экземпляр значения
        /// </summary>
        public object Entity_instance_get()
        {
            object Result = null;
            switch (Entity)
            {
                case eEntity.user:
                    Result = Manager.user_by_id(Entity_instance_id);
                    break;
                case eEntity.pos_temp:
                    Result = Manager.pos_temp_by_id(Entity_instance_id);
                    break;
                case eEntity.position:
                    Result = Manager.position_by_id(Entity_instance_id);
                    break;
                case eEntity.pos_temp_prop:
                    Result = Manager.pos_temp_prop_by_id(Entity_instance_id);
                    break;
                case eEntity.group:
                    Result = Manager.group_by_id(Entity_instance_id);
                    break;
                case eEntity.vclass:
                    Result = Manager.class_act_by_id(Entity_instance_id);
                    break;
                case eEntity.class_prop:
                    Result = Manager.class_prop_by_id(Entity_instance_id);
                    break;
                case eEntity.vobject:
                    Result = Manager.object_by_id(Entity_instance_id);
                    break;
                default:
                    Result = Manager.entity_by_id(Convert.ToInt32(Entity_instance_id));
                    break;
            }
            return Result;
        }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return String.Format("Действие: {0} Сущность: {1} Экземпляр: {2} Код завершения: {3} Описание: {4}",
                Action_desc,
                Entity_id,
                Entity_instance_id,
                Err_id,
                Errdesc);
        }
        #endregion
    }
}
