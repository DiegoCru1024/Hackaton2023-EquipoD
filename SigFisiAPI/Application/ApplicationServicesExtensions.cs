using System.Reflection;
using Application.Services;
using Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        #region Services
        services.AddScoped<ISemesterService, SemesterService>();
        #endregion

        return services;
    }
}