#nullable disable

namespace HRM.Application.Features.Employees.Dtos;

public class EmployeeDto
{
    public Guid Id { get; set; }
    public string EmployeeCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FatherName { get; set; }
    public string NationalCode { get; set; }
    public DateOnly BirthDate { get; set; }
    public string BirthPlace { get; set; }
    public int Gender { get; set; }
    public int MaritalStatus { get; set; }
    public DateOnly? MarriageDate { get; set; }
    public int HousingStatus { get; set; }
    public string MobileNumber { get; set; }
    public string Address { get; set; }
    public string ZipCode { get; set; }
    public byte[] ProfileImage { get; set; }
    public bool IsDeleted { get; set; }
}
