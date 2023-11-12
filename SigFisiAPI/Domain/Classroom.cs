namespace Domain;

public class Classroom : Base
{
    public int Code { get; set; }
    public int Capacity { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; }
    public IEnumerable<GroupSchedule> GroupSchedules { get; set; }
}