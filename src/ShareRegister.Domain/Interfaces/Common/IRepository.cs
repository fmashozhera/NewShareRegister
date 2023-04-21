namespace ShareRegister.Domain.Interfaces.Common;
public interface IRepository<T>
{
    T Add(T entity);
    T Update(T entity);
    bool Delete(T entity);
    List<T> GetAll();
    List<T> FindAll(Func<>);
}
