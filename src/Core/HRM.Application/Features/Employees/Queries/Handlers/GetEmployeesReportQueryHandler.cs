using AutoMapper;
using HRM.Application.Common.Interfaces.Repositories;
using HRM.Application.Common.Models.Paging;
using HRM.Application.Features.Employees.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HRM.Application.Features.Employees.Queries.Handlers;

public class GetEmployeesPagedQueryHandler : IRequestHandler<GetEmployeesReportQuery, PageResult<EmployeeReportDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetEmployeesPagedQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PageResult<EmployeeReportDto>> Handle(GetEmployeesReportQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Employee
            .AsQueryable()
            .AsNoTracking()
            .Where(x => !x.IsDeleted);

        // Paging
        int totalCount = await query.CountAsync(cancellationToken);
        var employees = await query
            .OrderByDescending(e => e.CreatedAt)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        // Mapping
        var dtos = _mapper.Map<List<EmployeeReportDto>>(employees);

        var selectedDtos = dtos.Select(dto =>
        {
            var shapedObj = new Dictionary<string, object?>();
            foreach (var field in request.SelectedFields)
            {
                var prop = dto.GetType().GetProperty(field);
                shapedObj[field] = prop?.GetValue(dto);
            }
            return shapedObj;
        }).ToList();

        return new PageResult<EmployeeReportDto>
        {
            Items = dtos,
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}
