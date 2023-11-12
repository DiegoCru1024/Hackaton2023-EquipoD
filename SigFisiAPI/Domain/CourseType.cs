namespace Domain;

//Obligatorio, electivo
public class CourseType : Base
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public IEnumerable<Course> Courses { get; set; }
}