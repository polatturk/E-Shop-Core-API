using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);

    Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

    Task AddAsync(T entity); 
    void Update(T entity);
    void Delete(T entity);
}