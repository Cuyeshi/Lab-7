
namespace LibraryForClasses
{
    /// <summary>
    /// Абстрактный класс для наследования к типам автобуса.
    /// </summary>
    abstract public class Bus
    {
        public int seats;
        public Ticket[] tickets = new Ticket[10];

        public int[] freeSeats = new int[5];

        /// <summary>
        /// Конструктор для абстракторного класса.
        /// </summary>
        public Bus()
        {
            for (int i = 0; i < 5; i++)
            {
                freeSeats[i] = seats;
            }
        }

        /// <summary>
        /// Метод подсчёта свободных мест по маршруту.
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int[] FreeSeats(int begin, int end)
        {
            int count = 0;
            for (int i = begin - 1; i < end; i++)
            {
                if (freeSeats[i] == 0)
                {
                    count = count + 1;
                }
            }
            if (count == 0)
            {
                for (int i = begin - 1; i < end - 1; ++i)
                {
                    freeSeats[i] = freeSeats[i] - 1;
                }
            }
            return freeSeats;
        }
    }
}
