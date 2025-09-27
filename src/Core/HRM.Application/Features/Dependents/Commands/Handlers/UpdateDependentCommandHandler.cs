using AutoMapper;
using HRM.Application.Common.Interfaces.Repositories;
using MediatR;

namespace HRM.Application.Features.Dependents.Commands.Handlers;

public class UpdateDependentCommandHandler : IRequestHandler<UpdateDependentCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateDependentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateDependentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Dependent.GetByIdAsync(request.UpdateDependent.Id, cancellationToken);

        _mapper.Map(request.UpdateDependent, entity);

        await _unitOfWork.Dependent.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
