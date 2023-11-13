using Application.Contracts.GroupSchedule;
using Application.Exceptions;
using Application.Repositories;
using Domain;

namespace Application.Services.Implementations;

public class GroupScheduleService : IGroupScheduleService
{
    private readonly IUnitOfWork _unitOfWork;

    public GroupScheduleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<GetGroupSchedule>> GetUnavailableSchedules(int groupNumber, int semester)
    {
        var unavailableSchedules = await _unitOfWork.GroupSchedules.GetUnavailableSchedulesAsync(groupNumber, semester);

        return unavailableSchedules.Select(x => new GetGroupSchedule()
        {
            CourseName = x.Group.Course.Name,
            DayId = x.DayId,
            DayName = x.Day.Name,
            EndTime = x.EndTime,
            StarTime = x.StartTime,
            GroupNumber = x.Group.Number,
            ClassroomCode = x.Classroom.Code
        });
    }
}