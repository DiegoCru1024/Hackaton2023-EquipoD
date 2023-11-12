namespace Domain;

public class StudyPlan : Base
{
    public string Code { get; set; }
    public string RR { get; set; }
    public DateTime Vigency { get; set; }
    public int Credits { get; set; }
    public bool IsActive { get; set; }
    public int SchoolId { get; set; }
    public School School { get; set; }
    public IEnumerable<Course> Courses { get; set; }
}