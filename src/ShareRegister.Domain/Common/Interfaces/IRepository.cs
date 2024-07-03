using System.Linq.Expressions;

namespace ShareRegister.Domain.Common.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{

    IEnumerable<TEntity> Find(ISpecification<TEntity> specification = null);

    Task AddAsync(TEntity entity);
    void AddRangeAsync(IEnumerable<TEntity> entities);

    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    TEntity GetById(Guid id);
}
