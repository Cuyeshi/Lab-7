
namespace LibraryForClasses
{
    /// <summary>
    /// Класс потомок для автобусов типа Мерседес.
    /// </summary>
    public class Mersedes : Bus
    {
        /// <summary>
        /// Поле, хранящее значение базовой стоимости проезда на автобусе типа Mersedes.
        /// </summary>
        public int coastBus = 380;

        /// <summary>
        /// Поле, хранящее значение количества мест в автобусе типа Mersedes.
        /// </summary>
        public int carSeats = 15;

        /// <summary>
        /// Конструктор для задания параметров объекта класса-потомка Mersedes.
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
