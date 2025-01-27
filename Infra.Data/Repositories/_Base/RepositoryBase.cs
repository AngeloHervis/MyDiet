using System.Linq.Expressions;
using Domain._Base.Interfaces;
using Domain._Base.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories._Base;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : Entity
{
    private readonly DbSet<TEntity> _dbSet;
    private readonly MyDietContext _context;

    protected RepositoryBase(MyDietContext context)
    {
        _dbSet = context.Set<TEntity>();
        _context = context;
    }
    
    public async Task<bool> EntityExistsByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await _dbSet.AsQueryable().AnyAsync(e => e.Id.Equals(id), cancellationToken: cancellationToken);

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken) =>
        await _dbSet.Where(predicate).ToListAsync(cancellationToken: cancellationToken);

    public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await _dbSet.FindAsync(id);
    
    public async Task AddAsync(TEntity obj) => await _dbSet.AddAsync(obj);
    
    public async Task AddAndSaveAsync(TEntity obj)
    {
        await AddAsync(obj);
        await _context.SaveChangesAsync();
    }

    public void Add(TEntity obj) => _dbSet.Add(obj);

    public async Task AddManyAsync(IEnumerable<TEntity> entities) => await _dbSet.AddRangeAsync(entities);

    public void Remove(TEntity obj) => _dbSet.Remove(obj);
        
    public void RemoveMany(IEnumerable<TEntity> entities) => _dbSet.RemoveRange(entities);

    public void Save() => _context.SaveChanges();
    public async Task SaveAsync() => await _context.SaveChangesAsync();
}