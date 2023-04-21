namespace ShareRegister.Domain.Common;
public class BankAccount 
{
    public Guid Id { get; set; }
    public Guid BankId { get; set; }
    public Guid BankBranchId { get; set; }
    public Currency Currency { get; set; }
    public string AccountNumber { get; set; }
}
