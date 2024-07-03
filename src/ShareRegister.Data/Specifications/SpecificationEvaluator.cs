using Microsoft.EntityFrameworkCore;
using ShareRegister.Domain.Common.Interfaces;

namespace ShareRegister.Data.Specifications;
public static class SpecificationEvaluator
{
    public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQueryable, ISpecification<TEntity> specification) where TEntity : class
    {
        if (specification.Criteria is not null)
        { 
            inputQueryable = inputQueryable.Where(specification.Criteria); 
        }

        inputQueryable = specification.Includes.Aggregate(inputQueryable, (current, include) =>  current.Include(include));

        if(specification.OrderBy is not null)
            inputQueryable.OrderBy(specification.OrderBy);
        else if(specification.OrderByDescending  is not null)
            inputQueryable.OrderByDescending(specification.OrderByDescending);

        if (specification.GroupBy != null)
        {
            inputQueryable = inputQueryable.GroupBy(specification.GroupBy).SelectMany(x => x);
        }

        if (specification.IsPagingEnabled)
        {
            inputQueryable = inputQueryable.Skip(specification.Skip)
                         .Take(specification.Take);
        }

        return inputQueryable;
    }
}

