﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data;
using pg_class.pg_exceptions;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class vclass : ICloneable
    {

        /// <summary>
        /// Клонированная сущность БД
        /// </summary>
        public object Clone()
        {
            object result = null;

            switch (StorageType)
            {
                case eStorageType.Active:
                    result = Manager.class_act_by_id(id);
                    break;
                case eStorageType.History:
                    result = Manager.class_snapshot_by_id(id,timestamp);
                    break;
            }
            return result;
        }

        /// <summary>
        /// Клонированная сущность БД
        /// </summary>
        public vclass CloneExt()
        {
            vclass result = null;

            switch (StorageType)
            {
                case eStorageType.Active:
                    result = Manager.class_act_by_id(id);
                    break;
                case eStorageType.History:
                    result = Manager.class_snapshot_by_id(id, timestamp);
                    break;
            }
            return result;
        }
    }
}
