#nullable disable

namespace HRM.Application.Features.Dependents.Dtos;

public class DependentDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Gender { get; set; }
    public int Relation { get; set; }
    public string NationalCode { get; set; }
    public DateOnly BirthDate { get; set; }
    public bool IsDeleted { get; set; }
}
