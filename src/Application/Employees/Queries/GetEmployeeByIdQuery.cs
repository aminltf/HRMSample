using Application.Employees.Dtos;
using MediatR;

namespace Application.Employees.Queries;

public record GetEmployeeByIdQuery(Guid Id) : IRequest<EmployeeDetailsDto>;
