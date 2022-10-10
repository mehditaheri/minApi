using AutoMapper;
using BasicInformation.Application.Responses;
using BasicInformation.Core.Entities; 

namespace BasicInformation.Application.Mapper.Location
{
    public class RuralDistrictMappingProfile : Profile
    {
        public RuralDistrictMappingProfile()
        {
            CreateMap<TblLocation4RuralDistrict, RuralDistrictResponse>().ReverseMap();
        }
    }
}
