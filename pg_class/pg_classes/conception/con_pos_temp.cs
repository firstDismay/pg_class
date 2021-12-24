using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class conception
    {
        private void Init_pos_temp()
        {
            pos_temp_state = eStatus.on;
        }

        #region СВОЙСТВА ДЛЯ РАБОТЫ С ШАБЛОНАМИ ПОЗИЦИЙ

        private eStatus pos_temp_state;
        /// <summary>
        /// Статус отображаемых шаблонов позиций
        /// </summary>
        public eStatus Pos_temp_state { get => pos_temp_state; set => pos_temp_state = value; }
        #endregion

        #region МЕТОДЫ РАБОТЫ С ШАБЛОНАМИ ПОЗИЦИЙ

        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новый шаблон позиций
        /// pos_temp_add
        /// </summary>
        public pos_temp Pos_temp_add(String iname, Int32 iid_prototype, Boolean inested_limit, String idesc)
        {
            pos_temp pt;
            pt = Manager.pos_temp_add(iname, this.id, iid_prototype, inested_limit, idesc);
            return pt;
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Pos_temp_add(out eAccess Access)
        {
            return Manager.pos_temp_add(out Access);
        }
        //*************************************************************************************

        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет шаблон позиции
        /// pos_temp_del
        /// </summary>
        public void Pos_temp_del(pos_temp pos_temp)
        {
            Manager.pos_temp_del(pos_temp);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Pos_temp_del(out eAccess Access)
        {
            return Manager.pos_temp_del(out Access);
        }
        //*************************************************************************************
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        ///  Лист шаблонов позиций концепции в соотвествии справилами вложенности
        ///  pos_temp_nestedlist_by_id
        /// </summary>
        public List<pos_temp> Pos_temp_nested_list_get()
        {
           return  Manager.pos_temp_nestedlist_by_id(0, id, pos_temp_state, false);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Pos_temp_nested_list_get(out eAccess Access)
        {
            return Manager.pos_temp_nestedlist_by_id(out Access);
        }
        //*************************************************************************************


        /// <summary>
        /// Лист шаблонов позиций по идентификатору прототипа
        /// pos_temp_by_id_prototype
        /// </summary>
        public List<pos_temp> Pos_temp_by_id_prototype(Int32 iid_prototype)
        {
            return Manager.pos_temp_by_id_prototype(this.id, iid_prototype);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Pos_temp_by_id_prototype(out eAccess Access)
        {
            return Manager.pos_temp_by_id_prototype(out Access);
        }
        //*************************************************************************************


        /// <summary>
        /// Лист шаблонов позиций концепции полный без учета правил вложенности
        /// pos_temp_by_id_con
        /// </summary>
        public List<pos_temp> Pos_temp_list_all_get()
        {
            return Manager.pos_temp_by_id_con(this.Id);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Pos_temp_all_list_get(out eAccess Access)
        {
            return Manager.pos_temp_by_id_con(out Access);
        }
        //*************************************************************************************
        #endregion

        #endregion
    }
}
