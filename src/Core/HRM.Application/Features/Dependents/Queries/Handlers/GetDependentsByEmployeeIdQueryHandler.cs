using AutoMapper;
using HRM.Application.Common.Interfaces.Repositories;
using HRM.Application.Features.Dependents.Dtos;
using MediatR;

namespace HRM.Application.Features.Dependents.Queries.Handlers;

public class GetDependentsByEmployeeIdQueryHandler : IRequestHandler<GetDependentsByEmployeeIdQuery, List<DependentDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetDependentsByEmployeeIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<DependentDto>> Handle(GetDependentsByEmployeeIdQuery request, CancellationToken cancellationToken)
    {
        var query = await _unitOfWork.Dependent.GetByEmployeeIdAsync(request.EmployeeId, cancellationToken);
        return _mapper.Map<List<DependentDto>>(query);
    }
}
