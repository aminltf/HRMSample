using HRM.Application.Common.Interfaces.Repositories;
using MediatR;

namespace HRM.Application.Features.Employees.Commands.Handlers;

public class RestoreEmployeeCommandHandler : IRequestHandler<RestoreEmployeeCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public RestoreEmployeeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(RestoreEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Employee.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null) return false;

        await _unitOfWork.Employee.RestoreAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
