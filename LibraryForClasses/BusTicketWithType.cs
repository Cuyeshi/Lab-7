
namespace LibraryForClasses
{
    /// <summary>
    /// Класс для хранения информации о билетах на автобус с указанием типа
    /// </summary>
    public class BusTicketWithType : BusTicket
    {
        public string BusType { get; set; }

        public BusTicketWithType(string route, double price, string busType) : base(route, price)
        {
            BusType = busType;
        }
    }
}
