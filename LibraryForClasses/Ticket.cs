
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
        public int begin;

        /// <summary>
        /// Поле, хранящее значение номера конца вводимого маршрута.
        /// </summary>
        public int end;

        /// <summary>
        /// Поле, хранящее значение типа автобуса для билета.
        /// </summary>
        public string type;

        /// <summary>
        /// Конструктор для задания параметров объекта класса Ticket.
        /// </summary>
        public Ticket()
        {
            begin = 0;
            end = 0;
            type = "нет";
        }

        /// <summary>
        /// Метод подсчёта стоимости билета.
        /// </summary>
        /// <returns></returns>
        public int CoastRoute()
        {
            int coast = (end - begin) * 7;
            return coast;
        }
    }
}
