namespace Domain;

public class Group : Base
{
    public int Number { get; set; }
    public int Limit { get; set; }
    public int SemesterId { get; set; }
    public Semester Semester { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public IEnumerable<GroupSchedule> GroupSchedules { get; set; }
}