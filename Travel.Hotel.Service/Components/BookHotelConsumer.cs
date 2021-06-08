using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Travel.Hotel.Service.Commands;
using Travel.Hotel.Service.Contracts.Events.Events;

namespace Travel.Hotel.Service.Components
{
    public class BookHotelConsumer : IConsumer<IBookHotel>
    {
        private readonly ILogger<BookHotelConsumer> _logger;

        public BookHotelConsumer(ILogger<BookHotelConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<IBookHotel> context)
        {
            
            if (context.Message.To == "h?")
            {
                return context.Publish<IHotelBookingFailed>(new { });
            }

            if (context.Message.To == "h??")
            {
                throw new ArgumentException("Invalid destination");
            }

            return context.Publish<IHotelBooked>(new { });
        }
    }
}