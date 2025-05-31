using HRM.Application.Common.Models.Paging;
using HRM.Application.Common.Models.Search;
using HRM.Application.Common.Models.Sorting;
using HRM.Application.Features.Employees.Dtos;
using MediatR;

namespace HRM.Application.Features.Employees.Queries;

public record GetAllEmployeesQuery : IRequest<PageResponse<EmployeeListDto>>
{
    public PageRequest Pagination { get; init; } = new();
    public SortOptions SortOptions { get; init; } = new();
    public SearchRequest SearchRequest { get; init; } = new();
}
