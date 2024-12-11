using CQRS_V00.Presistence;
using CQRS_V00.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CQRS_V00;

public static class Dependencies
{
    public static IServiceCollection AddDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddOpenApi();

        services.InjectServices();

        services.AddMapsterConfig();
        
        services.AddFluentValidatorConfig();

        services.AddDbConfig(configuration);

        services.AddMediatRConfig();

        return services;
    }
    private static IServiceCollection InjectServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        return services;
    }
    public static IServiceCollection AddMapsterConfig(this IServiceCollection services)
    {
        services.AddMapster();
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton<IMapper>(new Mapper(config));

        return services;
    }
    public static IServiceCollection AddFluentValidatorConfig(this IServiceCollection services)
    {
        services
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
    private static IServiceCollection AddDbConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }); 
        return services;
    }
    private static IServiceCollection AddMediatRConfig(this IServiceCollection services)
    {
        services
            .AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}
