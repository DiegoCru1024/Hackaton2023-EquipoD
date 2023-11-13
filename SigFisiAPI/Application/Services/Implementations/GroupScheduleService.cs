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

    public async Task<IEnumerable<Schedule>> FindAvailableSchedules(FindAvailableSchedules model)
    {
        var availableSchedules = new List<Schedule>();
        var groupNumber = await _unitOfWork.Groups.GetNextNumberByCourseId(model.CourseId);
        var day = await _unitOfWork.Days.GetByNumberAsync(model.DayNumber);
        if (day == null)
        {
            throw new AppException("El dia ingresado no es valido");
        }

        var unavailableSchedules =
            (await _unitOfWork.GroupSchedules.GetUnavailableScheduleInDayAsync(groupNumber, day.Id)).ToList();
        var initialHour = TimeOnly.Parse("08:00");
        var finalHour = TimeOnly.Parse("22:00");
        if (!unavailableSchedules.Any() || TimeOnly.FromTimeSpan(unavailableSchedules[0].StartTime) > initialHour)
        {
            availableSchedules.Add(new Schedule()
            {
                StartTime = initialHour,
                EndTime = unavailableSchedules.Count > 0
                    ? TimeOnly.FromTimeSpan(unavailableSchedules[0].StartTime)
                    : finalHour
            });
        }

        for (int i = 0; i < availableSchedules.Count - 1; i++)
        {
            TimeOnly startInterval = TimeOnly.FromTimeSpan(unavailableSchedules[i].EndTime);
            TimeOnly endInterval = TimeOnly.FromTimeSpan(unavailableSchedules[i + 1].StartTime);

            if (startInterval < endInterval)
            {
                availableSchedules.Add(new Schedule() { StartTime = startInterval, EndTime = endInterval });
            }
        }

        if (unavailableSchedules.Count > 0 && TimeOnly.FromTimeSpan(unavailableSchedules[^1].EndTime) < finalHour)
        {
            availableSchedules.Add(new Schedule()
                { StartTime = TimeOnly.FromTimeSpan(unavailableSchedules[^1].EndTime), EndTime = finalHour });
        }

        return availableSchedules;
    }
}