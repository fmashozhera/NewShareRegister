using ShareRegister.Domain.Common;
using ShareRegister.Domain.Common.Interfaces;

namespace ShareRegister.Application.Companies.Queries;
public interface ICompanyRepository : IRepository<Company>
{
    Company GetCompanyByCompanyCode(string companyCode);
    Company GetCompanyByISIN(string companyCode);    
    Company GetCompanyByName(string companyName);
    List<Company> GetAllCompanies();
    List<Company> GetAllCompanies(int skip,int take);
}
