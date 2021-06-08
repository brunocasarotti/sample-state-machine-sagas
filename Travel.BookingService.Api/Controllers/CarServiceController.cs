using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Travel.Flight.Service.Commands;

namespace Travel.BookingService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarServiceController : ControllerBase
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public CarServiceController(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        // GET
        [HttpPost]
        public async Task<IActionResult> Index(IBookCar request)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:book-car"));

            await endpoint.Send<IBookCar>(request);

            return Ok();
        }
    }
}