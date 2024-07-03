using ShareRegister.Domain.Common;

namespace ShareRegister.Data.Specifications.Companies;
public class GetCompanyByNameSpecification : Specification<Company>
{
    public GetCompanyByNameSpecification(string companyName) : base(company => company.Name == companyName)
    {
    }
}