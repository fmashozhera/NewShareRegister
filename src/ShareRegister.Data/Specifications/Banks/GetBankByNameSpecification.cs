using ShareRegister.Domain.Common;

namespace ShareRegister.Data.Specifications.Banks;
public class GetBankByNameSpecification : Specification<Bank>
{
    public GetBankByNameSpecification(string name):base(bank=>bank.Name==name)
    {        
    }
}
