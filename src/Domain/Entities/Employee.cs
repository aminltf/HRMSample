#nullable disable

using Domain.Common.Base;
using Domain.Enums;

namespace Domain.Entities;

public class Employee : BaseEntity
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

    public Employee()
    {
        
    }

    public Employee(
        string employeeCode,
        string firstName,
        string lastName,
        string fatherName,
        string nationalCode,
        string identityNumber,
        string issuePlace,
        DateOnly issueDate,
        Gender gender,
        string birthPlace,
        DateOnly birthDate,
        MaritalStatus maritalStatus,
        DateOnly marriageDate,
        BloodType bloodType,
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
        IdentityNumber = identityNumber;
        IssuePlace = issuePlace;
        IssueDate = issueDate;
        Gender = gender;
        BirthPlace = birthPlace;
        BirthDate = birthDate;
        MaritalStatus = maritalStatus;
        MarriageDate = marriageDate;
        BloodType = bloodType;
        HousingStatus = housingStatus;
        MobileNumber = mobileNumber;
        Address = address;
        ZipCode = zipCode;
        ProfileImage = profileImage;
    }
}
