namespace Entities
{
    public class Flight : Route
    {
        public string flightCarrier { get; set; }
        public string flightNumber { get; set; }
        public decimal price { get; set; }
    }
}
