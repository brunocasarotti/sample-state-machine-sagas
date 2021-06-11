using System;
using Travel.Flight.Service.Commands;
using Travel.Hotel.Service.Commands;

namespace Travel.BookingService.Api.Contracts
{
    public class TravelBookingSubmitted
    {
        public Guid TravelId { get; set; }
        public BookFlight FlightBooking { get; set; }
        public BookHotel HotelBooking { get; set; }
    }
}