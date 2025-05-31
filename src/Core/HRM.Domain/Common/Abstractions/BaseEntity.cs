using HRM.Domain.Common.Interfaces;

namespace HRM.Domain.Common.Abstractions;

public abstract class BaseEntity : IEntity
{
    public Guid Id { get; set; }
}
