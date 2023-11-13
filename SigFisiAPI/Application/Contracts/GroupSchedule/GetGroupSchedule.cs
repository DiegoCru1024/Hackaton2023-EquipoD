namespace Application.Contracts.GroupSchedule;

public class GetGroupSchedule
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Day { get; set; }
}