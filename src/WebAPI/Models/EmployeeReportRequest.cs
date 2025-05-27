namespace WebAPI.Models;

public class EmployeeReportRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public List<string> SelectedFields { get; set; } = new();
}
