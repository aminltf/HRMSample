using HRM.Application.Common.Interfaces.Repositories;
using HRM.Application.Common.Models.Paging;
using HRM.Application.Extensions;
using HRM.Application.Features.Employees.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRM.Application.Features.Employees.Queries.Handlers;

public class GetAllDeletedEmployeesQueryHandler : IRequestHandler<GetAllDeletedEmployeesQuery, PageResponse<EmployeeListDto>>
{
    private IUnitOfWork _unitOfWork;

    public GetAllDeletedEmployeesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PageResponse<EmployeeListDto>> Handle(GetAllDeletedEmployeesQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Employee
            .AsQueryable(includeDeleted: true)
            .AsNoTracking()
            .Where(x => x.IsDeleted);

        // Search
        if (!string.IsNullOrWhiteSpace(request.SearchRequest.SearchTerm))
        {
            var term = $"%{request.SearchRequest.SearchTerm.Trim()}%";
            query = query.Where(x => EF.Functions.Like(x.EmployeeCode, term));
        }

        // Sorting
        query = query.ApplySorting(request.SortOptions);

        // Count
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

        return new PageResponse<EmployeeListDto>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = request.Pagination.PageNumber,
            PageSize = request.Pagination.PageSize
        };
    }
}
