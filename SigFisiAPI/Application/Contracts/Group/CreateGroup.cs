using Application.Contracts.GroupSchedule;

namespace Application.Contracts.Group;

public class CreateGroup
{
    public int CourseId { get; set; }
    public int Limit { get; set; }
    public List<CreateGroupSchedule> GroupSchedules { get; set; }
}