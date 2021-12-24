using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial  class position
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ШАБЛОНАМИ ПОЗИЦИЙ

        private eStatus pos_temp_state;
        /// <summary>
        /// Статус отображаемых шаблонов позиций
        /// </summary>
        public eStatus Pos_temp_state { get => pos_temp_state; set => pos_temp_state = value; }

           

        /// <summary>
        /// Метод возвращает шаблон текущей позиции
        /// </summary>
        public pos_temp Pos_temp
        {
            get
            {
                return Manager.pos_temp_by_id(this.id_pos_temp);
            }
        }
        #endregion

        #region МЕТОДЫ РАБОТЫ С ШАБЛОНАМИ ПОЗИЦИЙ
        #region ВЫБРАТЬ

        /// <summary>
        /// Метод возвращает лист шаблонов позиций доступных к вложению в текущей позиции
        /// </summary>
        public List<pos_temp> Pos_temp_nested_list_get(Boolean ignore_nested_limit)
        {
            return Manager.pos_temp_nestedlist_by_id(this.id_pos_temp, this.id_con, this.Pos_temp_state, ignore_nested_limit);  
        }
        #endregion

        #region ОПРЕДЕЛЕНИЕ ОГРАНИЧЕНИЙ ВЛОЖЕННОСТИ
        /// <summary>
        /// Метод определяет максимальное количество позиций указанного шаблона доступных к вложению в указанную позицию, 0 без ограничений
        /// </summary>
        public Int32 Pos_temp_nested_limit_max(pos_temp pos_temp_nested)
        {
            return Manager.pos_temp_nested_limit_max(this.id_pos_temp, pos_temp_nested.Id);
        }

        /// <summary>
        /// Метод определяет текущее количество позиций указанного шаблона вложенных в указанную позицию
        /// </summary>
        public Int32 Pos_temp_nested_limit_curent(pos_temp pos_temp)
        {
            return Manager.pos_temp_nested_limit_curent(this, pos_temp);
        }
        /// <summary>
        /// Метод выполняет проверку доступности вложения позиции выбранного шаблона в родительскую позицию
        /// </summary>
        public Boolean Pos_nested_limit_control(pos_temp pos_temp_nested)
        {
            return Manager.pos_nested_limit_control(this, pos_temp_nested);
        }
        #endregion
        #endregion
    }
}
