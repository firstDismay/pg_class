namespace pg_class.pg_classes
{
    public partial class pos_temp
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С КОНЦЕПЦИЕЙ ШАБЛОНА ПОЗИЦИИ

        /// <summary>
        /// Лист позиций шаблона позиции
        /// </summary>
        public conception Conception
        {
            get
            {
                return Manager.conception_by_id(this.Id_conception);
            }
        }
        #endregion

    }
}
