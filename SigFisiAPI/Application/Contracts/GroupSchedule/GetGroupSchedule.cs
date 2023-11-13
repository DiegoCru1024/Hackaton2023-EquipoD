namespace Application.Contracts.GroupSchedule;

public class GetGroupSchedule
{
    public string CourseName { get; set; }
    public int GroupNumber { get; set; }
    public string CourseDictationTypeName { get; set; }
    public TimeSpan StarTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string DayName { get; set; }
    public int DayId { get; set; }
    public int? ClassroomCode { get; set; }
}