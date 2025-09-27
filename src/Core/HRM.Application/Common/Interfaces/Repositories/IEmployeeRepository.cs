using HRM.Application.Features.Employees.Dtos;
using HRM.Domain.Entities;

namespace HRM.Application.Common.Interfaces.Repositories;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<List<Employee>> GetForReportAsync(EmployeeReportRequestDto request, CancellationToken cancellationToken);
}
