using LibraryForClasses;
using System;
using System.Net.Sockets;

namespace Buses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MAZ bus1 = new MAZ();
            Mersedes bus2 = new Mersedes();
            Man bus3 = new Man();
            Ticket[] ticket = new Ticket[10];
            for (int j = 0; j < 10; j++)
            {
                ticket[j] = new Ticket();
            }
            bool validateValue = false, validateValue1 = false;
            int s = 0, n1 = 0, n2 = 0, n3 = 0;
            Console.WriteLine("Для 10 маршрутов введите сами маршруты и автобус, на котором поедет пассажир.\n");
            while (!validateValue || s < 10)
            {
                try
                {
                    validateValue = false;
                    Console.WriteLine("Маршрут:");
                    Console.Write("Начало: ");
                    string begin = Console.ReadLine();
                    ExceptionTickets.ValidateInt(begin, out ticket[s].Begin);
                    Console.Write("Конец: ");
                    string end = Console.ReadLine();
                    ExceptionTickets.ValidateInt(begin, out ticket[s].End);
                    if (ticket[s].End < ticket[s].Begin || ticket[s].Begin < 1 || ticket[s].Begin > 5 || ticket[s].End < 1 || ticket[s].End > 5)
                    {
                        Console.WriteLine("Такого маршрута нет.");
                    }
                    else
                    {
                        validateValue = true;
                        while (!validateValue1)
                        {
                            validateValue1 = false;
                            int coast = ticket[s].CoastRoute(), freeSeats1 = Program.SearchMin(bus1.freeSeats, ticket[s].Begin, ticket[s].End), freeSeats2 = Program.SearchMin(bus2.freeSeats, ticket[s].Begin, ticket[s].End), freeSeats3 = Program.SearchMin(bus3.freeSeats, ticket[s].Begin, ticket[s].End);
                            int sale1 = bus1.coastBus + coast, sale2 = bus2.coastBus + coast, sale3 = bus3.coastBus + coast;
                            string sales = "Автобус 1: " + freeSeats1 + " мест " + sale1 + "р.; Автобус 2: " + freeSeats2 + " мест " + sale2 + "р.; Автобус 3: " + freeSeats3 + " мест " + sale3 + "р.: ";
                            Console.WriteLine("Выберите автобус по цене и количеству мест(1-3).");
                            Console.Write(sales);
                            int value = Convert.ToInt32(Console.ReadLine());
                            if (value == 1)
                            {
                                if (freeSeats1 != 0)
                                {
                                    bus1.tickets[n1] = ticket[s];
                                    n1++;
                                    bus1.FreeSeats(ticket[s].Begin, ticket[s].End);
                                    s++;
                                    validateValue1 = true;
                                }
                                else
                                {
                                    Console.WriteLine("Мест в автобусе нет.");
                                }
                            }
                            if (value == 2)
                            {
                                if (freeSeats2 != 0)
                                {
                                    bus2.tickets[n2] = ticket[s];
                                    n2++;
                                    bus2.FreeSeats(ticket[s].Begin, ticket[s].End);
                                    s++;
                                    validateValue1 = true;
                                }
                                else
                                {
                                    Console.WriteLine("Мест в автобусе нет.");
                                }
                            }
                            if (value == 3)
                            {
                                if (freeSeats3 != 0)
                                {
                                    bus3.tickets[n3] = ticket[s];
                                    n3++;
                                    bus3.FreeSeats(ticket[s].Begin, ticket[s].End);
                                    s++;
                                    validateValue1 = true;
                                }
                                else
                                {
                                    Console.WriteLine("Мест в автобусе нет.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Такого автобуса нет!");
                            }
                        }
                    }
                }
                catch (ExceptionTickets ex)
                {
                    Console.WriteLine($"Ошибка ввода: {ex.Message}\n");
                }
            }
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1.Вывести свободные места для первого автобуса.");
                Console.WriteLine("2.Вывести свободные места для второго автобуса.");
                Console.WriteLine("3.Вывести свободные места для третьего автобуса.");
                Console.WriteLine("0.Выход.\n");
                int choice = 0;
                try
                {
                    string number = Console.ReadLine();
                    ExceptionTickets.ValidateInt(number, out choice);
                }
                catch (ExceptionTickets ex)
                {
                    Console.WriteLine($"Ошибка ввода: {ex.Message}\n");
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите маршрут: ");
                        Console.Write("Начало: ");
                        int begin = 0, end = 0;
                        try
                        {
                            string str = Console.ReadLine();
                            ExceptionTickets.ValidateInt(str, out begin);
                            Console.Write("Конец: ");
                            str = Console.ReadLine();
                            ExceptionTickets.ValidateInt(str, out end);
                        }
                        catch (ExceptionTickets ex)
                        {
                            Console.WriteLine($"Ошибка ввода: {ex.Message}\n");
                        }
                        if (end < begin || begin < 1 || begin > 5 || end < 1 || end > 5)
                        {
                            Console.WriteLine("Такого маршрута нет.");
                            break;
                        }
                        else
                        {
                            int min = Program.SearchMin(bus1.freeSeats, begin, end);
                            Console.Write("Количество пустых мест:");
                            Console.WriteLine(min);
                            break;
                        }
                    case 2:
                        Console.WriteLine("Введите маршрут: ");
                        Console.Write("Начало: ");
                        begin = 0;
                        end = 0;
                        try
                        {
                            string str = Console.ReadLine();
                            ExceptionTickets.ValidateInt(str, out begin);
                            Console.Write("Конец: ");
                            str = Console.ReadLine();
                            ExceptionTickets.ValidateInt(str, out end);
                        }
                        catch (ExceptionTickets ex)
                        {
                            Console.WriteLine($"Ошибка ввода: {ex.Message}\n");
                        }
                        if (end < begin || begin < 1 || begin > 5 || end < 1 || end > 5)
                        {
                            Console.WriteLine("Такого маршрута нет.");
                            break;
                        }
                        else
                        {
                            int min = Program.SearchMin(bus2.freeSeats, begin, end);
                            Console.Write("Количество пустых мест:");
                            Console.WriteLine(min);
                            break;
                        }
                    case 3:
                        Console.WriteLine("Введите маршрут: ");
                        Console.Write("Начало: ");
                        begin = 0;
                        end = 0;
                        try
                        {
                            string str = Console.ReadLine();
                            ExceptionTickets.ValidateInt(str, out begin);
                            Console.Write("Конец: ");
                            str = Console.ReadLine();
                            ExceptionTickets.ValidateInt(str, out end);
                        }
                        catch (ExceptionTickets ex)
                        {
                            Console.WriteLine($"Ошибка ввода: {ex.Message}\n");
                        }
                        if (end < begin || begin < 1 || begin > 5 || end < 1 || end > 5)
                        {
                            Console.WriteLine("Такого маршрута нет.");
                            break;
                        }
                        else
                        {
                            int min = Program.SearchMin(bus3.freeSeats, begin, end);
                            Console.Write("Количество пустых мест:");
                            Console.WriteLine(min);
                            break;
                        }
                    case 0:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор. Пожалуйста, выберите существующую опцию.");
                        break;
                }
            }
        }

        /// <summary>
        /// Метод поиска минимального внутри массива.
        /// </summary>
        /// <param name="tickets"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        static int SearchMin(int[] tickets, int begin, int end)
        {
            int min = tickets[begin - 1];
            for (int i = begin - 1; i < end; i++)
            {
                if (tickets[i] < min)
                {
                    min = tickets[i];
                }
            }
            return min;
        }
    }
}
