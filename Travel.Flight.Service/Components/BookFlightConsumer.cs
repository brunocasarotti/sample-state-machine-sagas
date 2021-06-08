using System;
using System.Threading.Tasks;
using GreenPipes;
using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;
using Microsoft.Extensions.Logging;
using Travel.Flight.Service.Commands;
using Travel.Flight.Service.Contracts.Events.Events;

namespace Travel.Flight.Service.Components
{
    public class BookFlightConsumer : IConsumer<IBookFlight>
    {
        private readonly ILogger<BookFlightConsumer> _logger;

        public BookFlightConsumer(ILogger<BookFlightConsumer> logger)
        {
            _logger = logger;
        }
        
        public Task Consume(ConsumeContext<IBookFlight> context)
        {
            _logger.LogInformation("Consuming message {@Message}", context.Message);
            
            if (context.Message.To == "f?")
            {
                return context.Publish<IFlightBookingFailed>(new { });
            }

            if (context.Message.To == "f??")
            {
                throw new ArgumentException("Invalid destination");
            }

            return context.Publish<IFlightBooked>(new { });
        }
    }


    public class BookFlightConsumerDefinition : ConsumerDefinition<BookFlightConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<BookFlightConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Immediate(10));
        }
    }
}