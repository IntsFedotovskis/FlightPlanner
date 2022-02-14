using Microsoft.AspNetCore.Mvc;
using FlightPlanner.Models;
using FlightPlanner.Storage;
using Microsoft.AspNetCore.Authorization;

namespace FlightPlanner.Controllers
{
    [Route("admin-api")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        private static readonly object Lock = new object();

        [HttpGet]
        [Route("Flights/{id}")]
        [Authorize]
        public IActionResult GetFlights(int id)
        {
            lock (Lock)
            {
                var flight = FlightStorage.GetFlight(id);
                if (flight == null)
                    return NotFound();
                return Ok(flight);
            }
        }

        [HttpDelete]
        [Route("Flights/{id}")]
        [Authorize]
        public IActionResult DeleteFlight(int id)
        {
            lock (Lock)
            {
                FlightStorage.DeleteFlight(id);
                return Ok();
            }
        }

        [HttpPut, Authorize]
        [Route("flights")]
        [Authorize]
        public IActionResult PutFlights(AddFlightRequest request)
        {
            lock (Lock)
            {
                if (!FlightStorage.IsValid(request))
                    return BadRequest();

                if (FlightStorage.Exists(request))
                    return Conflict();

                return Created("", FlightStorage.AddFlight(request));
            }
        }
    }
}