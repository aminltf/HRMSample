namespace Application.Common.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository Employees { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
