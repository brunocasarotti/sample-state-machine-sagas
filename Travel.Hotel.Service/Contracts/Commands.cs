using System;

// ReSharper disable once CheckNamespace
namespace Travel.Hotel.Service.Commands
{
    public class IBookHotel
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Departure { get; set; }
    }
}