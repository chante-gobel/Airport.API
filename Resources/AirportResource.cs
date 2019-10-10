namespace Airport.API.Resources
{
    public class AirportResource
    {
        public double DistanceInMiles { get; set; }
        public AirportDetailsResource FirstAirportResource { get; set; }
        public AirportDetailsResource SecondAirportResource { get; set; }

    }

    public class AirportDetailsResource
    {
        public string Ident { get; set; }
        public string Name { get; set; }
        public string Icao_Code { get; set; }
        public string Iata_Code { get; set; }
    }
}
