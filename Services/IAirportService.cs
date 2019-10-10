using RestEase;
using System.Threading.Tasks;
using Airport.API.Models;

namespace Airport.API.Services
{
    [Header("Content-Type", "application/json")]
    [Header("X-RapidAPI-Key", "1fcf0a69c8mshd1bed658a580b49p14a7eajsn248699c2fcc1")]
    public interface IAirportService
    {
        [Path("icao_iata")]
        string icao_iata { get; set; }

        [Get("read/{icao_iata}")]
        Task<AirportDto> ReadAsync();

        [Path("route")]
        string route { get; set; }

        [Path("speed")]
        string speed { get; set; }

        [Get("route/{route}/{speed}")]
        Task<RouteDto> RouteAsync();
    }
}