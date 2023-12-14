using System;

namespace LibraryForClasses
{
    /// <summary>
    /// Базовый класс для хранения информации о билетах на автобус
    /// </summary>
    public class BusTicket
    {
        public string Route { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }

        public BusTicket(string route, double price)
        {
            Route = route;
            Price = price;
            IsAvailable = true;
        }

        public void SellTicket()
        {
            if (IsAvailable)
            {
                IsAvailable = false;
                Console.WriteLine($"Продан билет на маршрут: {Route}");
            }
            else
            {
                Console.WriteLine($"Нет свободных мест на маршрут: {Route}. Билет не может быть продан.");
            }
        }
    }
}
