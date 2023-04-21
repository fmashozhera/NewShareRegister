namespace ShareRegister.Domain.Common;
public class BankBranch : AuditableEntity
{
    public Guid BankId { get; set; }
    public string BranchName { get; set; }
    public string BranchCode { get; set; }
}
