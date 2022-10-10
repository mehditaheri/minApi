using AutoMapper;
using BasicInformation.Application.Responses;
using BasicInformation.Core.Entities; 

namespace BasicInformation.Application.Mapper.Location
{
    public class DistrictMappingProfile : Profile
    {
        public DistrictMappingProfile()
        {
            CreateMap<TblLocation3District, DistrictResponse>().ReverseMap();
        }
    }
}
