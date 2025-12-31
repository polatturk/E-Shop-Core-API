using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll(); 
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method); 
        Task<T> GetByIdAsync(Guid id); 
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);

        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);

        bool Update(T entity);
        bool Remove(T entity);
        void RemoveRange(List<T> entities);

        Task<int> SaveAsync();
    }
}
