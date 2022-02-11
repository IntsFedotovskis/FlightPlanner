using FlightPlanner.Models;
using FlightPlanner.Storage;
using Microsoft.AspNetCore.Mvc;
using PageResult = FlightPlanner.Models.PageResult;

namespace FlightPlanner.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        [HttpGet]
        [Route("Airports")]
        public IActionResult SearchAirports(string search)
        {
            var airport = FlightStorage.FindAirports(search);
            return Ok(airport);
        }

        [HttpPost]
        [Route("flights/search")]
        public IActionResult SearchFlights(SearchFlightRequest request)
        {
            if (!FlightRequest.IsValid(request))
                return BadRequest();
            return Ok(new PageResult());
        }

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult FindFlightById(int id)
        {
            var flight = FlightStorage.GetFlight(id);

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }
    }
}