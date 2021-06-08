using System;

// ReSharper disable once CheckNamespace
namespace Travel.Flight.Service.Commands
{
    public class IBookCar
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Departure { get; set; }
    }
}