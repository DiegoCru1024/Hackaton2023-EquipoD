namespace Application.Contracts.Semester;

public class UpdateSemester
{
    public string Code { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}