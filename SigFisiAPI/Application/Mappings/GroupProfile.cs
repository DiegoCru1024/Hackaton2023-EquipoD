using Application.Contracts.Group;
using AutoMapper;
using Domain;

namespace Application.Mappings;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<CreateGroup, Group>();
        CreateMap<Group, GetGroupWithSchedules>()
            .ForMember(dest => dest.Semester , opt => opt.MapFrom(src => src.Course.Semester))
            .ForMember(dest => dest.GroupNumber, opt => opt.MapFrom(src => src.Number))
            .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
            .ForMember(dest => dest.GroupSchedules, opt => opt.MapFrom(src => src.GroupSchedules));
        CreateMap<Group, GetGroup>()
            .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
            .ForMember(dest => dest.Semester, opt => opt.MapFrom(src => src.Course.Semester))
            .ForMember(dest => dest.GroupNumber, opt => opt.MapFrom(src => src.Number));
    }
}