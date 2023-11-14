using System.Reflection;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Data;

public class ApplicationContext : DbContext
{
    #region DbSets

    DbSet<AcademicArea> AcademicAreas { get; set; }
    DbSet<Classroom> Classrooms { get; set; }
    DbSet<Course> Courses { get; set; }
    DbSet<CourseDictationType> CourseDictationTypes { get; set; }
    DbSet<CourseEquivalent> CourseEquivalents { get; set; }
    DbSet<CourseHoursDictated> CourseHoursDictateds { get; set; }
    DbSet<CoursePrerequisite> CoursePrerequisites { get; set; }
    DbSet<CourseTrainingArea> CourseTrainingAreas { get; set; }
    DbSet<CourseType> CourseTypes { get; set; }
    DbSet<Day> Days { get; set; }
    DbSet<Faculty> Faculties { get; set; }
    DbSet<Group> Groups { get; set; }
    DbSet<GroupSchedule> GroupSchedules { get; set; }
    DbSet<Location> Locations { get; set; }
    DbSet<School> Schools { get; set; }
    DbSet<Semester> Semesters { get; set; }
    DbSet<StudyPlan> StudyPlans { get; set; }

    #endregion
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}