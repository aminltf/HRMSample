using HRM.Application.Features.Dependents.Dtos;
using MediatR;

namespace HRM.Application.Features.Dependents.Commands;

public record UpdateDependentCommand(UpdateDependentDto UpdateDependent) : IRequest<bool>;
