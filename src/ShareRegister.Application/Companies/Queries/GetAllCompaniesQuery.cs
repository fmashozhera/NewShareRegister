using ShareRegister.Application.Companies.Dtos;
using ShareRegister.Application.Interfaces.Common;
using ShareRegister.Domain.Common;

namespace ShareRegister.Application.Companies.Queries;
public class GetAllCompaniesQuery : ICommand<List<CompanyDto>>
{
    public int Take { get; set; }
    public int Skip { get; set; }
}
