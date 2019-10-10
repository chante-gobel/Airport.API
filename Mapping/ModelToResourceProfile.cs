using Airport.API.Resources;
using Airport.API.Models;
using AutoMapper;

namespace Airport.API.Mapping
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<AirportDto, AirportDetailsResource>();
        }

    }
}
