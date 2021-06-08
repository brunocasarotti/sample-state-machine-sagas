using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Travel.Flight.Service.Contracts.Events.Events;

namespace Travel.Car.Service.Components
{
    public class CarBookingFailedConsumer : IConsumer<ICarBookingFailed>
    {
        private readonly ILogger<CarBookingFailedConsumer> _logger;

        public CarBookingFailedConsumer(ILogger<CarBookingFailedConsumer> logger)
        {
            _logger = logger;
        }
        
        public Task Consume(ConsumeContext<ICarBookingFailed> context)
        {
            _logger.LogWarning("Failed to book a car for {@Message}", context.Message);
            return Task.CompletedTask;
        }
    }
}