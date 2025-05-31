using FluentValidation;
using HRM.Shared.Kernel.Enums;

namespace HRM.Application.Common.Models.Sorting;

public class SortOptions
{
    public List<string> Fields { get; init; } = new();
    public SortDirection Direction { get; init; } = SortDirection.Asc;
}

public class SortOptionsValidator : AbstractValidator<SortOptions>
{
    public SortOptionsValidator()
    {
        RuleFor(x => x.Fields)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("فیلد مرتب‌سازی نباید null باشد.")
            .Must(fields => fields.All(f => !string.IsNullOrWhiteSpace(f)))
            .WithMessage("هیچ فیلد خالی نباید در مرتب‌سازی باشد.");

        RuleFor(x => x.Direction)
            .IsInEnum()
            .WithMessage("جهت مرتب‌سازی نامعتبر است.");
    }
}
