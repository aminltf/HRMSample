using Application.Common.Interfaces.Repositories;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IEmployeeRepository Employees { get; }

    public UnitOfWork(AppDbContext context, IEmployeeRepository employeeRepository)
    {
        _context = context;
        Employees = employeeRepository;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose() => _context.Dispose();
}
