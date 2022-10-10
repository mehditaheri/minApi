using AutoMapper;
using BasicInformation.Application.InputModel; 

namespace BasicInformation.Application.Mapper.Location
{
    public class LocationModelMappingProfile : Profile
    {
        public LocationModelMappingProfile()
        {
            CreateMap<LocationInputModel, BaseLocationInputModel>().ReverseMap();
        }
    }
}
