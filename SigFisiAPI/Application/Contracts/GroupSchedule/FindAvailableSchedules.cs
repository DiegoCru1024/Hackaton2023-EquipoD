namespace Application.Contracts.GroupSchedule;

public class FindAvailableSchedules
{
    public int DayNumber { get; set; }
    public int CourseId { get; set; }
}

public class Schedule
{
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}