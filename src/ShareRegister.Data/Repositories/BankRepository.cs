using ShareRegister.Application.Banks.Queries;
using ShareRegister.Data.Common;
using ShareRegister.Data.Specifications.Banks;
using ShareRegister.Domain.Common;

namespace ShareRegister.Data.Repositories;
public class BankRepository : Repository<Bank>, IBankRepository
{

    public BankRepository(ApplicationDbContext context):base(context)
    {        
    }

    public IEnumerable<Bank> GetAll(int take, int skip)
    {
        GetAllBanksSpecification spec = new GetAllBanksSpecification(take, skip);
        return ApplySpecification(spec);
    }

    public Bank GetByCode(string bankCode)
    {
        GetBankByBankCodeSpecification spec = new GetBankByBankCodeSpecification(bankCode);
        return ApplySpecification(spec).FirstOrDefault();
    }

    public Bank GetByName(string name)
    {
        GetBankByNameSpecification spec = new GetBankByNameSpecification(name);
        return ApplySpecification(spec).FirstOrDefault();
    }
}
