namespace Domain;

public class GroupSchedule : Base
{
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    public int GroupId { get; set; }
    public Group Group { get; set; }
    public int DayId { get; set; }
    public Day Day { get; set; }
    public int? ClassroomId { get; set; }
    public Classroom? Classroom { get; set; }
    public int CourseDictationTypeId { get; set; }
    public CourseDictationType CourseDictationType { get; set; }
}