using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Travel.Flight.Service.Contracts.Events.Events;

namespace Travel.Flight.Service.Components
{
    public class FlightBookingFailedConsumer : IConsumer<IFlightBookingFailed>
    {
        private readonly ILogger<FlightBookingFailedConsumer> _logger;

        public FlightBookingFailedConsumer(ILogger<FlightBookingFailedConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<IFlightBookingFailed> context)
        {
           _logger.LogWarning("Flight booking failed for {@Message}", context.Message); 
           return Task.CompletedTask;
        }
    }
}