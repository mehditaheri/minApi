using BasicInformation.Core.Entities;
using BasicInformation.Core.Repositories.Base;

namespace BasicInformation.Core.Repositories
{
    public interface ITblLocationRepository : IRepository<TblLocation, long>
    {
        Task<IReadOnlyList<TblLocation1Province>> GetAllProvinceAsync();
        Task<IReadOnlyList<TblLocation2County>> GetAllCountyAsync();
        Task<IReadOnlyList<TblLocation3District>> GetAllDistrictAsync();
        Task<IReadOnlyList<TblLocation4City>> GetAllCityAsync(long ProvinceId);
        Task<IReadOnlyList<TblLocation4RuralDistrict>> GetAllRuralDistrictAsync();
        Task<IReadOnlyList<TblLocation5Village>> GetAllVillageAsync(); 
    }
}
