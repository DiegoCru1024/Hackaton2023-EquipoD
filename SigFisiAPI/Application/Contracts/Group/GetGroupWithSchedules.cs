using Application.Contracts.GroupSchedule;

namespace Application.Contracts.Group;

public class GetGroupWithSchedules
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public int Semester { get; set; }
    public int GroupNumber { get; set; }
    public int Limit { get; set; }
    public List<GetGroupSchedule> GroupSchedules { get; set; }
}
