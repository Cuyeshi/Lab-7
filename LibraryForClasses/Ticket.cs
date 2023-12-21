
namespace LibraryForClasses
{
    /// <summary>
    /// Класс билет для хранения информации о билете.
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// Поле, хранящее значение номера начала вводимого маршрута.
        /// </summary>
        public int Begin;

        /// <summary>
        /// Поле, хранящее значение номера конца вводимого маршрута.
        /// </summary>
        public int End;

        /// <summary>
        /// Конструктор для задания параметров объекта класса Ticket.
        /// </summary>
        public Ticket()
        {
            Begin = 0;
            End = 0;
        }

        /// <summary>
        /// Метод подсчёта стоимости билета.
        /// </summary>
        /// <returns></returns>
        public int CoastRoute()
        {
            int coast = (End - Begin) * 7;
            return coast;
        }
    }
}
