using Application.Contracts.Group;
using Application.Contracts.GroupSchedule;
using Application.Exceptions;
using Application.Repositories;
using AutoMapper;
using Domain;

namespace Application.Services.Implementations;

public class GroupService : IGroupService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetGroupWithSchedules> CreateGroupAsync(CreateGroup createGroup)
    {
        var course = await _unitOfWork.Courses.GetByIdAsync(createGroup.CourseId);
        if (course == null)
        {
            throw new AppException("El id de curso no existe");
        }
        var nextGroupNumber = await _unitOfWork.Groups.GetNextNumberByCourseId(course.Id);
        var semester = await _unitOfWork.Semesters.GetActiveSemester();
        if (semester == null)
        {
            throw new AppException("No hay un semestre activo");
        }
        var group = _mapper.Map<Group>(createGroup);
        group.Number = nextGroupNumber;
        group.SemesterId = semester.Id;

        var groupSchedules = _mapper.Map<List<GroupSchedule>>(createGroup.GroupSchedules);
        group.GroupSchedules = groupSchedules;
        var createdGroup = await _unitOfWork.Groups.AddAsync(group);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<Group, GetGroupWithSchedules>(createdGroup);
    }

    public async Task<GetGroupWithSchedules?> GetGroupByIdAsync(int id)
    {
        var group = await _unitOfWork.Groups.GetByIdAsync(id);

        if (group == null)
        {
            throw new AppException("No se encontro la el grupo");
        }

        return _mapper.Map<GetGroupWithSchedules>(group);
    }

    public async Task<IEnumerable<GetGroup>?> GetAllGroupsAsync()
    {
        var groups = await _unitOfWork.Groups.GetAllAsync();

        return _mapper.Map<List<GetGroup>>(groups);
    }

    public async Task<int> GetNextGroupNumberByCourseId(int courseId)
    {
        var lastGroupNumber = await _unitOfWork.Groups.GetNextNumberByCourseId(courseId);
        return lastGroupNumber;
    }
}