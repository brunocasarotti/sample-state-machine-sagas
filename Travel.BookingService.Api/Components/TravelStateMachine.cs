using System;
using Automatonymous;
using MassTransit;
using MassTransit.Saga;
using Travel.BookingService.Api.Contracts;
using Travel.Flight.Service.Commands;
using Travel.Flight.Service.Contracts.Events.Events;
using Travel.Hotel.Service.Commands;
using Travel.Hotel.Service.Contracts.Events.Events;

namespace Travel.BookingService.Api.Components
{
    public class TravelStateMachine : MassTransitStateMachine<TravelState>
    {
        public TravelStateMachine()
        {
            InstanceState(x => x.CurrentState);

            Event(() => TravelBookingSubmitted, context => context.CorrelateById(m => m.Message.TravelId));
            Event(() => FlightBooked, context => context.CorrelateById(m => m.Message.TravelId));
            Event(() => HotelBooked, context => context.CorrelateById(m => m.Message.TravelId));

            Initially(
                When(TravelBookingSubmitted)
                    .Then(context =>
                    {
                        context.Instance.CorrelationId = context.Data.TravelId;
                        context.Instance.HotelId = context.Data.HotelBooking.HotelId;
                    })
                    .SendAsync(new Uri("queue:book-flight"), context => context.Init<BookFlight>(new
                    {
                        TravelId = context.Instance.CorrelationId,
                        context.Data.FlightBooking.From,
                        context.Data.FlightBooking.To,
                        context.Data.FlightBooking.Departure
                    }))
                    .TransitionTo(FlightBookingRequested)
            );

            During(FlightBookingRequested,
                When(FlightBooked)
                    .SendAsync(new Uri("queue:book-hotel"), context => context.Init<BookHotel>(new
                    {
                        context.Instance.HotelId,
                        context.Data.TravelId
                    }))
                    .TransitionTo(HotelBookingRequested)
            );
            
            During(HotelBookingRequested,
                When(HotelBooked)
                    .Then(_ => Console.WriteLine("Hotel reservado"))
                    .Finalize()
                );
        }


        public State HotelBookingRequested { get; set; }
        public State FlightBookingRequested { get; set; }

        
        public Event<TravelBookingSubmitted> TravelBookingSubmitted { get; set; }
        public Event<IFlightBooked> FlightBooked { get; set; }
        public Event<IHotelBooked> HotelBooked { get; set; }
    }

    public class TravelState : 
        SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public int HotelId { get; set; }
        public int Version { get; set; }
    }
}