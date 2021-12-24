using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class conception
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ СО СПИСКОМ ИЗМЕРЯЕМЫХ ВЕЛИЧИН КОНЦЕПЦИИ

        /// <summary>
        /// Лист измеряемых величин концепции
        /// unit_conception_by_all
        /// </summary>
        public List<unit_conception> Unit_conception_list_get()
        {
            return Manager.unit_conception_by_all(Id);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Unit_conception_list_get(out eAccess Access)
        {
            return Manager.unit_conception_by_all(out Access);
        }
        //*************************************************************************************
        #endregion
    }
}
