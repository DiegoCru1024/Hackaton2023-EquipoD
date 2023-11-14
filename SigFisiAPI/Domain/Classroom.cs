namespace Domain;

public class Classroom : Base
{
    public string Code { get; set; }
    public int Capacity { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; }
    public IEnumerable<GroupSchedule> GroupSchedules { get; set; }
}