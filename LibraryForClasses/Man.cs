
namespace LibraryForClasses
{
    /// <summary>
    /// Класс потомок для автобусов типа Мэн.
    /// </summary>
    public class Man : Bus
    {
        /// <summary>
        /// Поле, хранящее значение базовой стоимости проезда на автобусе типа Man.
        /// </summary>
        public int coastBus = 310;

        /// <summary>
        /// Поле, хранящее значение количества мест в автобусе типа Man.
        /// </summary>
        public int carSeats = 12;

        /// <summary>
        /// Конструктор для задания параметров объекта класса-потомка Man.
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
