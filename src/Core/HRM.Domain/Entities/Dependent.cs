#nullable disable

using HRM.Domain.Common.Abstractions;
using HRM.Shared.Kernel.Enums;

namespace HRM.Domain.Entities;

public class Dependent : BaseAuditableEntity
{
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Relation Relation { get; set; }
    public Gender Gender { get; set; }
    public string NationalCode { get; set; }
    public DateOnly BirthDate { get; set; }

    public Dependent()
    {
        
    }

    public Dependent(
        Guid employeeId,
        string firstName,
        string lastName,
        Relation relation,
        Gender gender,
        string nationalCode,
        DateOnly birthDate)
    {
        EmployeeId = employeeId;
        FirstName = firstName;
        LastName = lastName;
        Relation = relation;
        Gender = gender;
        NationalCode = nationalCode;
        BirthDate = birthDate;
    }
}
