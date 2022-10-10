using AutoMapper;
using BasicInformation.Application.Responses;
using BasicInformation.Core.Entities; 

namespace BasicInformation.Application.Mapper.Location
{
    public class VillageMappingProfile : Profile
    {
        public VillageMappingProfile()
        {
            CreateMap<TblLocation5Village, VillageResponse>().ReverseMap();
        }
    }
}
