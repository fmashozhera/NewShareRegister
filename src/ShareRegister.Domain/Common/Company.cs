namespace ShareRegister.Domain.Common;
public class Company : AuditableEntity
{
    private ICollection<TelephoneNumber> _telephoneNumbers;
    public string CompanyCode { get; set; }
    public string Name { get; set; }
    public string ISIN { get; set; }
    public Address Address { get; set; }
    public Email Email { get; set; }
    public ICollection<TelephoneNumber> TelephoneNumbers { get => _telephoneNumbers; }


}
