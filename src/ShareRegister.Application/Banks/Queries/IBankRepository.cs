using ShareRegister.Domain.Common;

namespace ShareRegister.Application.Banks.Queries;
public interface IBankRepository
{
    Bank GetByName(string name);

    Bank GetByCode(string code);

    IEnumerable<Bank> GetAll(int take,int skip);
}
