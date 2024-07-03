using ShareRegister.Application.Companies.Dtos;
using ShareRegister.Application.Interfaces.Common;

namespace ShareRegister.Application.Companies.Queries;
public class GetCompanyByISINQuery : ICommand<CompanyDto>
{
    public string ISIN { get; set; }
}
