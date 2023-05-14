namespace ShareRegister.Domain.Common.Interfaces;

public interface IContactable
{
    public Address Address { get; }
    public Email Email { get; }
    public ISet<TelephoneNumber> TelephoneNumbers { get; }
}
