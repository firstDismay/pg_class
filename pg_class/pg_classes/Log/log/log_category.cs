﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class log
    {
        #region МЕТОДЫ РАБОТЫ С ДОКУМЕНТАМИ

        #region ВЫБРАТЬ

        log_category log_category;
        /// <summary>
        /// Категория документа
        /// </summary>
        public log_category log_category_get(Boolean DirectRequest = true)
        {
            /*if (DirectRequest || log_category == null)
            {
                log_category = Manager.log_category_by_id(Id_category);
            }
            return log_category;*/
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}