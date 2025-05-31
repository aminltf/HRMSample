#nullable disable

using HRM.Application.Common.Interfaces.Repositories;
using HRM.Domain.Common.Abstractions;
using HRM.Infrastructure.Persistence.Contexts;
using System.Collections;

namespace HRM.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;
    private Hashtable _repositories;

    public UnitOfWork(
        ApplicationContext context,
        IEmployeeRepository employeeRepository)
    {
        _context = context;
        Employee = employeeRepository;
    }

    public IEmployeeRepository Employee { get; }

    public async ValueTask DisposeAsync()
            => await _context.DisposeAsync();

    public IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity
    {
        if (_repositories == null)
            _repositories = new Hashtable();

        var type = typeof(T).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(GenericRepository<T>);
            var repositoryInstance = Activator.CreateInstance(repositoryType, _context);

            _repositories.Add(type, repositoryInstance);
        }

        return (IGenericRepository<T>)_repositories[type];
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
