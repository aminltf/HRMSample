using Domain.Entities;

namespace Application.Common.Interfaces.Repositories;

public interface IEmployeeRepository
{
    IQueryable<Employee> GetAll();
    Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(Employee employee, CancellationToken cancellationToken);
    Task UpdateAsync(Employee employee, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
