namespace Domain;

public class School : Base
{
    public string Code { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }
    public int AcademicAreaId { get; set; }
    public AcademicArea AcademicArea { get; set; }
    public IEnumerable<StudyPlan> StudyPlans { get; set; }
}