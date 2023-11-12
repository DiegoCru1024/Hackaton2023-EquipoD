namespace Application.Contracts.Semester;

public class CreateSemester
{
    public string Code { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}