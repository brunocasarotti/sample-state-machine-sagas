using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Travel.Flight.Service.Contracts.Events.Events;

namespace Travel.Flight.Service.Components
{
    public class FlightBookedConsumer : IConsumer<IFlightBooked>
    {
        private readonly ILogger<FlightBookedConsumer> _logger;

        public FlightBookedConsumer(ILogger<FlightBookedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<IFlightBooked> context)
        {
            _logger.LogInformation("Flight booked with success");
            return Task.CompletedTask;
        }
    }
}