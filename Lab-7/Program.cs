﻿using LibraryForClasses;
using System;

namespace Lab_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MAZ MAZBus = new MAZ();
            Mersedes MersedesBus = new Mersedes();
            Man ManBus = new Man();
            
            bool tryCatchExit = true, exit = false, validateValue1;
            int s = 0, n1 = 0, n2 = 0, n3 = 0;

            while (tryCatchExit)
            {
                try
                {
                    while (!exit)
                    {
                        Console.Clear();
                        Console.WriteLine("╔══════════════════════════════════════════════╗");
                        Console.WriteLine("║                Выберите действие:            ║");
                        Console.WriteLine("║              1. Добавить маршрут             ║");
                        Console.WriteLine("║    2. Вывести информацию о всех маршрутах    ║");
                        Console.WriteLine("║        3. Вывести свободные места для        ║");
                        Console.WriteLine("║         определённого типа автобуса.         ║");
                        Console.WriteLine("║              4. Удалить маршрут              ║");
                        Console.WriteLine("║                   0.Выход.                   ║");
                        Console.WriteLine("╚══════════════════════════════════════════════╝\n");
                        int choice = 0;
                        string switchNumber = Console.ReadLine();
                        ExceptionTickets.ValidateInt(switchNumber, out choice);
                        switch (choice)
                        {
                            case 1:
                                Console.Write("Введите количество маршрутов (максимум 10): ");
                                string inputK = Console.ReadLine();
                                ExceptionTickets.ValidateInt(inputK, out int outputK);

                                Ticket[] ticket = new Ticket[10];
                                for (int j = 0; j < 10; j++)
                                {
                                    ticket[j] = new Ticket();
                                }

                                Console.WriteLine("|| 1 - Гомель; 2 - Речица; 3 - Светлогорск; 4 - Жлобин; 5 - Бобруйск ||");
                                Console.WriteLine("\nВведите маршруты и автобус, на котором поедет пассажир.\n");
                                while (s <= outputK)
                                {
                                    validateValue1 = false;
                                    Console.WriteLine("\nВведите номер пункта: ");
                                    Console.Write("посадки - ");
                                    string begin = Console.ReadLine();
                                    Console.Write("высадки - ");
                                    string end = Console.ReadLine();
                                    ExceptionTickets.ValidateInt(begin, out ticket[s].Begin);
                                    ExceptionTickets.ValidateInt(end, out ticket[s].End);

                                    if (ticket[s].End < ticket[s].Begin || ticket[s].Begin < 1 || ticket[s].Begin > 5 || ticket[s].End < 1 || ticket[s].End > 5)
                                    {
                                        Console.WriteLine("\nТакого маршрута нет.");
                                    }
                                    else
                                    {
                                        while (!validateValue1)
                                        {
                                            int coast = ticket[s].CoastRoute();
                                            int freeSeats1 = SearchMin(MAZBus.freeSeats, ticket[s].Begin, ticket[s].End),
                                                freeSeats2 = SearchMin(MersedesBus.freeSeats, ticket[s].Begin, ticket[s].End),
                                                freeSeats3 = SearchMin(ManBus.freeSeats, ticket[s].Begin, ticket[s].End);
                                            int sale1 = MAZBus.coastBus + coast,
                                                sale2 = MersedesBus.coastBus + coast,
                                                sale3 = ManBus.coastBus + coast;

                                            Console.WriteLine("Выберите автобус по цене и количеству мест(1-3).");
                                            Console.Write($"MAZ: {freeSeats1} мест {sale1} р.; Mersedes: {freeSeats2} мест {sale2} р.; " +
                                                $"Man: {freeSeats3} мест {sale3} р.\n");

                                            
                                            string switchValue = Console.ReadLine();
                                            ExceptionTickets.ValidateInt(switchValue, out int value);
                                            switch (value)
                                            {
                                                case 1:
                                                    if (freeSeats1 != 0)
                                                    {
                                                        MAZBus.tickets[n1] = ticket[s];
                                                        n1++;
                                                        MAZBus.FreeSeats(ticket[s].Begin, ticket[s].End);
                                                        s++;
                                                        validateValue1 = true;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("\nМест в автобусе нет.");
                                                    }
                                                    break;

                                                case 2:
                                                    if (freeSeats2 != 0)
                                                    {
                                                        MersedesBus.tickets[n2] = ticket[s];
                                                        n2++;
                                                        MersedesBus.FreeSeats(ticket[s].Begin, ticket[s].End);
                                                        s++;
                                                        validateValue1 = true;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("\nМест в автобусе нет.");
                                                    }
                                                    break;

                                                case 3:
                                                    if (freeSeats3 != 0)
                                                    {
                                                        ManBus.tickets[n3] = ticket[s];
                                                        n3++;
                                                        ManBus.FreeSeats(ticket[s].Begin, ticket[s].End);
                                                        s++;
                                                        validateValue1 = true;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("\nМест в автобусе нет.");
                                                    }
                                                    break;

                                                default:
                                                    Console.WriteLine("\nТакого автобуса нет!");
                                                    break;
                                            }
                                        }
                                    }
                                    s++;
                                }
                                break;

                            case 2:
                                Console.WriteLine("Выберите тип автобуса: 1 - Maz     ");
                                Console.WriteLine("                       2 - Mersedes");
                                Console.WriteLine("                       3 - Man     ");
                                string switchChoice = Console.ReadLine();
                                ExceptionTickets.ValidateInt(switchChoice, out int busChoice);


                                switch (busChoice)
                                {
                                    case 1:
                                        RemainingPlaces(MAZBus);
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        RemainingPlaces(MersedesBus);
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        RemainingPlaces(ManBus);
                                        Console.ReadKey();
                                        break;

                                    default:
                                        Console.WriteLine("Некорректный выбор. Выберите существующую опцию.");
                                        Console.ReadKey();
                                        break;
                                }

                                break;

                            case 3:
                                Console.WriteLine("Выберите тип автобуса: 1 - Maz     ");
                                Console.WriteLine("                       2 - Mersedes");
                                Console.WriteLine("                       3 - Man     ");
                                string switchValue = Console.ReadLine();
                                ExceptionTickets.ValidateInt(switchValue, out int value);
                                switch (value)
                                {
                                    case 1:

                                        break; 
                                    
                                    case 2:

                                        break; 
                                    
                                    case 3:

                                        break;

                                    default:
                                        Console.WriteLine("Некорректный выбор. Выберите существующую опцию.");
                                        Console.ReadKey();
                                        break;
                                }

                                break;

                            case 0:
                                exit = true;
                                break;

                            default:
                                Console.WriteLine("Некорректный выбор. Выберите существующую опцию.");
                                Console.ReadKey();
                                break;
                        }

                        
                    }
                    
                    tryCatchExit = false;
                }
                catch (ExceptionTickets ex)
                {
                    Console.WriteLine($"Ошибка ввода: {ex.Message}\n");
                    Console.ReadKey();
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

        /// <summary>
        /// Метод для вывода информации о свободных местах в указываемом транспорте.
        /// </summary>
        /// <param name="bus"></param>
        static void RemainingPlaces(Bus bus)
        {
            try
            {
                int begin = 0, end = 0;
                Console.WriteLine("\nВведите номер пункта: ");
                Console.Write("посадки - ");
                string input1 = Console.ReadLine();
                Console.Write("высадки - ");
                string input2 = Console.ReadLine();
                ExceptionTickets.ValidateInt(input1, out begin);
                ExceptionTickets.ValidateInt(input2, out end);
                //Console.Write("Начало (1-5): ");
                //Console.Write("Конец (1-5): ");
                
                if (end > begin && begin >= 1 && begin <= 5 && end >= 1 && end <= 5)
                {
                    int min = Program.SearchMin(bus.freeSeats, begin, end);
                    Console.Write("Количество пустых мест:");
                    Console.WriteLine(min);
                }
                else
                {
                    Console.WriteLine("Такого маршрута нет.");
                }
            }
            catch (ExceptionTickets ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}\n");
            }

        }

        static void OutputInformation(string busName, int freeSeats, int sale, Ticket ticket)
        {
            for (int i = 0; i < )
            Console.Write($"{busName}: {freeSeats} мест {sale} р., {ticket[i].Begin}, {ticket[i].End}");
            MAZBus.tickets[n1] = ticket[s];
            n1++;
            s++;
        }
    }
}
