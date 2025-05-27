using Application.Employees.Dtos;

namespace Application.Common.Interfaces.Services.Reporting;

public interface IEmployeeReportPdfService
{
    byte[] Generate(List<EmployeeReportDto> employees, List<string> selectedFields);
}
