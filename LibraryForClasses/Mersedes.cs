using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForClasses
{
    /// <summary>
    /// Класс потомок для автобусов типа Мерседес.
    /// </summary>
    public class Mersedes : Bus
    {
        public int coastBus = 360;

        public int carSeats = 6;

        /// <summary>
        /// Коструктор для данного класса.
        /// </summary>
        public Mersedes() : base()
        {
            for (int i = 0; i < 5; i++)
            {
                freeSeats[i] = carSeats;
            }
        }
    }
}
