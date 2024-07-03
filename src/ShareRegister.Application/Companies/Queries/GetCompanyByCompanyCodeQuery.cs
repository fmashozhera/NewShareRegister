using ShareRegister.Application.Companies.Dtos;
using ShareRegister.Application.Interfaces.Common;
using ShareRegister.Domain.Common;


namespace ShareRegister.Application.Companies.Queries;
public class GetCompanyByCompanyCodeQuery : ICommand<CompanyDto>
{
    public string CompanyCode { get; set; }
}
