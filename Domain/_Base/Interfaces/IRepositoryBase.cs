using System.Linq.Expressions;

namespace Domain._Base.Interfaces;

public interface IRepositoryBase<TEntity>
{
    Task<bool> EntityExistsByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(TEntity obj);
    Task AddAndSaveAsync(TEntity obj);
    void Add(TEntity obj);
    Task AddManyAsync(IEnumerable<TEntity> entities);
    void Remove(TEntity obj);
    void RemoveMany(IEnumerable<TEntity> entities); 
    void Save();
    Task SaveAsync();
}