using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DataAccess.Repository;

public class GenericRepository<TEntity>(ApiContext _context) : IGenericRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _dbset = _context.Set<TEntity>();

    public async Task<IEnumerable<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> query = _dbset;
        if (include != null) query = include(query);
        if (filter != null) query = query.Where(filter);
        return await query.AsNoTracking().ToListAsync();
    }

    public IQueryable<TEntity> GetAll() => _dbset.AsNoTracking();

    public async Task<TEntity?> GetByIdAsync(Guid id) => await _dbset.FindAsync(id);

    public async Task AddAsync(TEntity entity) => await _dbset.AddAsync(entity);

    public void Update(TEntity entity) => _dbset.Update(entity);

    public void Delete(TEntity entity) => _dbset.Remove(entity);
}