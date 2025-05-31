using HRM.Application.Features.Employees.Dtos;
using MediatR;

namespace HRM.Application.Features.Employees.Queries;

public record GetEmployeeByIdQuery(Guid Id) : IRequest<EmployeeDetailDto>;
