namespace ShareRegister.Domain.Common;
public class Broker : AuditableEntity
{
    public string BrokerCode { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
    public ICollection<TelephoneNumber> TelephoneNumbers { get; set; }
}
