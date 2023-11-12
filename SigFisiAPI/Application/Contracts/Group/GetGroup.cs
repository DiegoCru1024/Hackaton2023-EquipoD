namespace Application.Contracts.Group;

public class GetGroup
{
    public int Id { get; set; }
    public string CourseName { get; set; } = null!;
    public int Semester { get; set; }
    public int GroupNumber { get; set; }
    public int Limit { get; set; }
}