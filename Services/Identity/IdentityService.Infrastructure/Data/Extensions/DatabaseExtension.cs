namespace IdentityService.Infrastructure.Data.Extensions
{
    public static class DatabaseExtension
    {
        public static async Task ApplyDatabaseMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.MigrateAsync().GetAwaiter().GetResult();
        }
    }
}
