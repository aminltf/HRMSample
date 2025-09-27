using HRM.Application.Features.Dependents.Dtos;
using MediatR;

namespace HRM.Application.Features.Dependents.Queries;

public record GetDependentsByEmployeeIdQuery(Guid EmployeeId) : IRequest<List<DependentDto>>;
