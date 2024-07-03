using ShareRegister.Domain.Common;

namespace ShareRegister.Data.Specifications.Companies;

public class GetCompanyByIdSpecification : Specification<Company>
{
    public GetCompanyByIdSpecification(Guid Id) : base(c=>c.Id==Id)
    {
    }
}
