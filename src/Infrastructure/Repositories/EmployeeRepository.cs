using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<Employee> GetAll()
        => _context.Employees.AsQueryable();

    public async Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

    public async Task AddAsync(Employee employee, CancellationToken cancellationToken)
    {
        await _context.Employees.AddAsync(employee, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Employee employee, CancellationToken cancellationToken)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
