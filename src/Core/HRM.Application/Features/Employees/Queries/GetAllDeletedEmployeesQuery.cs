using HRM.Application.Common.Models.Paging;
using HRM.Application.Common.Models.Search;
using HRM.Application.Common.Models.Sorting;
using HRM.Application.Features.Employees.Dtos;
using MediatR;

namespace HRM.Application.Features.Employees.Queries;

public record GetAllDeletedEmployeesQuery : IRequest<PageResponse<EmployeeListDto>>
{
    public PageRequest Pagination { get; set; } = new();
    public SortOptions SortOptions { get; set; } = new();
    public SearchRequest SearchRequest { get; set; } = new();
}
