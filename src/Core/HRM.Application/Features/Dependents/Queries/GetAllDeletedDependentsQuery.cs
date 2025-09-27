using HRM.Application.Common.Models.Paging;
using HRM.Application.Common.Models.Search;
using HRM.Application.Common.Models.Sorting;
using HRM.Application.Features.Dependents.Dtos;
using MediatR;

namespace HRM.Application.Features.Dependents.Queries;

public record GetAllDeletedDependentsQuery : IRequest<PageResponse<DependentListDto>>
{
    public PageRequest Pagination { get; set; } = new();
    public SortOptions SortOptions { get; set; } = new();
    public SearchRequest SearchRequest { get; set; } = new();
}
