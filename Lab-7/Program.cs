using System;
using System.Collections.Generic;
using LibraryForClasses;

class Program
{
    static void Main()
    {
        List<BusTicketWithType> tickets = new List<BusTicketWithType>();

        // Создаем билеты для разных маршрутов и типов автобусов
        tickets.Add(new BusTicketWithType("Гомель - Речица", 10.0, "Маз"));
        tickets.Add(new BusTicketWithType("Речица - Светлогорск", 15.0, "Мерседес"));
        tickets.Add(new BusTicketWithType("Светлогорск - Жлобин", 20.0, "Ман"));
        // ... Добавьте другие билеты для оставшихся маршрутов и типов автобусов

        // Продажа билетов (пример)
        tickets[0].SellTicket();
        tickets[0].SellTicket();
        tickets[0].SellTicket();

        // Подсчет оставшихся свободных билетов для каждого маршрута
        Dictionary<string, int> availableTickets = new Dictionary<string, int>();
        foreach (var ticket in tickets)
        {
            if (ticket.IsAvailable)
            {
                if (!availableTickets.ContainsKey(ticket.Route))
                {
                    availableTickets[ticket.Route] = 1;
                }
                else
                {
                    availableTickets[ticket.Route]++;
                }
            }
        }

        // Вывод информации о свободных билетах по каждому маршруту
        Console.WriteLine("Свободные билеты:");
        foreach (var pair in availableTickets)
        {
            Console.WriteLine($"Маршрут: {pair.Key}, Свободные билеты: {pair.Value}");
        }

        Console.ReadKey();
    }
}