using AutoMapper;
using HRM.Application.Common.Interfaces.Repositories;
using MediatR;

namespace HRM.Application.Features.Employees.Commands.Handlers;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Employee.GetByIdAsync(request.Employee.Id, cancellationToken);

        if (entity is null) return false;

        _mapper.Map(request.Employee, entity);

        await _unitOfWork.Employee.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
