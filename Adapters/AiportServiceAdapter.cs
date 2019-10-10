using Airport.API.Services;
using System;
using AutoMapper;
using System.Threading.Tasks;
using Airport.API.Resources;
using Airport.API.Models;

namespace Airport.API.Adapters
{
    public class AiportServiceAdapter: IAiportServiceAdapter
    {
        IAirportService _airportService;
        private readonly IMapper _mapper;

        public AiportServiceAdapter(IAirportService airportService, IMapper mapper)
        {
            _airportService = airportService;
            _mapper = mapper;
        }

        public async Task<AirportResource> GetAiportDistanceByCode(AirportDistanceDto airportsInfo)
        {
            // Get Icao code in order to calculate distance between two airports
            var firstAirportIcaoCode = await GetAirportIcaoCode(airportsInfo.FirstAirport);
            var secondAirportIcaoCode = await GetAirportIcaoCode(airportsInfo.SecondAirport);

            // Calculate route and get distance in kms
            _airportService.route = $"{firstAirportIcaoCode.Icao_Code}-{ secondAirportIcaoCode.Icao_Code}";

            var distanceInKms = ((await _airportService.RouteAsync()).Totals.Distance_Km);

            // Convert distance in kms to miles
            var distanceInMiles = ConvertKilometersToMiles(distanceInKms);

            return new AirportResource
            {
                DistanceInMiles = distanceInMiles,
                FirstAirportResource = _mapper.Map<AirportDto, AirportDetailsResource>(firstAirportIcaoCode),
                SecondAirportResource = _mapper.Map<AirportDto, AirportDetailsResource>(secondAirportIcaoCode)
            };
        }

        public async Task<AirportDto> GetAirportIcaoCode(string iataCode)
        {
            _airportService.icao_iata = iataCode;
            return (await _airportService.ReadAsync());
        }

        public double ConvertKilometersToMiles (string distanceInKms)
        {
           var distanceInMiles = double.Parse(distanceInKms, System.Globalization.CultureInfo.InvariantCulture) / 1.609344;
           return Math.Round(distanceInMiles, 2);
        }
    }
}
