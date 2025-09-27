using HRM.Domain.Entities;
using HRM.Shared.Kernel.Enums;

namespace HRM.Application.Common.Interfaces.Services;

public interface IEmployeeReportExcelService
{
    byte[] Generate(List<Employee> employees, List<EmployeeReportField> selectedFields);
}
