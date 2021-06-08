using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Travel.Hotel.Service.Contracts.Events.Events;

namespace Travel.Hotel.Service.Components
{
    public class HotelBookedConsumer : IConsumer<IHotelBooked>
    {
        private readonly ILogger<HotelBookedConsumer> _logger;

        public HotelBookedConsumer(ILogger<HotelBookedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<IHotelBooked> context)
        {
            _logger.LogInformation("Hotel booked with success {@Message}", context.Message);
            return Task.CompletedTask;
        }
    }
}