using HRM.Domain.Common.Abstractions;

namespace HRM.Application.Common.Interfaces.Repositories;

public interface IUnitOfWork : IAsyncDisposable
{
    IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;

    IEmployeeRepository Employee { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
