using AutoMapper;
using HRM.Application.Common.Interfaces.Repositories;
using HRM.Application.Features.Dependents.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRM.Application.Features.Dependents.Queries.Handlers;

public class GetDependentByIdQueryHandler : IRequestHandler<GetDependentByIdQuery, DependentDetailDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetDependentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DependentDetailDto> Handle(GetDependentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Dependent
            .AsQueryable()
            .Include(x => x.Employee)
            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

        return _mapper.Map<DependentDetailDto>(entity);
    }
}
