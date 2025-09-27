using HRM.Application.Common.Interfaces.Repositories;
using HRM.Application.Common.Models.Paging;
using HRM.Application.Extensions;
using HRM.Application.Features.Dependents.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRM.Application.Features.Dependents.Queries.Handlers;

public class GetAllDeletedDependentsQueryHandler : IRequestHandler<GetAllDeletedDependentsQuery, PageResponse<DependentListDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDeletedDependentsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PageResponse<DependentListDto>> Handle(GetAllDeletedDependentsQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Dependent
            .AsQueryable(includeDeleted: true)
            .Include(x => x.Employee)
            .AsNoTracking()
            .Where(x => x.IsDeleted);

        // Search
        if (!string.IsNullOrWhiteSpace(request.SearchRequest.SearchTerm))
        {
            var term = $"%{request.SearchRequest.SearchTerm.Trim()}%";
            query = query.Where(x => EF.Functions.Like(x.NationalCode, term));
        }

        // Sorting
        query = query.ApplySorting(request.SortOptions);

        // Count
        var totalCount = await query.CountAsync(cancellationToken);

        // Paging + Projection
        var items = await query
            .ApplyPaging(request.Pagination)
            .Select(d => new DependentListDto
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                NationalCode = d.NationalCode,
                EmployeeFullName = d.Employee.FirstName + " " + d.Employee.LastName,
                IsDeleted = d.IsDeleted,
            })
            .ToListAsync(cancellationToken);

        return new PageResponse<DependentListDto>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = request.Pagination.PageNumber,
            PageSize = request.Pagination.PageSize
        };
    }
}
