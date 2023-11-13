namespace Application.Contracts.CourseHoursDictated;

public class GetCourseHoursDictated
{
    public int Id { get; set; }
    public string DictationTypeName { get; set; }
    public string CourseName { get; set; }
    public int Hours { get; set; }
}