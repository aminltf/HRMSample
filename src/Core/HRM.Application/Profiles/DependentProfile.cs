using AutoMapper;
using HRM.Application.Features.Dependents.Dtos;
using HRM.Domain.Entities;
using HRM.Shared.Kernel.Enums;

namespace HRM.Application.Profiles;

public class DependentProfile : Profile
{
    public DependentProfile()
    {
        // Create
        CreateMap<Dependent, CreateDependentDto>()
            .ForMember(dest => dest.Relation, opt => opt.MapFrom(src => (int)src.Relation))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (int)src.Gender))
            .ReverseMap()
            .ForMember(dest => dest.Relation, opt => opt.MapFrom(src => (Relation)src.Relation))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (Gender)src.Gender));

        // Detail
        CreateMap<Dependent, DependentDetailDto>()
            .ForMember(dest => dest.Relation, opt => opt.MapFrom(src => (int)src.Relation))
            .ForMember(dest => dest.RelationTitle, opt => opt.MapFrom(src => src.Relation.ToString()))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (int)src.Gender))
            .ForMember(dest => dest.GenderTitle, opt => opt.MapFrom(src => src.Gender.ToString()))
            .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => src.Employee != null ? $"{src.Employee.FirstName} {src.Employee.LastName}" : ""));
    }
}
