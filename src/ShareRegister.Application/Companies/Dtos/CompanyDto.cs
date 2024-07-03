using ShareRegister.Domain.Common;

namespace ShareRegister.Application.Companies.Dtos;

public class CompanyDto : BaseDto
{
    public Guid Id { get; set; }
    public string CompanyCode { get; set; }
    public string Name { get; set; }
    public string ISIN { get; set; }
    public string Street { get; set; }
    public string Surburb { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string? PostalCode { get; set; }
    public string Email { get; set; }
    public IDictionary<string, TelephoneNumberType> TelephoneNumbers { get; set; }
}
