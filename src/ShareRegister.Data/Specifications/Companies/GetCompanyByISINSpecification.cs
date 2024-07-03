using ShareRegister.Domain.Common;

namespace ShareRegister.Data.Specifications.Companies;

public class GetCompanyByISINSpecification : Specification<Company>
{
    public GetCompanyByISINSpecification(string ISIN) : base(company => company.ISIN == ISIN)
    {
    }
}
