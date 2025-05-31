using HRM.Domain.Entities.Identity;

namespace HRM.Application.Common.Interfaces.Repositories.Identity;

public interface IUserRepository
{
    IQueryable<ApplicationUser> AsQueryable(bool includeDeleted = false);
}
