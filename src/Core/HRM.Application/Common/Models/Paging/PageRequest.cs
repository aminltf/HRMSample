using FluentValidation;

namespace HRM.Application.Common.Models.Paging;

public class PageRequest
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;

    public int Skip => (PageNumber - 1) * PageSize;
    public bool IsPagingEnabled => PageSize > 0;
}

public class PageRequestValidator : AbstractValidator<PageRequest>
{
    public PageRequestValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0).WithMessage("شماره صفحه باید بزرگتر از صفر باشد.");

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100)
            .WithMessage("اندازه صفحه باید بین ۱ تا ۱۰۰ باشد.");
    }
}
