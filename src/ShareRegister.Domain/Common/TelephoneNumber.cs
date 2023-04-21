namespace ShareRegister.Domain.Common;
public class TelephoneNumber
{
    public Guid Id { get; set; }
    public string Value { get; set; }
    public TelephoneNumberType TelephoneNumberType { get; set; }
}
