namespace ShareRegister.Domain.Common;
public class Nominee : AuditableEntity
{
    public string NomineeCode { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
    public ICollection<TelephoneNumber> TelephoneNumbers { get; set; }
}
