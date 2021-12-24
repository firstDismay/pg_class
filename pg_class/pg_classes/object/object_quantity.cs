using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс обобщенного представления объектов
    /// </summary>
    public partial class object_general 
    {

        #region СВОЙСТВА КЛАССА

        /// <summary>
        /// Коэффициент пересчета в базовые единицы
        /// </summary>
        public Decimal MC { get => mc; }

        /// <summary>
        /// Разрядность окруления
        /// </summary>
        public Int32 Round { get => round; }

        /// <summary>
        /// Кооличество объекта в установленных единицах
        /// </summary>
        public Decimal Quantity_curent
        {
            get
            {
                return cquantity;
            }
            set
            {
                if (cquantity != value)
                {
                    cquantity = value;
                    bquantity = mc * value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Количество объекта в базовых единицах
        /// </summary>
        public Decimal Quantity_base { get => bquantity; }

        
        #endregion

    }
}
