using ShareRegister.Application.Companies.Dtos;
using ShareRegister.Application.Interfaces.Common;

namespace ShareRegister.Application.Companies.Commands;
public class UpdateCompanyCommand : ICommand<CompanyDto>
{
    public CreateCompanyDto Company { get; set; }
}
