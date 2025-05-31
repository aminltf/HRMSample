using MediatR;

namespace HRM.Application.Features.Employees.Commands;

public record RestoreEmployeeCommand(Guid Id) : IRequest<bool>;
