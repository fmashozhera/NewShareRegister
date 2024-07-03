namespace ShareRegister.Domain.Common;
public class BankAccount 
{
    public Guid BankId { get; set; }
    public Guid BranchId { get; set; }
    public Currency Currency { get; set; }
    public string AccountNumber { get; set; }
}
