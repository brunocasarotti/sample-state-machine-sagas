using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Travel.Flight.Service.Commands;

namespace Travel.BookingService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightServiceController : ControllerBase
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public FlightServiceController(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        // GET
        [HttpPost]
        public async Task<IActionResult> Index(IBookFlight request)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:book-flight"));

            await endpoint.Send<IBookFlight>(request);

            return Ok();
        }
    }
}