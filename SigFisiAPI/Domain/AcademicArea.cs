namespace Domain;

public class AcademicArea : Base
{
    public string Code { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public IEnumerable<School> Schools { get; set; }
}