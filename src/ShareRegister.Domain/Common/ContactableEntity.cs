using ShareRegister.Domain.Common.Interfaces;

namespace ShareRegister.Domain.Common;
internal class ContactableEntity : IContactable
{
    public Address Address { get ; protected set; }
    public Email Email { get; protected set; }
    public ISet<TelephoneNumber> TelephoneNumbers { get; protected set; }
}
