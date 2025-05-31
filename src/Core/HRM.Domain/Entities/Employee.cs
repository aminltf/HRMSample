#nullable disable

using HRM.Domain.Common.Abstractions;
using HRM.Shared.Kernel.Enums;

namespace HRM.Domain.Entities;

public class Employee : BaseAuditableEntity
{
    public string EmployeeCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FatherName { get; set; }
    public string NationalCode { get; set; }
    public DateOnly BirthDate { get; set; }
    public string BirthPlace { get; set; }
    public Gender Gender { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public DateOnly? MarriageDate { get; set; }
    public HousingStatus HousingStatus { get; set; }
    public string MobileNumber { get; set; }
    public string Address { get; set; }
    public string ZipCode { get; set; }
    public byte[] ProfileImage { get; set; }

    public Employee()
    {

    }

    public Employee(
        string employeeCode,
        string firstName,
        string lastName,
        string fatherName,
        string nationalCode,
        DateOnly birthDate,
        string birthPlace,
        Gender gender,
        MaritalStatus maritalStatus,
        DateOnly marriageDate,
        HousingStatus housingStatus,
        string mobileNumber,
        string address,
        string zipCode,
        byte[] profileImage)
    {
        EmployeeCode = employeeCode;
        FirstName = firstName;
        LastName = lastName;
        FatherName = fatherName;
        NationalCode = nationalCode;
        BirthDate = birthDate;
        BirthPlace = birthPlace;
        Gender = gender;
        MaritalStatus = maritalStatus;
        MarriageDate = marriageDate;
        HousingStatus = housingStatus;
        MobileNumber = mobileNumber;
        Address = address;
        ZipCode = zipCode;
        ProfileImage = profileImage;
    }
}
