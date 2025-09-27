using HRM.Application.Common.Interfaces.Repositories;
using HRM.Application.Features.Employees.Dtos;
using HRM.Domain.Entities;
using HRM.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure.Persistence.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationContext context) : base(context) { }

    public async Task<List<Employee>> GetForReportAsync(EmployeeReportRequestDto request, CancellationToken cancellationToken)
    {
        return await _context.Employees
            .Where(x => !x.IsDeleted)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

}
