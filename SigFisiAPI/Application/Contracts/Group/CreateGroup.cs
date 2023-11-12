namespace Application.Contracts.Group;

public class CreateGroup
{
    public int SemesterId { get; set; }
    public int CourseId { get; set; }
    public int StudyPlanId { get; set; }
    public int Limit { get; set; }
}