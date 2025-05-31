using FluentValidation;

namespace HRM.Application.Common.Models.Search;

public class SearchRequest
{
    public string? SearchTerm { get; set; }
}

public class SearchRequestValidator : AbstractValidator<SearchRequest>
{
    public SearchRequestValidator()
    {
        RuleFor(x => x.SearchTerm).MaximumLength(100).WithMessage("عبارت جستجو نمی‌تواند بیشتر از ۱۰۰ کاراکتر باشد.");
    }
}
