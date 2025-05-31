using HRM.Domain.Common.Interfaces;

namespace HRM.Domain.Common.Abstractions;

public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity
{
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string? ModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }

    public void Delete(string deletedBy)
    {
        IsDeleted = true;
        DeletedBy = deletedBy;
        DeletedAt = DateTime.UtcNow;
        ModifiedBy = null;
        ModifiedAt = null;
    }

    public void Restore(string modifiedBy)
    {
        IsDeleted = false;
        DeletedBy = null;
        DeletedAt = null;
        ModifiedBy = modifiedBy;
        ModifiedAt = DateTime.UtcNow;
    }
}
