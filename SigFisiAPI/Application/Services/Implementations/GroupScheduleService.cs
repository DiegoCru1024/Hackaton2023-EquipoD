using Application.Contracts.Group;
using Application.Contracts.GroupSchedule;
using Application.Exceptions;
using Application.Repositories;
using AutoMapper;
using Domain;

namespace Application.Services.Implementations;

public class GroupScheduleService : IGroupScheduleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GroupScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetGroupSchedule>> GetAllSchedules()
    {
        var schedules = await _unitOfWork.GroupSchedules.GetAllAsync();
        return _mapper.Map<List<GetGroupSchedule>>(schedules);
    }

    public async Task<IEnumerable<GetGroupSchedule>> SearchGroupSchedule(int groupNumber, int semester, int studyPlanId)
    {
        var activeSemester = await _unitOfWork.Semesters.GetActiveSemester();

        if (activeSemester == null)
        {
            throw new AppException("No hay un semestre activo.");
        }

        var groups = await _unitOfWork.GroupSchedules.SearchGroupSchedule(groupNumber, semester, studyPlanId);

        groups = groups.Where(x => x.Group.SemesterId == activeSemester.Id);

        return _mapper.Map<List<GetGroupSchedule>>(groups);
    }

    public async Task<IEnumerable<GetGroupSchedule>> GetUnavailableSchedules(int groupNumber, int semester)
    {
        var activeSemester = await _unitOfWork.Semesters.GetActiveSemester();
        if (activeSemester == null)
        {
            throw new AppException("No hay un semestre activo.");
        }

        var unavailableSchedules =
            (await _unitOfWork.GroupSchedules.GetUnavailableSchedulesAsync(groupNumber, semester)).Where(x =>
                x.Group.SemesterId == activeSemester.Id);

        return _mapper.Map<List<GetGroupSchedule>>(unavailableSchedules);
    }

    public async Task<GetGroupSchedule> AssignClassroom(int scheduleId, int classroomId)
    {
        var activeSemester = await _unitOfWork.Semesters.GetActiveSemester();

        if (activeSemester == null)
        {
            throw new AppException("No hay un semestre activo");
        }

        var schedule = await _unitOfWork.GroupSchedules.GetByIdAsync(scheduleId);
        if (schedule == null)
        {
            throw new NotFoundException(nameof(GroupSchedule), scheduleId);
        }

        var classroom = await _unitOfWork.Classrooms.GetByIdAsync(classroomId);
        if (classroom == null)
        {
            throw new NotFoundException(nameof(Classroom), classroomId);
        }

        var availableClassrooms =
            await _unitOfWork.Classrooms.GetAvailableClassroomsByScheduleAndCapacity(schedule.StartTime,
                schedule.EndTime, schedule.DayId, schedule.Group.Limit, activeSemester.Id);

        var classroomIsAvailable = availableClassrooms.Any(x => x.Id == classroom.Id);

        if (!classroomIsAvailable)
        {
            throw new AppException("El aula no esta disponible para ese horario");
        }

        schedule.ClassroomId = classroom.Id;
        await _unitOfWork.CommitAsync();
        return _mapper.Map<GetGroupSchedule>(schedule);
    }

    public async Task<GetGroupSchedule> UpdateClassroom(int scheduleId, int classroomId)
    {
        var activeSemester = await _unitOfWork.Semesters.GetActiveSemester();

        if (activeSemester == null)
        {
            throw new AppException("No hay un semestre activo");
        }

        var schedule = await _unitOfWork.GroupSchedules.GetByIdAsync(scheduleId);
        if (schedule == null)
        {
            throw new NotFoundException(nameof(GroupSchedule), scheduleId);
        }

        var classroom = await _unitOfWork.Classrooms.GetByIdAsync(classroomId);
        if (classroom == null)
        {
            throw new NotFoundException(nameof(Classroom), classroomId);
        }

        var availableClassrooms =
            await _unitOfWork.Classrooms.GetAvailableClassroomsByScheduleAndCapacity(schedule.StartTime,
                schedule.EndTime, schedule.DayId, schedule.Group.Limit, activeSemester.Id);

        var classroomIsAvailable = availableClassrooms.Any(x => x.Id == classroom.Id);

        if (!classroomIsAvailable)
        {
            throw new AppException("El aula no esta disponible para ese horario");
        }

        schedule.ClassroomId = classroom.Id;
        await _unitOfWork.CommitAsync();
        return _mapper.Map<GetGroupSchedule>(schedule);
    }

    public async Task<IEnumerable<GetGroupSchedule>> GetSchedulesWithoutClassroom()
    {
        var activeSemester = await _unitOfWork.Semesters.GetActiveSemester();

        if (activeSemester == null)
        {
            throw new AppException("No hay un semestre activo");
        }


        var schedules = (await _unitOfWork.GroupSchedules.GetSchedulesWithoutClassroom())
            .OrderBy(x => x.GroupId)
            .ThenBy(x => x.Group.Course)
            .ThenBy(x => x.Group.Number)
            .Where(x => x.Group.SemesterId == activeSemester.Id);

        return _mapper.Map<List<GetGroupSchedule>>(schedules);
    }
}