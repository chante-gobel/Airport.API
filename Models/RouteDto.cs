using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.API.Models
{
    public class RouteDto
    {
        public Totals Totals { get; set; }
    }

    public class Totals
    {
        public string Distance_Km { get; set; }
        public string Distance_Nm { get; set; }
        public string Flight_time_min { get; set; }
        public string Speed_kmh { get; set; }
        public string Speed_kts { get; set; }
    }
}
