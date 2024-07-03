using ShareRegister.Domain.Common;

namespace ShareRegister.Application.Banks.Dtos;
public class BankDto
{
    public string BankCode { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string Surburb { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string? PostalCode { get; set; }    
    public IDictionary<string, TelephoneNumberType> TelephoneNumbers { get; set; }
}
