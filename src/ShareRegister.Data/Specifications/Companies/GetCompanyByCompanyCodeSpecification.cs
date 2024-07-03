using ShareRegister.Data.Specifications;
using ShareRegister.Domain.Common;

namespace ShareRegister.Application.Companies.Specifications;
public class GetCompanyByCompanyCodeSpecification : Specification<Company>
{
    public GetCompanyByCompanyCodeSpecification(string companyCode) : base(company=>company.CompanyCode == companyCode)
    {    
    }
}
