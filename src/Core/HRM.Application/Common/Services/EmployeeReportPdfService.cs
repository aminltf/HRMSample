using HRM.Application.Common.Interfaces.Services;
using HRM.Domain.Entities;
using HRM.Shared.Kernel.Enums;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace HRM.Application.Common.Services;

public class EmployeeReportPdfService : IEmployeeReportPdfService
{
    public byte[] Generate(List<Employee> employees, List<EmployeeReportField> selectedFields)
    {
        using var stream = new MemoryStream();

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(20);
                page.Content().Table(table =>
                {
                    // Columns
                    table.ColumnsDefinition(columns =>
                    {
                        for (int i = 0; i < selectedFields.Count; i++)
                            columns.RelativeColumn();
                    });

                    // Header
                    table.Header(header =>
                    {
                        foreach (var field in selectedFields)
                        {
                            header.Cell().Element(CellStyle).Text(GetDisplayName(field));
                        }
                    });

                    // Rows
                    foreach (var emp in employees)
                    {
                        foreach (var field in selectedFields)
                        {
                            table.Cell().Element(CellStyle).Text(GetEmployeeFieldValue(emp, field));
                        }
                    }
                });
            });
        });

        document.GeneratePdf(stream);
        return stream.ToArray();
    }


    private string GetDisplayName(EmployeeReportField field)
    {
        return field switch
        {
            EmployeeReportField.EmployeeCode => "کد پرسنلی",
            EmployeeReportField.FirstName => "نام",
            EmployeeReportField.LastName => "نام خانوادگی",
            EmployeeReportField.FatherName => "نام پدر",
            EmployeeReportField.NationalCode => "کد ملی",
            EmployeeReportField.BirthDate => "تاریخ تولد",
            EmployeeReportField.BirthPlace => "محل تولد",
            EmployeeReportField.Gender => "جنسیت",
            EmployeeReportField.MaritalStatus => "وضعیت تاهل",
            EmployeeReportField.MobileNumber => "شماره همراه",
            EmployeeReportField.Address => "آدرس",
            EmployeeReportField.ZipCode => "کد پستی",
            _ => field.ToString()
        };
    }

    private string GetEmployeeFieldValue(Employee emp, EmployeeReportField field)
    {
        return field switch
        {
            EmployeeReportField.EmployeeCode => "کد پرسنلی",
            EmployeeReportField.FirstName => "نام",
            EmployeeReportField.LastName => "نام خانوادگی",
            EmployeeReportField.FatherName => "نام پدر",
            EmployeeReportField.NationalCode => "کد ملی",
            EmployeeReportField.BirthDate => "تاریخ تولد",
            EmployeeReportField.BirthPlace => "محل تولد",
            EmployeeReportField.Gender => "جنسیت",
            EmployeeReportField.MaritalStatus => "وضعیت تاهل",
            EmployeeReportField.MobileNumber => "شماره همراه",
            EmployeeReportField.Address => "آدرس",
            EmployeeReportField.ZipCode => "کد پستی",
            _ => ""
        };
    }

    private IContainer CellStyle(IContainer container) => container.PaddingVertical(5).BorderBottom(1);
}
