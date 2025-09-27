#nullable disable

using HRM.Shared.Kernel.Enums;

namespace HRM.Application.Features.Employees.Dtos;

public class EmployeeReportRequestDto
{
    public List<EmployeeReportField> SelectedFields { get; set; }
}
