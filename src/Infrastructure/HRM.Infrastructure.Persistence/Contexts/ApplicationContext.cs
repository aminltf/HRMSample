using HRM.Domain.Common.Interfaces;
using HRM.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRM.Infrastructure.Persistence.Contexts;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(IAuditableEntity).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Property(parameter, nameof(IAuditableEntity.IsDeleted));
                var compare = Expression.Equal(property, Expression.Constant(false));
                var lambda = Expression.Lambda(compare, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
        {
            if (entry.State == EntityState.Added)
                entry.Entity.CreatedAt = DateTime.UtcNow;

            if (entry.State == EntityState.Modified)
                entry.Entity.ModifiedAt = DateTime.UtcNow;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
