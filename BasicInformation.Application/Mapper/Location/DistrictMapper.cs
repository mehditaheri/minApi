using AutoMapper; 

namespace BasicInformation.Application.Mapper.Location
{
    public class DistrictMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

               cfg.AddProfile<DistrictMappingProfile>(); 
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
