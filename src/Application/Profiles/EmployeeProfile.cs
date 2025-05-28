using Application.Employees.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeReportDto>();

        CreateMap<Employee, EmployeeDetailsDto>();

        CreateMap<Employee, CreateEmployeeDto>()
            .ReverseMap();
    }
}
