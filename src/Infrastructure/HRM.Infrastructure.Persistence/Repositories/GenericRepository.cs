#nullable disable

using HRM.Application.Common.Interfaces.Repositories;
using HRM.Domain.Common.Abstractions;
using HRM.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseAuditableEntity
{
    protected readonly ApplicationContext _context;

    public GenericRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<T> AsQueryable(bool includeDeleted = false)
    {
        var query = _context.Set<T>().AsQueryable();

        if (includeDeleted)
            query = query.IgnoreQueryFilters();

        else
            query = query.Where(x => !x.IsDeleted);

        return query;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetAllDeletedAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<T>()
            .IgnoreQueryFilters()
            .Where(x => x.IsDeleted)
            .ToListAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var query = _context.Set<T>().AsQueryable();

        return await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);

        if (entity is null) return;

        entity.IsDeleted = true;
        entity.DeletedAt = DateTime.UtcNow;
        entity.ModifiedAt = DateTime.UtcNow;

        _context.Set<T>().Update(entity);
    }

    public async Task RestoreAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<T>()
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity is null) return;

        entity.IsDeleted = false;
        entity.DeletedAt = null;
        entity.ModifiedAt = DateTime.UtcNow;

        _context.Set<T>().Update(entity);
    }
}
