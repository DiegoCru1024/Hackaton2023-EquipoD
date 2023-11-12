namespace Domain;

public class CourseTrainingArea : Base
{
    public string Name { get; set; }
    public IEnumerable<Course> Courses { get; set; }
}