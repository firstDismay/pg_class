using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class pos_temp
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПРОТОТИПАМИ ПОЗИЦИЙ
 
        /// <summary>
        /// Лист прототипов
        /// </summary>
        public List<pos_prototype> Pos_prototype_nested_list
        {
            get
            {
                return Manager.pos_prototype_nested_by_id_prototype(this.id_prototype);
            }
        }

        private pos_prototype pos_prototype;
        /// <summary>
        /// Прототип текущего шаблона позиции
        /// </summary>
        public pos_prototype Pos_prototype
        {
            get
            {
                if (pos_prototype == null)
                {
                    pos_prototype = Manager.pos_prototype_by_id(this.id_prototype);
                }
                return pos_prototype;
            }
        }
        #endregion

        #region МЕТОДЫ РАБОТЫ С ЛИСТАМИ ПРОТОТИПОВ ПОЗИЦИЙ
        /// <summary>
        /// Метод обновляет лист доступных прототипов позиций 
        /// </summary>
        public List<pos_prototype> Pos_prototype_nested_list_get()
        {
            return Manager.pos_prototype_nested_by_id_prototype(this.id_prototype);
        }

        #endregion
    }
}
