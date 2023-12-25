
namespace LibraryForClasses
{
    /// <summary>
    /// Класс потомок для автобусов типа МАЗ.
    /// </summary>
    public class MAZ : Bus
    {
        /// <summary>
        /// Поле, хранящее значение базовой стоимости проезда на автобусе типа MAZ.
        /// </summary>
        public int coastBus = 250;

        /// <summary>
        /// Поле, хранящее значение количества мест в автобусе типа MAZ.
        /// </summary>
        public int carSeats = 1;

        /// <summary>
        /// Конструктор для задания параметров объекта класса-потомка MAZ.
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
