using System;

// ReSharper disable once CheckNamespace
namespace Travel.Hotel.Service.Commands
{
    public class BookHotel
    {
        public int HotelId { get; set; }
        public Guid TravelId { get; set; }
    }
}