using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airport.API.Models
{
    public class AirportDistanceDto
    {
        public string FirstAirport { get; set; }
        public string SecondAirport { get; set; }
    }
}
