using HRM.Application.Common.Interfaces.Repositories;
using HRM.Domain.Entities;
using HRM.Infrastructure.Persistence.Contexts;

namespace HRM.Infrastructure.Persistence.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationContext context) : base(context) { }
}
