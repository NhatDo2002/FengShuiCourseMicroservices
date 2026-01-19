

namespace IdentityService.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddCarter();
            services.AddExceptionHandler<CustomExceptionHandler>();
            return services;
        }

        public static IApplicationBuilder UseApiServices(this WebApplication app)
        {
            app.MapCarter();
            app.UseExceptionHandler(opt => {  });
            app.ApplyDatabaseMigrations();
            return app;
        }
    }
}
