using AutoMapper; 

namespace BasicInformation.Application.Mapper.Location
{
    public class CountyMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

               cfg.AddProfile<CountyMappingProfile>(); 
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
