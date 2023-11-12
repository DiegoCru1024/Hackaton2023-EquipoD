namespace Domain;

public class Course : Base
{
    public string Code { get; set; }
    public string Name { get; set; }
    public decimal Credits { get; set; }
    public decimal RequiredCredits { get; set; }
    //Define en que ciclo de la carrera deberia de dictarse el curso
    public int Semester { get; set; }
    public int StudyPlanId { get; set; }
    public StudyPlan StudyPlan { get; set; }
    public int CourseTypeId { get; set; }
    public CourseType CourseType { get; set; }
    public int CourseTrainingAreaId { get; set; }
    public CourseTrainingArea CourseTrainingArea { get; set; }
    public IEnumerable<CourseHoursDictated> CourseHoursDictateds { get; set; }
    public IEnumerable<CoursePrerequisite> CoursePrerequisites { get; set; }
    public IEnumerable<Group> Groups { get; set; }
    public IEnumerable<CourseEquivalent> CourseEquivalents { get; set; }
}