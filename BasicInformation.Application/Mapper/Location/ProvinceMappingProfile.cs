using AutoMapper;
using BasicInformation.Application.Responses;
using BasicInformation.Core.Entities; 

namespace BasicInformation.Application.Mapper.Location
{
    public class ProvinceMappingProfile : Profile
    {
        public ProvinceMappingProfile()
        {
            CreateMap<TblLocation1Province, ProvinceResponse>().ReverseMap();
        }
    }
}
