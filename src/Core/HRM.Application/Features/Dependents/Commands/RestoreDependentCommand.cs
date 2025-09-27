using MediatR;

namespace HRM.Application.Features.Dependents.Commands;

public record RestoreDependentCommand(Guid Id) : IRequest<bool>;
