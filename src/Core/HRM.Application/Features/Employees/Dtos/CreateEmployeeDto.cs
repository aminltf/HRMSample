#nullable disable

using FluentValidation;
using HRM.Shared.Kernel.Enums;

namespace HRM.Application.Features.Employees.Dtos;

public class CreateEmployeeDto
{
    public string EmployeeCode { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string FatherName { get; init; }
    public string NationalCode { get; init; }
    public DateOnly BirthDate { get; init; }
    public string BirthPlace { get; init; }
    public int Gender { get; init; }
    public int MaritalStatus { get; init; }
    public DateOnly? MarriageDate { get; init; }
    public int HousingStatus { get; init; }
    public string MobileNumber { get; init; }
    public string Address { get; init; }
    public string ZipCode { get; init; }
    public byte[] ProfileImage { get; init; }
}

public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeDto>
{
    public CreateEmployeeValidator()
    {
        RuleFor(x => x.EmployeeCode)
                .NotEmpty().WithMessage("کد کارمندی الزامی است.")
                .MaximumLength(20).WithMessage("کد کارمندی نباید بیشتر از 20 کاراکتر باشد.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("نام الزامی است.")
            .MaximumLength(50).WithMessage("نام نباید بیشتر از 50 کاراکتر باشد.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("نام خانوادگی الزامی است.")
            .MaximumLength(50).WithMessage("نام خانوادگی نباید بیشتر از 50 کاراکتر باشد.");

        RuleFor(x => x.NationalCode)
            .NotEmpty().WithMessage("کد ملی الزامی است.")
            .Length(10).WithMessage("کد ملی باید دقیقاً 10 رقم باشد.");

        RuleFor(x => x.BirthDate)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage("تاریخ تولد باید کوچکتر یا مساوی امروز باشد.");

        RuleFor(x => x.MarriageDate)
            .Null().When(x => x.MaritalStatus == (int)MaritalStatus.Single)
            .WithMessage("تاریخ ازدواج باید برای افراد مجرد خالی باشد.");

        RuleFor(x => x.MarriageDate)
            .NotNull().When(x => x.MaritalStatus == (int)MaritalStatus.Married)
            .WithMessage("تاریخ ازدواج برای متاهل‌ها الزامی است.");

        RuleFor(x => x.MobileNumber)
            .NotEmpty().WithMessage("شماره تماس الزامی است.")
            .MaximumLength(15).WithMessage("شماره تماس نباید بیشتر از 15 رقم باشد.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("آدرس الزامی است.")
            .MaximumLength(250).WithMessage("آدرس نباید بیشتر از 250 کاراکتر باشد.");

        RuleFor(x => x.ZipCode)
            .NotEmpty().WithMessage("کد پستی الزامی است.")
            .MaximumLength(10).WithMessage("کد پستی نباید بیشتر از 10 رقم باشد.");
    }
}
