using ShareRegister.Domain.Common;

namespace ShareRegister.Data.Specifications.Companies;
public class GetAllCompaniesSpecification : Specification<Company>
{
    public GetAllCompaniesSpecification(int skip,int take) : base(company => company.IsDeleted == false)
    {
        SetOrderByExpression(company => company.CompanyCode);
        ApplyPaging(skip,take);
    }

    public GetAllCompaniesSpecification() : base(company => company.IsDeleted == false)
    {
        SetOrderByExpression(company => company.CompanyCode);        
    }
}
