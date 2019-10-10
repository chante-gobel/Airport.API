using Airport.API.Models;
using Airport.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.API.Adapters
{
    public interface IAiportServiceAdapter
    {
        public Task<AirportResource> GetAiportDistanceByCode(AirportDistanceDto airportsInfo); 
    }
}
