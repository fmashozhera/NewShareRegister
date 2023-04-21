using ShareRegister.Domain.Common;

namespace ShareRegister.Domain.IntialPublicOffer;
public class ApplicationBatch : AuditableEntity
{
    public string BatchNumber { get; }
    public int NumberOfApplications { get; set; }
    public double Amount { get; set; }
    public long NumberOfShares { get; set; }
    public Type SubmitterType { get; set; }
    public Guid SubmitterId { get; set; }
    public ICollection<Application> Applications { get; set; }
}
