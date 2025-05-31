using AutoMapper;
using HRM.Application.Common.Interfaces.Repositories;
using HRM.Application.Features.Employees.Dtos;
using HRM.Domain.Entities;
using HRM.Shared.Kernel.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRM.Application.Features.Employees.Queries.Handlers;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDetailDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetEmployeeByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<EmployeeDetailDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Employee
            .AsQueryable().FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new NotFoundException(nameof(Employee), request.Id);

        return _mapper.Map<EmployeeDetailDto>(entity);
    }
}
