using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Travel.Hotel.Service.Commands;
using Travel.Hotel.Service.Contracts.Events.Events;

namespace Travel.Hotel.Service.Components
{
    public class BookHotelConsumer : IConsumer<BookHotel>
    {
        private readonly ILogger<BookHotelConsumer> _logger;

        public BookHotelConsumer(ILogger<BookHotelConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<BookHotel> context)
        {
            _logger.LogInformation("Consumindo hotel book");
            if (context.Message.HotelId == 0)
            {
                _logger.LogInformation("Falhou para reservar o hotel");
                return context.Publish<IHotelBookingFailed>(new { });
            }

            if (context.Message.HotelId == -1)
            {
                _logger.LogInformation("Erro ao reservar o hotel");
                throw new ArgumentException();
            }

            return context.Publish<IHotelBooked>(new
            {
                context.Message.HotelId,
                context.Message.TravelId
            });
        }
    }
}