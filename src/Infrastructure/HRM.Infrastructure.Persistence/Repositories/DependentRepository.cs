using HRM.Application.Common.Interfaces.Repositories;
using HRM.Domain.Entities;
using HRM.Infrastructure.Persistence.Contexts;

namespace HRM.Infrastructure.Persistence.Repositories;

public class DependentRepository : GenericRepository<Dependent>, IDependentRepository
{
    public DependentRepository(ApplicationContext context) : base(context)
    {
    }
}
