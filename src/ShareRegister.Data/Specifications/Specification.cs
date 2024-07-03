using ShareRegister.Domain.Common.Interfaces;
using System.Linq.Expressions;

namespace ShareRegister.Data.Specifications;
public abstract class Specification<TEntity> : ISpecification<TEntity>
{
    public Expression<Func<TEntity,bool>>? Criteria { get;private  set; }

    public List<Expression<Func<TEntity, object>>> Includes { get; private set; } = new();

    public Expression<Func<TEntity,object>>? OrderBy { get; private set; }

    public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }

    public Expression<Func<TEntity, object>>? GroupBy { get; private set; }

public int Take { get; private set; }
    public int Skip { get; private set; }
    public bool IsPagingEnabled { get; private set; }    

    public Specification(Expression<Func<TEntity, bool>> criteria)
    {
        Criteria = criteria;
    }

    public void AddInclude(Expression<Func<TEntity, object>> include)
        => Includes.Add(include);

    public void SetOrderByExpression(Expression<Func<TEntity, object>> orderBy)
        => this.OrderBy = orderBy;

    public void SetOrderByDescendingExpression(Expression<Func<TEntity, object>> orderByDescending)
        => this.OrderBy = orderByDescending;

    public void SetGroupBy(Expression<Func<TEntity, object>> groupBy)
        => this.GroupBy = groupBy;

    protected virtual void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
    }
}
