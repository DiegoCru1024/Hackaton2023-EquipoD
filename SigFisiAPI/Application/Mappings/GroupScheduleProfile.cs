using Application.Contracts.GroupSchedule;
using AutoMapper;
using Domain;

namespace Application.Mappings;

public class GroupScheduleProfile : Profile
{
    public GroupScheduleProfile()
    {
        CreateMap<CreateGroupSchedule, GroupSchedule>()
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => TimeSpan.FromHours(src.StartTime)))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => TimeSpan.FromHours(src.EndTime)));
        CreateMap<GroupSchedule, GetGroupSchedule>()
            .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Group.Course.Name))
            .ForMember(dest => dest.GroupNumber, opt => opt.MapFrom(src => src.Group.Number))
            .ForMember(dest => dest.CourseDictationTypeName, opt => opt.MapFrom(src => src.CourseDictationType.Name))
            .ForMember(dest => dest.StarTime, opt => opt.MapFrom(src => src.StartTime))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
            .ForMember(dest => dest.DayName, opt => opt.MapFrom(src => src.Day.Name))
            .ForMember(dest => dest.DayId, opt => opt.MapFrom(src => src.DayId))
            .ForMember(dest => dest.ClassroomCode, opt => opt.MapFrom(src => src.ClassroomId));
    }
}