using Microsoft.EntityFrameworkCore;
using ShareRegister.Application.Interfaces.Common;
using System.Linq.Expressions;
using ShareRegister.Data.Specifications;
using ShareRegister.Domain.Common.Interfaces;

namespace ShareRegister.Data.Common;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public void AddRangeAsync(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().AddRangeAsync(entities);
    }

    public IEnumerable<TEntity> Find(ISpecification<TEntity> specification = null)
    {
        return ApplySpecification(specification);
    }

    public TEntity GetById(Guid id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    protected IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
    {
        return SpecificationEvaluator.GetQuery(_context.Set<TEntity>().AsQueryable(), spec);
    }
}
