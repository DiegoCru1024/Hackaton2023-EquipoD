namespace Application.Contracts.Semester;

public class GetSemester
{
    public int Id { get; set; }
    public string Code { get; set; }
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}