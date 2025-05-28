#nullable disable

using Domain.Enums;

namespace Application.Employees.Dtos;

public class CreateEmployeeDto
{
    public string EmployeeCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FatherName { get; set; }
    public string NationalCode { get; set; }
    public string IdentityNumber { get; set; }
    public string IssuePlace { get; set; }
    public DateOnly IssueDate { get; set; }
    public Gender Gender { get; set; }
    public string BirthPlace { get; set; }
    public DateOnly BirthDate { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public DateOnly? MarriageDate { get; set; }
    public BloodType BloodType { get; set; }
    public HousingStatus HousingStatus { get; set; }
    public string MobileNumber { get; set; }
    public string Address { get; set; }
    public string ZipCode { get; set; }
    public byte[] ProfileImage { get; set; }
}
