using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using Application.Employees.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Employees.Queries.Handlers;

public class GetEmployeesPagedQueryHandler : IRequestHandler<GetEmployeesPagedQuery, PagedResult<EmployeeReportDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetEmployeesPagedQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedResult<EmployeeReportDto>> Handle(GetEmployeesPagedQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.Employees.GetAll().AsNoTracking().Where(e => !e.IsDeleted);

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

        return new PagedResult<EmployeeReportDto>
        {
            Items = dtos,
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}
