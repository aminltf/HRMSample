using Application.Employees.Dtos;
using MediatR;

namespace Application.Employees.Commands;

public record CreateEmployeeCommand(CreateEmployeeDto Employee) : IRequest<Guid>;
