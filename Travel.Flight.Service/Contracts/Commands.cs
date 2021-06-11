using System;

// ReSharper disable once CheckNamespace
namespace Travel.Flight.Service.Commands
{
    public class BookFlight
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Departure { get; set; }
        public Guid TravelId { get; set; }
    }
}