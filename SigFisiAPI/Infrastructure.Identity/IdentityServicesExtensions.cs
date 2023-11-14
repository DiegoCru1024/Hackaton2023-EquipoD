using System.Reflection;
using System.Text;
using Application.Services;
using Infrastructure.Identity.Data;
using Infrastructure.Identity.Models;
using Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Infrastructure.Identity;

public static class IdentityServicesExtension
{
    public static IServiceCollection AddIdentityServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        #region IdentityContext

        var connectionString = configuration.GetConnectionString("IdentityConnection");
        services.AddDbContext<IdentityContext>(options =>
        {
            options.UseMySql(
                connectionString, ServerVersion.AutoDetect(connectionString),
                o =>
                {
                    o.MigrationsHistoryTable(
                        tableName: HistoryRepository.DefaultTableName,
                        schema: "identity");
                    o.SchemaBehavior(MySqlSchemaBehavior.Ignore);
                });
        });
        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]!)),
                ClockSkew = TimeSpan.Zero
            });

        #endregion


        services.AddTransient<IUserService, UserService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}