using Application.Contracts.Semester;
using AutoMapper;
using Domain;

namespace Application.Mappings;

public class SemesterProfile : Profile
{
    public SemesterProfile()
    {
        CreateMap<CreateSemester, Semester>();
        CreateMap<Semester, GetSemester>();
    }
}