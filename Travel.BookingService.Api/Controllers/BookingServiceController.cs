using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Travel.BookingService.Api.Contracts;
using Travel.Flight.Service.Commands;
using Travel.Hotel.Service.Commands;

namespace Travel.BookingService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingServiceController : ControllerBase
    {
        private readonly ILogger<BookingServiceController> _logger;
        private readonly ISendEndpointProvider _endpointProvider;
        private readonly IPublishEndpoint _publishEndpoint;

        public BookingServiceController(
            ILogger<BookingServiceController> logger,
            ISendEndpointProvider endpointProvider,
            IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _endpointProvider = endpointProvider;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TravelBookingSubmitted trip)
        {
            var travelId = Guid.NewGuid();
            trip.TravelId = travelId;
            trip.FlightBooking.TravelId = travelId;
            trip.HotelBooking.TravelId = travelId;
            
            await _publishEndpoint.Publish(trip);
            return Ok(trip);
        }
    }

}