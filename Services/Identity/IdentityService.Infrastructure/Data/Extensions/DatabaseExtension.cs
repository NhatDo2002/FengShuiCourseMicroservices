namespace IdentityService.Infrastructure.Data.Extensions
{
    public static class DatabaseExtension
    {
        public static async Task ApplyDatabaseMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await dbContext.Database.MigrateAsync();
            await SeedingDatabase(dbContext);
        }

        private async static Task SeedingDatabase(ApplicationDbContext dbContext)
        {
            await SeedingRole(dbContext);
            await SeedingAccountAdmin(dbContext);
        }

        private async static Task SeedingRole(ApplicationDbContext dbContext)
        {
            var roleName = RoleName.Of("Admin");
            if (!dbContext.Roles.Any(r => r.Name == roleName))
            {
                var adminRole = Role.Create(
                    id: RoleId.Of(Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")),
                    name: RoleName.Of("Admin"),
                    description: "Administrator role with full permissions"
                );
                await dbContext.Roles.AddAsync(adminRole);
                await dbContext.SaveChangesAsync();
            }
        }

        private async static Task SeedingAccountAdmin(ApplicationDbContext dbContext)
        {
            var adminUsername = AccountUsername.Of("admin");
            if(!dbContext.Accounts.Any(a => a.Username == adminUsername))
            {
                var adminId = AccountId.Of(Guid.Parse("11111111-1111-1111-1111-111111111111"));
                var adminPassword = AccountPassword.Of("Admin@05112002");
                var userAdminInfo = UserInfo.Of(
                        fullName: "System Administrator",
                        email: "nhatdo0511@gmail.com",
                        phoneNumber: "0123456789",
                        address: "Viet Nam",
                        gender: Gender.Male,
                        dateOfBirth: new DateTime(2002, 11, 5)
                    );
                var adminAccount = Account.Create(
                        id: adminId,
                        username: adminUsername,
                        password: adminPassword,
                        userInfo: userAdminInfo
                    );

                var adminRole = await dbContext.Roles.FirstOrDefaultAsync(r => r.Name == RoleName.Of("Admin"));
                if (adminRole != null)
                {
                    adminAccount.AssignRole(adminRole);
                }
                await dbContext.Accounts.AddAsync(adminAccount);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
