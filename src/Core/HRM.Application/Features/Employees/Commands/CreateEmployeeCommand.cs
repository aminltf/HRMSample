using HRM.Application.Features.Employees.Dtos;
using MediatR;

namespace HRM.Application.Features.Employees.Commands;

public record CreateEmployeeCommand(CreateEmployeeDto Employee) : IRequest<Guid>;
