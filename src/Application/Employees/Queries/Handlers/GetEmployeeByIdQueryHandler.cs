using Application.Common.Exceptions;
using Application.Common.Interfaces.Repositories;
using Application.Employees.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Employees.Queries.Handlers;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDetailsDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetEmployeeByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<EmployeeDetailsDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Employees.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            throw new NotFoundException(nameof(Employees), request.Id);

        return _mapper.Map<EmployeeDetailsDto>(entity);
    }
}
