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
            .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
            .ForMember(dest => dest.GroupSchedules, opt => opt.MapFrom(src => src.GroupSchedules));
    }
}