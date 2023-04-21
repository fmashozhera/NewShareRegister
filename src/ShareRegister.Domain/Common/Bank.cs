namespace ShareRegister.Domain.Common;
public class Bank : AuditableEntity
{
    public string BankCode { get; set; }
    public string Name { get; set; }    
    public Address Address { get; set; }
    public ICollection<TelephoneNumber> TelephoneNumbers { get; set; }
}
