using HRM.Application.Common.Models.Paging;
using HRM.Application.Features.Employees.Dtos;
using MediatR;

namespace HRM.Application.Features.Employees.Queries;

public record GetEmployeesReportQuery : IRequest<PageResult<EmployeeReportDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public List<string> SelectedFields { get; set; } = new();
}
