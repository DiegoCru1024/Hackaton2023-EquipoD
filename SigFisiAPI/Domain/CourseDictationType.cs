namespace Domain;

//Teoria, practica y laboratorio
public class CourseDictationType : Base
{
    public string Name { get; set; }
    public IEnumerable<CourseHoursDictated> CourseHoursDictateds { get; set; }
    public IEnumerable<GroupSchedule> GroupSchedules { get; set; }
}