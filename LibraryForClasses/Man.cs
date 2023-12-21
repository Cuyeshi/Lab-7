using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForClasses
{
    /// <summary>
    /// Класс потомок для автобусов типа Мэн.
    /// </summary>
    public class Man : Bus
    {
        public int coastBus = 400;

        public int carSeats = 5;

        /// <summary>
        /// Конструктор данного класса.
        /// </summary>
        public Man() : base()
        {
            for (int i = 0; i < 5; i++)
            {
                freeSeats[i] = carSeats;
            }
        }
    }
}
