using AutoMapper;
using BasicInformation.Application.Features;
using BasicInformation.Application.InputModel;
using BasicInformation.Application.Responses;
using BasicInformation.Core.Entities;

namespace BasicInformation.Application.Mapper.Location
{
    public class LocationMappingProfile : Profile
    {
        public LocationMappingProfile()
        {
            CreateMap<TblLocation, LocationResponse>().ReverseMap();

            CreateMap<UpdateLocation.Command, LocationInputModel>().ReverseMap();
            CreateMap<AddLocation.Command, LocationInputModel>().ReverseMap();
        }
    }
}
