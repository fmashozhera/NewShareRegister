using ShareRegister.Domain.Common;

namespace ShareRegister.Data.Specifications.Companies;
public class GetActiveCompaniesWithTelephoneNumbersSpecification : Specification<Company>
{
    public GetActiveCompaniesWithTelephoneNumbersSpecification() : base(company=>!company.IsDeleted)
    {
        AddInclude(company=>company.TelephoneNumbers);
    }
}
