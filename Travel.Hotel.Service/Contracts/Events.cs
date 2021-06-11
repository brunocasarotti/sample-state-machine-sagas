// ReSharper disable once CheckNamespace

using System;

namespace Travel.Hotel.Service.Contracts.Events.Events
{
    public interface IHotelBooked
    {
       int HotelId { get; }
       Guid TravelId { get; set; }
    }

    public interface IHotelBookingFailed
    {
        
    }

}