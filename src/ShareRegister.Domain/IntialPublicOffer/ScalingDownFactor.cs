namespace ShareRegister.Domain.IntialPublicOffer;
public class ScalingDownFactor
{
    public Guid Id { get; set; }
    public long MinimumNumberOfShares { get; set; }
    public long MaximumNumberOfShares { get; set; }
    public double Rate { get; set; }
}
