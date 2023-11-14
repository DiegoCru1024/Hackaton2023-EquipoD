using Application.Contracts.Classroom;
using AutoMapper;
using Domain;

namespace Application.Mappings;

public class ClassroomProfile: Profile
{
    public ClassroomProfile()
    {
        CreateMap<Classroom, GetClassroom>();
    }
}