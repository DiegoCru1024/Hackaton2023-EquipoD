namespace Domain;

public class CourseHoursDictated : Base
{
    public int Hours { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public int CourseDictationTypeId { get; set; }
    public CourseDictationType CourseDictationType { get; set; }
}