using HRM.Application.Common.Interfaces.Repositories;
using HRM.Domain.Entities;
using HRM.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure.Persistence.Repositories;

public class DependentRepository : GenericRepository<Dependent>, IDependentRepository
{
    public DependentRepository(ApplicationContext context) : base(context) { }

    public async Task<IEnumerable<Dependent>> GetByEmployeeIdAsync(Guid employeeId, CancellationToken cancellationToken)
    {
        return await _context.Dependents
            .AsNoTracking()
            .Where(d => d.EmployeeId == employeeId && !d.IsDeleted)
            .ToListAsync(cancellationToken);
    }
}
