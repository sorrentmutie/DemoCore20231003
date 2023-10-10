namespace DemoMVC.Core.Interfaces;

public interface IRepository<TEntity, TKey> where TEntity : IEntity<TKey>
{
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TKey id);
    Task<TEntity?> GetByIdAsync(TKey id);
    IQueryable<TEntity> GetAll();
}
