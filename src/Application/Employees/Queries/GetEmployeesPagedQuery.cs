using Application.Common.Models;
using Application.Employees.Dtos;
using MediatR;

namespace Application.Employees.Queries;

public class GetEmployeesPagedQuery : IRequest<PagedResult<EmployeeReportDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public List<string> SelectedFields { get; set; } = new();
}
