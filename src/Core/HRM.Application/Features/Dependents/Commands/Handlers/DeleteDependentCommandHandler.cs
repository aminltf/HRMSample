using HRM.Application.Common.Interfaces.Repositories;
using MediatR;

namespace HRM.Application.Features.Dependents.Commands.Handlers;

public class DeleteDependentCommandHandler : IRequestHandler<DeleteDependentCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDependentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteDependentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Dependent.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null) return false;

        await _unitOfWork.Dependent.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
