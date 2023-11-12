namespace Domain;

public class Faculty : Base
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public IEnumerable<School> Schools { get; set; }
}