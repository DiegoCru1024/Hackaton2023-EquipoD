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
            throw new NotFoundException(nameof(Course), createGroup.CourseId);
        }

        var expectedSchedulesQuantity = (await _unitOfWork.CourseHoursDictated.SearchCourseHoursDictated(course.Id)).Count();
        if (createGroup.GroupSchedules.Count != expectedSchedulesQuantity)
        {
            throw new AppException("Se debe ingresar todos los horarios del curso");
        }
        var semester = await _unitOfWork.Semesters.GetActiveSemester();
        if (semester == null)
        {
            throw new AppException("No hay un semestre activo");
        }
        var group = _mapper.Map<Group>(createGroup);
        group.SemesterId = semester.Id;

        var groupSchedules = _mapper.Map<List<GroupSchedule>>(createGroup.GroupSchedules);
        var groupNumberIsValid = await ValidateGroupNumber(group);
        if (!groupNumberIsValid)
        {
            throw new AppException("El numero de grupo ya existe");
        }

        var groupNumber = createGroup.GroupNumber;
        var courseSemester = course.Semester;

        foreach (var schedule in groupSchedules)
        {
            var scheduleIsValid = await ValidateGroupSchedule(schedule, groupNumber, courseSemester);
            if (!scheduleIsValid)
            {
                throw new AppException("El horario no es valido");
            }
        }
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
            throw new NotFoundException(nameof(Group), id);
        }

        return _mapper.Map<GetGroupWithSchedules>(group);
    }

    public async Task<IEnumerable<GetGroup>?> GetAllGroupsAsync()
    {
        var groups = await _unitOfWork.Groups.GetAllAsync();

        return _mapper.Map<List<GetGroup>>(groups);
    }

    public async Task<IEnumerable<GetGroupNumber>?> GetNumberByStudyPlanAndSemesterAsync(int studyPlanId, int semester)
    {
        var groups = await _unitOfWork.Groups.GetGroupNumbers(studyPlanId, semester);

        return _mapper.Map<List<GetGroupNumber>>(groups);
    }

    public async Task<int> GetNextGroupNumberByCourseId(int courseId)
    {
        var lastGroupNumber = await _unitOfWork.Groups.GetNextNumberByCourseId(courseId);
        return lastGroupNumber;
    }

    private async Task<bool> ValidateGroupNumber(Group group)
    {
        var groupExists = await _unitOfWork.Groups.GetByNumberAndCourseId(group.Number, group.CourseId);
        return groupExists == null;
    }

    private async Task<bool> ValidateGroupSchedule(GroupSchedule newGroupSchedule,int groupNumber, int semester)
    {
        var unavailableSchedulesInDay = await _unitOfWork.GroupSchedules.GetUnavailableSchedulesByDayAsync(groupNumber, semester, newGroupSchedule.DayId);
        foreach (var schedule in unavailableSchedulesInDay)
        {
            if(!(newGroupSchedule.EndTime <= schedule.StartTime || newGroupSchedule.StartTime >= schedule.EndTime))
                return false;
        }
        return true;
    }
}