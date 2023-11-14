using Application.Repositories;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Infrastructure.Persistence;

public static class PersistenceServicesExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                o =>
                {
                    o.MigrationsHistoryTable(
                        tableName: HistoryRepository.DefaultTableName,
                        schema: "dbo");
                    o.SchemaBehavior(MySqlSchemaBehavior.Ignore);
                });
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}