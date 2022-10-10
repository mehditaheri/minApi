using BasicInformation.Core.Caching;
using BasicInformation.Core.Entities;
using BasicInformation.Core.Repositories;
using BasicInformation.Infrastructure.Data;
using BasicInformation.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BasicInformation.Infrastructure.Repositories
{
    public class TblLocationRepository : Repository<TblLocation, long>, ITblLocationRepository
    {
        public TblLocationRepository(BasicInformatinContext context, Func<CacheTech, ICacheService> cacheService) : base(context, cacheService) { }

        //public override DbSet<TblLocation> GetDbSet()
        //{
        //    return _dbContext.TblLocations;
        //}

        public async Task<IReadOnlyList<TblLocation4City>> GetAllCityAsync(long ProvinceId)
        {
            return await _dbContext.Set<TblLocation4City>().Where(p => p.ProvinceId == ProvinceId).ToListAsync();
        }

        public async Task<IReadOnlyList<TblLocation2County>> GetAllCountyAsync()
        {
            return await _dbContext.Set<TblLocation2County>().ToListAsync();
        }

        public async Task<IReadOnlyList<TblLocation3District>> GetAllDistrictAsync()
        {
            return await _dbContext.Set<TblLocation3District>().ToListAsync();
        }

        public async Task<IReadOnlyList<TblLocation1Province>> GetAllProvinceAsync()
        {
            return await _dbContext.Set<TblLocation1Province>().ToListAsync();
        }

        public async Task<IReadOnlyList<TblLocation4RuralDistrict>> GetAllRuralDistrictAsync()
        {
            return await _dbContext.Set<TblLocation4RuralDistrict>().ToListAsync();
        }

        public async Task<IReadOnlyList<TblLocation5Village>> GetAllVillageAsync()
        {
            return await _dbContext.Set<TblLocation5Village>().ToListAsync();
        }
    }
}
