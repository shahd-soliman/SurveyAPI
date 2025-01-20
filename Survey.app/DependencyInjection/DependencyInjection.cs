using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Survey.app.Data;
using System.Reflection;

namespace Survey.app.IndependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services )
        {
            services.AddMappingServices()
                    .AddValidationServices()
                    .AddSwaggerServices();

            return services;
        }
        public static IServiceCollection AddMappingServices(this IServiceCollection services)
        {
            var mapconfig = TypeAdapterConfig.GlobalSettings;
            mapconfig.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(mapconfig);
            return services;
        }

        public static IServiceCollection AddValidationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IPollService, pollService>();

            return services;

        }

        public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }

    }





}
