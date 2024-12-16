using Hospital.Application.Interface.Repository;
using Hospital.Application.Interface.Service;
using Hospital.Infrastructure.Implementation.Repository;
using Hospital.Infrastructure.Implementation.Service;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Hospital.API.Extension
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

        public static void ConfigureInMemoryDatabaseContext(this IServiceCollection services, IWebHostEnvironment env, IConfiguration configuration)
        {
            if (env.IsProduction())
            {
                Console.WriteLine("----> using sql server  database");
                services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Hospital.API")));
            }
               
            else
            {
                Console.WriteLine("----> using Inmemory database");
                services.AddDbContext<RepositoryContext>(options => options.UseInMemoryDatabase("InMem"));
                //services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Hospital.API")));
            }

        }

    

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

        public static void ConfigureHttpClient(this IServiceCollection services)
        {
            //services.AddHttpClient<IHttpService, HttpService>().SetHandlerLifetime(TimeSpan.FromMinutes(5)).AddPolicyHandler(PollyPolicy.GetRetryPolicy());
            services.AddHttpContextAccessor();
            services.AddHttpClient<IHttpService, HttpService>().SetHandlerLifetime(TimeSpan.FromMinutes(5));
            services.AddScoped<IHttpService, HttpService>();
        }

        public static void ConfigureMessageBusService(this IServiceCollection services) => services.AddSingleton<IMessageBusClient, MessageBusClient>();
    }
}
