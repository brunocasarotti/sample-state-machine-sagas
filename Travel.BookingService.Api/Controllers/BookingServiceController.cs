using System;
using System.Collections.Generic;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public BookingServiceController(ILogger<BookingServiceController> logger,
            ISendEndpointProvider endpointProvider)
        {
            _logger = logger;
            _endpointProvider = endpointProvider;
        }

        [HttpPost]
        public IActionResult Post(TripBooking trip)
        {
            
            return Ok(trip);
        }
    }

    public class TripBooking
    {
        public Guid BookId { get; set; } = Guid.NewGuid();
        public IBookFlight FlightBooking { get; set; }
        public IBookHotel HotelBooking { get; set; }
        public IBookCar CarBooking { get; set; }
    }
}