using LibraryForClasses;
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
            Ticket[] ticket = new Ticket[10];
            for (int j = 0; j < 10; j++)
            {
                ticket[j] = new Ticket();
            }

            bool tryCatchExit = true, exit = false, validateValue1;
            int freeSeats1, freeSeats2, freeSeats3, sale1, sale2, sale3, routesCount = 0, s = 0, n1 = 0, n2 = 0, n3 = 0, i;

            while (tryCatchExit)
            {
                try
                {
                    while (!exit)
                    {
                        Console.Clear();
                        Console.WriteLine("\n╔══════════════════════════════════════════════╗");
                        Console.WriteLine("║                Выберите действие:            ║");
                        Console.WriteLine("║       1. Создать новый список маршрутов      ║");
                        Console.WriteLine("║    2. Вывести информацию о всех маршрутах    ║");
                        Console.WriteLine("║        3. Вывести свободные места для        ║");
                        Console.WriteLine("║         определённого типа автобуса          ║");
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
                                ExceptionTickets.ValidateIntForInput(inputK, out routesCount);

                                Console.WriteLine("|| 1 - Гомель; 2 - Речица; 3 - Светлогорск; 4 - Жлобин; 5 - Бобруйск ||");                                
                                for (i = 0; i < routesCount; i++)
                                {
                                    validateValue1 = false;
                                    Console.WriteLine("\nВведите номер пункта: ");
                                    Console.Write("посадки - ");
                                    string begin = Console.ReadLine();
                                    Console.Write("высадки - ");
                                    string end = Console.ReadLine();
                                    ExceptionTickets.ValidateInt(begin, out ticket[s].begin);
                                    ExceptionTickets.ValidateInt(end, out ticket[s].end);

                                    if (ticket[s].end < ticket[s].begin || ticket[s].begin < 1 || ticket[s].begin > 5 || ticket[s].end < 1 || ticket[s].end > 5)
                                    {
                                        Console.WriteLine("\nТакого маршрута нет.");
                                    }
                                    else
                                    {
                                        while (!validateValue1)
                                        {
                                            int coast = ticket[s].CoastRoute();
                                            freeSeats1 = SearchMin(MAZBus.freeSeats, ticket[s].begin, ticket[s].end);
                                            freeSeats2 = SearchMin(MersedesBus.freeSeats, ticket[s].begin, ticket[s].end);
                                            freeSeats3 = SearchMin(ManBus.freeSeats, ticket[s].begin, ticket[s].end);
                                            sale1 = MAZBus.coastBus + coast;
                                            sale2 = MersedesBus.coastBus + coast;
                                            sale3 = ManBus.coastBus + coast;

                                            Console.WriteLine("\nВыберите автобус по цене и количеству мест(1-3):");
                                            Console.Write($"1). MAZ: {freeSeats1} мест {sale1} р.; \n2). Mersedes: {freeSeats2} мест {sale2} р.; " +
                                                $"\n3). Man: {freeSeats3} мест {sale3} р.\n");

                                            
                                            string switchValue = Console.ReadLine();
                                            ExceptionTickets.ValidateInt(switchValue, out int value);
                                            switch (value)
                                            {
                                                case 1:
                                                    if (freeSeats1 != 0)
                                                    {
                                                        ticket[s].type = "Maz";
                                                        MAZBus.tickets[n1] = ticket[s];
                                                        n1++;
                                                        MAZBus.FreeSeats(ticket[s].begin, ticket[s].end);
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
                                                        ticket[s].type = "Mersedes";
                                                        MersedesBus.tickets[n2] = ticket[s];
                                                        n2++;
                                                        MersedesBus.FreeSeats(ticket[s].begin, ticket[s].end);
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
                                                        ticket[s].type = "Man";
                                                        ManBus.tickets[n3] = ticket[s];
                                                        n3++;
                                                        ManBus.FreeSeats(ticket[s].begin, ticket[s].end);
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
                                }
                                break;

                            case 2:
                                Console.WriteLine("Список купленных билетов:");
                                for (i = 0; i < 10; i++)
                                {
                                    if (ticket[i].begin != 0 && ticket[i].end != 0 && ticket[i].type != "нет")
                                        Console.WriteLine($"{i + 1}: автобус {ticket[i].type}, маршрут {ticket[i].begin} - {ticket[i].end}.");
                                }
                                Console.ReadKey();
                                break;

                            case 3:
                                Console.WriteLine("Выберите тип автобуса: 1 - Maz     ");
                                Console.WriteLine("                       2 - Mersedes");
                                Console.WriteLine("                       3 - Man     ");
                                string switchChoice1 = Console.ReadLine();
                                ExceptionTickets.ValidateInt(switchChoice1, out int busChoice1);


                                switch (busChoice1)
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

                            case 4:
                                Console.Write("Введите номер маршрута для его удаления: ");
                                string inputN = Console.ReadLine();
                                ExceptionTickets.ValidateInt(inputN, out int outputN);
                                if (outputN > 0 && outputN <= 10)
                                    ticket[outputN - 1] = new Ticket();
                                else
                                    Console.WriteLine("Вы ввели неверный номер маршрута!");

                                Console.ReadKey();
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

       
    }
}
