using HRM.Application.Features.Dependents.Dtos;
using MediatR;

namespace HRM.Application.Features.Dependents.Commands;

public record CreateDependentCommand(CreateDependentDto CreateDependent) : IRequest<Guid>;
