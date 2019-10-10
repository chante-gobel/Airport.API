using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Airport.API.Models;
using Microsoft.AspNetCore.Authorization;
using Airport.API.Authorization;
using Airport.API.Adapters;

namespace Airport.API.Controllers
{
    [Route("api/airport")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IAiportServiceAdapter _aiportServiceAdapter;

        public AirportController(IAiportServiceAdapter aiportServiceAdapter)
        {
            _aiportServiceAdapter = aiportServiceAdapter;
        }

        [HttpGet("only-third-party")]
        [Authorize(Policy = Policies.OnlyThirdParties)]
        [Route("[action]")]
        public async Task<IActionResult> GetAirportDistance(string firstAirport, string secondAirport)
        {

            if (string.IsNullOrEmpty(firstAirport) || string.IsNullOrWhiteSpace(secondAirport))
            {
                return BadRequest("You need to specify both airport IATA codes in order to calculate the distance.");
            }

            var airportDistanceDto = new AirportDistanceDto
            {
                FirstAirport = firstAirport,
                SecondAirport = secondAirport
            };
            return Ok(await _aiportServiceAdapter.GetAiportDistanceByCode(airportDistanceDto));
        }
    }
}
