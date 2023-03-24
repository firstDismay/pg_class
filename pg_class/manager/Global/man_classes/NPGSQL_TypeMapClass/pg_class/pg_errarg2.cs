using System;

namespace pg_class
{
    /// <summary>
    /// Композитный тип данных аргумента ошибки функции версия 2
    /// </summary>
    public class pg_errarg2
    {
        /// <summary>
        /// Идентифкатор ошибки
        /// </summary>
        public Int32 err_id { get; set; }
        /// <summary>
        /// Подробное описание ошибки
        /// </summary>
        public String errdesc { get; set; }
        /// <summary>
        /// Идентифкатор сущности
        /// </summary>
        public Int32 entity_id { get; set; }
        /// <summary>
        /// Идентифкатор действия
        /// </summary>
        public Int32 action_id { get; set; }
        /// <summary>
        /// Идентифкатор подкласса ошибки
        /// </summary>
        public Int32 errsubclass_id { get; set; }
        /// <summary>
        /// Описание подкласса ошибки
        /// </summary>
        public String errsubclass_desc { get; set; }
    }
}
