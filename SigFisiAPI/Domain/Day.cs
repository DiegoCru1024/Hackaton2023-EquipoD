namespace Domain;

public class Day : Base
{
    public int Number { get; set;  }
    public string Name { get; set; }
    public IEnumerable<GroupSchedule> GroupSchedules { get; set; }
}