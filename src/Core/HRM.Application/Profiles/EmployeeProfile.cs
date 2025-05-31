using AutoMapper;
using HRM.Application.Features.Employees.Dtos;
using HRM.Domain.Entities;
using HRM.Shared.Kernel.Enums;

namespace HRM.Application.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        // Create/Update
        CreateMap<Employee, CreateEmployeeDto>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (int)src.Gender))
            .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => (int)src.MaritalStatus))
            .ForMember(dest => dest.HousingStatus, opt => opt.MapFrom(src => (int)src.HousingStatus))
            .ReverseMap()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (Gender)src.Gender))
            .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => (MaritalStatus)src.MaritalStatus))
            .ForMember(dest => dest.HousingStatus, opt => opt.MapFrom(src => (HousingStatus)src.HousingStatus));

        CreateMap<Employee, UpdateEmployeeDto>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (int)src.Gender))
            .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => (int)src.MaritalStatus))
            .ForMember(dest => dest.HousingStatus, opt => opt.MapFrom(src => (int)src.HousingStatus))
            .ReverseMap()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (Gender)src.Gender))
            .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => (MaritalStatus)src.MaritalStatus))
            .ForMember(dest => dest.HousingStatus, opt => opt.MapFrom(src => (HousingStatus)src.HousingStatus));

        // List/Detail
        CreateMap<Employee, EmployeeListDto>();

        CreateMap<Employee, EmployeeDetailDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (int)src.Gender))
            .ForMember(dest => dest.GenderTitle, opt => opt.MapFrom(src => src.Gender.ToString()))
            .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => (int)src.MaritalStatus))
            .ForMember(dest => dest.MaritalStatusTitle, opt => opt.MapFrom(src => src.MaritalStatus.ToString()))
            .ForMember(dest => dest.HousingStatus, opt => opt.MapFrom(src => (int)src.HousingStatus))
            .ForMember(dest => dest.HousingStatusTitle, opt => opt.MapFrom(src => src.HousingStatus.ToString()));

        CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (int)src.Gender))
            .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => (int)src.MaritalStatus))
            .ForMember(dest => dest.HousingStatus, opt => opt.MapFrom(src => (int)src.HousingStatus));
    }
}
