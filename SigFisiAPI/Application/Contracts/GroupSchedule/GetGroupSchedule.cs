namespace Application.Contracts.GroupSchedule;

public class GetGroupSchedule
{
    public string CourseName { get; set; }
    public int GroupNumber { get; set; }
    public string CourseDictationTypeName { get; set; }
    public int StartTime { get; set; }
    public int EndTime { get; set; }
    public string DayName { get; set; }
    public int DayId { get; set; }
    public string? ClassroomCode { get; set; }
    public int Limit { get; set; }
}