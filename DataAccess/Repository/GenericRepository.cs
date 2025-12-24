using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    using DataAccess;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Linq.Expressions;

    namespace DataAccess.Repositories
    {
        public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
        {
            private readonly ApiContext _context;
            private readonly DbSet<TEntity> _dbset;

            public GenericRepository(ApiContext context)
            {
                _context = context;
                _dbset = context.Set<TEntity>();
            }

            #region Expression-Bodied (Tek İşlem)
            public IQueryable<TEntity> GetAll() => _dbset.AsNoTracking();

            public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method)
                => _dbset.Where(method).AsNoTracking();

            public async Task<TEntity> GetByIdAsync(Guid id)
                => await _dbset.FindAsync(id); 

            public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method)
                => await _dbset.AsNoTracking().FirstOrDefaultAsync(method);
            #endregion

            #region Statement Block (Çoklu İşlem / Kontrol)
            public async Task<bool> AddAsync(TEntity entity)
            {
                EntityEntry<TEntity> entityEntry = await _dbset.AddAsync(entity);
                return entityEntry.State == EntityState.Added;
            }

            public async Task<bool> AddRangeAsync(List<TEntity> entities)
            {
                await _dbset.AddRangeAsync(entities);
                return true;
            }

            public bool Update(TEntity entity)
            {
                EntityEntry entityEntry = _dbset.Update(entity);
                return entityEntry.State == EntityState.Modified;
            }

            public bool Remove(TEntity entity)
            {
                EntityEntry<TEntity> entityEntry = _dbset.Remove(entity);
                return entityEntry.State == EntityState.Deleted;
            }

            public void RemoveRange(List<TEntity> entities)
            {
                _dbset.RemoveRange(entities);
            }
            #endregion

            #region Database Save Operation
            public async Task<int> SaveAsync()
                => await _context.SaveChangesAsync();
            #endregion
        }
    }
}
