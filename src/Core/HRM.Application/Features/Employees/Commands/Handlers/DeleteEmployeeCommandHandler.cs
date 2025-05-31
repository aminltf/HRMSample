using HRM.Application.Common.Interfaces.Repositories;
using MediatR;

namespace HRM.Application.Features.Employees.Commands.Handlers;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Employee.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null) return false;

        await _unitOfWork.Employee.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
