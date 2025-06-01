namespace HRM.Application.Common.Models.Paging;

public class PageResult<T>
{
    public List<T>? Items { get; set; }
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
