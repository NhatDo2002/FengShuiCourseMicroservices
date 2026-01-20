
namespace IdentityService.Infrastructure.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                   .HasConversion(
                        roleId => roleId.Value,
                        dbId => RoleId.Of(dbId)
                   );
            builder.Property(r => r.Name)
                   .HasConversion(
                        roleName => roleName.Value,
                        dbName => RoleName.Of(dbName)
                   );
            builder.HasIndex(r => r.Name).IsUnique();
            builder.Property(r => r.Description);
        }
    }
}
