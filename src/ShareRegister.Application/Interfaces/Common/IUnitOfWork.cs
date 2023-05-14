namespace ShareRegister.Application.Interfaces.Common;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
