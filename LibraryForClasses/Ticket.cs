using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForClasses
{
    /// <summary>
    /// Класс билет для хранения информации о билете.
    /// </summary>
    public class Ticket
    {
        public int Begin;

        public int End;

        public Ticket()
        {
            this.Begin = 0;
            this.End = 0;
        }

        /// <summary>
        /// Метод подсчёта стоимости билета.
        /// </summary>
        /// <returns></returns>
        public int CoastRoute()
        {
            int coast = (End - Begin) * 150;
            return coast;
        }
    }
}
