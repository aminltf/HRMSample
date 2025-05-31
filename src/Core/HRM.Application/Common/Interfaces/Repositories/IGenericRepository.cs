using HRM.Domain.Common.Abstractions;

namespace HRM.Application.Common.Interfaces.Repositories;

public interface IGenericRepository<T> where T : BaseAuditableEntity
{
    IQueryable<T> AsQueryable(bool includeDeleted = false);
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<T>> GetAllDeletedAsync(CancellationToken cancellationToken);
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken); // Soft Delete
    Task RestoreAsync(Guid id, CancellationToken cancellationToken);
}
