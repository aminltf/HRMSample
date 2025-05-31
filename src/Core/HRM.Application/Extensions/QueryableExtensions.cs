using System.Linq.Dynamic.Core;
using HRM.Application.Common.Models.Paging;
using HRM.Application.Common.Models.Sorting;
using HRM.Shared.Kernel.Enums;

namespace HRM.Application.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, SortOptions sortOptions)
    {
        if (sortOptions?.Fields == null || !sortOptions.Fields.Any()) return query;

        var direction = sortOptions.Direction == SortDirection.Asc ? "ascending" : "descending";
        var sortExpression = string.Join(",", sortOptions.Fields.Select(f => $"{f} {direction}"));

        return query.OrderBy(sortExpression);
    }

    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int pageNumber, int pageSize)
    {
        if (pageNumber <= 0) pageNumber = 1;
        if (pageSize <= 0) return query;

        return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }

    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, PageRequest request)
    {
        if (request is null || !request.IsPagingEnabled)
            return query;

        return query.ApplyPaging(request.PageNumber, request.PageSize);
    }
}
