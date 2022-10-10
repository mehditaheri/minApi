using BasicInformation.Core.Caching;
using BasicInformation.Core.Entities;
using BasicInformation.Core.Repositories;
using BasicInformation.Infrastructure.Data;
using BasicInformation.Infrastructure.Repositories.Base;

namespace BasicInformation.Infrastructure.Repositories
{
    public class TblLocationTypeRepository : Repository<TblLocationType, short>, ITblLocationTypeRepository
    {
        public TblLocationTypeRepository(BasicInformatinContext context, Func<CacheTech, ICacheService> cacheService) : base(context, cacheService) { }
    }
}
