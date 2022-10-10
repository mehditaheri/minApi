using BasicInformation.Core.Base;
using System.Linq.Expressions;

namespace BasicInformation.Core.Repositories.Base
{
    //public interface IPagedRepository<T, Entity> where T : IPersistentObject<Entity>
    //{
    //    Task<IReadOnlyList<T>> GetPagedAsync(PagedQueryRequest pagingParam);
    //}

    //public interface IQueryPagedRepository<T, Entity> where T : IPersistentObject<Entity>
    //{
    //    Task<IReadOnlyList<T>> GetPagedAsync(PagedQueryRequest pagingParam, Expression<Func<T, bool>> expression);

    //    Task<IReadOnlyList<T>> GetPagedAsync(PagedQueryRequest pagingParam);
    //}

    public interface IRepository<T, E> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression);
        Task<IReadOnlyList<T>> GetPagedAsync(PagedQueryRequest pagingParam, Expression<Func<T, bool>> expression);
        Task<IReadOnlyList<T>> GetPagedAsync(PagedQueryRequest pagingParam);

        Task<T> GetByIdAsync(E id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
