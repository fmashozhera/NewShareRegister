using ShareRegister.Application.Companies.Dtos;
using ShareRegister.Application.Interfaces.Common;
using ShareRegister.Domain.Common;

namespace ShareRegister.Application.Companies.Commands;
public class CreateCompanyCommand : ICommand<CompanyDto>
{
    public CreateCompanyDto CompanyData { get; set; }
}
