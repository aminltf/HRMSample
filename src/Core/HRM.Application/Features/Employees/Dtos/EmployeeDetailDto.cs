#nullable disable

namespace HRM.Application.Features.Employees.Dtos;

public class EmployeeDetailDto
{
    public Guid Id { get; init; }
    public string EmployeeCode { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string FullName { get; init; }
    public string FatherName { get; init; }
    public string NationalCode { get; init; }
    public DateOnly BirthDate { get; init; }
    public string BirthPlace { get; init; }
    public int Gender { get; init; }
    public string GenderTitle { get; init; }
    public int MaritalStatus { get; init; }
    public string MaritalStatusTitle { get; init; }
    public DateOnly? MarriageDate { get; init; }
    public int HousingStatus { get; init; }
    public string HousingStatusTitle { get; init; }
    public string MobileNumber { get; init; }
    public string Address { get; init; }
    public string ZipCode { get; init; }
    public byte[] ProfileImage { get; init; }
    public bool IsDeleted { get; init; }
}
