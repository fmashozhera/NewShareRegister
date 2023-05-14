using System.Linq.Expressions;

namespace ShareRegister.Application.Interfaces.Common;

public interface IRepository<T> where T : class
{
    Task AddAsync(T entity);    
    void DeleteAsync(T entity);
    Task<List<T>> GetAll();
    Task<List<T>> FindAll(Expression<Func<T,bool>> query);
    Task<T> GetById(Guid id);
}
