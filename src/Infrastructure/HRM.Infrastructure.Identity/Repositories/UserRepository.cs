using HRM.Application.Common.Interfaces.Repositories.Identity;
using HRM.Domain.Entities.Identity;
using HRM.Infrastructure.Identity.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure.Identity.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IdentityContext _context;

    public UserRepository(IdentityContext context)
    {
        _context = context;
    }

    public IQueryable<ApplicationUser> AsQueryable(bool includeDeleted = false)
    {
        if (includeDeleted)
            return _context.ApplicationUsers.IgnoreQueryFilters().Where(x => x.IsDeleted);

        return _context.ApplicationUsers.AsQueryable();
    }
}
