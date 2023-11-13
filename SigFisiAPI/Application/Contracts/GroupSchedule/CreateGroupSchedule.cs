namespace Application.Contracts.GroupSchedule;

public class CreateGroupSchedule
{
    public int DayId { get; set; }
    public int CourseDictationTypeId { get; set; }
    public int StartTime { get; set; }
    public int EndTime { get; set; }
}