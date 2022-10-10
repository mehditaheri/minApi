using BasicInformation.Core.Base;
using BasicInformation.Core.Caching;
using BasicInformation.Core.Entities.Base;
using BasicInformation.Core.Repositories.Base;
using BasicInformation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BasicInformation.Infrastructure.Repositories.Base
{
    public class Repository<T, E> : IRepository<T, E> where T : class, IIdentityObject<E>
        //where T : IIdentityObject<E>
    {
        protected readonly static CacheTech cacheTech = CacheTech.Memory;
        protected readonly BasicInformatinContext _dbContext;

        protected readonly Func<CacheTech, ICacheService> _cacheService;
        protected readonly string cacheKey = $"{typeof(T)}";
        public Repository(BasicInformatinContext dbContext
            , Func<CacheTech, ICacheService> cacheService)
        {
            _dbContext = dbContext;
            _cacheService = cacheService;
        }

        virtual public DbSet<T> GetDbSet()
        {
            return _dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await GetDbSet().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            GetDbSet().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await GetDbSet().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await GetDbSet().Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(E id)
        {
            return await GetDbSet().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetPagedAsync(PagedQueryRequest pagingParam, Expression<Func<T, bool>> expression)
        {
            var skip = (pagingParam.Page - 1) * pagingParam.Size;
            return await GetDbSet().Where(expression)
                .OrderByDescending(p => p.Id).Skip(skip).Take(pagingParam.Size).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetPagedAsync(PagedQueryRequest pagingParam)
        {
            var skip = (pagingParam.Page - 1) * pagingParam.Size;
            return await GetDbSet()
                .OrderByDescending(p => p.Id).Skip(skip).Take(pagingParam.Size).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            GetDbSet().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
