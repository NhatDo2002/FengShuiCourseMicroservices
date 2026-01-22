namespace IdentityService.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddCarter();
            services.AddExceptionHandler<CustomExceptionHandler>();
            services.AddScoped<IAuthCookieWriter, AuthCookieWriter>();
            return services;
        }

        public static IApplicationBuilder UseApiServices(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapCarter();
            app.UseExceptionHandler(opt => {  });
            return app;
        }
    }
}
