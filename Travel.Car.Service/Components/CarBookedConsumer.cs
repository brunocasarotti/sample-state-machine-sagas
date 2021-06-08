using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Travel.Flight.Service.Contracts.Events.Events;

namespace Travel.Car.Service.Components
{
    public class CarBookedConsumer : IConsumer<ICarBooked>
    {
        private readonly ILogger<CarBookedConsumer> _logger;

        public CarBookedConsumer(ILogger<CarBookedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<ICarBooked> context)
        {
            _logger.LogInformation("Car booked with success {@Message}", context.Message);
            return Task.CompletedTask;
        }
    }
}