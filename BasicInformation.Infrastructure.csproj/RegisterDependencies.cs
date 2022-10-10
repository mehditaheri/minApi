using BasicInformation.Core.Repositories;
using BasicInformation.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection; 

namespace BasicInformation.Infrastructure
{
    public static class RegisterDependencies
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITblLocationRepository, TblLocationRepository>();
        }
    }
}
