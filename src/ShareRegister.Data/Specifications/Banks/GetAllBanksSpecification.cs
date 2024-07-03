using ShareRegister.Domain.Common;
using System.Linq.Expressions;

namespace ShareRegister.Data.Specifications.Banks;
internal class GetAllBanksSpecification : Specification<Bank>
{
    public GetAllBanksSpecification(int take,int skip) : base(bank=>bank.IsDeleted==false)
    {
        SetOrderByExpression(bnk => bnk.Name);
        ApplyPaging(skip, take);
    }

    public GetAllBanksSpecification():base(bank=>bank.IsDeleted==false) 
    {
        SetOrderByExpression(bnk => bnk.Name);
    }
}
