// ReSharper disable once CheckNamespace

using System;

namespace Travel.Flight.Service.Contracts.Events.Events
{
    public interface IFlightBooked
    {
        Guid TravelId { get; set; }
    }

    public interface IFlightBookingFailed
    {
        
    }

}