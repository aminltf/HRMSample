#nullable disable

namespace HRM.Application.Features.Employees.Dtos;

public record EmployeeListDto
{
    public Guid Id { get; init; }
    public string EmployeeCode { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string NationalCode { get; init; }
    public bool IsDeleted { get; init; }
}
