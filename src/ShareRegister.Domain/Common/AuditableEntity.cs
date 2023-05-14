namespace ShareRegister.Domain.Common;

public abstract class AuditableEntity
{
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; }
    public Guid CreatorId { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public Guid ModifierId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DateDeleted { get; set; }
    public Guid DeletedById { get; set; }
}

