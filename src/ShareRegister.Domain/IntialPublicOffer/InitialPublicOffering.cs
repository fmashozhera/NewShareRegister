using ShareRegister.Domain.Common;

namespace ShareRegister.Domain.IntialPublicOffer;
public class InitialPublicOffering : AuditableEntity
{
    public long IssuedShareCapital { get; set; }
    public long AuthorisedShareCapital { get; set; }
    public Currency Currency { get; set; }
    public double SharePrice { get; set; }
    public Guid UnderwriterName { get; set; }
    public Guid UnderwriterBankId { get; set; }
    public Guid UnderwriterBankBranchId { get; set; }
    public string UnderwriterAccountNumber { get; set; }
    public Guid BankId { get; set; }
    public Guid BankBranchId { get; set; }
    public string AccountNumber { get; set; }
    public Guid CompanyId { get; set; }
}
