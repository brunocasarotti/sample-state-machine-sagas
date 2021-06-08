using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Travel.Flight.Service.Commands;
using Travel.Flight.Service.Contracts.Events.Events;

namespace Travel.Car.Service.Components
{
    public class BookCarConsumer : IConsumer<IBookCar>
    {
        private readonly ILogger<BookCarConsumer> _logger;

        public BookCarConsumer(ILogger<BookCarConsumer> logger)
        {
            _logger = logger;
        }
        
        public Task Consume(ConsumeContext<IBookCar> context)
        {
            _logger.LogInformation("Booking car for message {@Message}", context.Message);
            if (context.Message.To == "c?")
            {
                return context.Publish<ICarBookingFailed>(new { });
            }

            if (context.Message.To == "c??")
            {
                throw new ArgumentException("Invalid destination");
            }

            return context.Publish<ICarBooked>(new { });
        }
    }
}