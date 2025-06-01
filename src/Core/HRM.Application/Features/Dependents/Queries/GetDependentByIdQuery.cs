using HRM.Application.Features.Dependents.Dtos;
using MediatR;

namespace HRM.Application.Features.Dependents.Queries;

public record GetDependentByIdQuery(Guid Id) : IRequest<DependentDetailDto>;
