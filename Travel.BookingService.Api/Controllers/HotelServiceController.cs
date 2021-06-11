using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Travel.Flight.Service.Commands;
using Travel.Hotel.Service.Commands;

namespace Travel.BookingService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelServiceController : ControllerBase
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public HotelServiceController(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        // GET
        [HttpPost]
        public async Task<IActionResult> Index(BookHotel request)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:book-hotel"));

            await endpoint.Send<BookHotel>(request);

            return Ok();
        }
    }
}