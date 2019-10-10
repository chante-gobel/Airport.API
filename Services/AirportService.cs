using RestEase;
using System.Threading.Tasks;
using Airport.API.Models;

namespace Airport.API.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAirportService service;
        public AirportService()
        {
            service = RestClient.For<IAirportService>("https://greatcirclemapper.p.rapidapi.com/airports/");
        }

        public string icao_iata { get; set; }
        public string route { get; set ; }
        public string speed { get; set ; }

        public async Task<AirportDto> ReadAsync()
        {
            service.icao_iata = icao_iata;

            return await service.ReadAsync(); ;
        }

        public async Task<RouteDto> RouteAsync()
        {
            service.speed = "510"; // Required by api call so I've just hardcoded the average speed
            service.route = route;

            return await service.RouteAsync();
        }
    }
}
