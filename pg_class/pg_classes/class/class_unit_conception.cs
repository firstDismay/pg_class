namespace pg_class.pg_classes
{
    public partial class vclass
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ИЗМЕРЯЕМОЙ ВЕЛИЧИНОЙ КЛАССА

        /// <summary>
        /// Измеряемая величина класса
        /// </summary>
        public unit_conception Unit_conception
        {
            get
            {
                return Manager.unit_conception_by_id(Id_unit, Id_conception);
            }
        }
        #endregion

    }
}
