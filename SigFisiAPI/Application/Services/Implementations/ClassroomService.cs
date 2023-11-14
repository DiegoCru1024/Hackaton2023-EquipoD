using Application.Contracts.Classroom;
using Application.Exceptions;
using Application.Repositories;
using AutoMapper;
using Domain;

namespace Application.Services.Implementations;

public class ClassroomService : IClassroomService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClassroomService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetClassroom>> GetAllAvailableByScheduleId(int scheduleId)
    {
        var schedule = await _unitOfWork.GroupSchedules.GetByIdAsync(scheduleId);
        if (schedule == null)
        {
            throw new NotFoundException(nameof(GroupSchedule), scheduleId);
        }
        var classrooms = await _unitOfWork.Classrooms.GetAvailableClassroomsByScheduleAndCapacity(schedule.StartTime, schedule.EndTime, schedule.DayId, schedule.Group.Limit);
        return _mapper.Map<IEnumerable<GetClassroom>>(classrooms);
    }
}