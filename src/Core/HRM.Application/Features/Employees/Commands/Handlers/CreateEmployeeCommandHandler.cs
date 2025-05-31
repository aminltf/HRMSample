using AutoMapper;
using HRM.Application.Common.Interfaces.Repositories;
using HRM.Domain.Entities;
using MediatR;

namespace HRM.Application.Features.Employees.Commands.Handlers;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Employee>(request.Employee);
        
        await _unitOfWork.Employee.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return entity.Id;
    }
}
