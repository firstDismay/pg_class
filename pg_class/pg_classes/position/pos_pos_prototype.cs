namespace pg_class.pg_classes
{
    public partial class position
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПРОТОТИПАМИ ШАБЛОНОВ ПОЗИЦИЙ

        /// <summary>
        /// Метод возвращает прототип текущей позиции
        /// </summary>
        public pos_prototype Pos_prototype
        {
            get
            {
                return Manager.pos_prototype_by_id_pos_temp(this.id_pos_temp);
            }
        }
        #endregion

    }
}
