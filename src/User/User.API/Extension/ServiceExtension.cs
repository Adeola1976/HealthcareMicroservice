using Microsoft.EntityFrameworkCore;
using Serilog;
using User.Application.Interface.Repository;
using User.Application.Interface.Service;
using User.Infrastructure.Implementation.Repository;
using User.Infrastructure.Implementation.Service;

namespace User.API.Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services) =>
         services.AddCors(options =>
         {
             options.AddPolicy("CorsPolicy", builder =>
               builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
         });

        public static void ConfigureInMemoryDatabaseContext(this IServiceCollection services) =>
        services.AddDbContext<RepositoryContext>(options => options.UseInMemoryDatabase("InMem"));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder)
        {
            var logger = new LoggerConfiguration()
           .ReadFrom.Configuration(builder.Configuration)
           .Enrich.FromLogContext()
           .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
            return builder;
        }

        public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();
    }
}
