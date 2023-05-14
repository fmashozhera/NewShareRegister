using MediatR;
using ShareRegister.Application.Interfaces.Common;

namespace ShareRegister.Application.Companies.Commands;
public class CreateCompanyCommand : ICommand
{
    public string CompanyCode { get; set; }
    public string Name { get; set; }
    public string ISIN { get; set; }
    public string Street { get; set; }
    public string Surburb { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
}
