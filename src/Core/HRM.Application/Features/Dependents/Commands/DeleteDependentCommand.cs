using MediatR;

namespace HRM.Application.Features.Dependents.Commands;

public record DeleteDependentCommand(Guid Id) : IRequest<bool>;
