using HRM.Application.Common.Interfaces.Repositories;
using HRM.Application.Common.Models.Paging;
using HRM.Application.Extensions;
using HRM.Application.Features.Employees.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRM.Application.Features.Employees.Queries.Handlers;

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, PageResponse<EmployeeListDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllEmployeesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PageResponse<EmployeeListDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Employee
            .AsQueryable()
            .AsNoTracking()
            .Where(x => !x.IsDeleted);

        // Search
        if (!string.IsNullOrWhiteSpace(request.SearchRequest?.SearchTerm))
        {
            var term = $"%{request.SearchRequest.SearchTerm.Trim()}%";
            query = query.Where(x =>
                EF.Functions.Like(x.EmployeeCode, term) ||
                EF.Functions.Like(x.FirstName, term) ||
                EF.Functions.Like(x.LastName, term)
            );
        }

        // Sorting (multi-field)
        query = query.ApplySorting(request.SortOptions);

        // Total Count
        var totalCount = await query.CountAsync(cancellationToken);

        // Paging + Projection
        var items = await query
            .ApplyPaging(request.Pagination)
            .Select(e => new EmployeeListDto
            {
                Id = e.Id,
                EmployeeCode = e.EmployeeCode,
                FirstName = e.FirstName,
                LastName = e.LastName,
                NationalCode = e.NationalCode,
                IsDeleted = e.IsDeleted
            })
            .ToListAsync(cancellationToken);

        // Result
        return new PageResponse<EmployeeListDto>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = request.Pagination.PageNumber,
            PageSize = request.Pagination.PageSize
        };
    }
}
