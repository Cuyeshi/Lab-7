using System;

namespace LibraryForClasses
{
    /// <summary>
    /// Класс исключений для задачи.
    /// </summary>
    public class ExceptionTickets : Exception
    {
        /// <summary>
        /// Конструктор для создания собственных исключений.
        /// </summary>
        /// <param name="message"></param>
        public ExceptionTickets(string message) : base(message) { }

        /// <summary>
        /// Метод исключения для переменных типа int.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <exception cref="ExceptionTickets"></exception>
        public static void ValidateInt(string input, out int result)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ExceptionTickets("Строка пуста!");
            }

            if (!Int32.TryParse(input, out result))
            {
                throw new ExceptionTickets("Строка содержит вещественное число или текст!");
            }
            if (result < 0)
            {
                throw new ExceptionTickets("Введённое число меньше нуля!");
            }
        }

        /// <summary>
        /// Метод исключения для переменных типа int для случая ввода количества маршрутов.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <exception cref="ExceptionTickets"></exception>
        public static void ValidateIntForInput(string input, out int result)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ExceptionTickets("Строка пуста!");
            }

            if (!Int32.TryParse(input, out result))
            {
                throw new ExceptionTickets("Строка содержит вещественное число или текст!");
            }
            if (result < 0 || result > 10)
            {
                throw new ExceptionTickets("Введённое число меньше нуля или больше 10!");
            }
        }
    }
}
