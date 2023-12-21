using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForClasses
{
    /// <summary>
    /// Класс потомок для автобусов типа МАЗ.
    /// </summary>
    public class MAZ : Bus
    {
        public int coastBus = 250;

        public int carSeats = 8;

        /// <summary>
        /// Конструктор для данного класса.
        /// </summary>
        public MAZ() : base()
        {
            for (int i = 0; i < 5; i++)
            {
                freeSeats[i] = carSeats;
            }
        }
    }
}
