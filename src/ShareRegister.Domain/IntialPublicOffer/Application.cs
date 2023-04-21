using ShareRegister.Domain.Common;

namespace ShareRegister.Domain.IntialPublicOffer;
public class Application : AuditableEntity
{
    public long NumberOfShares { get; set; }
    public double Amount { get; set; }
    public string PaymentReference { get; set; }
    public Guid InvestorId { get; set; }
    public Guid ScalingDownFactorId { get; set; }
    public double AmountRepaid { get; set; }
    public long NumberOfSharesAlloted { get; set; }
    public string RepaymentReference { get; set; }
    public Guid BankId { get; set; }
    public Guid BankBranchId { get; set; }
    public string AccountNumber { get; set; }
    public Guid ApplicationBatchId { get; set; }
}
