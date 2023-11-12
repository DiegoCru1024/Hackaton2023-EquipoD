namespace Domain;

public class CourseEquivalent : Base
{
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public int EquivalentId { get; set; }
    public Course Equivalent { get; set; }
}