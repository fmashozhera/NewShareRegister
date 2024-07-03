namespace ShareRegister.Domain.Common;
public abstract class  Investor : AuditableEntity
{
    public string IdentificationNumber { get; protected set; }
    public IdentificationType IdentificationType { get; protected set; }
    public ICollection<BankAccount> BankAccounts { get; protected set; } = new List<BankAccount>();
    public Address Address { get; protected set; }
    public Email Email { get; protected set; }
    public TelephoneNumber TelephoneNumber { get;protected set; }
}
