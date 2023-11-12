namespace Domain;

public class Location : Base
{
    public string Code { get; set; }
    public string Name { get; set; }
    public IEnumerable<Classroom> Classrooms { get; set; }
}