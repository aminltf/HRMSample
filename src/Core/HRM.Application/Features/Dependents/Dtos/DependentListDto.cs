#nullable disable

namespace HRM.Application.Features.Dependents.Dtos;

public record DependentListDto
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string NationalCode { get; init; }
    public Guid EmployeeId { get; init; }
    public string EmployeeFullName { get; init; }
    public bool IsDeleted { get; init; }
}
