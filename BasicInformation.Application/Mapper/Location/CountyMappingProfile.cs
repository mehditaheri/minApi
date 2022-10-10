using AutoMapper;
using BasicInformation.Application.Responses;
using BasicInformation.Core.Entities; 

namespace BasicInformation.Application.Mapper.Location
{
    public class CountyMappingProfile : Profile
    {
        public CountyMappingProfile()
        {
            CreateMap<TblLocation2County, CountyResponse>().ReverseMap();
        }
    }
}
