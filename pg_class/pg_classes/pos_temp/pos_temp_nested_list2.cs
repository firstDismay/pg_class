using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class pos_temp
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПРАВИЛАМИ ВЛОЖЕННОСТИ ОБЪЕКТОВ ГРУППА - ПОЗИЦИЯ

        /// <summary>
        /// Созданные Правила вложенности шаблонов позиций
        /// </summary>
        public List<pos_temp_nested_rule> Pos_temp_nested_whitelist
        {
            get
            {
                return Manager.pos_temp_nested_whitelist(this);
            }
        }


        /// <summary>
        /// Полный список Правил вложенности шаблонов позиций
        /// </summary>
        public List<pos_temp_nested_rule> Pos_temp_nested_whitelist_full
        {
            get
            {
                return Manager.pos_temp_nested_whitelist_full(this);
            }
        }
        #endregion

        #region МЕТОДЫ РАБОТЫ С ГРУППАМИ
        #region ДОБАВИТЬ

        /// <summary>
        /// Добавление шаблона позиций в список ограничения вложенности для текущего шблона позиций
        /// </summary>
        public void Pos_Temp_Nested_Limit_Include(pos_temp pos_temp, Int32 ipos_temp_nested_limit = 0)
        {
            Manager.pos_temp_nested_include(this.id, pos_temp.id, ipos_temp_nested_limit);
            nested_limit = true;
        }

        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Удаление шаблона позиций из списка ограничения вложенности для текущего шблона позиций
        /// </summary>
        public void Pos_Temp_Nested_Limit_Exclude(pos_temp pos_temp)
        {
            Manager.pos_temp_nested_exclude(this.id, pos_temp.id);
        }

        /// <summary>
        /// Очистка списка ограничения вложенности для текущего шблона позиций
        /// </summary>
        public void Pos_Temp_Nested_Limit_Exclude_All(pos_temp pos_temp)
        {
            Manager.pos_temp_nested_exclude_all(this.id);
            nested_limit = false;
        }
        #endregion
        #endregion
    }
}
