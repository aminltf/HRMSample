using AutoMapper;
using HRM.Application.Common.Interfaces.Repositories;
using HRM.Domain.Entities;
using MediatR;

namespace HRM.Application.Features.Dependents.Commands.Handlers;

public class CreateDependentCommandHandler : IRequestHandler<CreateDependentCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateDependentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateDependentCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Dependent>(request.CreateDependent);
        await _unitOfWork.Dependent.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
