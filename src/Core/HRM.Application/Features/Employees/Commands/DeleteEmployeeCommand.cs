using MediatR;

namespace HRM.Application.Features.Employees.Commands;

public record DeleteEmployeeCommand(Guid Id) : IRequest<bool>;
