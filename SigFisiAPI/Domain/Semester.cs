namespace Domain;

public class Semester : Base
{
    public string Code { get; set; }
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public IEnumerable<Group> Groups { get; set; }
}