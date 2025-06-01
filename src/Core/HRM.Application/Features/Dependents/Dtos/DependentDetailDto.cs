#nullable disable

namespace HRM.Application.Features.Dependents.Dtos;

public class DependentDetailDto
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int Relation { get; init; }
    public string RelationTitle { get; init; }
    public int Gender { get; init; }
    public string GenderTitle { get; init; }
    public string NationalCode { get; init; }
    public DateOnly BirthDate { get; init; }
    public Guid EmployeeId { get; init; }
    public string EmployeeFullName { get; init; }
    public bool IsDeleted { get; init; }
}
