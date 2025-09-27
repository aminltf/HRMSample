using HRM.Application.Common.Interfaces.Repositories;
using MediatR;

namespace HRM.Application.Features.Dependents.Commands.Handlers;

public class RestoreDependentCommandHandler : IRequestHandler<RestoreDependentCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public RestoreDependentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(RestoreDependentCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Dependent.RestoreAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
