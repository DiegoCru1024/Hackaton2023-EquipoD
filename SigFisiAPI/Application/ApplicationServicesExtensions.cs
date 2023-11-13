using System.Reflection;
using Application.Services;
using Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        #region Services
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<ISemesterService, SemesterService>();
        services.AddScoped<IStudyPlanService, StudyPlanService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ICourseDictationTypeService, CourseDictationTypeService>();
        services.AddScoped<IGroupScheduleService, GroupScheduleService>();
        services.AddScoped<ICourseHoursDictatedService, CourseHoursDictatedService>();
        #endregion

        return services;
    }
}