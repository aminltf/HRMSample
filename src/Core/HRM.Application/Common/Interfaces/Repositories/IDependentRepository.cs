using HRM.Domain.Entities;

namespace HRM.Application.Common.Interfaces.Repositories;

public interface IDependentRepository : IGenericRepository<Dependent>
{
    Task<IEnumerable<Dependent>> GetByEmployeeIdAsync(Guid employeeId, CancellationToken cancellationToken);
}
