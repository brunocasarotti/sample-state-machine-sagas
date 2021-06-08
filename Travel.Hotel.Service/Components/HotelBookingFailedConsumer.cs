using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Travel.Hotel.Service.Contracts.Events.Events;

namespace Travel.Hotel.Service.Components
{
    public class HotelBookingFailedConsumer : IConsumer<IHotelBookingFailed>
    {
        private readonly ILogger<HotelBookingFailedConsumer> _logger;

        public HotelBookingFailedConsumer(ILogger<HotelBookingFailedConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<IHotelBookingFailed> context)
        {
            _logger.LogWarning("Failed to book hotel for {@Message}", context.Message);
            return Task.CompletedTask;
        }
    }
}