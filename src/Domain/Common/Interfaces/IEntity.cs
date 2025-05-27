namespace Domain.Common.Interfaces;

public interface IEntity
{
    Guid Id { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime? ModifiedAt { get; set; }
    bool IsDeleted { get; set; }
}
