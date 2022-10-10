using AutoMapper;
using BasicInformation.Application.Responses;
using BasicInformation.Core.Entities; 

namespace BasicInformation.Application.Mapper.Location
{
    public class CityMappingProfile : Profile
    {
        public CityMappingProfile()
        {
            CreateMap<TblLocation4City, CityResponse>().ReverseMap();
        }
    }
}
