#nullable disable

using FluentValidation;
using HRM.Shared.Kernel.Validators;

namespace HRM.Application.Features.Dependents.Dtos;

public class UpdateDependentDto
{
    public Guid Id { get; init; }
    public Guid EmployeeId { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int Relation { get; init; }
    public int Gender { get; init; }
    public string NationalCode { get; init; }
    public DateOnly BirthDate { get; init; }
}

public class UpdateDependentValidator : AbstractValidator<UpdateDependentDto>
{
    public UpdateDependentValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("شناسه وابسته الزامی است.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("نام الزامی است.")
            .MinimumLength(2).WithMessage("نام باید حداقل ۲ کاراکتر باشد.")
            .MaximumLength(50).WithMessage("نام نباید بیش از ۵۰ کاراکتر باشد.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("نام خانوادگی الزامی است.")
            .MinimumLength(2).WithMessage("نام خانوادگی باید حداقل ۲ کاراکتر باشد.")
            .MaximumLength(50).WithMessage("نام خانوادگی نباید بیش از ۵۰ کاراکتر باشد.");

        RuleFor(x => x.Relation)
            .IsInEnum().WithMessage("نوع نسبت انتخاب شده معتبر نیست.");

        RuleFor(x => x.Gender)
            .InclusiveBetween(0, 1).WithMessage("جنسیت باید مرد یا زن باشد.");

        RuleFor(x => x.NationalCode)
            .NotEmpty().WithMessage("کد ملی الزامی است.")
            .Matches(@"^\d{10}$").WithMessage("کد ملی باید دقیقاً ۱۰ رقم باشد.")
            .Must(ValidationHelpers.IsValidIranianNationalCode).WithMessage("کد ملی نامعتبر است.");

        RuleFor(x => x.BirthDate)
            .NotNull().WithMessage("تاریخ تولد الزامی است.")
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage("تاریخ تولد نمی‌تواند در آینده باشد.");
    }
}
