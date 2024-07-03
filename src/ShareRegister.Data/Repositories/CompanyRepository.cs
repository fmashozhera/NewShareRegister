using ShareRegister.Application.Companies.Queries;
using ShareRegister.Application.Companies.Specifications;
using ShareRegister.Data.Common;
using ShareRegister.Data.Specifications.Companies;
using ShareRegister.Domain.Common;

namespace ShareRegister.Data.Repositories;
public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    public CompanyRepository(ApplicationDbContext context):base(context)
    {            
    }

    public List<Company> GetAllCompanies(int skip,int take)
    {
        GetAllCompaniesSpecification spec = new GetAllCompaniesSpecification(skip,take);
        return ApplySpecification(spec).ToList();
    }

    public List<Company> GetAllCompanies()
    {
        GetAllCompaniesSpecification spec = new GetAllCompaniesSpecification();
        return ApplySpecification(spec).ToList();
    }

    public Company GetCompanyByCompanyCode(string companyCode)
    {
        GetCompanyByCompanyCodeSpecification spec = new GetCompanyByCompanyCodeSpecification(companyCode);
        return ApplySpecification(spec).FirstOrDefault();
    }

    public Company GetCompanyByISIN(string ISIN)
    {
        GetCompanyByISINSpecification spec = new GetCompanyByISINSpecification(ISIN);
        return ApplySpecification(spec).FirstOrDefault();
    }

    public Company GetById(Guid id)
    {
        GetCompanyByIdSpecification spec = new GetCompanyByIdSpecification(id);
        return ApplySpecification(spec).FirstOrDefault();
    }

    public Company GetCompanyByName(string companyName)
    {
        GetCompanyByNameSpecification spec  = new GetCompanyByNameSpecification(companyName);
        return ApplySpecification(spec).FirstOrDefault();
    }
}
