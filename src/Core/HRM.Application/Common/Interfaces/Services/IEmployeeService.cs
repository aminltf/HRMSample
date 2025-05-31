using HRM.Application.Features.Employees.Dtos;

namespace HRM.Application.Common.Interfaces.Services;

public interface IEmployeeService
{
    byte[] GenerateDynamicReport(List<EmployeeReportDto> employees, List<string> selectedFields);
}
