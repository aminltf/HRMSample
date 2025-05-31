using HRM.Application.Features.Employees.Dtos;
using MediatR;

namespace HRM.Application.Features.Employees.Commands;

public record UpdateEmployeeCommand(UpdateEmployeeDto Employee) : IRequest<bool>;
