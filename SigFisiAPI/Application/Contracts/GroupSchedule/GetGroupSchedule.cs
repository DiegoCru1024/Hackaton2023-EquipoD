namespace Application.Contracts.GroupSchedule;

public class GetGroupSchedule
{
    public string CourseName { get; set; }
    public int GroupNumber { get; set; }
    public TimeSpan StarTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int DayNumber { get; set; }
}